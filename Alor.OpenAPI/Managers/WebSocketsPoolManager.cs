using Alor.OpenAPI.Interfaces;
using Alor.OpenAPI.Models;
using Alor.OpenAPI.Models.Heavy;
using Alor.OpenAPI.Models.Simple;
using Alor.OpenAPI.Models.Slim;
using Alor.OpenAPI.Services;
using Alor.OpenAPI.Utilities;
using Alor.OpenAPI.Websocket;
using Serilog;
using Serilog.Core;
using System.Collections.Concurrent;

namespace Alor.OpenAPI.Managers
{
    public sealed class WebSocketsPoolManager : IWebSocketsPoolManager, IInternalWebSocketsPoolManagerActions
    {
        private readonly ILogger _logger;
        private readonly List<IWebSocketConnectionManager> _webSocketConnections = [];
        private string? _jwtToken;
        private readonly IWebSocketConnectionManager _commandWebSocket;
        private readonly ConcurrentDictionary<string, IWebSocketConnectionManager> _guidAndSocketsDict = [];
        public ISubscriptionManager Subscriptions { get; }
        public ICwsManager CommandWs { get; }
        private readonly ICwsAuthService _cwsAuthService;
        private readonly IWebSocketMessageHandler _webSocketMessageHandler;

        private Action<WsResponseMessage>? _wsResponseMessageChangedFromUser;
        private Action<WsResponseCommandMessage>? _wsResponseCommandMessageChangedFromUser;

