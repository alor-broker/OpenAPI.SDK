using System.Timers;
using Timer = System.Timers.Timer;

namespace Alor.OpenAPI.Utilities
{
    internal sealed class AlarmClock : IDisposable
    {
        public AlarmClock(DateTime alarmTime)
        {
            _alarmTime = alarmTime;

            _timer = new Timer();
            _timer.Elapsed += timer_Elapsed;
            _timer.Interval = 100;
            _timer.Start();

            _enabled = true;
        }

        private void timer_Elapsed(object? sender, ElapsedEventArgs e)
        {
            if (_enabled && DateTime.Now > _alarmTime)
            {
                _enabled = false;
                OnAlarm();
                _timer.Stop();
            }
        }

        private void OnAlarm()
        {
            _alarmEvent?.Invoke(this, EventArgs.Empty);
        }

        public void Dispose()
        {
            _enabled = false;
            _alarmEvent = null;
            _timer.Stop();
            _timer.Dispose();
        }

        public event EventHandler? Alarm
        {
            add => _alarmEvent += value;
            remove => _alarmEvent -= value;
        }

        private EventHandler? _alarmEvent;
        private readonly Timer _timer;
        private readonly DateTime _alarmTime;
        private bool _enabled;
    }
}
