using Alor.OpenAPI.Interfaces;
using Alor.OpenAPI.Utilities;
using Alor.OpenAPI.Websocket;
using App.Metrics.Gauge;
using Polly;
using Polly.CircuitBreaker;
using Polly.Wrap;
using Serilog;
using System.Text;

namespace Alor.OpenAPI.Managers
{
    internal class WebSocketConnectionManager : IWebSocketConnectionManager
    {
        private readonly ILogger _logger;
        private string? _jwtToken;
        private readonly IMetricsRegistry _metricsRegistry;
        private readonly IWebSocketInfo _webSocketInfo;

        private readonly SemaphoreSlim _socketLifecycleSemaphore = new(1, 1);
        private Task? _socketStartingTask;

        private readonly AsyncPolicyWrap _policyWrap;

        private Action? _incrementSocketsCounter;
        private Action? _decrementSocketsCounter;
        private Action<(byte[], int, DateTime), string>? _onMessageReceived;

        internal WebSocketConnectionManager(ILogger logger, Uri webSocketUri,
            string? jwtToken, IMetricsRegistry metricsRegistry, Action incrementSocketsCounter,
            Action decrementSocketsCounter, int socketId, string? name,
            Action<(byte[], int, DateTime), string> onMessageReceived,
            Dictionary<string, string>? webSocketHeaders = null)
        {
            ArgumentNullException.ThrowIfNull(logger);
            ArgumentNullException.ThrowIfNull(webSocketUri);
            ArgumentNullException.ThrowIfNull(metricsRegistry);
            ArgumentNullException.ThrowIfNull(incrementSocketsCounter);
            ArgumentNullException.ThrowIfNull(decrementSocketsCounter);
            ArgumentNullException.ThrowIfNull(onMessageReceived);

            _logger = logger;
            _jwtToken = jwtToken;
            _metricsRegistry = metricsRegistry;
            _incrementSocketsCounter = incrementSocketsCounter;
            _decrementSocketsCounter = decrementSocketsCounter;

            var retryPolicy = Policy
                .Handle<Exception>()
                .WaitAndRetryAsync(
                    retryCount: 5,
                    sleepDurationProvider: attempt => TimeSpan.FromSeconds(Math.Pow(2, attempt)),
                    onRetryAsync: (exception, timeSpan, retryCount, context) =>
                    {
                        SendSocketStatus(AlorOpenApiLogLevel.Warning, $"Попытка {retryCount}: {exception.Message}");
                        return Task.CompletedTask;
                    });

            var durationOfBreak = TimeSpan.FromSeconds(30);
            var circuitBreakerPolicy = Policy
                .Handle<Exception>()
                .CircuitBreakerAsync(
                    exceptionsAllowedBeforeBreaking: 1,
                    durationOfBreak: durationOfBreak
                );

            var outerRetryPolicy = Policy
                .Handle<Exception>()
                .WaitAndRetryForeverAsync(
                    sleepDurationProvider: (retryCount, exception, context) => TimeSpan.FromSeconds(
                        exception is BrokenCircuitException
                            ?
                            durationOfBreak.TotalSeconds
                            :
                            1),
                    onRetryAsync: (exception, timeSpan, context) =>
                    {
                        SendSocketStatus(AlorOpenApiLogLevel.Warning,
                            $"Повторяем цикл из-за: {exception.Message}. Ждем {timeSpan.TotalSeconds} секунд.");
                        return Task.CompletedTask;
                    });


            _policyWrap = Policy.WrapAsync(outerRetryPolicy, circuitBreakerPolicy, retryPolicy);

            _webSocketInfo = new WebSocketInfo(socketId, string.IsNullOrEmpty(name) ? "AlorSocketName" : name,
                () => new WebSocketClientWrapper(webSocketUri, webSocketHeaders));
            _webSocketInfo.SendSocketStatus += (x, y) => SendSocketStatus(x, name + ' ' + y);

            InitialiseMetrics();
            _onMessageReceived = onMessageReceived;
        }

