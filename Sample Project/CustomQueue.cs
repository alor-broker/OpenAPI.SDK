using System.Threading.Channels;

namespace Sample_Project
{
    internal class CustomQueue<T>
    {
        private readonly CancellationTokenSource _cts = new();
        private readonly Task _multiplexer;
        private readonly Channel<T> _channel;
        private readonly Action<T> _action;

        internal CustomQueue(Action<T> action)
        {
            _action = action;
            _channel = Channel.CreateBounded<T>(new BoundedChannelOptions(int.MaxValue)
                                                                         {
                                                                             SingleReader = true,
                                                                             SingleWriter = true,
                                                                             AllowSynchronousContinuations = true,
            });

            _multiplexer = StartMultiplexerLoop();
            _ = _multiplexer.ContinueWith(_ => Finisher(), _cts.Token);
        }

        internal bool WriteToQueue(T el)
        {
            return _channel.Writer.TryWrite(el);
        }

        private async Task StartMultiplexerLoop()
        {

            while (!_cts.IsCancellationRequested)
            {
                try
                {
                    var element = await _channel.Reader.ReadAsync(_cts.Token);
                    if (element != null)
                    {
                        _action(element);
                    }
                }
                catch (Exception error)
                {
                    return;
                }
            }
        }

        private async Task Finisher()
        {
                await StopChannel();
        }

        public async Task StopChannel()
        {
            if (_cts.IsCancellationRequested)
                return;

            try
            {
                _= _cts.CancelAsync();
                await _multiplexer;
            }
            catch (TaskCanceledException)
            {
            } 
            catch (ObjectDisposedException)
            {
            } 
            catch (NullReferenceException nex)
            {
            }
        }
    }
}
