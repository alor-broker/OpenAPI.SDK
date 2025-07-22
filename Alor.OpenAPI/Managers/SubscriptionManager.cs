using Alor.OpenAPI.Enums;
using Alor.OpenAPI.Extensions;
using Alor.OpenAPI.Interfaces;
using Alor.OpenAPI.Models;
using Alor.OpenAPI.Models.Heavy;
using Alor.OpenAPI.Models.Simple;
using Alor.OpenAPI.Models.Slim;
using System.Collections.Concurrent;

namespace Alor.OpenAPI.Managers
{
    public class SubscriptionManager : ISubscriptionManager
    {
        public Action<Action<WsOrderBookSimple>>? UpdateWsMessageHandlerWsOrderBookSimpleDelegat { get; set; }
        public Action<Action<WsOrderBookSlim>>? UpdateWsMessageHandlerWsOrderBookSlimDelegat { get; set; }
        public Action<Action<WsOrderBookHeavy>>? UpdateWsMessageHandlerWsOrderBookHeavyDelegat { get; set; }
        public Action<Action<WsCandleSimple>>? UpdateWsMessageHandlerWsCandleSimpleDelegat { get; set; }
        public Action<Action<WsCandleSlim>>? UpdateWsMessageHandlerWsCandleSlimDelegat { get; set; }
        public Action<Action<WsCandleHeavy>>? UpdateWsMessageHandlerWsCandleHeavyDelegat { get; set; }
        public Action<Action<WsSymbolSimple>>? UpdateWsMessageHandlerWsSymbolSimpleDelegat { get; set; }
        public Action<Action<WsSymbolSlim>>? UpdateWsMessageHandlerWsSymbolSlimDelegat { get; set; }
        public Action<Action<WsSymbolHeavy>>? UpdateWsMessageHandlerWsSymbolHeavyDelegat { get; set; }
        public Action<Action<WsAllTradeSimple>>? UpdateWsMessageHandlerWsAllTradeSimpleDelegat { get; set; }
        public Action<Action<WsAllTradeSlim>>? UpdateWsMessageHandlerWsAllTradeSlimDelegat { get; set; }
        public Action<Action<WsAllTradeHeavy>>? UpdateWsMessageHandlerWsAllTradeHeavyDelegat { get; set; }
        public Action<Action<WsPositionSimple>>? UpdateWsMessageHandlerWsPositionSimpleDelegat { get; set; }
        public Action<Action<WsPositionSlim>>? UpdateWsMessageHandlerWsPositionSlimDelegat { get; set; }
        public Action<Action<WsPositionHeavy>>? UpdateWsMessageHandlerWsPositionHeavyDelegat { get; set; }
        public Action<Action<WsSummarySimple>>? UpdateWsMessageHandlerWsSummarySimpleDelegat { get; set; }
        public Action<Action<WsSummarySlim>>? UpdateWsMessageHandlerWsSummarySlimDelegat { get; set; }
        public Action<Action<WsSummaryHeavy>>? UpdateWsMessageHandlerWsSummaryHeavyDelegat { get; set; }
        public Action<Action<WsRiskSimple>>? UpdateWsMessageHandlerWsRiskSimpleDelegat { get; set; }
        public Action<Action<WsRiskSlim>>? UpdateWsMessageHandlerWsRiskSlimDelegat { get; set; }
        public Action<Action<WsRiskHeavy>>? UpdateWsMessageHandlerWsRiskHeavyDelegat { get; set; }
        public Action<Action<WsFortsriskSimple>>? UpdateWsMessageHandlerWsFortsriskSimpleDelegat { get; set; }
        public Action<Action<WsFortsriskSlim>>? UpdateWsMessageHandlerWsFortsriskSlimDelegat { get; set; }
        public Action<Action<WsFortsriskHeavy>>? UpdateWsMessageHandlerWsFortsriskHeavyDelegat { get; set; }
        public Action<Action<WsTradeSimple>>? UpdateWsMessageHandlerWsTradeSimpleDelegat { get; set; }
        public Action<Action<WsTradeSlim>>? UpdateWsMessageHandlerWsTradeSlimDelegat { get; set; }
        public Action<Action<WsTradeHeavy>>? UpdateWsMessageHandlerWsTradeHeavyDelegat { get; set; }
        public Action<Action<WsOrderSimple>>? UpdateWsMessageHandlerWsOrderSimpleDelegat { get; set; }
        public Action<Action<WsOrderSlim>>? UpdateWsMessageHandlerWsOrderSlimDelegat { get; set; }
        public Action<Action<WsOrderHeavy>>? UpdateWsMessageHandlerWsOrderHeavyDelegat { get; set; }
        public Action<Action<WsSecurityFromWsSimple>>? UpdateWsMessageHandlerWsSecurityFromWsSimpleDelegat { get; set; }
        public Action<Action<WsSecurityFromWsSlim>>? UpdateWsMessageHandlerWsSecurityFromWsSlimDelegat { get; set; }
        public Action<Action<WsSecurityFromWsHeavy>>? UpdateWsMessageHandlerWsSecurityFromWsHeavyDelegat { get; set; }
        public Action<Action<WsStopOrderSimple>>? UpdateWsMessageHandlerWsStopOrderSimpleDelegat { get; set; }
        public Action<Action<WsStopOrderSlim>>? UpdateWsMessageHandlerWsStopOrderSlimDelegat { get; set; }
        public Action<Action<WsStopOrderHeavy>>? UpdateWsMessageHandlerWsStopOrderHeavyDelegat { get; set; }

        private long _guidCounter;
        private readonly ConcurrentDictionary<string, Parameters> _parameters;
        private Func<Dictionary<string, string>, Task<bool[]>>? _msgDictionaryUpdate;
        private Func<Dictionary<string, string>, Task<bool[]>>? _msgDeleteRequest;