        private void InitialiseMetrics()
        {
            _metricsRegistry.MetricsOptions.TryAdd(
                $"gaugeOption{_webSocketInfo.Name}RecievedCount",
                new GaugeOptions { Name = $"{_webSocketInfo.Name} websocket recieved messages count" });
            _metricsRegistry.MetricsOptions.TryAdd(
                $"gaugeOption{_webSocketInfo.Name}LastUpdate",
                new GaugeOptions { Name = $"{_webSocketInfo.Name} websocket last message timestamp" });
            _metricsRegistry.MetricsOptions.TryAdd(
                $"gaugeOption{_webSocketInfo.Name}ReconnectCount",
                new GaugeOptions { Name = $"{_webSocketInfo.Name} websocket reconnect count" });
            _metricsRegistry.MetricsOptions.TryAdd(
                $"gaugeOption{_webSocketInfo.Name}ReceiveBufferCount",
                new GaugeOptions { Name = $"{_webSocketInfo.Name} websocket receive buffer elements count" });
            _metricsRegistry.MetricsOptions.TryAdd(
                $"gaugeOption{_webSocketInfo.Name}ReceiveRate",
                new GaugeOptions { Name = $"{_webSocketInfo.Name} websocket receive rate for a sec" });
        }

        public void JwtUpdate(string? newToken)
        {
            _jwtToken = newToken;
        }

        public bool AddToOpcodes(string guid, string message) => _webSocketInfo.Opcodes.TryAdd(guid, message);

        public bool TryToRemoveFromOpcodes(string guid) => _webSocketInfo.Opcodes.TryRemove(guid, out _);

        public WebSocketInfoDetails GetSocketInfoDetails() => new(_webSocketInfo.Name, _webSocketInfo.SentCount,
            _webSocketInfo.ReceivedCount, _webSocketInfo.LastUpdate, _webSocketInfo.ReconnectCount,
            _webSocketInfo.ReceiveRate, Convert.ToDouble(_webSocketInfo.GetReaderCount()), _webSocketInfo.SentRate);

        public void CalculateWebSocketInfoRecieveRate() => _webSocketInfo.CalculateReceiveRate();
        public void CalculateWebSocketInfoSentRate() => _webSocketInfo.CalculateSentRate();

        public async Task<bool> SendOrStartAndSendCws(string message)
        {
            try
            {
                await EnsureSocketStartedAsync();

                await SendToSocket(_webSocketInfo, message);
                return true;
            }
            catch (Exception ex)
            {
                SendSocketStatus(AlorOpenApiLogLevel.Error, $"Ошибка при отправке сообщения: {ex.Message}");
                return false;
            }
        }

        public async Task<bool> SendOrStartAndSend(string message)
        {
            try
            {
                await EnsureSocketStartedAsync();

                var str = message.Replace("JwtToken", _jwtToken);
                await SendToSocket(_webSocketInfo, str);
                return true;
            }
            catch (Exception ex)
            {
                SendSocketStatus(AlorOpenApiLogLevel.Error, $"Ошибка при отправке сообщения: {ex.Message}");
                return false;
            }
        }

        public async Task<bool> SendOrStartAndSend(IReadOnlyCollection<string> messages)
        {
            try
            {
                if (messages.Count <= 0) return false;

                await EnsureSocketStartedAsync();
                
                foreach (var msg in messages)
                {
                    var str = msg.Replace("JwtToken", _jwtToken);
                    await SendToSocket(_webSocketInfo, str);
                }

                return true;
            }
            catch (Exception ex)
            {
                SendSocketStatus(AlorOpenApiLogLevel.Error, $"Ошибка при отправке сообщения: {ex.Message}");
                return false;
            }
        }

        private async Task SendToSocket(IWebSocketInfo ws, string msg)
        {
            var sent = await ws.SendAsync(msg);
            SendSocketStatus(AlorOpenApiLogLevel.Verbose, $"{ws.Name}: {msg}");

            if (!sent)
            {
                var errorMessage = $"{ws.Name}: Ошибка при отправке запроса: \"{msg}\"";
                SendSocketStatus(AlorOpenApiLogLevel.Error, errorMessage);
                throw new Exception(errorMessage);
            }
        }
        
        private async Task EnsureSocketStartedAsync()
        {
            await _socketLifecycleSemaphore.WaitAsync();
            try
            {
                if (_webSocketInfo.IsConnected)
                    return;

                if (_socketStartingTask is { IsCompleted: false })
                {
                    await _socketStartingTask;
                    return;
                }

                _socketStartingTask = StartSocket(_webSocketInfo);
                
                await _socketStartingTask;
            }
            finally
            {
                _socketLifecycleSemaphore.Release();
            }
        }

