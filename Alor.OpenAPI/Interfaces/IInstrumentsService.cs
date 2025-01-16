using Alor.OpenAPI.Core;
using Alor.OpenAPI.Enums;
using Alor.OpenAPI.Models;
using Alor.OpenAPI.Models.Heavy;
using Alor.OpenAPI.Models.Simple;
using Alor.OpenAPI.Models.Slim;

namespace Alor.OpenAPI.Interfaces
{
    public interface IInstrumentsService
    {
        /// <include file='../XmlDocs/IInstrumentsService.xml' path='Docs/Members[@name="IInstrumentsService"]/Member[@name="MdV2SecuritiesGetSimpleAsync"]/*' />
        public Task<ICollection<SecuritySimple>> MdV2SecuritiesGetSimpleAsync(string? query = null, int? limit = null,
            int? offset = null, Sector? sector = null, string? cficode = null, Exchange? exchange = null,
            string? instrumentGroup = null, bool? includeNonBaseBoards = null);

        /// <include file='../XmlDocs/IInstrumentsService.xml' path='Docs/Members[@name="IInstrumentsService"]/Member[@name="MdV2SecuritiesGetSlimAsync"]/*' />
        public Task<ICollection<SecuritySlim>> MdV2SecuritiesGetSlimAsync(string? query = null, int? limit = null,
            int? offset = null, Sector? sector = null, string? cficode = null, Exchange? exchange = null,
            string? instrumentGroup = null, bool? includeNonBaseBoards = null);

        /// <include file='../XmlDocs/IInstrumentsService.xml' path='Docs/Members[@name="IInstrumentsService"]/Member[@name="MdV2SecuritiesGetHeavyAsync"]/*' />
        public Task<ICollection<SecurityHeavy>> MdV2SecuritiesGetHeavyAsync(string? query = null, int? limit = null,
            int? offset = null, Sector? sector = null, string? cficode = null, Exchange? exchange = null,
            string? instrumentGroup = null, bool? includeNonBaseBoards = null);

        /// <include file='../XmlDocs/IInstrumentsService.xml' path='Docs/Members[@name="IInstrumentsService"]/Member[@name="MdV2SecuritiesExchangeGetSimpleAsync"]/*' />
        public Task<ICollection<SecuritySimple>> MdV2SecuritiesExchangeGetSimpleAsync(
            Exchange exchange, Market? market = null, bool? includeOld = null, int? limit = null, int? offset = null,
            bool? includeNonBaseBoards = null);

        /// <include file='../XmlDocs/IInstrumentsService.xml' path='Docs/Members[@name="IInstrumentsService"]/Member[@name="MdV2SecuritiesExchangeGetSlimAsync"]/*' />
        public Task<ICollection<SecuritySlim>> MdV2SecuritiesExchangeGetSlimAsync(
            Exchange exchange, Market? market = null, bool? includeOld = null, int? limit = null, int? offset = null,
            bool? includeNonBaseBoards = null);

        /// <include file='../XmlDocs/IInstrumentsService.xml' path='Docs/Members[@name="IInstrumentsService"]/Member[@name="MdV2SecuritiesExchangeGetHeavyAsync"]/*' />
        public Task<ICollection<SecurityHeavy>> MdV2SecuritiesExchangeGetHeavyAsync(
            Exchange exchange, Market? market = null, bool? includeOld = null, int? limit = null, int? offset = null,
            bool? includeNonBaseBoards = null);

        /// <include file='../XmlDocs/IInstrumentsService.xml' path='Docs/Members[@name="IInstrumentsService"]/Member[@name="MdV2SecuritiesExchangeSymbolGetSimpleAsync"]/*' />
        public Task<SecuritySimple> MdV2SecuritiesExchangeSymbolGetSimpleAsync(Exchange exchange, string symbol,
            string? instrumentGroup = null);

        /// <include file='../XmlDocs/IInstrumentsService.xml' path='Docs/Members[@name="IInstrumentsService"]/Member[@name="MdV2SecuritiesExchangeSymbolGetSlimAsync"]/*' />
        public Task<SecuritySlim> MdV2SecuritiesExchangeSymbolGetSlimAsync(Exchange exchange, string symbol,
            string? instrumentGroup = null);

        /// <include file='../XmlDocs/IInstrumentsService.xml' path='Docs/Members[@name="IInstrumentsService"]/Member[@name="MdV2SecuritiesExchangeSymbolGetHeavyAsync"]/*' />
        public Task<SecurityHeavy> MdV2SecuritiesExchangeSymbolGetHeavyAsync(Exchange exchange, string symbol,
            string? instrumentGroup = null);

        /// <include file='../XmlDocs/IInstrumentsService.xml' path='Docs/Members[@name="IInstrumentsService"]/Member[@name="MdV2SecuritiesExchangeSymbolAvailableBoardsGetAsync"]/*' />
        public Task<ICollection<string>> MdV2SecuritiesExchangeSymbolAvailableBoardsGetAsync(Exchange exchange,
            string symbol);