        internal SubscriptionManager(ConcurrentDictionary<string, Parameters> parameters,
            Func<Dictionary<string, string>, Task<bool[]>> msgDictionaryUpdate,
            Func<Dictionary<string, string>, Task<bool[]>> msgDeleteRequest,
            Action<Action<WsOrderBookSimple>> updateWsMessageHandlerWsOrderBookDelegat,
            Action<Action<WsOrderBookSlim>> updateWsMessageHandlerWsOrderBookSlimDelegat,
            Action<Action<WsOrderBookHeavy>> updateWsMessageHandlerWsOrderBookHeavyDelegat,
            Action<Action<WsCandleSimple>> updateWsMessageHandlerWsCandleSimpleDelegat,
            Action<Action<WsCandleSlim>> updateWsMessageHandlerWsCandleSlimDelegat,
            Action<Action<WsCandleHeavy>> updateWsMessageHandlerWsCandleHeavyDelegat,
            Action<Action<WsSymbolSimple>> updateWsMessageHandlerWsSymbolSimpleDelegat,
            Action<Action<WsSymbolSlim>> updateWsMessageHandlerWsSymbolSlimDelegat,
            Action<Action<WsSymbolHeavy>> updateWsMessageHandlerWsSymbolHeavyDelegat,
            Action<Action<WsAllTradeSimple>> updateWsMessageHandlerWsAllTradeSimpleDelegat,
            Action<Action<WsAllTradeSlim>> updateWsMessageHandlerWsAllTradeSlimDelegat,
            Action<Action<WsAllTradeHeavy>> updateWsMessageHandlerWsAllTradeHeavyDelegat,
            Action<Action<WsPositionSimple>> updateWsMessageHandlerWsPositionSimpleDelegat,
            Action<Action<WsPositionSlim>> updateWsMessageHandlerWsPositionSlimDelegat,
            Action<Action<WsPositionHeavy>> updateWsMessageHandlerWsPositionHeavyDelegat,
            Action<Action<WsSummarySimple>> updateWsMessageHandlerWsSummarySimpleDelegat,
            Action<Action<WsSummarySlim>> updateWsMessageHandlerWsSummarySlimDelegat,
            Action<Action<WsSummaryHeavy>> updateWsMessageHandlerWsSummaryHeavyDelegat,
            Action<Action<WsRiskSimple>> updateWsMessageHandlerWsRiskSimpleDelegat,
            Action<Action<WsRiskSlim>> updateWsMessageHandlerWsRiskSlimDelegat,
            Action<Action<WsRiskHeavy>> updateWsMessageHandlerWsRiskHeavyDelegat,
            Action<Action<WsFortsriskSimple>> updateWsMessageHandlerWsFortsriskSimpleDelegat,
            Action<Action<WsFortsriskSlim>> updateWsMessageHandlerWsFortsriskSlimDelegat,
            Action<Action<WsFortsriskHeavy>> updateWsMessageHandlerWsFortsriskHeavyDelegat,
            Action<Action<WsTradeSimple>> updateWsMessageHandlerWsTradeSimpleDelegat,
            Action<Action<WsTradeSlim>> updateWsMessageHandlerWsTradeSlimDelegat,
            Action<Action<WsTradeHeavy>> updateWsMessageHandlerWsTradeHeavyDelegat,
            Action<Action<WsOrderSimple>> updateWsMessageHandlerWsOrderSimpleDelegat,
            Action<Action<WsOrderSlim>> updateWsMessageHandlerWsOrderSlimDelegat,
            Action<Action<WsOrderHeavy>> updateWsMessageHandlerWsOrderHeavyDelegat,
            Action<Action<WsSecurityFromWsSimple>> updateWsMessageHandlerWsSecurityFromWsSimpleDelegat,
            Action<Action<WsSecurityFromWsSlim>> updateWsMessageHandlerWsSecurityFromWsSlimDelegat,
            Action<Action<WsSecurityFromWsHeavy>> updateWsMessageHandlerWsSecurityFromWsHeavyDelegat,
            Action<Action<WsStopOrderSimple>> updateWsMessageHandlerWsStopOrderSimpleDelegat,
            Action<Action<WsStopOrderSlim>> updateWsMessageHandlerWsStopOrderSlimDelegat,
            Action<Action<WsStopOrderHeavy>> updateWsMessageHandlerWsStopOrderHeavyDelegat)
        {
            _parameters = parameters;
            _msgDictionaryUpdate = msgDictionaryUpdate;
            _msgDeleteRequest = msgDeleteRequest;
            UpdateWsMessageHandlerWsOrderBookSimpleDelegat = updateWsMessageHandlerWsOrderBookDelegat;
            UpdateWsMessageHandlerWsOrderBookSlimDelegat = updateWsMessageHandlerWsOrderBookSlimDelegat;
            UpdateWsMessageHandlerWsOrderBookHeavyDelegat = updateWsMessageHandlerWsOrderBookHeavyDelegat;
            UpdateWsMessageHandlerWsCandleSimpleDelegat = updateWsMessageHandlerWsCandleSimpleDelegat;
            UpdateWsMessageHandlerWsCandleSlimDelegat = updateWsMessageHandlerWsCandleSlimDelegat;
            UpdateWsMessageHandlerWsCandleHeavyDelegat = updateWsMessageHandlerWsCandleHeavyDelegat;
            UpdateWsMessageHandlerWsSymbolSimpleDelegat = updateWsMessageHandlerWsSymbolSimpleDelegat;
            UpdateWsMessageHandlerWsSymbolSlimDelegat = updateWsMessageHandlerWsSymbolSlimDelegat;
            UpdateWsMessageHandlerWsSymbolHeavyDelegat = updateWsMessageHandlerWsSymbolHeavyDelegat;
            UpdateWsMessageHandlerWsAllTradeSimpleDelegat = updateWsMessageHandlerWsAllTradeSimpleDelegat;
            UpdateWsMessageHandlerWsAllTradeSlimDelegat = updateWsMessageHandlerWsAllTradeSlimDelegat;
            UpdateWsMessageHandlerWsAllTradeHeavyDelegat = updateWsMessageHandlerWsAllTradeHeavyDelegat;
            UpdateWsMessageHandlerWsPositionSimpleDelegat = updateWsMessageHandlerWsPositionSimpleDelegat;
            UpdateWsMessageHandlerWsPositionSlimDelegat = updateWsMessageHandlerWsPositionSlimDelegat;
            UpdateWsMessageHandlerWsPositionHeavyDelegat = updateWsMessageHandlerWsPositionHeavyDelegat;
            UpdateWsMessageHandlerWsSummarySimpleDelegat = updateWsMessageHandlerWsSummarySimpleDelegat;
            UpdateWsMessageHandlerWsSummarySlimDelegat = updateWsMessageHandlerWsSummarySlimDelegat;
            UpdateWsMessageHandlerWsSummaryHeavyDelegat = updateWsMessageHandlerWsSummaryHeavyDelegat;
            UpdateWsMessageHandlerWsRiskSimpleDelegat = updateWsMessageHandlerWsRiskSimpleDelegat;
            UpdateWsMessageHandlerWsRiskSlimDelegat = updateWsMessageHandlerWsRiskSlimDelegat;
            UpdateWsMessageHandlerWsRiskHeavyDelegat = updateWsMessageHandlerWsRiskHeavyDelegat;
            UpdateWsMessageHandlerWsFortsriskSimpleDelegat = updateWsMessageHandlerWsFortsriskSimpleDelegat;
            UpdateWsMessageHandlerWsFortsriskSlimDelegat = updateWsMessageHandlerWsFortsriskSlimDelegat;
            UpdateWsMessageHandlerWsFortsriskHeavyDelegat = updateWsMessageHandlerWsFortsriskHeavyDelegat;
            UpdateWsMessageHandlerWsTradeSimpleDelegat = updateWsMessageHandlerWsTradeSimpleDelegat;
            UpdateWsMessageHandlerWsTradeSlimDelegat = updateWsMessageHandlerWsTradeSlimDelegat;
            UpdateWsMessageHandlerWsTradeHeavyDelegat = updateWsMessageHandlerWsTradeHeavyDelegat;
            UpdateWsMessageHandlerWsOrderSimpleDelegat = updateWsMessageHandlerWsOrderSimpleDelegat;
            UpdateWsMessageHandlerWsOrderSlimDelegat = updateWsMessageHandlerWsOrderSlimDelegat;
            UpdateWsMessageHandlerWsOrderHeavyDelegat = updateWsMessageHandlerWsOrderHeavyDelegat;
            UpdateWsMessageHandlerWsSecurityFromWsSimpleDelegat = updateWsMessageHandlerWsSecurityFromWsSimpleDelegat;
            UpdateWsMessageHandlerWsSecurityFromWsSlimDelegat = updateWsMessageHandlerWsSecurityFromWsSlimDelegat;
            UpdateWsMessageHandlerWsSecurityFromWsHeavyDelegat = updateWsMessageHandlerWsSecurityFromWsHeavyDelegat;
            UpdateWsMessageHandlerWsStopOrderSimpleDelegat = updateWsMessageHandlerWsStopOrderSimpleDelegat;
            UpdateWsMessageHandlerWsStopOrderSlimDelegat = updateWsMessageHandlerWsStopOrderSlimDelegat;
            UpdateWsMessageHandlerWsStopOrderHeavyDelegat = updateWsMessageHandlerWsStopOrderHeavyDelegat;
        }

