using Alor.OpenAPI.Models;
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


    /// <summary>
    /// Устанавливает обработчик WS-сообщений пользователя (основной поток).
    /// </summary>
    void SetWsResponseMessageHandler(Action<WsResponseMessage>? handler);

    /// <summary>
    /// Устанавливает обработчик WS-командных сообщений пользователя.
    /// </summary>
    void SetWsResponseCommandMessageHandler(Action<WsResponseCommandMessage>? handler);

    IWebSocketsPoolManager CreateWsPool(IReadOnlyList<string>? names = null, string? commandSocketName = null,
        int sockets = 1, AlorOpenApiLogLevel logLevel = AlorOpenApiLogLevel.Error, string? logFileNameSuffix = null);
}