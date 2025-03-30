using Alor.OpenAPI.Interfaces;
using Alor.OpenAPI.Models;
using Alor.OpenAPI.Models.Heavy;
using Alor.OpenAPI.Models.Simple;
using Alor.OpenAPI.Models.Slim;
using Alor.OpenAPI.Utilities;
using Serilog;
using SpanJson;
using System.Collections.Concurrent;
using System.Collections.Frozen;
using System.Text;

namespace Alor.OpenAPI.Managers
{
    internal class WebSocketMessageHandler : IWebSocketMessageHandler
    {
        private readonly ILogger _logger;
        private readonly ILogger _commandLogger;
        private readonly AlorOpenApiLogLevel _logLevel;
        private readonly FrozenDictionary<ReadOnlyMemory<byte>, Action<(byte[] data, int len, DateTime timestamp)>> _handlers;
        private readonly ConcurrentDictionary<string, Parameters> _parameters;
        private Action<WsResponseMessage>? _wsResponseMessageChangedToUser;
        private Action<WsResponseCommandMessage>? _wsResponseCommandMessageChangedToUser;
        private Action<WsOrderBookSimple>? _wsOrderBookSimpleChangedToUser;
        private Action<WsOrderBookSlim>? _wsOrderBookSlimChangedToUser;
        private Action<WsOrderBookHeavy>? _wsOrderBookHeavyChangedToUser;
        private Action<WsCandleSimple>? _wsCandleSimpleChangedToUser;
        private Action<WsCandleSlim>? _wsCandleSlimChangedToUser;
        private Action<WsCandleHeavy>? _wsCandleHeavyChangedToUser;
        private Action<WsSymbolSimple>? _wsSymbolSimpleChangedToUser;
        private Action<WsSymbolSlim>? _wsSymbolSlimChangedToUser;
        private Action<WsSymbolHeavy>? _wsSymbolHeavyChangedToUser;
        private Action<WsAllTradeSimple>? _wsAllTradeSimpleChangedToUser;
        private Action<WsAllTradeSlim>? _wsAllTradeSlimChangedToUser;
        private Action<WsAllTradeHeavy>? _wsAllTradeHeavyChangedToUser;
        private Action<WsPositionSimple>? _wsPositionSimpleChangedToUser;
        private Action<WsPositionSlim>? _wsPositionSlimChangedToUser;
        private Action<WsPositionHeavy>? _wsPositionHeavyChangedToUser;
        private Action<WsSummarySimple>? _wsSummarySimpleChangedToUser;
        private Action<WsSummarySlim>? _wsSummarySlimChangedToUser;
        private Action<WsSummaryHeavy>? _wsSummaryHeavyChangedToUser;
        private Action<WsRiskSimple>? _wsRiskSimpleChangedToUser;
        private Action<WsRiskSlim>? _wsRiskSlimChangedToUser;
        private Action<WsRiskHeavy>? _wsRiskHeavyChangedToUser;
        private Action<WsFortsriskSimple>? _wsFortsriskSimpleChangedToUser;
        private Action<WsFortsriskSlim>? _wsFortsriskSlimChangedToUser;
        private Action<WsFortsriskHeavy>? _wsFortsriskHeavyChangedToUser;
        private Action<WsTradeSimple>? _wsTradeSimpleChangedToUser;
        private Action<WsTradeSlim>? _wsTradeSlimChangedToUser;
        private Action<WsTradeHeavy>? _wsTradeHeavyChangedToUser;
        private Action<WsOrderSimple>? _wsOrderSimpleChangedToUser;
        private Action<WsOrderSlim>? _wsOrderSlimChangedToUser;
        private Action<WsOrderHeavy>? _wsOrderHeavyChangedToUser;
        private Action<WsSecurityFromWsSimple>? _wsSecurityFromWsSimpleChangedToUser;
        private Action<WsSecurityFromWsSlim>? _wsSecurityFromWsSlimChangedToUser;
        private Action<WsSecurityFromWsHeavy>? _wsSecurityFromWsHeavyChangedToUser;
        private Action<WsStopOrderSimple>? _wsStopOrderSimpleChangedToUser;
        private Action<WsStopOrderSlim>? _wsStopOrderSlimChangedToUser;
        private Action<WsStopOrderHeavy>? _wsStopOrderHeavyChangedToUser;


