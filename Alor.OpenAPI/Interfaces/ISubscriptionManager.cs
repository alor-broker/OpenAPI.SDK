using Alor.OpenAPI.Enums;
using Alor.OpenAPI.Models.Heavy;
using Alor.OpenAPI.Models.Simple;
using Alor.OpenAPI.Models.Slim;

namespace Alor.OpenAPI.Interfaces
{
    public interface ISubscriptionManager : IDisposable
    {
        /// <include file='../XmlDocs/ISubscriptionManager.xml' path='Docs/Members[@name="ISubscriptionManager"]/Member[@name="OrderBookGetAndSubscribeSimpleAsync"]/*' />
        public Task<Dictionary<string, string>> OrderBookGetAndSubscribeSimpleAsync(
            Action<WsOrderBookSimple> orderBookChanged,
            IEnumerable<string?> tickersList,
            Exchange exchange, int depth = 20, string? instrumentGroup = null);

        Action<Action<WsOrderBookSimple>>? UpdateWsMessageHandlerWsOrderBookSimpleDelegat { get; set; }

        /// <include file='../XmlDocs/ISubscriptionManager.xml' path='Docs/Members[@name="ISubscriptionManager"]/Member[@name="OrderBookGetAndSubscribeSlimAsync"]/*' />
        public Task<Dictionary<string, string>> OrderBookGetAndSubscribeSlimAsync(
            Action<WsOrderBookSlim> orderBookChanged,
            IEnumerable<string?> tickersList,
            Exchange exchange, int depth = 20, string? instrumentGroup = null);

        Action<Action<WsOrderBookSlim>>? UpdateWsMessageHandlerWsOrderBookSlimDelegat { get; set; }

        /// <include file='../XmlDocs/ISubscriptionManager.xml' path='Docs/Members[@name="ISubscriptionManager"]/Member[@name="OrderBookGetAndSubscribeHeavyAsync"]/*' />
        public Task<Dictionary<string, string>> OrderBookGetAndSubscribeHeavyAsync(
            Action<WsOrderBookHeavy> orderBookChanged,
            IEnumerable<string?> tickersList,
            Exchange exchange, int depth = 20, string? instrumentGroup = null);

        Action<Action<WsOrderBookHeavy>>? UpdateWsMessageHandlerWsOrderBookHeavyDelegat { get; set; }

        /// <include file='../XmlDocs/ISubscriptionManager.xml' path='Docs/Members[@name="ISubscriptionManager"]/Member[@name="BarsGetAndSubscribeSimpleAsync"]/*' />
        public Task<Dictionary<string, string>> BarsGetAndSubscribeSimpleAsync(Action<WsCandleSimple> candleChanged,
            IEnumerable<string?> tickersList,
            Exchange exchange, string tf, DateTime from, string? instrumentGroup = null, bool skipHistory = false,
            bool? splitAdjust = null, CandleSliceMode sliceMode = CandleSliceMode.DailyIntervals);

        Action<Action<WsCandleSimple>>? UpdateWsMessageHandlerWsCandleSimpleDelegat { get; set; }

        /// <include file='../XmlDocs/ISubscriptionManager.xml' path='Docs/Members[@name="ISubscriptionManager"]/Member[@name="BarsGetAndSubscribeSlimAsync"]/*' />
        public Task<Dictionary<string, string>> BarsGetAndSubscribeSlimAsync(Action<WsCandleSlim> candleChanged,
            IEnumerable<string?> tickersList,
            Exchange exchange, string tf, DateTime from, string? instrumentGroup = null, bool skipHistory = false, 
            bool? splitAdjust = null, CandleSliceMode sliceMode = CandleSliceMode.DailyIntervals);

        Action<Action<WsCandleSlim>>? UpdateWsMessageHandlerWsCandleSlimDelegat { get; set; }

        /// <include file='../XmlDocs/ISubscriptionManager.xml' path='Docs/Members[@name="ISubscriptionManager"]/Member[@name="BarsGetAndSubscribeHeavyAsync"]/*' />
        public Task<Dictionary<string, string>> BarsGetAndSubscribeHeavyAsync(Action<WsCandleHeavy> candleChanged,
            IEnumerable<string?> tickersList,
            Exchange exchange, string tf, DateTime from, string? instrumentGroup = null, bool skipHistory = false,
            bool? splitAdjust = null, CandleSliceMode sliceMode = CandleSliceMode.DailyIntervals);

