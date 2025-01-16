using Alor.OpenAPI.Utilities;
using System.Buffers;
using System.Collections.Concurrent;
using System.Net.WebSockets;
using System.Text;
using System.Threading.Channels;

namespace Alor.OpenAPI.Websocket
{
    internal class WebSocketInfo(int socketId, string name, Func<IWebSocketClient> webSocketClientFactory) : IWebSocketInfo
    {
        private IWebSocketClient? _webSocketClient;
        public Func<IWebSocketInfo, Task>? Closed { get; set; }
        public Func<IWebSocketInfo, Exception, Task>? Error { get; set; }
        public Action<IWebSocketInfo, string>? Warning { get; set; }

        private readonly ConcurrentDictionary<Action<IWebSocketInfo, (byte[] data, int len, DateTime timestamp)>, bool> _msgSubs = [];
        public event Action<IWebSocketInfo, (byte[] data, int len, DateTime timestamp)> Message
        {
            add => _msgSubs.TryAdd(value, true);
            remove => _msgSubs.TryRemove(value, out _);
        }

        public WebSocketState State => _webSocketClient?.State ?? WebSocketState.None;

        //GUID, Opcode
        public ConcurrentDictionary<string, string> Opcodes { get; } = [];
        public bool IsConnected => _webSocketClient?.State == WebSocketState.Open;

        public int ReconnectCount { get; set; }
        public long ReceivedCount { get; private set; }
        public long ReceiveRate { get; private set; }
        private long PrevReceivedCount { get; set; }
        public long SentCount { get; private set; }
        public long SentRate { get; private set; }
        private long PrevSentCount { get; set; }

        public DateTime? LastUpdate { get; private set; }


        public int SocketId { get; } = socketId;
        public string Name { get; } = name;

        private CancellationTokenSource _cts = new();
        private Channel<(byte[] data, int len, DateTime timestamp)>? _bucket;

        //10 seconds mute for startup
        private DateTime _lastConsumerSlowWarn = DateTime.UtcNow;

        private Task _listener = Task.CompletedTask;
        private Task _multiplexer = Task.CompletedTask;

        private bool _isClosing = false;

        public int? GetReaderCount() => _bucket?.Reader.Count;

        public void CalculateReceiveRate()
        {
            ReceiveRate = ReceivedCount - PrevReceivedCount;
            PrevReceivedCount = ReceivedCount;
        }

        public void CalculateSentRate()
        {
            SentRate = SentCount - PrevSentCount;
            PrevSentCount = SentCount;
        }

        public async Task StartAsync()
        {
            _webSocketClient = webSocketClientFactory();

            var ws = _webSocketClient;
            var cts = _cts = new();
            _bucket = Channel.CreateBounded<(byte[] data, int len, DateTime timestamp)>(
                new BoundedChannelOptions(int.MaxValue)
                {
                    SingleReader = true,
                    SingleWriter = true,
                    AllowSynchronousContinuations = true,
                });
            _lastConsumerSlowWarn = DateTime.UtcNow;

            await ws.ConnectAsync(cts.Token); //can fail but probaly OK

            _multiplexer = StartMultiplexerLoop(_bucket);
            _listener = StartListenerLoop();
            _ = _multiplexer.ContinueWith(l => Finisher(l, cts, ws), cts.Token);
            _ = _listener.ContinueWith(l => Finisher(l, cts, ws), cts.Token);
        }

        private async Task Finisher(Task prev, CancellationTokenSource cts, IWebSocketClient ws)
        {
            if (prev.IsFaulted)
            {
                var exception = prev.Exception?.InnerException ?? prev.Exception;
                await CloseAsync(cts, ws, exception);
#if DEBUG
                //Console.WriteLine(DateTime.Now);
                //Console.WriteLine(prev.Exception);
#endif
            }
            else
            {
                await CloseAsync(cts, ws);
            }
        }

        private async Task StartMultiplexerLoop(Channel<(byte[] data, int len, DateTime timestamp)>? channel)
        {
            var cts = _cts;
            while (!cts.IsCancellationRequested)
            {

                try
                {
                    //using queue to preserve message order
                    //(msg, len) = await channel.Reader.ReadAsync(cts.Token);
                    if (channel != null && channel.Reader.TryRead(out (byte[] msg, int len, DateTime timestamp) name))
                    {
                        foreach (var handler in _msgSubs)
                        {
                            handler.Key(this, name);

#if DEBUG
                            bool xx = false;
                            if (xx)
                                throw new Exception("test error");
#endif
                        }
                        ArrayPool<byte>.Shared.Return(name.msg);
                    }
                    else
                    {

                        await Task.Delay(1, cts.Token);
                    }
                }
                catch (OperationCanceledException) //it's a pity that ms libs still do logic through exceptions
                                                   //catch (Exception error)
                {
                    return;
                }
            }
        }