        private readonly FrozenDictionary<string, byte[]> _subscriptionTypesDictionary =
            new KeyValuePair<string, byte[]>[]
            {
                new("requestGuid", "{\"requestGuid\":\""u8.ToArray()),
                new("guid", "\"guid\":\""u8.ToArray()),
                new("_", "_"u8.ToArray()),
                new("auth", "auth"u8.ToArray()),
                new("a", "a"u8.ToArray()),
                new("b0", "b0"u8.ToArray()),
                new("b1", "b1"u8.ToArray()),
                new("b2", "b2"u8.ToArray()),
                new("c0", "c0"u8.ToArray()),
                new("c1", "c1"u8.ToArray()),
                new("c2", "c2"u8.ToArray()),
                new("d0", "d0"u8.ToArray()),
                new("d1", "d1"u8.ToArray()),
                new("d2", "d2"u8.ToArray()),
                new("e0", "e0"u8.ToArray()),
                new("e1", "e1"u8.ToArray()),
                new("e2", "e2"u8.ToArray()),
                new("f0", "f0"u8.ToArray()),
                new("f1", "f1"u8.ToArray()),
                new("f2", "f2"u8.ToArray()),
                new("g0", "g0"u8.ToArray()),
                new("g1", "g1"u8.ToArray()),
                new("g2", "g2"u8.ToArray()),
                new("h0", "h0"u8.ToArray()),
                new("h1", "h1"u8.ToArray()),
                new("h2", "h2"u8.ToArray()),
                new("i0", "i0"u8.ToArray()),
                new("i1", "i1"u8.ToArray()),
                new("i2", "i2"u8.ToArray()),
                new("j0", "j0"u8.ToArray()),
                new("j1", "j1"u8.ToArray()),
                new("j2", "j2"u8.ToArray()),
                new("k0", "k0"u8.ToArray()),
                new("k1", "k1"u8.ToArray()),
                new("k2", "k2"u8.ToArray()),
                new("l0", "l0"u8.ToArray()),
                new("l1", "l1"u8.ToArray()),
                new("l2", "l2"u8.ToArray()),
                new("m0", "m0"u8.ToArray()),
                new("m1", "m1"u8.ToArray()),
                new("m2", "m2"u8.ToArray()),
                new("n0", "n0"u8.ToArray()),
                new("n1", "n1"u8.ToArray()),
                new("n2", "n2"u8.ToArray()),
                new("o0", "o0"u8.ToArray()),
                new("o1", "o1"u8.ToArray()),
                new("o2", "o2"u8.ToArray()),
                new("p0", "p0"u8.ToArray()),
                new("p1", "p1"u8.ToArray()),
                new("p2", "p2"u8.ToArray()),
                new("q0", "q0"u8.ToArray()),
                new("q1", "q1"u8.ToArray()),
                new("q2", "q2"u8.ToArray()),
                new("r0", "r0"u8.ToArray()),
                new("r1", "r1"u8.ToArray()),
                new("r2", "r2"u8.ToArray()),
                new("s0", "s0"u8.ToArray()),
                new("s1", "s1"u8.ToArray()),
                new("s2", "s2"u8.ToArray()),
                new("t0", "t0"u8.ToArray()),
                new("t1", "t1"u8.ToArray()),
                new("t2", "t2"u8.ToArray()),
                new("u0", "u0"u8.ToArray()),
                new("u1", "u1"u8.ToArray()),
                new("u2", "u2"u8.ToArray()),
                new("v0", "v0"u8.ToArray()),
                new("v1", "v1"u8.ToArray()),
                new("v2", "v2"u8.ToArray()),
                new("w0", "w0"u8.ToArray()),
                new("w1", "w1"u8.ToArray()),
                new("w2", "w2"u8.ToArray()),
                new("x0", "x0"u8.ToArray()),
                new("x1", "x1"u8.ToArray()),
                new("x2", "x2"u8.ToArray()),
                new("y0", "y0"u8.ToArray()),
                new("y1", "y1"u8.ToArray()),
                new("y2", "y2"u8.ToArray()),
                new("z0", "z0"u8.ToArray()),
                new("z1", "z1"u8.ToArray()),
                new("z2", "z2"u8.ToArray()),
            }.ToFrozenDictionary();

