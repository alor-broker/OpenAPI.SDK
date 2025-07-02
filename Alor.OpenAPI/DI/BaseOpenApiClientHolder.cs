using Alor.OpenAPI.Interfaces;
using Alor.OpenAPI.Models;
using Alor.OpenAPI.Utilities;

namespace Alor.OpenAPI.DI;

public abstract class BaseOpenApiClientHolder : IAlorOpenApiClient
{
    private IAlorOpenApiClient? _client;
    public void SetClient(IAlorOpenApiClient client) => _client = client ?? throw new ArgumentNullException(nameof(client));
    protected IAlorOpenApiClient Client => _client ?? throw new InvalidOperationException("OpenApiClient is not initialized yet");

    public IWebSocketsPoolManager WsPoolManager => Client.WsPoolManager;
    public IInstrumentsService Instruments => Client.Instruments;
    public IClientInfoService ClientInfo => Client.ClientInfo;
    public IOthersService Others => Client.Others;
    public IOrdersService Orders => Client.Orders;
    public IStopOrdersService StopOrders => Client.StopOrders;
    public IOrderGroupsService OrderGroups => Client.OrderGroups;

    public void EnableMetricsCollection() => Client.EnableMetricsCollection();
    public void DisableMetricsCollection() => Client.DisableMetricsCollection();

    public void SetWsResponseMessageHandler(Action<WsResponseMessage>? handler)
        => Client.SetWsResponseMessageHandler(handler);
    public void SetWsResponseCommandMessageHandler(Action<WsResponseCommandMessage>? handler)
        => Client.SetWsResponseCommandMessageHandler(handler);

    public IWebSocketsPoolManager CreateWsPool(
        IReadOnlyList<string>? names = null,
        string? commandSocketName = null,
        int sockets = 1,
        AlorOpenApiLogLevel logLevel = AlorOpenApiLogLevel.Error,
        string? logFileNameSuffix = null) =>
        Client.CreateWsPool(names, commandSocketName, sockets, logLevel, logFileNameSuffix);

    public void Dispose()
    {
        if (_client is IDisposable d) d.Dispose();
    }
}