        #region Subscriptions Headers
        public Task<Dictionary<string, string>> OrderBookGetAndSubscribeSimpleAsync(
            Action<WsOrderBookSimple> orderBookChanged,
            IEnumerable<string?> tickersList,
            Exchange exchange, int depth = 20, string? instrumentGroup = null)
        {
            ArgumentNullException.ThrowIfNull(orderBookChanged);
            ArgumentNullException.ThrowIfNull(tickersList);

            UpdateWsMessageHandlerWsOrderBookSimpleDelegat?.Invoke(orderBookChanged);
            return OrderBookGetAndSubscribeAsync(Format.Simple, tickersList, exchange, depth, instrumentGroup);
        }

        public Task<Dictionary<string, string>> OrderBookGetAndSubscribeSlimAsync(
            Action<WsOrderBookSlim> orderBookChanged,
            IEnumerable<string?> tickersList,
            Exchange exchange, int depth = 20, string? instrumentGroup = null)
        {
            ArgumentNullException.ThrowIfNull(orderBookChanged);
            ArgumentNullException.ThrowIfNull(tickersList);

            UpdateWsMessageHandlerWsOrderBookSlimDelegat?.Invoke(orderBookChanged);
            return OrderBookGetAndSubscribeAsync(Format.Slim, tickersList, exchange, depth, instrumentGroup);
        }

        public Task<Dictionary<string, string>> OrderBookGetAndSubscribeHeavyAsync(
            Action<WsOrderBookHeavy> orderBookChanged,
            IEnumerable<string?> tickersList,
            Exchange exchange, int depth = 20, string? instrumentGroup = null)
        {
            ArgumentNullException.ThrowIfNull(orderBookChanged);
            ArgumentNullException.ThrowIfNull(tickersList);

            UpdateWsMessageHandlerWsOrderBookHeavyDelegat?.Invoke(orderBookChanged);
            return OrderBookGetAndSubscribeAsync(Format.Heavy, tickersList, exchange, depth, instrumentGroup);
        }

        public Task<Dictionary<string, string>> BarsGetAndSubscribeSimpleAsync(Action<WsCandleSimple> candleChanged,
            IEnumerable<string?> tickersList,
            Exchange exchange, string tf, DateTime from, string? instrumentGroup = null, bool skipHistory = false,
            bool? splitAdjust = null, CandleSliceMode sliceMode = CandleSliceMode.DailyIntervals)
        {
            ArgumentNullException.ThrowIfNull(candleChanged);
            ArgumentNullException.ThrowIfNull(tickersList);

            UpdateWsMessageHandlerWsCandleSimpleDelegat?.Invoke(candleChanged);
            return BarsGetAndSubscribeAsync(Format.Simple, tickersList, exchange, tf, from, instrumentGroup, skipHistory, splitAdjust, sliceMode);
        }

        public Task<Dictionary<string, string>> BarsGetAndSubscribeSlimAsync(Action<WsCandleSlim> candleChanged,
            IEnumerable<string?> tickersList,
            Exchange exchange, string tf, DateTime from, string? instrumentGroup = null, bool skipHistory = false,
            bool? splitAdjust = null, CandleSliceMode sliceMode = CandleSliceMode.DailyIntervals)
        {
            ArgumentNullException.ThrowIfNull(candleChanged);
            ArgumentNullException.ThrowIfNull(tickersList);

            UpdateWsMessageHandlerWsCandleSlimDelegat?.Invoke(candleChanged);
            return BarsGetAndSubscribeAsync(Format.Slim, tickersList, exchange, tf, from, instrumentGroup, skipHistory, splitAdjust, sliceMode);
        }

        public Task<Dictionary<string, string>> BarsGetAndSubscribeHeavyAsync(Action<WsCandleHeavy> candleChanged,
            IEnumerable<string?> tickersList,
            Exchange exchange, string tf, DateTime from, string? instrumentGroup = null, bool skipHistory = false,
            bool? splitAdjust = null, CandleSliceMode sliceMode = CandleSliceMode.DailyIntervals)
        {
            ArgumentNullException.ThrowIfNull(candleChanged);
            ArgumentNullException.ThrowIfNull(tickersList);

            UpdateWsMessageHandlerWsCandleHeavyDelegat?.Invoke(candleChanged);
            return BarsGetAndSubscribeAsync(Format.Heavy, tickersList, exchange, tf, from, instrumentGroup, skipHistory, splitAdjust, sliceMode);
        }