        public void UpdateWsOrderBookSimpleUserDelegate(Action<WsOrderBookSimple>? wsOrderBookChangedFromUser) =>
            _wsOrderBookSimpleChangedToUser = wsOrderBookChangedFromUser;
        public void UpdateWsOrderBookSlimUserDelegate(Action<WsOrderBookSlim>? wsOrderBookChangedFromUser) =>
            _wsOrderBookSlimChangedToUser = wsOrderBookChangedFromUser;
        public void UpdateWsOrderBookHeavyUserDelegate(Action<WsOrderBookHeavy>? wsOrderBookChangedFromUser) =>
            _wsOrderBookHeavyChangedToUser = wsOrderBookChangedFromUser;
        public void UpdateWsCandleSimpleUserDelegate(Action<WsCandleSimple>? wsCandleChangedFromUser) =>
            _wsCandleSimpleChangedToUser = wsCandleChangedFromUser;
        public void UpdateWsCandleSlimUserDelegate(Action<WsCandleSlim>? wsCandleChangedFromUser) =>
            _wsCandleSlimChangedToUser = wsCandleChangedFromUser;
        public void UpdateWsCandleHeavyUserDelegate(Action<WsCandleHeavy>? wsCandleChangedFromUser) =>
            _wsCandleHeavyChangedToUser = wsCandleChangedFromUser;
        public void UpdateWsSymbolSimpleUserDelegate(Action<WsSymbolSimple>? wsSymbolChangedFromUser) =>
            _wsSymbolSimpleChangedToUser = wsSymbolChangedFromUser;
        public void UpdateWsSymbolSlimUserDelegate(Action<WsSymbolSlim>? wsSymbolChangedFromUser) =>
            _wsSymbolSlimChangedToUser = wsSymbolChangedFromUser;
        public void UpdateWsSymbolHeavyUserDelegate(Action<WsSymbolHeavy>? wsSymbolChangedFromUser) =>
            _wsSymbolHeavyChangedToUser = wsSymbolChangedFromUser;
        public void UpdateWsAllTradeSimpleUserDelegate(Action<WsAllTradeSimple>? wsAllTradeChangedFromUser) =>
            _wsAllTradeSimpleChangedToUser = wsAllTradeChangedFromUser;
        public void UpdateWsAllTradeSlimUserDelegate(Action<WsAllTradeSlim>? wsAllTradeChangedFromUser) =>
            _wsAllTradeSlimChangedToUser = wsAllTradeChangedFromUser;
        public void UpdateWsAllTradeHeavyUserDelegate(Action<WsAllTradeHeavy>? wsAllTradeChangedFromUser) =>
            _wsAllTradeHeavyChangedToUser = wsAllTradeChangedFromUser;
        public void UpdateWsPositionSimpleUserDelegate(Action<WsPositionSimple>? wsPositionChangedFromUser) =>
            _wsPositionSimpleChangedToUser = wsPositionChangedFromUser;
        public void UpdateWsPositionSlimUserDelegate(Action<WsPositionSlim>? wsPositionChangedFromUser) =>
            _wsPositionSlimChangedToUser = wsPositionChangedFromUser;
        public void UpdateWsPositionHeavyUserDelegate(Action<WsPositionHeavy>? wsPositionChangedFromUser) =>
            _wsPositionHeavyChangedToUser = wsPositionChangedFromUser;
        public void UpdateWsSummarySimpleUserDelegate(Action<WsSummarySimple>? wsSummaryChangedFromUser) =>
            _wsSummarySimpleChangedToUser = wsSummaryChangedFromUser;
        public void UpdateWsSummarySlimUserDelegate(Action<WsSummarySlim>? wsSummaryChangedFromUser) =>
            _wsSummarySlimChangedToUser = wsSummaryChangedFromUser;
        public void UpdateWsSummaryHeavyUserDelegate(Action<WsSummaryHeavy>? wsSummaryChangedFromUser) =>
            _wsSummaryHeavyChangedToUser = wsSummaryChangedFromUser;
        public void UpdateWsRiskSimpleUserDelegate(Action<WsRiskSimple>? wsRiskChangedFromUser) =>
            _wsRiskSimpleChangedToUser = wsRiskChangedFromUser;
        public void UpdateWsRiskSlimUserDelegate(Action<WsRiskSlim>? wsRiskChangedFromUser) =>
            _wsRiskSlimChangedToUser = wsRiskChangedFromUser;
        public void UpdateWsRiskHeavyUserDelegate(Action<WsRiskHeavy>? wsRiskChangedFromUser) =>
            _wsRiskHeavyChangedToUser = wsRiskChangedFromUser;
        public void UpdateWsFortsriskSimpleUserDelegate(Action<WsFortsriskSimple>? wsFortsriskChangedFromUser) =>
            _wsFortsriskSimpleChangedToUser = wsFortsriskChangedFromUser;
        public void UpdateWsFortsriskSlimUserDelegate(Action<WsFortsriskSlim>? wsFortsriskChangedFromUser) =>
            _wsFortsriskSlimChangedToUser = wsFortsriskChangedFromUser;
        public void UpdateWsFortsriskHeavyUserDelegate(Action<WsFortsriskHeavy>? wsFortsriskChangedFromUser) =>
            _wsFortsriskHeavyChangedToUser = wsFortsriskChangedFromUser;
        public void UpdateWsTradeSimpleUserDelegate(Action<WsTradeSimple>? wsTradeChangedFromUser) =>
            _wsTradeSimpleChangedToUser = wsTradeChangedFromUser;
        public void UpdateWsTradeSlimUserDelegate(Action<WsTradeSlim>? wsTradeChangedFromUser) =>
            _wsTradeSlimChangedToUser = wsTradeChangedFromUser;
        public void UpdateWsTradeHeavyUserDelegate(Action<WsTradeHeavy>? wsTradeChangedFromUser) =>
            _wsTradeHeavyChangedToUser = wsTradeChangedFromUser;
        public void UpdateWsOrderSimpleUserDelegate(Action<WsOrderSimple>? wsOrderChangedFromUser) =>
            _wsOrderSimpleChangedToUser = wsOrderChangedFromUser;
        public void UpdateWsOrderSlimUserDelegate(Action<WsOrderSlim>? wsOrderChangedFromUser) =>
            _wsOrderSlimChangedToUser = wsOrderChangedFromUser;
        public void UpdateWsOrderHeavyUserDelegate(Action<WsOrderHeavy>? wsOrderChangedFromUser) =>
            _wsOrderHeavyChangedToUser = wsOrderChangedFromUser;
        public void UpdateWsSecurityFromWsSimpleUserDelegate(Action<WsSecurityFromWsSimple>? wsSecurityFromWsChangedFromUser) =>
            _wsSecurityFromWsSimpleChangedToUser = wsSecurityFromWsChangedFromUser;
        public void UpdateWsSecurityFromWsSlimUserDelegate(Action<WsSecurityFromWsSlim>? wsSecurityFromWsChangedFromUser) =>
            _wsSecurityFromWsSlimChangedToUser = wsSecurityFromWsChangedFromUser;
        public void UpdateWsSecurityFromWsHeavyUserDelegate(Action<WsSecurityFromWsHeavy>? wsSecurityFromWsChangedFromUser) =>
            _wsSecurityFromWsHeavyChangedToUser = wsSecurityFromWsChangedFromUser;
        public void UpdateWsStopOrderSimpleUserDelegate(Action<WsStopOrderSimple>? wsStopOrderChangedFromUser) =>
            _wsStopOrderSimpleChangedToUser = wsStopOrderChangedFromUser;
        public void UpdateWsStopOrderSlimUserDelegate(Action<WsStopOrderSlim>? wsStopOrderChangedFromUser) =>
            _wsStopOrderSlimChangedToUser = wsStopOrderChangedFromUser;
        public void UpdateWsStopOrderHeavyUserDelegate(Action<WsStopOrderHeavy>? wsStopOrderChangedFromUser) =>
            _wsStopOrderHeavyChangedToUser = wsStopOrderChangedFromUser;


