using Alor.OpenAPI.Models;

namespace Alor.OpenAPI.Interfaces
{
    internal interface IMetricsService : IDisposable
    {
        void UpdateSocketsCounterMetric(int socketsCounter);
        void UpdatePingStatsUserDelegate(Action<PingStats?>? pingStatsChangedFromUser);
        void UpdateWsPingStatsUserDelegate(Action<WsPingStats?>? wsPingStatsChangedFromUser);
        void EnableMetricsCollection();
        void DisableMetricsCollection();
        IMetricsRegistry GetMetricsRegistry();
    }
}