        internal WebSocketsPoolManager(ConcurrentDictionary<string, Parameters> parameters, Action incrementSocketsCounter, Action decrementSocketsCounter,
            string? jwtToken, IMetricsRegistry metricsRegistry, Uri webSocketUri, Uri commandWebSocketUri, AlorOpenApiLogLevel logLevel,
            IReadOnlyList<string>? names = null, string? commandSocketName = null, int sockets = 1, string? logFileNameSuffix = null,
            Action<WsResponseMessage>? wsResponseMessageHandlerFromUser = null, Action<WsResponseCommandMessage>? wsResponseCommandMessageHandlerFromUser = null,
            Dictionary<string, string>? webSocketHeaders = null, Dictionary<string, string>? commandWebSocketHeaders = null)
        {
            var levelSwitch = new LoggingLevelSwitch(logLevel.ToSerilogLevel());
            _logger = new LoggerConfiguration().MinimumLevel.ControlledBy(levelSwitch)
                //.WriteTo.Console(outputTemplate: "[{Timestamp:HH:mm:ss.ffff} {Level:u3}] {Message:lj}{NewLine}{Exception}")
                .WriteTo.Async(a =>
                    a.File(
                        $"logs/log-WebSocketsPoolProvider{(!string.IsNullOrEmpty(logFileNameSuffix) ? "-" + logFileNameSuffix : logFileNameSuffix)}_.txt",
                        rollingInterval: RollingInterval.Day,
                        outputTemplate: "[{Timestamp:HH:mm:ss.ffff} {Level:u3}] {Message:lj}{NewLine}{Exception}",
                        flushToDiskInterval: TimeSpan.FromSeconds(5)))
                .CreateLogger();

            var commandLogger = new LoggerConfiguration().MinimumLevel.ControlledBy(levelSwitch)
                //.WriteTo.Console(outputTemplate: "[{Timestamp:HH:mm:ss.ffff} {Level:u3}] {Message:lj}{NewLine}{Exception}")
                .WriteTo.Async(a =>
                    a.File(
                        $"logs/log-WebSocketsPoolProvider_Cws{(!string.IsNullOrEmpty(logFileNameSuffix) ? "-" + logFileNameSuffix : logFileNameSuffix)}_.txt",
                        rollingInterval: RollingInterval.Day,
                        outputTemplate: "[{Timestamp:HH:mm:ss.ffff} {Level:u3}] {Message:lj}{NewLine}{Exception}",
                        flushToDiskInterval: TimeSpan.FromSeconds(5)))
                .CreateLogger();

            _jwtToken = jwtToken;

            if (wsResponseMessageHandlerFromUser != null) _wsResponseMessageChangedFromUser = wsResponseMessageHandlerFromUser;
            if (wsResponseCommandMessageHandlerFromUser != null)
                _wsResponseCommandMessageChangedFromUser = wsResponseCommandMessageHandlerFromUser;

            _webSocketMessageHandler = new WebSocketMessageHandler(_logger, commandLogger, logLevel, parameters, _wsResponseMessageChangedFromUser, _wsResponseCommandMessageChangedFromUser);
            var onMessageRecieved = _webSocketMessageHandler.MessageReceived;

            Subscriptions = new SubscriptionManager(parameters, OnMsgDictionaryUpdatedAsync, OnMsgDeleteRequestAsync,
                UpdateWsMessageHandlerWsOrderBookSimpleDelegat, UpdateWsMessageHandlerWsOrderBookSlimDelegat,
                UpdateWsMessageHandlerWsOrderBookHeavyDelegat, UpdateWsMessageHandlerWsCandleSimpleDelegat,
                UpdateWsMessageHandlerWsCandleSlimDelegat, UpdateWsMessageHandlerWsCandleHeavyDelegat,
                UpdateWsMessageHandlerWsSymbolSimpleDelegat, UpdateWsMessageHandlerWsSymbolSlimDelegat,
                UpdateWsMessageHandlerWsSymbolHeavyDelegat, UpdateWsMessageHandlerWsAllTradeSimpleDelegat,
                UpdateWsMessageHandlerWsAllTradeSlimDelegat, UpdateWsMessageHandlerWsAllTradeHeavyDelegat,
                UpdateWsMessageHandlerWsPositionSimpleDelegat, UpdateWsMessageHandlerWsPositionSlimDelegat,
                UpdateWsMessageHandlerWsPositionHeavyDelegat, UpdateWsMessageHandlerWsSummarySimpleDelegat,
                UpdateWsMessageHandlerWsSummarySlimDelegat, UpdateWsMessageHandlerWsSummaryHeavyDelegat,
                UpdateWsMessageHandlerWsRiskSimpleDelegat, UpdateWsMessageHandlerWsRiskSlimDelegat,
                UpdateWsMessageHandlerWsRiskHeavyDelegat, UpdateWsMessageHandlerWsFortsriskSimpleDelegat,
                UpdateWsMessageHandlerWsFortsriskSlimDelegat, UpdateWsMessageHandlerWsFortsriskHeavyDelegat,
                UpdateWsMessageHandlerWsTradeSimpleDelegat, UpdateWsMessageHandlerWsTradeSlimDelegat,
                UpdateWsMessageHandlerWsTradeHeavyDelegat, UpdateWsMessageHandlerWsOrderSimpleDelegat,
                UpdateWsMessageHandlerWsOrderSlimDelegat, UpdateWsMessageHandlerWsOrderHeavyDelegat,
                UpdateWsMessageHandlerWsSecurityFromWsSimpleDelegat, UpdateWsMessageHandlerWsSecurityFromWsSlimDelegat,
                UpdateWsMessageHandlerWsSecurityFromWsHeavyDelegat, UpdateWsMessageHandlerWsStopOrderSimpleDelegat,
                UpdateWsMessageHandlerWsStopOrderSlimDelegat, UpdateWsMessageHandlerWsStopOrderHeavyDelegat);

            _cwsAuthService = new CwsAuthService(commandLogger, OnAuthMsgUpdatedAsync);
            CommandWs = new CwsManager(OnCommandMsgUpdatedAsync, CwsAuthorizeAndSetRefreshTimer);

            if (names != null)
            {
                for (var i = 0; i < sockets && i < names.Count; i++)
                {
                    _webSocketConnections.Add(new WebSocketConnectionManager(_logger, webSocketUri, _jwtToken,
                        metricsRegistry, incrementSocketsCounter, decrementSocketsCounter, i, names[i], onMessageRecieved, webSocketHeaders));
                }
                _commandWebSocket = new WebSocketConnectionManager(commandLogger, commandWebSocketUri, _jwtToken, metricsRegistry,
                    incrementSocketsCounter, decrementSocketsCounter, names.Count, commandSocketName, onMessageRecieved, commandWebSocketHeaders);
            }
            else
            {
                _webSocketConnections.Add(new WebSocketConnectionManager(_logger, webSocketUri, _jwtToken,
                    metricsRegistry, incrementSocketsCounter, decrementSocketsCounter, 0, "WS Alor+", onMessageRecieved, webSocketHeaders));
                _commandWebSocket = new WebSocketConnectionManager(commandLogger, commandWebSocketUri, _jwtToken, metricsRegistry,
                    incrementSocketsCounter, decrementSocketsCounter, 1, "CWS Alor+", onMessageRecieved, commandWebSocketHeaders);
            }
        }

