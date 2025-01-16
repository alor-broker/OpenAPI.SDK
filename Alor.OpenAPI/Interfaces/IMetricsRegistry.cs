using System.Collections.Concurrent;

namespace Alor.OpenAPI.Interfaces;

public interface IMetricsRegistry
{
    ConcurrentDictionary<string, object> MetricsOptions { get; }
    bool CurrentStatusMetricsCollection { get; }

    void EnableMetricsCollection();
    void DisableMetricsCollection();
    void UpdateGauge(string key, double value);
    void UpdateCounter(string key, long value);
    void MarkMeter(string key);
    void RecordTimer(string key, Action operation);
}