        public Task<Dictionary<string, string>> QuotesSubscribeSimpleAsync(Action<WsSymbolSimple> symbolChanged,
            IEnumerable<string?> tickersList, Exchange exchange, string? instrumentGroup = null)
        {
            ArgumentNullException.ThrowIfNull(symbolChanged);
            ArgumentNullException.ThrowIfNull(tickersList);

            UpdateWsMessageHandlerWsSymbolSimpleDelegat?.Invoke(symbolChanged);
            return QuotesSubscribeAsync(Format.Simple, tickersList, exchange, instrumentGroup);
        }

        public Task<Dictionary<string, string>> QuotesSubscribeSlimAsync(Action<WsSymbolSlim> symbolChanged,
            IEnumerable<string?> tickersList, Exchange exchange, string? instrumentGroup = null)
        {
            ArgumentNullException.ThrowIfNull(symbolChanged);
            ArgumentNullException.ThrowIfNull(tickersList);

            UpdateWsMessageHandlerWsSymbolSlimDelegat?.Invoke(symbolChanged);
            return QuotesSubscribeAsync(Format.Slim, tickersList, exchange, instrumentGroup);
        }

        public Task<Dictionary<string, string>> QuotesSubscribeHeavyAsync(Action<WsSymbolHeavy> symbolChanged,
            IEnumerable<string?> tickersList, Exchange exchange, string? instrumentGroup = null)
        {
            ArgumentNullException.ThrowIfNull(symbolChanged);
            ArgumentNullException.ThrowIfNull(tickersList);

            UpdateWsMessageHandlerWsSymbolHeavyDelegat?.Invoke(symbolChanged);
            return QuotesSubscribeAsync(Format.Heavy, tickersList, exchange, instrumentGroup);
        }

        public Task<Dictionary<string, string>> AllTradesGetAndSubscribeSimpleAsync(
            Action<WsAllTradeSimple> allTradeChanged,
            IEnumerable<string?> tickersList, Exchange exchange, string? instrumentGroup = null, int depth = 0, bool includeVirtualTrades = true)
        {
            ArgumentNullException.ThrowIfNull(allTradeChanged);
            ArgumentNullException.ThrowIfNull(tickersList);

            UpdateWsMessageHandlerWsAllTradeSimpleDelegat?.Invoke(allTradeChanged);
            return AllTradesGetAndSubscribeAsync(Format.Simple, tickersList, exchange, depth, includeVirtualTrades, instrumentGroup);
        }

        public Task<Dictionary<string, string>> AllTradesGetAndSubscribeSlimAsync(
            Action<WsAllTradeSlim> allTradeChanged,
            IEnumerable<string?> tickersList, Exchange exchange, string? instrumentGroup = null, int depth = 0, bool includeVirtualTrades = true)
        {
            ArgumentNullException.ThrowIfNull(allTradeChanged);
            ArgumentNullException.ThrowIfNull(tickersList);

            UpdateWsMessageHandlerWsAllTradeSlimDelegat?.Invoke(allTradeChanged);
            return AllTradesGetAndSubscribeAsync(Format.Slim, tickersList, exchange, depth, includeVirtualTrades, instrumentGroup);
        }

        public Task<Dictionary<string, string>> AllTradesGetAndSubscribeHeavyAsync(
            Action<WsAllTradeHeavy> allTradeChanged,
            IEnumerable<string?> tickersList, Exchange exchange, string? instrumentGroup = null, int depth = 0, bool includeVirtualTrades = true)
        {
            ArgumentNullException.ThrowIfNull(allTradeChanged);
            ArgumentNullException.ThrowIfNull(tickersList);

            UpdateWsMessageHandlerWsAllTradeHeavyDelegat?.Invoke(allTradeChanged);
            return AllTradesGetAndSubscribeAsync(Format.Heavy, tickersList, exchange, depth, includeVirtualTrades, instrumentGroup);
        }

        public Task<string> PositionsGetAndSubscribeV2SimpleAsync(Action<WsPositionSimple> positionChanged,
            Exchange exchange, string portfolio, bool skipHistory = false)
        {
            ArgumentNullException.ThrowIfNull(positionChanged);

            UpdateWsMessageHandlerWsPositionSimpleDelegat?.Invoke(positionChanged);
            return PositionsGetAndSubscribeV2Async(Format.Simple, exchange, portfolio, skipHistory);
        }

        public Task<string> PositionsGetAndSubscribeV2SlimAsync(Action<WsPositionSlim> positionChanged,
            Exchange exchange, string portfolio, bool skipHistory = false)
        {
            ArgumentNullException.ThrowIfNull(positionChanged);
            
            UpdateWsMessageHandlerWsPositionSlimDelegat?.Invoke(positionChanged);
            return PositionsGetAndSubscribeV2Async(Format.Slim, exchange, portfolio, skipHistory);
        }

        public Task<string> PositionsGetAndSubscribeV2HeavyAsync(Action<WsPositionHeavy> positionChanged,
            Exchange exchange, string portfolio, bool skipHistory = false)
        {
            ArgumentNullException.ThrowIfNull(positionChanged);

            UpdateWsMessageHandlerWsPositionHeavyDelegat?.Invoke(positionChanged);
            return PositionsGetAndSubscribeV2Async(Format.Heavy, exchange, portfolio, skipHistory);
        }

        public Task<string> SummariesGetAndSubscribeV2SimpleAsync(Action<WsSummarySimple> summaryChanged,
            Exchange exchange, string portfolio, bool skipHistory = false)
        {
            UpdateWsMessageHandlerWsSummarySimpleDelegat?.Invoke(summaryChanged);
            return SummariesGetAndSubscribeV2Async(Format.Simple, exchange, portfolio, skipHistory);
        }

        public Task<string> SummariesGetAndSubscribeV2SlimAsync(Action<WsSummarySlim> summaryChanged,
            Exchange exchange, string portfolio, bool skipHistory = false)
        {
            ArgumentNullException.ThrowIfNull(summaryChanged);
            
            UpdateWsMessageHandlerWsSummarySlimDelegat?.Invoke(summaryChanged);
            return SummariesGetAndSubscribeV2Async(Format.Slim, exchange, portfolio, skipHistory);
        }

        public Task<string> SummariesGetAndSubscribeV2HeavyAsync(Action<WsSummaryHeavy> summaryChanged,
            Exchange exchange, string portfolio, bool skipHistory = false)
        {
            ArgumentNullException.ThrowIfNull(summaryChanged);

            UpdateWsMessageHandlerWsSummaryHeavyDelegat?.Invoke(summaryChanged);
            return SummariesGetAndSubscribeV2Async(Format.Heavy, exchange, portfolio, skipHistory);
        }