        internal WebSocketMessageHandler(ILogger logger, ILogger commandLogger, AlorOpenApiLogLevel logLevel, ConcurrentDictionary<string, Parameters> parameters, Action<WsResponseMessage>? wsResponseMessageChangedFromUser, Action<WsResponseCommandMessage>? wsResponseCommandMessageChangedToUser)
        {
            _logger = logger;
            _commandLogger = commandLogger;
            _logLevel = logLevel;
            _parameters = parameters;
            _wsResponseMessageChangedToUser = wsResponseMessageChangedFromUser;
            _wsResponseCommandMessageChangedToUser = wsResponseCommandMessageChangedToUser;

            _handlers = new KeyValuePair<ReadOnlyMemory<byte>, Action<(byte[] data, int len, DateTime timestamp)>>[]
            {
                new(_subscriptionTypesDictionary["b0"], (msg) => ProcessMessage<WsOrderBookSimple, OrderbookSimple>(msg, _wsOrderBookSimpleChangedToUser)),
                new(_subscriptionTypesDictionary["b1"], (msg) => ProcessMessage<WsOrderBookSlim, OrderbookSlim>(msg, _wsOrderBookSlimChangedToUser)),
                new(_subscriptionTypesDictionary["b2"], (msg) => ProcessMessage<WsOrderBookHeavy, OrderbookHeavy>(msg, _wsOrderBookHeavyChangedToUser)),
                new(_subscriptionTypesDictionary["c0"], (msg) => ProcessMessage<WsCandleSimple, CandleSimple>(msg, _wsCandleSimpleChangedToUser)),
                new(_subscriptionTypesDictionary["c1"], (msg) => ProcessMessage<WsCandleSlim, CandleSlim>(msg, _wsCandleSlimChangedToUser)),
                new(_subscriptionTypesDictionary["c2"], (msg) => ProcessMessage<WsCandleHeavy, CandleHeavy>(msg, _wsCandleHeavyChangedToUser)),
                new(_subscriptionTypesDictionary["d0"], (msg) => ProcessMessage<WsSymbolSimple, SymbolSimple>(msg, _wsSymbolSimpleChangedToUser)),
                new(_subscriptionTypesDictionary["d1"], (msg) => ProcessMessage<WsSymbolSlim, SymbolSlim>(msg, _wsSymbolSlimChangedToUser)),
                new(_subscriptionTypesDictionary["d2"], (msg) => ProcessMessage<WsSymbolHeavy, SymbolHeavy>(msg, _wsSymbolHeavyChangedToUser)),
                new(_subscriptionTypesDictionary["e0"], (msg) => ProcessMessage<WsAllTradeSimple, AllTradeSimple>(msg, _wsAllTradeSimpleChangedToUser)),
                new(_subscriptionTypesDictionary["e1"], (msg) => ProcessMessage<WsAllTradeSlim, AllTradeSlim>(msg, _wsAllTradeSlimChangedToUser)),
                new(_subscriptionTypesDictionary["e2"], (msg) => ProcessMessage<WsAllTradeHeavy, AllTradeHeavy>(msg, _wsAllTradeHeavyChangedToUser)),
                new(_subscriptionTypesDictionary["f0"], (msg) => ProcessMessage<WsPositionSimple, PositionSimple>(msg, _wsPositionSimpleChangedToUser)),
                new(_subscriptionTypesDictionary["f1"], (msg) => ProcessMessage<WsPositionSlim, PositionSlim>(msg, _wsPositionSlimChangedToUser)),
                new(_subscriptionTypesDictionary["f2"], (msg) => ProcessMessage<WsPositionHeavy, PositionHeavy>(msg, _wsPositionHeavyChangedToUser)),
                new(_subscriptionTypesDictionary["g0"], (msg) => ProcessMessage<WsSummarySimple, SummarySimple>(msg, _wsSummarySimpleChangedToUser)),
                new(_subscriptionTypesDictionary["g1"], (msg) => ProcessMessage<WsSummarySlim, SummarySlim>(msg, _wsSummarySlimChangedToUser)),
                new(_subscriptionTypesDictionary["g2"], (msg) => ProcessMessage<WsSummaryHeavy, SummaryHeavy>(msg, _wsSummaryHeavyChangedToUser)),
                new(_subscriptionTypesDictionary["h0"], (msg) => ProcessMessage<WsRiskSimple, RiskSimple>(msg, _wsRiskSimpleChangedToUser)),
                new(_subscriptionTypesDictionary["h1"], (msg) => ProcessMessage<WsRiskSlim, RiskSlim>(msg, _wsRiskSlimChangedToUser)),
                new(_subscriptionTypesDictionary["h2"], (msg) => ProcessMessage<WsRiskHeavy, RiskHeavy>(msg, _wsRiskHeavyChangedToUser)),
                new(_subscriptionTypesDictionary["i0"], (msg) => ProcessMessage<WsFortsriskSimple, FortsriskSimple>(msg, _wsFortsriskSimpleChangedToUser)),
                new(_subscriptionTypesDictionary["i1"], (msg) => ProcessMessage<WsFortsriskSlim, FortsriskSlim>(msg, _wsFortsriskSlimChangedToUser)),
                new(_subscriptionTypesDictionary["i2"], (msg) => ProcessMessage<WsFortsriskHeavy, FortsriskHeavy>(msg, _wsFortsriskHeavyChangedToUser)),
                new(_subscriptionTypesDictionary["j0"], (msg) => ProcessMessage<WsTradeSimple, TradeSimple>(msg, _wsTradeSimpleChangedToUser)),
                new(_subscriptionTypesDictionary["j1"], (msg) => ProcessMessage<WsTradeSlim, TradeSlim>(msg, _wsTradeSlimChangedToUser)),
                new(_subscriptionTypesDictionary["j2"], (msg) => ProcessMessage<WsTradeHeavy, TradeHeavy>(msg, _wsTradeHeavyChangedToUser)),
                new(_subscriptionTypesDictionary["k0"], (msg) => ProcessMessage<WsOrderSimple, OrderSimple>(msg, _wsOrderSimpleChangedToUser)),
                new(_subscriptionTypesDictionary["k1"], (msg) => ProcessMessage<WsOrderSlim, OrderSlim>(msg, _wsOrderSlimChangedToUser)),
                new(_subscriptionTypesDictionary["k2"], (msg) => ProcessMessage<WsOrderHeavy, OrderHeavy>(msg, _wsOrderHeavyChangedToUser)),
                new(_subscriptionTypesDictionary["l0"], (msg) => ProcessMessage<WsSecurityFromWsSimple, SecurityFromWsSimple>(msg, _wsSecurityFromWsSimpleChangedToUser)),
                new(_subscriptionTypesDictionary["l1"], (msg) => ProcessMessage<WsSecurityFromWsSlim, SecurityFromWsSlim>(msg, _wsSecurityFromWsSlimChangedToUser)),
                new(_subscriptionTypesDictionary["l2"], (msg) => ProcessMessage<WsSecurityFromWsHeavy, SecurityFromWsHeavy>(msg, _wsSecurityFromWsHeavyChangedToUser)),
                new(_subscriptionTypesDictionary["m0"], (msg) => ProcessMessage<WsStopOrderSimple, StopOrderSimple>(msg, _wsStopOrderSimpleChangedToUser)),
                new(_subscriptionTypesDictionary["m1"], (msg) => ProcessMessage<WsStopOrderSlim, StopOrderSlim>(msg, _wsStopOrderSlimChangedToUser)),
                new(_subscriptionTypesDictionary["m2"], (msg) => ProcessMessage<WsStopOrderHeavy, StopOrderHeavy>(msg, _wsStopOrderHeavyChangedToUser)),

            }.ToFrozenDictionary(new ReadOnlyMemoryComparer());
        }