        private async Task StartListenerLoop()
        {
            var buf = new byte[1024 * 1024]; //actually MTE should be ~1400 bytes

            while (!_cts.IsCancellationRequested)
            {
                var length = 0;
                while (!_cts.IsCancellationRequested)
                {
                    if (_webSocketClient == null) continue;
                    
                    var rr = await _webSocketClient.ReceiveAsync(
                        new ArraySegment<byte>(buf, length, buf.Length - length), _cts.Token);
                    var completed = rr.EndOfMessage;
                    length += rr.Count;

                    if (!completed && rr.Count == 0)
                        throw new OperationCanceledException("ws closed");

                    if (completed)
                    {
                        break;
                    }
                }

                var timestampNow = DateTime.UtcNow;
                var msg = ArrayPool<byte>.Shared.Rent(length);
                Buffer.BlockCopy(buf, 0, msg, 0, length);
                if (_bucket != null && _bucket.Writer.TryWrite((msg, length, timestampNow)))
                {
                    ReceivedCount++;
                    LastUpdate = timestampNow;

                    if (_bucket.Reader.Count > 5000 && (timestampNow - _lastConsumerSlowWarn).TotalSeconds >= 10)
                    {
                        _lastConsumerSlowWarn = timestampNow;
                        Warning?.Invoke(this,
                            $"Websocket '{Name}' consumers are too slow, messages in queue: {_bucket.Reader.Count}!");
                    }
                }
            }
        }

        public async Task<bool> SendAsync(string json)
        {
            try
            {
                if (_webSocketClient is not { State: WebSocketState.Open })
                    return false;

                await _webSocketClient.SendAsync(Encoding.UTF8.GetBytes(json), WebSocketMessageType.Text, true, _cts.Token);
                SentCount++;
                return true;
            }
            catch (Exception ex)
            {
                SendSocketStatus?.Invoke(AlorOpenApiLogLevel.Error, $"Ошибка при отправке сообщения: {ex.Message}");
                throw;
            }
        }

        private async Task CloseAsync(CancellationTokenSource cts, IWebSocketClient? ws, Exception? error = null)
        {
            if (_isClosing)
                return;
            _isClosing = true;

            if (cts.IsCancellationRequested)
                return;

            try
            {
                await cts.CancelAsync();
                await _multiplexer;
                await _listener;
            }
            catch (Exception ex)
            {
                SendSocketStatus?.Invoke(AlorOpenApiLogLevel.Error, $"Ошибка при закрытии задач: {ex.Message}\n{ex.StackTrace}");
            }
            finally
            {
                try
                {
                    await (ws?.CloseAsync(WebSocketCloseStatus.NormalClosure, "Closing", CancellationToken.None) ?? Task.CompletedTask);
                }
                catch (Exception ex)
                {
                    SendSocketStatus?.Invoke(AlorOpenApiLogLevel.Warning, $"Ошибка при закрытии WebSocket: {ex.Message}");
                }
                finally
                {
                    ws?.Dispose();
                    _webSocketClient = null;
                }
            }

            if (error != null)
            {
                SendSocketStatus?.Invoke(AlorOpenApiLogLevel.Error,
                    $"Ошибка:\n{error.Message}\n{error.StackTrace}");
                await (Error?.Invoke(this, error) ?? Task.CompletedTask);
            }
            else
                await (Closed?.Invoke(this) ?? Task.CompletedTask);

            _isClosing = false;
        }

        public Task CloseSocketAndResetCounters()
        {
            //Console.WriteLine($"[{DateTime.Now}] Close called: ");
            ReceivedCount = 0;
            PrevReceivedCount = 0;
            ReceiveRate = 0;
            SentCount = 0;
            PrevSentCount = 0;
            SentRate = 0;

            return CloseAsync(_cts, _webSocketClient);
        }

        public void Dispose()
        {
            CloseSocketAndResetCounters();
            _cts.Dispose();
            SendSocketStatus = null;
            Closed = null;
            Error = null;
            Warning = null;
            _msgSubs.Clear();
            _webSocketClient?.Dispose();
            _webSocketClient = null;
        }
        
        public Action<AlorOpenApiLogLevel, string>? SendSocketStatus { get; set; }
    }
}