        private async Task StartSocketAndSubscribe(IWebSocketInfo ws)
        {
            ws.Closed = Websocket_Closed;
            ws.Error = Websocket_Error;
            ws.Warning = Websocket_Warning;
            ws.Message += Websocket_MessageReceived;

            await ws.StartAsync();
            _incrementSocketsCounter?.Invoke();

            if (ws.Opcodes.Count > 0)
            {
                foreach (var msg in ws.Opcodes.Select(opcode => opcode.Value.Replace("JwtToken", _jwtToken)))
                {
                    await SendToSocket(ws, msg);
                }

                SendSocketStatus(AlorOpenApiLogLevel.Information,
                    $"{ws.Name}: Подключились. Подписка на опкоды с 1 по {ws.Opcodes.Count}");
            }
        }

        private async Task<bool> StartSocket(IWebSocketInfo ws)
        {
            ws.Closed = Websocket_Closed;
            ws.Error = Websocket_Error;
            ws.Warning = Websocket_Warning;
            ws.Message += Websocket_MessageReceived;

            await ws.StartAsync();
            _incrementSocketsCounter?.Invoke();

            return true;
        }

        private Task StopSocket(IWebSocketInfo ws)
        {
            ws.Closed = null;
            ws.Error = null;
            ws.Warning = null;
            ws.Message -= Websocket_MessageReceived;

            return ws.CloseSocketAndResetCounters();
        }

        private async Task Restart(IWebSocketInfo ws)
        {
            await _socketLifecycleSemaphore.WaitAsync();

            try
            {
                await _policyWrap.ExecuteAsync(async () =>
                {
                    SendSocketStatus(AlorOpenApiLogLevel.Information, $"{ws.Name}: Перезапуск сокета");
                    await StopSocket(ws);
                    ws.ReconnectCount++;

                    await StartSocketAndSubscribe(ws);
                });
            }
            finally
            {
                _socketLifecycleSemaphore.Release();
            }
        }


        private Task Websocket_Closed(IWebSocketInfo ws)
        {
            SendSocketStatus(AlorOpenApiLogLevel.Information, $"{ws.Name}: Отключились от сокета");
            _decrementSocketsCounter?.Invoke();

            return Restart(ws);
        }

        private Task Websocket_Error(IWebSocketInfo ws, Exception e)
        {
            SendSocketStatus(AlorOpenApiLogLevel.Error, $"{ws.Name}: Поймали еррор: {e.Message}");

            return Restart(ws);

        }

        private void Websocket_Warning(IWebSocketInfo ws, string msg)
        {
            SendSocketStatus(AlorOpenApiLogLevel.Warning, $"{ws.Name}: Предупреждение: {msg}");
        }

        private void Websocket_MessageReceived(IWebSocketInfo ws, (byte[] data, int len, DateTime timestamp) byteMsg)
        {
            try
            {
                //Console.WriteLine(Encoding.UTF8.GetString(byteMsg.data));
                _onMessageReceived?.Invoke(byteMsg, ws.Name);
            }
            catch (Exception)
            {
                var message = byteMsg.data == null || byteMsg.data.Length == 0
                    ? " is null or empty"
                    : Encoding.UTF8.GetString(byteMsg.data);
                SendSocketStatus(AlorOpenApiLogLevel.Error, message);
            }
        }


        private void SendSocketStatus(AlorOpenApiLogLevel alorLogLevel, string socketMessage)
        {
            switch (alorLogLevel)
            {
                case AlorOpenApiLogLevel.Verbose:
                    _logger.Verbose(socketMessage);
                    break;
                case AlorOpenApiLogLevel.Debug:
                    _logger.Debug(socketMessage);
                    break;
                case AlorOpenApiLogLevel.Information:
                    _logger.Information(socketMessage);
                    break;
                case AlorOpenApiLogLevel.Warning:
                    _logger.Warning(socketMessage);
                    break;
                case AlorOpenApiLogLevel.Error:
                    _logger.Error(socketMessage);
                    break;
                case AlorOpenApiLogLevel.Fatal:
                    _logger.Fatal(socketMessage);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(alorLogLevel), alorLogLevel, null);
            }
        }

        public void Dispose()
        {
            _incrementSocketsCounter = null;
            _decrementSocketsCounter = null;
            _onMessageReceived = null;
            _webSocketInfo.Dispose();
            _socketLifecycleSemaphore.Dispose();

            SendSocketStatus(AlorOpenApiLogLevel.Information,
                $"Закрыли соединение в сокете {_webSocketInfo.Name}");
        }
    }
}
