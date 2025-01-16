using Alor.OpenAPI.Interfaces;
using App.Metrics;
using App.Metrics.Counter;
using App.Metrics.Gauge;
using App.Metrics.Meter;
using App.Metrics.Timer;
using System.Collections.Concurrent;

namespace Alor.OpenAPI.Services
{
    internal class MetricsRegistry(IMetrics metrics, bool isMetricsCollectionEnabled) : IMetricsRegistry
    {
        public ConcurrentDictionary<string, object> MetricsOptions { get; } = new();
        private volatile bool _isMetricsCollectionEnabled = isMetricsCollectionEnabled;

        public void EnableMetricsCollection() => _isMetricsCollectionEnabled = true;
        public void DisableMetricsCollection() => _isMetricsCollectionEnabled = false;
        public bool CurrentStatusMetricsCollection => _isMetricsCollectionEnabled;

        public void UpdateGauge(string key, double value)
        {
            if (!_isMetricsCollectionEnabled) return;

            if (MetricsOptions.TryGetValue(key, out var metricOption) && metricOption is GaugeOptions gaugeOptions)
            {
                metrics.Measure.Gauge.SetValue(gaugeOptions, value);
            }
        }

        public void UpdateCounter(string key, long value)
        {
            if (!_isMetricsCollectionEnabled) return;

            if (MetricsOptions.TryGetValue(key, out var metricOption) &&
                metricOption is CounterOptions counterOptions)
            {
                metrics.Measure.Counter.Increment(counterOptions, value);
            }
        }

        public void MarkMeter(string key)
        {
            if (!_isMetricsCollectionEnabled) return;

            if (MetricsOptions.TryGetValue(key, out var metricOption) && metricOption is MeterOptions meterOptions)
            {
                metrics.Measure.Meter.Mark(meterOptions);
            }

        }

        public void RecordTimer(string key, Action operation)
        {
            if (!_isMetricsCollectionEnabled) return;

            if (MetricsOptions.TryGetValue(key, out var metricOption) && metricOption is TimerOptions timerOptions)
            {
                metrics.Measure.Timer.Time(timerOptions, operation);
            }
        }
    }
}
