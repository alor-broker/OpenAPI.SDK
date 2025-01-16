using Alor.OpenAPI.Utilities;

namespace Alor.OpenAPI.Interfaces;

public interface IAlorOpenApiClient : IDisposable
{
    IWebSocketsPoolManager WsPoolManager { get; }
    IInstrumentsService Instruments { get; }
    IClientInfoService ClientInfo { get; }
    IOthersService Others { get; }
    IOrdersService Orders { get; }
    IStopOrdersService StopOrders { get; }
    IOrderGroupsService OrderGroups { get; }

    void EnableMetricsCollection();
    void DisableMetricsCollection();

    IWebSocketsPoolManager CreateWsPool(IReadOnlyList<string>? names = null, string? commandSocketName = null,
        int sockets = 1, AlorOpenApiLogLevel logLevel = AlorOpenApiLogLevel.Fatal, string? logFileNameSuffix = null);
}