        private void UpdateWsMessageHandlerWsOrderBookSimpleDelegat(Action<WsOrderBookSimple> wsOrderBookChanged) =>
            _webSocketMessageHandler.UpdateWsOrderBookSimpleUserDelegate(wsOrderBookChanged);
        private void UpdateWsMessageHandlerWsOrderBookSlimDelegat(Action<WsOrderBookSlim> wsOrderBookChanged) =>
            _webSocketMessageHandler.UpdateWsOrderBookSlimUserDelegate(wsOrderBookChanged);
        private void UpdateWsMessageHandlerWsOrderBookHeavyDelegat(Action<WsOrderBookHeavy> wsOrderBookChanged) =>
            _webSocketMessageHandler.UpdateWsOrderBookHeavyUserDelegate(wsOrderBookChanged);
        private void UpdateWsMessageHandlerWsCandleSimpleDelegat(Action<WsCandleSimple> wsCandleChanged) =>
            _webSocketMessageHandler.UpdateWsCandleSimpleUserDelegate(wsCandleChanged);
        private void UpdateWsMessageHandlerWsCandleSlimDelegat(Action<WsCandleSlim> wsCandleChanged) =>
            _webSocketMessageHandler.UpdateWsCandleSlimUserDelegate(wsCandleChanged);
        private void UpdateWsMessageHandlerWsCandleHeavyDelegat(Action<WsCandleHeavy> wsCandleChanged) =>
            _webSocketMessageHandler.UpdateWsCandleHeavyUserDelegate(wsCandleChanged);
        private void UpdateWsMessageHandlerWsSymbolSimpleDelegat(Action<WsSymbolSimple> wsSymbolChanged) =>
            _webSocketMessageHandler.UpdateWsSymbolSimpleUserDelegate(wsSymbolChanged);
        private void UpdateWsMessageHandlerWsSymbolSlimDelegat(Action<WsSymbolSlim> wsSymbolChanged) =>
            _webSocketMessageHandler.UpdateWsSymbolSlimUserDelegate(wsSymbolChanged);
        private void UpdateWsMessageHandlerWsSymbolHeavyDelegat(Action<WsSymbolHeavy> wsSymbolChanged) =>
            _webSocketMessageHandler.UpdateWsSymbolHeavyUserDelegate(wsSymbolChanged);
        private void UpdateWsMessageHandlerWsAllTradeSimpleDelegat(Action<WsAllTradeSimple> wsAllTradeChanged) =>
            _webSocketMessageHandler.UpdateWsAllTradeSimpleUserDelegate(wsAllTradeChanged);
        private void UpdateWsMessageHandlerWsAllTradeSlimDelegat(Action<WsAllTradeSlim> wsAllTradeChanged) =>
            _webSocketMessageHandler.UpdateWsAllTradeSlimUserDelegate(wsAllTradeChanged);
        private void UpdateWsMessageHandlerWsAllTradeHeavyDelegat(Action<WsAllTradeHeavy> wsAllTradeChanged) =>
            _webSocketMessageHandler.UpdateWsAllTradeHeavyUserDelegate(wsAllTradeChanged);
        private void UpdateWsMessageHandlerWsPositionSimpleDelegat(Action<WsPositionSimple> wsPositionChanged) =>
            _webSocketMessageHandler.UpdateWsPositionSimpleUserDelegate(wsPositionChanged);
        private void UpdateWsMessageHandlerWsPositionSlimDelegat(Action<WsPositionSlim> wsPositionChanged) =>
            _webSocketMessageHandler.UpdateWsPositionSlimUserDelegate(wsPositionChanged);
        private void UpdateWsMessageHandlerWsPositionHeavyDelegat(Action<WsPositionHeavy> wsPositionChanged) =>
            _webSocketMessageHandler.UpdateWsPositionHeavyUserDelegate(wsPositionChanged);
        private void UpdateWsMessageHandlerWsSummarySimpleDelegat(Action<WsSummarySimple> wsSummaryChanged) =>
            _webSocketMessageHandler.UpdateWsSummarySimpleUserDelegate(wsSummaryChanged);
        private void UpdateWsMessageHandlerWsSummarySlimDelegat(Action<WsSummarySlim> wsSummaryChanged) =>
            _webSocketMessageHandler.UpdateWsSummarySlimUserDelegate(wsSummaryChanged);
        private void UpdateWsMessageHandlerWsSummaryHeavyDelegat(Action<WsSummaryHeavy> wsSummaryChanged) =>
            _webSocketMessageHandler.UpdateWsSummaryHeavyUserDelegate(wsSummaryChanged);
        private void UpdateWsMessageHandlerWsRiskSimpleDelegat(Action<WsRiskSimple> wsRiskChanged) =>
            _webSocketMessageHandler.UpdateWsRiskSimpleUserDelegate(wsRiskChanged);
        private void UpdateWsMessageHandlerWsRiskSlimDelegat(Action<WsRiskSlim> wsRiskChanged) =>
            _webSocketMessageHandler.UpdateWsRiskSlimUserDelegate(wsRiskChanged);
        private void UpdateWsMessageHandlerWsRiskHeavyDelegat(Action<WsRiskHeavy> wsRiskChanged) =>
            _webSocketMessageHandler.UpdateWsRiskHeavyUserDelegate(wsRiskChanged);
        private void UpdateWsMessageHandlerWsFortsriskSimpleDelegat(Action<WsFortsriskSimple> wsFortsriskChanged) =>
            _webSocketMessageHandler.UpdateWsFortsriskSimpleUserDelegate(wsFortsriskChanged);
        private void UpdateWsMessageHandlerWsFortsriskSlimDelegat(Action<WsFortsriskSlim> wsFortsriskChanged) =>
            _webSocketMessageHandler.UpdateWsFortsriskSlimUserDelegate(wsFortsriskChanged);
        private void UpdateWsMessageHandlerWsFortsriskHeavyDelegat(Action<WsFortsriskHeavy> wsFortsriskChanged) =>
            _webSocketMessageHandler.UpdateWsFortsriskHeavyUserDelegate(wsFortsriskChanged);
        private void UpdateWsMessageHandlerWsTradeSimpleDelegat(Action<WsTradeSimple> wsTradeChanged) =>
            _webSocketMessageHandler.UpdateWsTradeSimpleUserDelegate(wsTradeChanged);
        private void UpdateWsMessageHandlerWsTradeSlimDelegat(Action<WsTradeSlim> wsTradeChanged) =>
            _webSocketMessageHandler.UpdateWsTradeSlimUserDelegate(wsTradeChanged);
        private void UpdateWsMessageHandlerWsTradeHeavyDelegat(Action<WsTradeHeavy> wsTradeChanged) =>
            _webSocketMessageHandler.UpdateWsTradeHeavyUserDelegate(wsTradeChanged);
        private void UpdateWsMessageHandlerWsOrderSimpleDelegat(Action<WsOrderSimple> wsOrderChanged) =>
            _webSocketMessageHandler.UpdateWsOrderSimpleUserDelegate(wsOrderChanged);
        private void UpdateWsMessageHandlerWsOrderSlimDelegat(Action<WsOrderSlim> wsOrderChanged) =>
            _webSocketMessageHandler.UpdateWsOrderSlimUserDelegate(wsOrderChanged);
        private void UpdateWsMessageHandlerWsOrderHeavyDelegat(Action<WsOrderHeavy> wsOrderChanged) =>
            _webSocketMessageHandler.UpdateWsOrderHeavyUserDelegate(wsOrderChanged);
        private void UpdateWsMessageHandlerWsSecurityFromWsSimpleDelegat(Action<WsSecurityFromWsSimple> wsSecurityFromWsChanged) =>
            _webSocketMessageHandler.UpdateWsSecurityFromWsSimpleUserDelegate(wsSecurityFromWsChanged);
        private void UpdateWsMessageHandlerWsSecurityFromWsSlimDelegat(Action<WsSecurityFromWsSlim> wsSecurityFromWsChanged) =>
            _webSocketMessageHandler.UpdateWsSecurityFromWsSlimUserDelegate(wsSecurityFromWsChanged);
        private void UpdateWsMessageHandlerWsSecurityFromWsHeavyDelegat(Action<WsSecurityFromWsHeavy> wsSecurityFromWsChanged) =>
            _webSocketMessageHandler.UpdateWsSecurityFromWsHeavyUserDelegate(wsSecurityFromWsChanged);
        private void UpdateWsMessageHandlerWsStopOrderSimpleDelegat(Action<WsStopOrderSimple> wsStopOrderChanged) =>
            _webSocketMessageHandler.UpdateWsStopOrderSimpleUserDelegate(wsStopOrderChanged);
        private void UpdateWsMessageHandlerWsStopOrderSlimDelegat(Action<WsStopOrderSlim> wsStopOrderChanged) =>
            _webSocketMessageHandler.UpdateWsStopOrderSlimUserDelegate(wsStopOrderChanged);
        private void UpdateWsMessageHandlerWsStopOrderHeavyDelegat(Action<WsStopOrderHeavy> wsStopOrderChanged) =>
            _webSocketMessageHandler.UpdateWsStopOrderHeavyUserDelegate(wsStopOrderChanged);