        Action<Action<WsCandleHeavy>>? UpdateWsMessageHandlerWsCandleHeavyDelegat { get; set; }

        /// <include file='../XmlDocs/ISubscriptionManager.xml' path='Docs/Members[@name="ISubscriptionManager"]/Member[@name="QuotesSubscribeSimpleAsync"]/*' />
        public Task<Dictionary<string, string>> QuotesSubscribeSimpleAsync(Action<WsSymbolSimple> symbolChanged,
            IEnumerable<string?> tickersList, Exchange exchange, string? instrumentGroup = null);

        Action<Action<WsSymbolSimple>>? UpdateWsMessageHandlerWsSymbolSimpleDelegat { get; set; }

        /// <include file='../XmlDocs/ISubscriptionManager.xml' path='Docs/Members[@name="ISubscriptionManager"]/Member[@name="QuotesSubscribeSlimAsync"]/*' />
        public Task<Dictionary<string, string>> QuotesSubscribeSlimAsync(Action<WsSymbolSlim> symbolChanged,
            IEnumerable<string?> tickersList, Exchange exchange, string? instrumentGroup = null);

        Action<Action<WsSymbolSlim>>? UpdateWsMessageHandlerWsSymbolSlimDelegat { get; set; }

        /// <include file='../XmlDocs/ISubscriptionManager.xml' path='Docs/Members[@name="ISubscriptionManager"]/Member[@name="QuotesSubscribeHeavyAsync"]/*' />
        public Task<Dictionary<string, string>> QuotesSubscribeHeavyAsync(Action<WsSymbolHeavy> symbolChanged,
            IEnumerable<string?> tickersList, Exchange exchange, string? instrumentGroup = null);

        Action<Action<WsSymbolHeavy>>? UpdateWsMessageHandlerWsSymbolHeavyDelegat { get; set; }

        /// <include file='../XmlDocs/ISubscriptionManager.xml' path='Docs/Members[@name="ISubscriptionManager"]/Member[@name="AllTradesGetAndSubscribeSimpleAsync"]/*' />
        public Task<Dictionary<string, string>> AllTradesGetAndSubscribeSimpleAsync(
            Action<WsAllTradeSimple> allTradeChanged,
            IEnumerable<string?> tickersList, Exchange exchange, string? instrumentGroup = null, int depth = 0, bool includeVirtualTrades = true);

        Action<Action<WsAllTradeSimple>>? UpdateWsMessageHandlerWsAllTradeSimpleDelegat { get; set; }

        /// <include file='../XmlDocs/ISubscriptionManager.xml' path='Docs/Members[@name="ISubscriptionManager"]/Member[@name="AllTradesGetAndSubscribeSlimAsync"]/*' />
        public Task<Dictionary<string, string>> AllTradesGetAndSubscribeSlimAsync(
            Action<WsAllTradeSlim> allTradeChanged,
            IEnumerable<string?> tickersList, Exchange exchange, string? instrumentGroup = null, int depth = 0, bool includeVirtualTrades = true);

        Action<Action<WsAllTradeSlim>>? UpdateWsMessageHandlerWsAllTradeSlimDelegat { get; set; }

        /// <include file='../XmlDocs/ISubscriptionManager.xml' path='Docs/Members[@name="ISubscriptionManager"]/Member[@name="AllTradesGetAndSubscribeHeavyAsync"]/*' />
        public Task<Dictionary<string, string>> AllTradesGetAndSubscribeHeavyAsync(
            Action<WsAllTradeHeavy> allTradeChanged,
            IEnumerable<string?> tickersList, Exchange exchange, string? instrumentGroup = null, int depth = 0, bool includeVirtualTrades = true);

        Action<Action<WsAllTradeHeavy>>? UpdateWsMessageHandlerWsAllTradeHeavyDelegat { get; set; }

        /// <include file='../XmlDocs/ISubscriptionManager.xml' path='Docs/Members[@name="ISubscriptionManager"]/Member[@name="PositionsGetAndSubscribeV2SimpleAsync"]/*' />
        public Task<string> PositionsGetAndSubscribeV2SimpleAsync(Action<WsPositionSimple> positionChanged,
            Exchange exchange, string portfolio, bool skipHistory = false);

        Action<Action<WsPositionSimple>>? UpdateWsMessageHandlerWsPositionSimpleDelegat { get; set; }