        /// <include file='../XmlDocs/IInstrumentsService.xml' path='Docs/Members[@name="IInstrumentsService"]/Member[@name="MdV2SecuritiesSymbolsQuotesGetSimpleAsync"]/*' />
        public Task<ICollection<SymbolSimple>> MdV2SecuritiesSymbolsQuotesGetSimpleAsync(string? symbols);

        /// <include file='../XmlDocs/IInstrumentsService.xml' path='Docs/Members[@name="IInstrumentsService"]/Member[@name="MdV2SecuritiesSymbolsQuotesGetSlimAsync"]/*' />
        public Task<ICollection<SymbolSlim>> MdV2SecuritiesSymbolsQuotesGetSlimAsync(string? symbols);

        /// <include file='../XmlDocs/IInstrumentsService.xml' path='Docs/Members[@name="IInstrumentsService"]/Member[@name="MdV2SecuritiesSymbolsQuotesGetHeavyAsync"]/*' />
        public Task<ICollection<SymbolHeavy>> MdV2SecuritiesSymbolsQuotesGetHeavyAsync(string? symbols);

        /// <include file='../XmlDocs/IInstrumentsService.xml' path='Docs/Members[@name="IInstrumentsService"]/Member[@name="MdV2OrderbooksExchangeSymbolGetSimpleAsync"]/*' />
        public Task<OrderbookSimple> MdV2OrderbooksExchangeSymbolGetSimpleAsync(Exchange exchange, string symbol,
            string? instrumentGroup = null, int? depth = null);

        /// <include file='../XmlDocs/IInstrumentsService.xml' path='Docs/Members[@name="IInstrumentsService"]/Member[@name="MdV2OrderbooksExchangeSymbolGetSlimAsync"]/*' />
        public Task<OrderbookSlim> MdV2OrderbooksExchangeSymbolGetSlimAsync(Exchange exchange, string symbol,
            string? instrumentGroup = null, int? depth = null);

        /// <include file='../XmlDocs/IInstrumentsService.xml' path='Docs/Members[@name="IInstrumentsService"]/Member[@name="MdV2OrderbooksExchangeSymbolGetHeavyAsync"]/*' />
        public Task<OrderbookHeavy> MdV2OrderbooksExchangeSymbolGetHeavyAsync(Exchange exchange, string symbol,
            string? instrumentGroup = null, int? depth = null);

        /// <include file='../XmlDocs/IInstrumentsService.xml' path='Docs/Members[@name="IInstrumentsService"]/Member[@name="MdV2SecuritiesExchangeSymbolAlltradesGetSimpleAsync"]/*' />
        public Task<ICollection<AllTradeSimple>> MdV2SecuritiesExchangeSymbolAlltradesGetSimpleAsync(Exchange exchange,
            string symbol, string? instrumentGroup = null,
            DateTime? from = null, DateTime? to = null, long? fromId = null, long? toId = null, int? qtyFrom = null,
            int? qtyTo = null, decimal? priceFrom = null,
            decimal? priceTo = null, Side? side = null, int? offset = null, int? take = null,
            bool? descending = null, bool? includeVirtualTrades = null);

        /// <include file='../XmlDocs/IInstrumentsService.xml' path='Docs/Members[@name="IInstrumentsService"]/Member[@name="MdV2SecuritiesExchangeSymbolAlltradesGetSlimAsync"]/*' />
        public Task<ICollection<AllTradeSlim>> MdV2SecuritiesExchangeSymbolAlltradesGetSlimAsync(Exchange exchange,
            string symbol, string? instrumentGroup = null,
            DateTime? from = null, DateTime? to = null, long? fromId = null, long? toId = null, int? qtyFrom = null,
            int? qtyTo = null, decimal? priceFrom = null,
            decimal? priceTo = null, Side? side = null, int? offset = null, int? take = null,
            bool? descending = null, bool? includeVirtualTrades = null);

        /// <include file='../XmlDocs/IInstrumentsService.xml' path='Docs/Members[@name="IInstrumentsService"]/Member[@name="MdV2SecuritiesExchangeSymbolAlltradesGetHeavyAsync"]/*' />
        public Task<ICollection<AllTradeHeavy>> MdV2SecuritiesExchangeSymbolAlltradesGetHeavyAsync(Exchange exchange,
            string symbol, string? instrumentGroup = null,
            DateTime? from = null, DateTime? to = null, long? fromId = null, long? toId = null, int? qtyFrom = null,
            int? qtyTo = null, decimal? priceFrom = null,
            decimal? priceTo = null, Side? side = null, int? offset = null, int? take = null,
            bool? descending = null, bool? includeVirtualTrades = null);