        public void JwtUpdate(string? newToken)
        {
            _jwtToken = newToken;
            foreach (var webSocketConnection in _webSocketConnections)
            {
                webSocketConnection.JwtUpdate(newToken);
            }
            _commandWebSocket.JwtUpdate(newToken);
        }

        IEnumerable<WebSocketInfoDetails> IInternalWebSocketsPoolManagerActions.GetWebSocketsInfoDetail() =>
            _webSocketConnections
                .Select(webSocketConnection => webSocketConnection.GetSocketInfoDetails()).Append(_commandWebSocket.GetSocketInfoDetails());

        public void CalculateWebSocketsInfoSentRecieveRates()
        {
            foreach (var webSocketConnection in _webSocketConnections)
            {
                webSocketConnection.CalculateWebSocketInfoRecieveRate();
                webSocketConnection.CalculateWebSocketInfoSentRate();
            }
            _commandWebSocket.CalculateWebSocketInfoSentRate();
            _commandWebSocket.CalculateWebSocketInfoSentRate();
        }

        public void SetWsResponseMessageHandler(Action<WsResponseMessage>? handler)
            => _webSocketMessageHandler.SetWsResponseMessageHandler(handler);

        public void SetWsResponseCommandMessageHandler(Action<WsResponseCommandMessage>? handler)
            => _webSocketMessageHandler.SetWsResponseCommandMessageHandler(handler);