        /// <include file='../XmlDocs/ISubscriptionManager.xml' path='Docs/Members[@name="ISubscriptionManager"]/Member[@name="PositionsGetAndSubscribeV2SlimAsync"]/*' />
        public Task<string> PositionsGetAndSubscribeV2SlimAsync(Action<WsPositionSlim> positionChanged,
            Exchange exchange, string portfolio, bool skipHistory = false);

        Action<Action<WsPositionSlim>>? UpdateWsMessageHandlerWsPositionSlimDelegat { get; set; }

        /// <include file='../XmlDocs/ISubscriptionManager.xml' path='Docs/Members[@name="ISubscriptionManager"]/Member[@name="PositionsGetAndSubscribeV2HeavyAsync"]/*' />
        public Task<string> PositionsGetAndSubscribeV2HeavyAsync(Action<WsPositionHeavy> positionChanged,
            Exchange exchange, string portfolio, bool skipHistory = false);

        Action<Action<WsPositionHeavy>>? UpdateWsMessageHandlerWsPositionHeavyDelegat { get; set; }

        /// <include file='../XmlDocs/ISubscriptionManager.xml' path='Docs/Members[@name="ISubscriptionManager"]/Member[@name="SummariesGetAndSubscribeV2SimpleAsync"]/*' />
        public Task<string> SummariesGetAndSubscribeV2SimpleAsync(Action<WsSummarySimple> summaryChanged,
            Exchange exchange, string portfolio, bool skipHistory = false);

        Action<Action<WsSummarySimple>>? UpdateWsMessageHandlerWsSummarySimpleDelegat { get; set; }

        /// <include file='../XmlDocs/ISubscriptionManager.xml' path='Docs/Members[@name="ISubscriptionManager"]/Member[@name="SummariesGetAndSubscribeV2SlimAsync"]/*' />
        public Task<string> SummariesGetAndSubscribeV2SlimAsync(Action<WsSummarySlim> summaryChanged,
            Exchange exchange, string portfolio, bool skipHistory = false);

        Action<Action<WsSummarySlim>>? UpdateWsMessageHandlerWsSummarySlimDelegat { get; set; }

        /// <include file='../XmlDocs/ISubscriptionManager.xml' path='Docs/Members[@name="ISubscriptionManager"]/Member[@name="SummariesGetAndSubscribeV2HeavyAsync"]/*' />
        public Task<string> SummariesGetAndSubscribeV2HeavyAsync(Action<WsSummaryHeavy> summaryChanged,
            Exchange exchange, string portfolio, bool skipHistory = false);

        Action<Action<WsSummaryHeavy>>? UpdateWsMessageHandlerWsSummaryHeavyDelegat { get; set; }

        /// <include file='../XmlDocs/ISubscriptionManager.xml' path='Docs/Members[@name="ISubscriptionManager"]/Member[@name="RisksGetAndSubscribeSimpleAsync"]/*' />
        public Task<string> RisksGetAndSubscribeSimpleAsync(Action<WsRiskSimple> riskChanged,
            Exchange exchange, string portfolio, bool skipHistory = false);

        Action<Action<WsRiskSimple>>? UpdateWsMessageHandlerWsRiskSimpleDelegat { get; set; }

        /// <include file='../XmlDocs/ISubscriptionManager.xml' path='Docs/Members[@name="ISubscriptionManager"]/Member[@name="RisksGetAndSubscribeSlimAsync"]/*' />
        public Task<string> RisksGetAndSubscribeSlimAsync(Action<WsRiskSlim> riskChanged,
            Exchange exchange, string portfolio, bool skipHistory = false);

        Action<Action<WsRiskSlim>>? UpdateWsMessageHandlerWsRiskSlimDelegat { get; set; }

        /// <include file='../XmlDocs/ISubscriptionManager.xml' path='Docs/Members[@name="ISubscriptionManager"]/Member[@name="RisksGetAndSubscribeHeavyAsync"]/*' />
        public Task<string> RisksGetAndSubscribeHeavyAsync(Action<WsRiskHeavy> riskChanged,
            Exchange exchange, string portfolio, bool skipHistory = false);

        Action<Action<WsRiskHeavy>>? UpdateWsMessageHandlerWsRiskHeavyDelegat { get; set; }

        /// <include file='../XmlDocs/ISubscriptionManager.xml' path='Docs/Members[@name="ISubscriptionManager"]/Member[@name="SpectraRisksGetAndSubscribeSimpleAsync"]/*' />
        public Task<string> SpectraRisksGetAndSubscribeSimpleAsync(Action<WsFortsriskSimple> fortsriskChanged,
            Exchange exchange, string portfolio, bool skipHistory = false);