        /// <include file='../XmlDocs/IInstrumentsService.xml' path='Docs/Members[@name="IInstrumentsService"]/Member[@name="MdV2SecuritiesExchangeSymbolAlltradesHistoryGetSimpleAsync"]/*' />
        public Task<AllTradesHistorySimple> MdV2SecuritiesExchangeSymbolAlltradesHistoryGetSimpleAsync(
            Exchange exchange, string symbol, int limit, string? instrumentGroup = null, DateTime? from = null,
            DateTime? to = null, int? offset = null);

        /// <include file='../XmlDocs/IInstrumentsService.xml' path='Docs/Members[@name="IInstrumentsService"]/Member[@name="MdV2SecuritiesExchangeSymbolAlltradesHistoryGetSlimAsync"]/*' />
        public Task<AllTradesHistorySlim> MdV2SecuritiesExchangeSymbolAlltradesHistoryGetSlimAsync(Exchange exchange,
            string symbol, int limit, string? instrumentGroup, DateTime? from = null, DateTime? to = null, int? offset = null);

        /// <include file='../XmlDocs/IInstrumentsService.xml' path='Docs/Members[@name="IInstrumentsService"]/Member[@name="MdV2SecuritiesExchangeSymbolAlltradesHistoryGetHeavyAsync"]/*' />
        public Task<AllTradesHistoryHeavy> MdV2SecuritiesExchangeSymbolAlltradesHistoryGetHeavyAsync(Exchange exchange,
            string symbol, int limit, string? instrumentGroup = null, DateTime? from = null, DateTime? to = null,
            int? offset = null);

        /// <include file='../XmlDocs/IInstrumentsService.xml' path='Docs/Members[@name="IInstrumentsService"]/Member[@name="MdV2SecuritiesExchangeSymbolActualFuturesQuoteGetSimpleAsync"]/*' />
        public Task<FuturesSimple> MdV2SecuritiesExchangeSymbolActualFuturesQuoteGetSimpleAsync(Exchange exchange,
            string symbol);

        /// <include file='../XmlDocs/IInstrumentsService.xml' path='Docs/Members[@name="IInstrumentsService"]/Member[@name="MdV2SecuritiesExchangeSymbolActualFuturesQuoteGetSlimAsync"]/*' />
        public Task<FuturesSlim> MdV2SecuritiesExchangeSymbolActualFuturesQuoteGetSlimAsync(Exchange exchange,
            string symbol);

        /// <include file='../XmlDocs/IInstrumentsService.xml' path='Docs/Members[@name="IInstrumentsService"]/Member[@name="MdV2SecuritiesExchangeSymbolActualFuturesQuoteGetHeavyAsync"]/*' />
        public Task<FuturesHeavy> MdV2SecuritiesExchangeSymbolActualFuturesQuoteGetHeavyAsync(Exchange exchange,
            string symbol);

        /// <include file='../XmlDocs/IInstrumentsService.xml' path='Docs/Members[@name="IInstrumentsService"]/Member[@name="MdV2RiskRatesGetAsync"]/*' />
        public Task<RiskRates> MdV2RiskRatesGetAsync(Exchange exchange, string? ticker = null,
            int? riskCategoryId = null, string? search = null, int? limit = null, int? offset = null);

        /// <include file='../XmlDocs/IInstrumentsService.xml' path='Docs/Members[@name="IInstrumentsService"]/Member[@name="MdV2HistoryGetSimpleAsync"]/*' />
        public Task<HistorySimple> MdV2HistoryGetSimpleAsync(string symbol, Exchange exchange, string tf, DateTime from,
            DateTime to, string? instrumentGroup = null, int? countBack = null, bool? untraded = null, bool? splitAdjust = null, CandleSliceMode? sliceMode = null);

        /// <include file='../XmlDocs/IInstrumentsService.xml' path='Docs/Members[@name="IInstrumentsService"]/Member[@name="MdV2HistoryGetSlimAsync"]/*' />
        public Task<HistorySlim> MdV2HistoryGetSlimAsync(string symbol, Exchange exchange, string tf, DateTime from,
            DateTime to, string? instrumentGroup = null, int? countBack = null, bool? untraded = null, bool? splitAdjust = null, CandleSliceMode? sliceMode = null);

        /// <include file='../XmlDocs/IInstrumentsService.xml' path='Docs/Members[@name="IInstrumentsService"]/Member[@name="MdV2HistoryGetHeavyAsync"]/*' />
        public Task<HistoryHeavy> MdV2HistoryGetHeavyAsync(string symbol, Exchange exchange, string tf, DateTime from,
            DateTime to, string? instrumentGroup = null, int? countBack = null, bool? untraded = null, bool? splitAdjust = null, CandleSliceMode? sliceMode = null);

        /// <include file='../XmlDocs/IInstrumentsService.xml' path='Docs/Members[@name="IInstrumentsService"]/Member[@name="MdV2SecuritiesCurrencyPairsGetAsync"]/*' />
        public Task<ICollection<CurrencyPair>> MdV2SecuritiesCurrencyPairsGetAsync();
    }
}