        public Task<string> RisksGetAndSubscribeSimpleAsync(Action<WsRiskSimple> riskChanged,
            Exchange exchange, string portfolio, bool skipHistory = false)
        {
            ArgumentNullException.ThrowIfNull(riskChanged);

            UpdateWsMessageHandlerWsRiskSimpleDelegat?.Invoke(riskChanged);
            return RisksGetAndSubscribeAsync(Format.Simple, exchange, portfolio, skipHistory);
        }

        public Task<string> RisksGetAndSubscribeSlimAsync(Action<WsRiskSlim> riskChanged,
            Exchange exchange, string portfolio, bool skipHistory = false)
        {
            ArgumentNullException.ThrowIfNull(riskChanged);

            UpdateWsMessageHandlerWsRiskSlimDelegat?.Invoke(riskChanged);
            return RisksGetAndSubscribeAsync(Format.Slim, exchange, portfolio, skipHistory);
        }

        public Task<string> RisksGetAndSubscribeHeavyAsync(Action<WsRiskHeavy> riskChanged,
            Exchange exchange, string portfolio, bool skipHistory = false)
        {
            ArgumentNullException.ThrowIfNull(riskChanged);

            UpdateWsMessageHandlerWsRiskHeavyDelegat?.Invoke(riskChanged);
            return RisksGetAndSubscribeAsync(Format.Heavy, exchange, portfolio, skipHistory);
        }

        public Task<string> SpectraRisksGetAndSubscribeSimpleAsync(Action<WsFortsriskSimple> fortsriskChanged,
            Exchange exchange, string portfolio, bool skipHistory = false)
        {
            ArgumentNullException.ThrowIfNull(fortsriskChanged);

            UpdateWsMessageHandlerWsFortsriskSimpleDelegat?.Invoke(fortsriskChanged);
            return SpectraRisksGetAndSubscribeAsync(Format.Simple, exchange, portfolio, skipHistory);
        }

        public Task<string> SpectraRisksGetAndSubscribeSlimAsync(Action<WsFortsriskSlim> fortsriskChanged,
            Exchange exchange, string portfolio, bool skipHistory = false)
        {
            ArgumentNullException.ThrowIfNull(fortsriskChanged);

            UpdateWsMessageHandlerWsFortsriskSlimDelegat?.Invoke(fortsriskChanged);
            return SpectraRisksGetAndSubscribeAsync(Format.Slim, exchange, portfolio, skipHistory);
        }

        public Task<string> SpectraRisksGetAndSubscribeHeavyAsync(Action<WsFortsriskHeavy> fortsriskChanged,
            Exchange exchange, string portfolio, bool skipHistory = false)
        {
            ArgumentNullException.ThrowIfNull(fortsriskChanged);

            UpdateWsMessageHandlerWsFortsriskHeavyDelegat?.Invoke(fortsriskChanged);
            return SpectraRisksGetAndSubscribeAsync(Format.Heavy, exchange, portfolio, skipHistory);
        }

        public Task<string> TradesGetAndSubscribeV2SimpleAsync(Action<WsTradeSimple> tradeChanged,
            Exchange exchange, string portfolio, bool skipHistory = false)
        {
            ArgumentNullException.ThrowIfNull(tradeChanged);

            UpdateWsMessageHandlerWsTradeSimpleDelegat?.Invoke(tradeChanged);
            return TradesGetAndSubscribeV2Async(Format.Simple, exchange, portfolio, skipHistory);
        }

        public Task<string> TradesGetAndSubscribeV2SlimAsync(Action<WsTradeSlim> tradeChanged,
            Exchange exchange, string portfolio, bool skipHistory = false)
        {
            ArgumentNullException.ThrowIfNull(tradeChanged);

            UpdateWsMessageHandlerWsTradeSlimDelegat?.Invoke(tradeChanged);
            return TradesGetAndSubscribeV2Async(Format.Slim, exchange, portfolio, skipHistory);
        }

        public Task<string> TradesGetAndSubscribeV2HeavyAsync(Action<WsTradeHeavy> tradeChanged,
            Exchange exchange, string portfolio, bool skipHistory = false)
        {
            ArgumentNullException.ThrowIfNull(tradeChanged);

            UpdateWsMessageHandlerWsTradeHeavyDelegat?.Invoke(tradeChanged);
            return TradesGetAndSubscribeV2Async(Format.Heavy, exchange, portfolio, skipHistory);
        }

        public Task<string> OrdersGetAndSubscribeV2SimpleAsync(Action<WsOrderSimple> orderChanged,
            Exchange exchange, string portfolio, List<OrderStatus>? orderStatuses = null, bool skipHistory = false)
        {
            ArgumentNullException.ThrowIfNull(orderChanged);

            UpdateWsMessageHandlerWsOrderSimpleDelegat?.Invoke(orderChanged);
            return OrdersGetAndSubscribeV2Async(Format.Simple, exchange, portfolio, orderStatuses, skipHistory);
        }

        public Task<string> OrdersGetAndSubscribeV2SlimAsync(Action<WsOrderSlim> orderChanged,
            Exchange exchange, string portfolio, List<OrderStatus>? orderStatuses = null, bool skipHistory = false)
        {
            ArgumentNullException.ThrowIfNull(orderChanged);

            UpdateWsMessageHandlerWsOrderSlimDelegat?.Invoke(orderChanged);
            return OrdersGetAndSubscribeV2Async(Format.Slim, exchange, portfolio, orderStatuses, skipHistory);
        }

        public Task<string> OrdersGetAndSubscribeV2HeavyAsync(Action<WsOrderHeavy> orderChanged,
            Exchange exchange, string portfolio, List<OrderStatus>? orderStatuses = null, bool skipHistory = false)
        {
            ArgumentNullException.ThrowIfNull(orderChanged);

            UpdateWsMessageHandlerWsOrderHeavyDelegat?.Invoke(orderChanged);
            return OrdersGetAndSubscribeV2Async(Format.Heavy, exchange, portfolio, orderStatuses, skipHistory);
        }