        private Task<bool[]> OnMsgDictionaryUpdatedAsync(Dictionary<string, string> dict)
        {
            var msgDic = new Dictionary<IWebSocketConnectionManager, List<string>>();

            var i = 0;
            foreach (var item in dict)
            {
                var socketIndex = i % _webSocketConnections.Count;
                var currentSocket = _webSocketConnections[socketIndex];

                currentSocket.AddToOpcodes(item.Key, item.Value);
                if (!msgDic.TryGetValue(currentSocket, out var value))
                {
                    value = [];
                    msgDic[currentSocket] = value;
                }

                value.Add(item.Value);

                _guidAndSocketsDict.TryAdd(item.Key, currentSocket);

                i++;
            }

            return Task.WhenAll(msgDic.Select(x => x.Key.SendOrStartAndSend(x.Value))
                .ToArray()); // стартуем все таски параллельно
        }

        private Task<bool[]> OnMsgDeleteRequestAsync(Dictionary<string, string> dict)
        {
            var msgDic = new Dictionary<IWebSocketConnectionManager, List<string>>();

            foreach (var item in dict)
            {
                if (!_guidAndSocketsDict.TryGetValue(item.Key, out var socket)) continue;
                socket.TryToRemoveFromOpcodes(item.Key);
                if (!msgDic.TryGetValue(socket, out var value))
                {
                    value = [];
                    msgDic[socket] = value;
                }

                value.Add(item.Value);
            }

            return Task.WhenAll(msgDic.Select(x => x.Key.SendOrStartAndSend(x.Value))
                .ToArray()); // стартуем все таски параллельно
        }

        private Task<bool> OnCommandMsgUpdatedAsync(string message) => _commandWebSocket.SendOrStartAndSendCws(message);
        private Task<bool> OnAuthMsgUpdatedAsync(string message) => _commandWebSocket.SendOrStartAndSend(message);
        private Task CwsAuthorizeAndSetRefreshTimer() => _cwsAuthService.CwsAuthorizeAndSetRefreshTimer();

        public void Dispose()
        {
            _wsResponseMessageChangedFromUser = null;
            _wsResponseCommandMessageChangedFromUser = null;

            foreach (var webSocketConnection in _webSocketConnections)
            {
                webSocketConnection.Dispose();
            }

            _cwsAuthService.Dispose();
            Subscriptions.Dispose();
            CommandWs.Dispose();
            _commandWebSocket.Dispose();
            _webSocketMessageHandler.Dispose();
            _webSocketConnections.Clear();

            _logger.Information("Закрыли и уничтожили все сокеты.");
        }
    }
}
