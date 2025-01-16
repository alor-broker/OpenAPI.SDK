namespace Alor.OpenAPI.Interfaces
{
    internal interface IMetricsService : IDisposable
    {
        void UpdateSocketsCounterMetric(int socketsCounter);
        void EnableMetricsCollection();
        void DisableMetricsCollection();
        IMetricsRegistry GetMetricsRegistry();
    }
}