        public Task<Dictionary<string, string>> InstrumentsGetAndSubscribeV2SimpleAsync(Action<WsSecurityFromWsSimple> securityFromWsChanged,
            IEnumerable<string?> tickersList, Exchange exchange, string? instrumentGroup = null)
        {
            ArgumentNullException.ThrowIfNull(securityFromWsChanged);
            ArgumentNullException.ThrowIfNull(tickersList);

            UpdateWsMessageHandlerWsSecurityFromWsSimpleDelegat?.Invoke(securityFromWsChanged);
            return InstrumentsGetAndSubscribeV2Async(Format.Simple, tickersList, exchange, instrumentGroup);
        }

        public Task<Dictionary<string, string>> InstrumentsGetAndSubscribeV2SlimAsync(Action<WsSecurityFromWsSlim> securityFromWsChanged,
            IEnumerable<string?> tickersList, Exchange exchange, string? instrumentGroup = null)
        {
            ArgumentNullException.ThrowIfNull(securityFromWsChanged);
            ArgumentNullException.ThrowIfNull(tickersList);

            UpdateWsMessageHandlerWsSecurityFromWsSlimDelegat?.Invoke(securityFromWsChanged);
            return InstrumentsGetAndSubscribeV2Async(Format.Slim, tickersList, exchange, instrumentGroup);
        }

        public Task<Dictionary<string, string>> InstrumentsGetAndSubscribeV2HeavyAsync(Action<WsSecurityFromWsHeavy> securityFromWsChanged,
            IEnumerable<string?> tickersList, Exchange exchange, string? instrumentGroup = null)
        {
            ArgumentNullException.ThrowIfNull(securityFromWsChanged);
            ArgumentNullException.ThrowIfNull(tickersList);

            UpdateWsMessageHandlerWsSecurityFromWsHeavyDelegat?.Invoke(securityFromWsChanged);
            return InstrumentsGetAndSubscribeV2Async(Format.Heavy, tickersList, exchange, instrumentGroup);
        }

        public Task<string> StopOrdersGetAndSubscribeV2SimpleAsync(Action<WsStopOrderSimple> stopOrderChanged,
            Exchange exchange, string portfolio, List<OrderStatus>? orderStatuses = null, bool skipHistory = false)
        {
            ArgumentNullException.ThrowIfNull(stopOrderChanged);

            UpdateWsMessageHandlerWsStopOrderSimpleDelegat?.Invoke(stopOrderChanged);
            return StopOrdersGetAndSubscribeV2Async(Format.Simple, exchange, portfolio, orderStatuses, skipHistory);
        }

        public Task<string> StopOrdersGetAndSubscribeV2SlimAsync(Action<WsStopOrderSlim> stopOrderChanged,
            Exchange exchange, string portfolio, List<OrderStatus>? orderStatuses = null, bool skipHistory = false)
        {
            ArgumentNullException.ThrowIfNull(stopOrderChanged);

            UpdateWsMessageHandlerWsStopOrderSlimDelegat?.Invoke(stopOrderChanged);
            return StopOrdersGetAndSubscribeV2Async(Format.Slim, exchange, portfolio, orderStatuses, skipHistory);
        }

        public Task<string> StopOrdersGetAndSubscribeV2HeavyAsync(Action<WsStopOrderHeavy> stopOrderChanged,
            Exchange exchange, string portfolio, List<OrderStatus>? orderStatuses = null, bool skipHistory = false)
        {
            ArgumentNullException.ThrowIfNull(stopOrderChanged);

            UpdateWsMessageHandlerWsStopOrderHeavyDelegat?.Invoke(stopOrderChanged);
            return StopOrdersGetAndSubscribeV2Async(Format.Heavy, exchange, portfolio, orderStatuses, skipHistory);
        }
        #endregion

        #region Subscriptions Methods
        private async Task<Dictionary<string, string>> OrderBookGetAndSubscribeAsync(Format format,
            IEnumerable<string?> tickersList,
            Exchange exchange, int depth, string? instrumentGroup)
        {
            if (depth > 50) depth = 50;
            var msgDic = new Dictionary<string, string>();
            var guidToTickerDic = new Dictionary<string, string>();

            foreach (var ticker in tickersList)
            {
                if (string.IsNullOrEmpty(ticker)) continue;

                var guid = Utilities.Utilities.GuidFormatter("b", Interlocked.Increment(ref _guidCounter), format);

                _parameters?.TryAdd(guid, new Parameters
                                          {
                                              Guid = guid,
                                              Code = ticker,
                                              Depth = depth,
                                              Exchange = exchange,
                                              InstrumentGroup = instrumentGroup,
                                          });
                var message = new SubscriptionOrderBook(ticker, depth, exchange, instrumentGroup, format, 0, guid).ToJson();
                msgDic.Add(guid, message);
                guidToTickerDic.Add(guid, ticker);
            }

            await (_msgDictionaryUpdate?.Invoke(msgDic) ?? Task.CompletedTask);

            return guidToTickerDic;
        }

        private async Task<Dictionary<string, string>> BarsGetAndSubscribeAsync(Format format,
            IEnumerable<string?> tickersList,
            Exchange exchange, string tf, DateTime from, string? instrumentGroup, bool skipHistory,
            bool? splitAdjust, CandleSliceMode sliceMode)
        {
            var msgDic = new Dictionary<string, string>();
            var guidToTickerDic = new Dictionary<string, string>();

            foreach (var ticker in tickersList)
            {
                if (string.IsNullOrEmpty(ticker)) continue;

                var guid = Utilities.Utilities.GuidFormatter("c", Interlocked.Increment(ref _guidCounter), format);

                _parameters?.TryAdd(guid, new Parameters
                                          {
                                              Guid = guid,
                                              Code = ticker,
                                              Exchange = exchange,
                                              InstrumentGroup = instrumentGroup,
                                              Tf = tf,
                                              From = from,
                                              SkipHistory = skipHistory,
                                              SplitAdjust = splitAdjust,
                                              SliceMode = sliceMode,
                                          });
                var message = new SubscriptionBar(ticker, tf, from.GetUnixTimestampSecondsFromDateTime(), instrumentGroup, skipHistory, splitAdjust, sliceMode, exchange, format, 0, guid).ToJson();
                msgDic.Add(guid, message);
                guidToTickerDic.Add(guid, ticker);
            }

            await (_msgDictionaryUpdate?.Invoke(msgDic) ?? Task.CompletedTask);

            return guidToTickerDic;
        }