        Action<Action<WsFortsriskSimple>>? UpdateWsMessageHandlerWsFortsriskSimpleDelegat { get; set; }

        /// <include file='../XmlDocs/ISubscriptionManager.xml' path='Docs/Members[@name="ISubscriptionManager"]/Member[@name="SpectraRisksGetAndSubscribeSlimAsync"]/*' />
        public Task<string> SpectraRisksGetAndSubscribeSlimAsync(Action<WsFortsriskSlim> fortsriskChanged,
            Exchange exchange, string portfolio, bool skipHistory = false);

        Action<Action<WsFortsriskSlim>>? UpdateWsMessageHandlerWsFortsriskSlimDelegat { get; set; }

        /// <include file='../XmlDocs/ISubscriptionManager.xml' path='Docs/Members[@name="ISubscriptionManager"]/Member[@name="SpectraRisksGetAndSubscribeHeavyAsync"]/*' />
        public Task<string> SpectraRisksGetAndSubscribeHeavyAsync(Action<WsFortsriskHeavy> fortsriskChanged,
            Exchange exchange, string portfolio, bool skipHistory = false);

        Action<Action<WsFortsriskHeavy>>? UpdateWsMessageHandlerWsFortsriskHeavyDelegat { get; set; }

        /// <include file='../XmlDocs/ISubscriptionManager.xml' path='Docs/Members[@name="ISubscriptionManager"]/Member[@name="TradesGetAndSubscribeV2SimpleAsync"]/*' />
        public Task<string> TradesGetAndSubscribeV2SimpleAsync(Action<WsTradeSimple> tradeChanged,
            Exchange exchange, string portfolio, bool skipHistory = false);

        Action<Action<WsTradeSimple>>? UpdateWsMessageHandlerWsTradeSimpleDelegat { get; set; }

        /// <include file='../XmlDocs/ISubscriptionManager.xml' path='Docs/Members[@name="ISubscriptionManager"]/Member[@name="TradesGetAndSubscribeV2SlimAsync"]/*' />
        public Task<string> TradesGetAndSubscribeV2SlimAsync(Action<WsTradeSlim> tradeChanged,
            Exchange exchange, string portfolio, bool skipHistory = false);

        Action<Action<WsTradeSlim>>? UpdateWsMessageHandlerWsTradeSlimDelegat { get; set; }

        /// <include file='../XmlDocs/ISubscriptionManager.xml' path='Docs/Members[@name="ISubscriptionManager"]/Member[@name="TradesGetAndSubscribeV2HeavyAsync"]/*' />
        public Task<string> TradesGetAndSubscribeV2HeavyAsync(Action<WsTradeHeavy> tradeChanged,
            Exchange exchange, string portfolio, bool skipHistory = false);

        Action<Action<WsTradeHeavy>>? UpdateWsMessageHandlerWsTradeHeavyDelegat { get; set; }

        /// <include file='../XmlDocs/ISubscriptionManager.xml' path='Docs/Members[@name="ISubscriptionManager"]/Member[@name="OrdersGetAndSubscribeV2SimpleAsync"]/*' />
        public Task<string> OrdersGetAndSubscribeV2SimpleAsync(Action<WsOrderSimple> orderChanged,
            Exchange exchange, string portfolio, List<OrderStatus>? orderStatuses = null, bool skipHistory = false);

        Action<Action<WsOrderSimple>>? UpdateWsMessageHandlerWsOrderSimpleDelegat { get; set; }

        /// <include file='../XmlDocs/ISubscriptionManager.xml' path='Docs/Members[@name="ISubscriptionManager"]/Member[@name="OrdersGetAndSubscribeV2SlimAsync"]/*' />
        public Task<string> OrdersGetAndSubscribeV2SlimAsync(Action<WsOrderSlim> orderChanged,
            Exchange exchange, string portfolio, List<OrderStatus>? orderStatuses = null, bool skipHistory = false);

        Action<Action<WsOrderSlim>>? UpdateWsMessageHandlerWsOrderSlimDelegat { get; set; }