        public void MessageReceived((byte[] data, int len, DateTime timestamp) byteMsg, string wsName)
        {
            try
            {
                //Console.WriteLine(Encoding.UTF8.GetString(byteMsg.data.AsSpan(0, byteMsg.len)));

                if (StartsWithPattern(byteMsg.data.AsSpan(0, byteMsg.len), _subscriptionTypesDictionary["requestGuid"]))
                {
                    var marker =
                        FindSubscriptionTypeMarker(byteMsg,
                            _subscriptionTypesDictionary["requestGuid"], _subscriptionTypesDictionary["_"]);

                    // парсинг ответов от /cws при постановке заявок, возвращается отдельный объект в отдельный обработчик
                    if (marker.Span.SequenceEqual(_subscriptionTypesDictionary["a"]))
                    {
                        if (_wsResponseCommandMessageChangedToUser == null) return;
                        var obj = JsonSerializer.Generic.Utf8.Deserialize<WsResponseCommandMessage>(
                            byteMsg.data.AsSpan(0, byteMsg.len)) with { SocketName = wsName };
                        _wsResponseCommandMessageChangedToUser(obj);

                        if (_logLevel == AlorOpenApiLogLevel.Verbose)
                            _commandLogger.Verbose(Encoding.UTF8.GetString(byteMsg.data.AsSpan(0, byteMsg.len)));
                    }
                    else
                    {
                        //парсинг ответов на обычные подписки через /ws
                        if (_wsResponseMessageChangedToUser == null) return;
                        var obj = JsonSerializer.Generic.Utf8.Deserialize<WsResponseMessage>(
                            byteMsg.data.AsSpan(0, byteMsg.len)) with { SocketName = wsName};
                        _wsResponseMessageChangedToUser(obj);

                        if (_logLevel == AlorOpenApiLogLevel.Verbose)
                        {
                            if (marker.Span.SequenceEqual(_subscriptionTypesDictionary["auth"]))
                                _commandLogger.Verbose(Encoding.UTF8.GetString(byteMsg.data.AsSpan(0, byteMsg.len)));
                            else
                                _logger.Verbose(Encoding.UTF8.GetString(byteMsg.data.AsSpan(0, byteMsg.len)));
                        }
                    }
                }
                else
                {
                    var marker =
                        FindSubscriptionTypeMarker(byteMsg,
                            _subscriptionTypesDictionary["guid"], _subscriptionTypesDictionary["_"]);
                    if (_handlers.TryGetValue(marker, out var handler))
                    {
                        handler(byteMsg);
                    }
                    if (_logLevel == AlorOpenApiLogLevel.Verbose)
                        _logger.Verbose(Encoding.UTF8.GetString(byteMsg.data.AsSpan(0, byteMsg.len)));
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
            }
        }

        public void Dispose()
        {
            _wsResponseMessageChangedToUser = null;
            _wsResponseCommandMessageChangedToUser = null;
            _wsOrderBookSimpleChangedToUser = null;
            _wsOrderBookSlimChangedToUser = null;
            _wsOrderBookHeavyChangedToUser = null;
            _wsCandleSimpleChangedToUser = null;
            _wsCandleSlimChangedToUser = null;
            _wsCandleHeavyChangedToUser = null;
            _wsSymbolSimpleChangedToUser = null;
            _wsSymbolSlimChangedToUser = null;
            _wsSymbolHeavyChangedToUser = null;
            _wsAllTradeSimpleChangedToUser = null;
            _wsAllTradeSlimChangedToUser = null;
            _wsAllTradeHeavyChangedToUser = null;
            _wsPositionSimpleChangedToUser = null;
            _wsPositionSlimChangedToUser = null;
            _wsPositionHeavyChangedToUser = null;
            _wsSummarySimpleChangedToUser = null;
            _wsSummarySlimChangedToUser = null;
            _wsSummaryHeavyChangedToUser = null;
            _wsRiskSimpleChangedToUser = null;
            _wsRiskSlimChangedToUser = null;
            _wsRiskHeavyChangedToUser = null;
            _wsFortsriskSimpleChangedToUser = null;
            _wsFortsriskSlimChangedToUser = null;
            _wsFortsriskHeavyChangedToUser = null;
            _wsTradeSimpleChangedToUser = null;
            _wsTradeSlimChangedToUser = null;
            _wsTradeHeavyChangedToUser = null;
            _wsOrderSimpleChangedToUser = null;
            _wsOrderSlimChangedToUser = null;
            _wsOrderHeavyChangedToUser = null;
            _wsSecurityFromWsSimpleChangedToUser = null;
            _wsSecurityFromWsSlimChangedToUser = null;
            _wsSecurityFromWsHeavyChangedToUser = null;
            _wsStopOrderSimpleChangedToUser = null;
            _wsStopOrderSlimChangedToUser = null;
            _wsStopOrderHeavyChangedToUser = null;
        }

        private void ProcessMessage<T, TU>((byte[] data, int len, DateTime timestamp) byteMsg, Action<T>? handler) where T : class, IWsElement<TU>, new()
            where TU : class
        {
            if (handler == null) return;

            var obj = JsonSerializer.Generic.Utf8.Deserialize<T>(byteMsg.data.AsSpan(0, byteMsg.len));
            if (obj?.Data == null) return;

            obj.ReceivedDateTimeUtc = byteMsg.timestamp;
            obj.Parameters = _parameters;
            handler(obj);
        }

        private static ReadOnlyMemory<byte> FindSubscriptionTypeMarker((byte[] data, int len, DateTime timestamp) byteMsg, byte[] patternStart, byte[] patternEnd)
        {
            var source = new ReadOnlyMemory<byte>(byteMsg.data, 0, byteMsg.len);
            var sourceSpan = source.Span;
            var start = -1;
            var end = -1;

            var searchEndIndex = sourceSpan.Length - patternStart.Length;
            // Поиск начала шаблона
            for (var i = 0; i <= searchEndIndex; ++i)
            {
                var isStartMatch = true;
                for (var j = 0; j < patternStart.Length; ++j)
                {
                    if (sourceSpan[i + j] == patternStart[j]) continue;
                    isStartMatch = false;
                    break;
                }

                if (!isStartMatch) continue;
                start = i + patternStart.Length;
                break;
            }

            if (start != -1)
            {
                searchEndIndex = sourceSpan.Length - patternEnd.Length; // Пересчитываем для поиска конца
                for (var i = start; i <= searchEndIndex; ++i)
                {
                    var isEndMatch = true;
                    for (var j = 0; j < patternEnd.Length; ++j)
                    {
                        if (sourceSpan[i + j] == patternEnd[j]) continue;
                        isEndMatch = false;
                        break;
                    }

                    if (!isEndMatch) continue;
                    end = i; // Уточняем, что end - это начало конечного шаблона
                    break;
                }
            }

            return start != -1 && end != -1 ? source[start..end] : ReadOnlyMemory<byte>.Empty;
        }

        private static bool StartsWithPattern(Span<byte> sourceArray, byte[]? patternArray)
        {
            if (sourceArray == null || patternArray == null || sourceArray.Length < patternArray.Length)
            {
                return false;
            }

            for (var i = 0; i < patternArray.Length; i++)
            {
                if (sourceArray[i] != patternArray[i])
                {
                    return false;
                }
            }

            return true;
        }
    }
}