        private async Task<Dictionary<string, string>> QuotesSubscribeAsync(Format format,
            IEnumerable<string?> tickersList,
            Exchange exchange, string? instrumentGroup)
        {
            var msgDic = new Dictionary<string, string>();
            var guidToTickerDic = new Dictionary<string, string>();

            foreach (var ticker in tickersList)
            {
                if (string.IsNullOrEmpty(ticker)) continue;

                var guid = Utilities.Utilities.GuidFormatter("d", Interlocked.Increment(ref _guidCounter), format);
                
                _parameters?.TryAdd(guid, new Parameters
                                          {
                                              Guid = guid,
                                              Code = ticker,
                                              Exchange = exchange,
                                              InstrumentGroup = instrumentGroup,
                                          });
                var message = new SubscriptionQuote(ticker, exchange, instrumentGroup, format, 0, guid).ToJson();
                msgDic.Add(guid, message);
                guidToTickerDic.Add(guid, ticker);
            }

            await (_msgDictionaryUpdate?.Invoke(msgDic) ?? Task.CompletedTask);

            return guidToTickerDic;
        }

        private async Task<Dictionary<string, string>> AllTradesGetAndSubscribeAsync(Format format,
            IEnumerable<string?> tickersList,
            Exchange exchange, int depth, bool includeVirtualTrades, string? instrumentGroup)
        {
            var msgDic = new Dictionary<string, string>();
            var guidToTickerDic = new Dictionary<string, string>();

            foreach (var ticker in tickersList)
            {
                if (string.IsNullOrEmpty(ticker)) continue;

                var guid = Utilities.Utilities.GuidFormatter("e", Interlocked.Increment(ref _guidCounter), format);
                
                _parameters?.TryAdd(guid, new Parameters
                                          {
                                              Guid = guid,
                                              Code = ticker,
                                              InstrumentGroup = instrumentGroup,
                                              Exchange = exchange,
                                              IncludeVirtualTrades = includeVirtualTrades
                                          });
                var message = new SubscriptionAllTrade(ticker, depth, includeVirtualTrades, instrumentGroup, exchange, format, 0, guid).ToJson();
                msgDic.Add(guid, message);
                guidToTickerDic.Add(guid, ticker);
            }

            await (_msgDictionaryUpdate?.Invoke(msgDic) ?? Task.CompletedTask);

            return guidToTickerDic;
        }

        private async Task<string> PositionsGetAndSubscribeV2Async(Format format,
            Exchange exchange, string? portfolio, bool skipHistory)
        {
            if (string.IsNullOrEmpty(portfolio))
                throw new ArgumentNullException(nameof(portfolio));

            var msgDic = new Dictionary<string, string>();

            var guid = Utilities.Utilities.GuidFormatter("f", Interlocked.Increment(ref _guidCounter), format);

            _parameters?.TryAdd(guid, new Parameters
                                      {
                                          Guid = guid,
                                          Portfolio = portfolio,
                                          Exchange = exchange,
                                          SkipHistory = skipHistory
                                      });
            var message = new SubscriptionPosition(portfolio, skipHistory, exchange, format, 0, guid).ToJson();
            msgDic.Add(guid, message);

            await (_msgDictionaryUpdate?.Invoke(msgDic) ?? Task.CompletedTask);

            return guid;
        }

        private async Task<string> SummariesGetAndSubscribeV2Async(Format format,
            Exchange exchange, string? portfolio, bool skipHistory)
        {
            if (string.IsNullOrEmpty(portfolio))
                throw new ArgumentNullException(nameof(portfolio));

            var msgDic = new Dictionary<string, string>();

            var guid = Utilities.Utilities.GuidFormatter("g", Interlocked.Increment(ref _guidCounter), format);

            _parameters?.TryAdd(guid, new Parameters
                                      {
                                          Guid = guid,
                                          Portfolio = portfolio,
                                          Exchange = exchange,
                                          SkipHistory = skipHistory
                                      });
            var message = new SubscriptionSummary(portfolio, skipHistory, exchange, format, 0, guid).ToJson();
            msgDic.Add(guid, message);

            await (_msgDictionaryUpdate?.Invoke(msgDic) ?? Task.CompletedTask);

            return guid;
        }

        private async Task<string> RisksGetAndSubscribeAsync(Format format,
            Exchange exchange, string? portfolio, bool skipHistory)
        {
            if (string.IsNullOrEmpty(portfolio))
                throw new ArgumentNullException(nameof(portfolio));

            var msgDic = new Dictionary<string, string>();

            var guid = Utilities.Utilities.GuidFormatter("h", Interlocked.Increment(ref _guidCounter), format);

            _parameters?.TryAdd(guid, new Parameters
                                      {
                                          Guid = guid,
                                          Portfolio = portfolio,
                                          Exchange = exchange,
                                          SkipHistory = skipHistory
                                      });
            var message = new SubscriptionRisk(portfolio, skipHistory, exchange, format, 0, guid).ToJson();
            msgDic.Add(guid, message);

            await (_msgDictionaryUpdate?.Invoke(msgDic) ?? Task.CompletedTask);

            return guid;
        }

        private async Task<string> SpectraRisksGetAndSubscribeAsync(Format format,
            Exchange exchange, string? portfolio, bool skipHistory)
        {
            if (string.IsNullOrEmpty(portfolio))
                throw new ArgumentNullException(nameof(portfolio));

            var msgDic = new Dictionary<string, string>();

            var guid = Utilities.Utilities.GuidFormatter("i", Interlocked.Increment(ref _guidCounter), format);

            _parameters?.TryAdd(guid, new Parameters
                                      {
                                          Guid = guid,
                                          Portfolio = portfolio,
                                          Exchange = exchange,
                                          SkipHistory = skipHistory
                                      });
            var message = new SubscriptionSpectraRisk(portfolio, skipHistory, exchange, format, 0, guid).ToJson();
            msgDic.Add(guid, message);

            await (_msgDictionaryUpdate?.Invoke(msgDic) ?? Task.CompletedTask);

            return guid;
        }

        private async Task<string> TradesGetAndSubscribeV2Async(Format format,
            Exchange exchange, string? portfolio, bool skipHistory)
        {
            if (string.IsNullOrEmpty(portfolio))
                throw new ArgumentNullException(nameof(portfolio));

            var msgDic = new Dictionary<string, string>();

            var guid = Utilities.Utilities.GuidFormatter("j", Interlocked.Increment(ref _guidCounter), format);

            _parameters?.TryAdd(guid, new Parameters
                                      {
                                          Guid = guid,
                                          Portfolio = portfolio,
                                          Exchange = exchange,
                                          SkipHistory = skipHistory
                                      });
            var message = new SubscriptionTrade(portfolio, skipHistory, exchange, format, 0, guid).ToJson();
            msgDic.Add(guid, message);

            await (_msgDictionaryUpdate?.Invoke(msgDic) ?? Task.CompletedTask);

            return guid;
        }