        /// <include file='../XmlDocs/ISubscriptionManager.xml' path='Docs/Members[@name="ISubscriptionManager"]/Member[@name="OrdersGetAndSubscribeV2HeavyAsync"]/*' />
        public Task<string> OrdersGetAndSubscribeV2HeavyAsync(Action<WsOrderHeavy> orderChanged,
            Exchange exchange, string portfolio, List<OrderStatus>? orderStatuses = null, bool skipHistory = false);

        Action<Action<WsOrderHeavy>>? UpdateWsMessageHandlerWsOrderHeavyDelegat { get; set; }

        /// <include file='../XmlDocs/ISubscriptionManager.xml' path='Docs/Members[@name="ISubscriptionManager"]/Member[@name="InstrumentsGetAndSubscribeV2SimpleAsync"]/*' />
        public Task<Dictionary<string, string>> InstrumentsGetAndSubscribeV2SimpleAsync(
            Action<WsSecurityFromWsSimple> securityFromWsChanged, IEnumerable<string?> tickersList, Exchange exchange, string? instrumentGroup = null);

        Action<Action<WsSecurityFromWsSimple>>? UpdateWsMessageHandlerWsSecurityFromWsSimpleDelegat { get; set; }

        /// <include file='../XmlDocs/ISubscriptionManager.xml' path='Docs/Members[@name="ISubscriptionManager"]/Member[@name="InstrumentsGetAndSubscribeV2SlimAsync"]/*' />
        public Task<Dictionary<string, string>> InstrumentsGetAndSubscribeV2SlimAsync(
            Action<WsSecurityFromWsSlim> securityFromWsChanged, IEnumerable<string?> tickersList, Exchange exchange, string? instrumentGroup = null);

        Action<Action<WsSecurityFromWsSlim>>? UpdateWsMessageHandlerWsSecurityFromWsSlimDelegat { get; set; }

        /// <include file='../XmlDocs/ISubscriptionManager.xml' path='Docs/Members[@name="ISubscriptionManager"]/Member[@name="InstrumentsGetAndSubscribeV2HeavyAsync"]/*' />
        public Task<Dictionary<string, string>> InstrumentsGetAndSubscribeV2HeavyAsync(
            Action<WsSecurityFromWsHeavy> securityFromWsChanged, IEnumerable<string?> tickersList, Exchange exchange, string? instrumentGroup = null);

        Action<Action<WsSecurityFromWsHeavy>>? UpdateWsMessageHandlerWsSecurityFromWsHeavyDelegat { get; set; }

        /// <include file='../XmlDocs/ISubscriptionManager.xml' path='Docs/Members[@name="ISubscriptionManager"]/Member[@name="StopOrdersGetAndSubscribeV2SimpleAsync"]/*' />
        public Task<string> StopOrdersGetAndSubscribeV2SimpleAsync(Action<WsStopOrderSimple> stopOrderChanged,
            Exchange exchange, string portfolio, List<OrderStatus>? orderStatuses = null, bool skipHistory = false);
        Action<Action<WsStopOrderSimple>>? UpdateWsMessageHandlerWsStopOrderSimpleDelegat { get; set; }

        /// <include file='../XmlDocs/ISubscriptionManager.xml' path='Docs/Members[@name="ISubscriptionManager"]/Member[@name="StopOrdersGetAndSubscribeV2SlimAsync"]/*' />
        public Task<string> StopOrdersGetAndSubscribeV2SlimAsync(Action<WsStopOrderSlim> stopOrderChanged,
            Exchange exchange, string portfolio, List<OrderStatus>? orderStatuses = null, bool skipHistory = false);
        Action<Action<WsStopOrderSlim>>? UpdateWsMessageHandlerWsStopOrderSlimDelegat { get; set; }

        /// <include file='../XmlDocs/ISubscriptionManager.xml' path='Docs/Members[@name="ISubscriptionManager"]/Member[@name="StopOrdersGetAndSubscribeV2HeavyAsync"]/*' />
        public Task<string> StopOrdersGetAndSubscribeV2HeavyAsync(Action<WsStopOrderHeavy> stopOrderChanged,
            Exchange exchange, string portfolio, List<OrderStatus>? orderStatuses = null, bool skipHistory = false);
        Action<Action<WsStopOrderHeavy>>? UpdateWsMessageHandlerWsStopOrderHeavyDelegat { get; set; }

        /// <include file='../XmlDocs/ISubscriptionManager.xml' path='Docs/Members[@name="ISubscriptionManager"]/Member[@name="UnsubscribeAsync"]/*' />
        public Task UnsubscribeAsync(IEnumerable<string> guids);

    }
}