        private async Task<string> OrdersGetAndSubscribeV2Async(Format format,
            Exchange exchange, string? portfolio, List<OrderStatus>? orderStatuses, bool skipHistory)
        {
            if (string.IsNullOrEmpty(portfolio))
                throw new ArgumentNullException(nameof(portfolio));

            var msgDic = new Dictionary<string, string>();

            var guid = Utilities.Utilities.GuidFormatter("k", Interlocked.Increment(ref _guidCounter), format);

            _parameters?.TryAdd(guid, new Parameters
                                      {
                                          Guid = guid,
                                          Portfolio = portfolio,
                                          Exchange = exchange,
                                          SkipHistory = skipHistory,
                                          OrderStatuses = orderStatuses,
            });
            var message = new SubscriptionOrder(portfolio, orderStatuses, skipHistory, exchange, format, 0, guid).ToJson();
            msgDic.Add(guid, message);

            await (_msgDictionaryUpdate?.Invoke(msgDic) ?? Task.CompletedTask);

            return guid;
        }

        private async Task<Dictionary<string, string>> InstrumentsGetAndSubscribeV2Async(Format format,
            IEnumerable<string?> tickersList, Exchange exchange, string? instrumentGroup)
        {
            var msgDic = new Dictionary<string, string>();
            var guidToTickerDic = new Dictionary<string, string>();

            foreach (var ticker in tickersList)
            {
                if (string.IsNullOrEmpty(ticker)) continue;

                var guid = Utilities.Utilities.GuidFormatter("l", Interlocked.Increment(ref _guidCounter), format);

                _parameters?.TryAdd(guid, new Parameters
                                          {
                                              Guid = guid,
                                              Code = ticker,
                                              InstrumentGroup = instrumentGroup,
                                              Exchange = exchange,
                                          });
                var message = new SubscriptionInstrument(ticker, instrumentGroup, exchange, format, 0, guid).ToJson();
                msgDic.Add(guid, message);
                guidToTickerDic.Add(guid, ticker);
            }

            await (_msgDictionaryUpdate?.Invoke(msgDic) ?? Task.CompletedTask);

            return guidToTickerDic;
        }

        private async Task<string> StopOrdersGetAndSubscribeV2Async(Format format,
            Exchange exchange, string? portfolio, List<OrderStatus>? orderStatuses, bool skipHistory)
        {
            if (string.IsNullOrEmpty(portfolio))
                throw new ArgumentNullException(nameof(portfolio));

            var msgDic = new Dictionary<string, string>();

            var guid = Utilities.Utilities.GuidFormatter("m", Interlocked.Increment(ref _guidCounter), format);

            _parameters?.TryAdd(guid, new Parameters
                                      {
                                          Guid = guid,
                                          Portfolio = portfolio,
                                          Exchange = exchange,
                                          SkipHistory = skipHistory,
                                          OrderStatuses = orderStatuses,
                                      });
            var message = new SubscriptionStopOrder(portfolio, orderStatuses, skipHistory, exchange, format, 0, guid).ToJson();
            msgDic.Add(guid, message);

            await (_msgDictionaryUpdate?.Invoke(msgDic) ?? Task.CompletedTask);

            return guid;
        }

        public Task UnsubscribeAsync(IEnumerable<string> guids)
        {
            var msgDic = new Dictionary<string, string>();

            foreach (var guid in guids)
            {
                var message = new SubscriptionUnsubscribe(guid).ToJson();

                msgDic.Add(guid, message);
            }

            return (_msgDeleteRequest?.Invoke(msgDic) ?? Task.CompletedTask);

        }
        #endregion

        public void Dispose()
        {
            _msgDictionaryUpdate = null;
            _msgDeleteRequest = null;
            UpdateWsMessageHandlerWsOrderBookSimpleDelegat = null;
            UpdateWsMessageHandlerWsOrderBookSlimDelegat = null;
            UpdateWsMessageHandlerWsOrderBookHeavyDelegat = null;
            UpdateWsMessageHandlerWsCandleSimpleDelegat = null;
            UpdateWsMessageHandlerWsCandleSlimDelegat = null;
            UpdateWsMessageHandlerWsCandleHeavyDelegat = null;
            UpdateWsMessageHandlerWsSymbolSimpleDelegat = null;
            UpdateWsMessageHandlerWsSymbolSlimDelegat = null;
            UpdateWsMessageHandlerWsSymbolHeavyDelegat = null;
            UpdateWsMessageHandlerWsAllTradeSimpleDelegat = null;
            UpdateWsMessageHandlerWsAllTradeSlimDelegat = null;
            UpdateWsMessageHandlerWsAllTradeHeavyDelegat = null;
            UpdateWsMessageHandlerWsPositionSimpleDelegat = null;
            UpdateWsMessageHandlerWsPositionSlimDelegat = null;
            UpdateWsMessageHandlerWsPositionHeavyDelegat = null;
            UpdateWsMessageHandlerWsSummarySimpleDelegat = null;
            UpdateWsMessageHandlerWsSummarySlimDelegat = null;
            UpdateWsMessageHandlerWsSummaryHeavyDelegat = null;
            UpdateWsMessageHandlerWsRiskSimpleDelegat = null;
            UpdateWsMessageHandlerWsRiskSlimDelegat = null;
            UpdateWsMessageHandlerWsRiskHeavyDelegat = null;
            UpdateWsMessageHandlerWsFortsriskSimpleDelegat = null;
            UpdateWsMessageHandlerWsFortsriskSlimDelegat = null;
            UpdateWsMessageHandlerWsFortsriskHeavyDelegat = null;
            UpdateWsMessageHandlerWsTradeSimpleDelegat = null;
            UpdateWsMessageHandlerWsTradeSlimDelegat = null;
            UpdateWsMessageHandlerWsTradeHeavyDelegat = null;
            UpdateWsMessageHandlerWsOrderSimpleDelegat = null;
            UpdateWsMessageHandlerWsOrderSlimDelegat = null;
            UpdateWsMessageHandlerWsOrderHeavyDelegat = null;
            UpdateWsMessageHandlerWsSecurityFromWsSimpleDelegat = null;
            UpdateWsMessageHandlerWsSecurityFromWsSlimDelegat = null;
            UpdateWsMessageHandlerWsSecurityFromWsHeavyDelegat = null;
            UpdateWsMessageHandlerWsStopOrderSimpleDelegat = null;
            UpdateWsMessageHandlerWsStopOrderSlimDelegat = null;
            UpdateWsMessageHandlerWsStopOrderHeavyDelegat = null;
        }
    }
}
