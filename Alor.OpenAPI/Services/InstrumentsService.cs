using Alor.OpenAPI.Enums;
using Alor.OpenAPI.Interfaces;
using Alor.OpenAPI.Models;
using Alor.OpenAPI.Models.Heavy;
using Alor.OpenAPI.Models.Simple;
using Alor.OpenAPI.Models.Slim;
using System.Text;
using Alor.OpenAPI.Extensions;

namespace Alor.OpenAPI.Services
{
    public class InstrumentsService : IInstrumentsService
    {
        private readonly IApiHttpClientService _apiHttpClient;
        private readonly Uri _baseUrl;
        private readonly CancellationTokenSource _cancellationTokenSource;


        internal InstrumentsService(IApiHttpClientService apiHttpClient, Uri baseUrl,
            CancellationTokenSource cancellationTokenSource)
        {
            _apiHttpClient = apiHttpClient;
            _baseUrl = baseUrl;
            _cancellationTokenSource = cancellationTokenSource;
        }

        #region Instruments Headers
        public Task<ICollection<SecuritySimple>> MdV2SecuritiesGetSimpleAsync(string? query = null, int? limit = null, int? offset = null, Sector? sector = null, string? cficode = null, Exchange? exchange = null, string? instrumentGroup = null, bool? includeNonBaseBoards = null) =>
            MdV2SecuritiesGetAsync<ICollection<SecuritySimple>>(Format.Simple, query, limit, offset, sector, cficode, exchange, instrumentGroup, includeNonBaseBoards, _cancellationTokenSource.Token);

        public Task<ICollection<SecuritySlim>> MdV2SecuritiesGetSlimAsync(string? query = null, int? limit = null, int? offset = null, Sector? sector = null, string? cficode = null, Exchange? exchange = null, string? instrumentGroup = null, bool? includeNonBaseBoards = null) =>
            MdV2SecuritiesGetAsync<ICollection<SecuritySlim>>(Format.Slim, query, limit, offset, sector, cficode, exchange, instrumentGroup, includeNonBaseBoards, _cancellationTokenSource.Token);

        public Task<ICollection<SecurityHeavy>> MdV2SecuritiesGetHeavyAsync(string? query = null, int? limit = null, int? offset = null, Sector? sector = null, string? cficode = null, Exchange? exchange = null, string? instrumentGroup = null, bool? includeNonBaseBoards = null) =>
            MdV2SecuritiesGetAsync<ICollection<SecurityHeavy>>(Format.Heavy, query, limit, offset, sector, cficode, exchange, instrumentGroup, includeNonBaseBoards, _cancellationTokenSource.Token);

        public Task<ICollection<SecuritySimple>> MdV2SecuritiesExchangeGetSimpleAsync(
            Exchange exchange, Market? market = null, bool? includeOld = null, int? limit = null, int? offset = null, bool? includeNonBaseBoards = null) =>
            MdV2SecuritiesExchangeGetAsync<ICollection<SecuritySimple>>(Format.Simple, exchange, market, includeOld, limit, offset, includeNonBaseBoards, _cancellationTokenSource.Token);

        public Task<ICollection<SecuritySlim>> MdV2SecuritiesExchangeGetSlimAsync(
            Exchange exchange, Market? market = null, bool? includeOld = null, int? limit = null, int? offset = null, bool? includeNonBaseBoards = null) =>
            MdV2SecuritiesExchangeGetAsync<ICollection<SecuritySlim>>(Format.Slim, exchange, market, includeOld, limit, offset, includeNonBaseBoards, _cancellationTokenSource.Token);

        public Task<ICollection<SecurityHeavy>> MdV2SecuritiesExchangeGetHeavyAsync(
            Exchange exchange, Market? market = null, bool? includeOld = null, int? limit = null, int? offset = null, bool? includeNonBaseBoards = null) =>
            MdV2SecuritiesExchangeGetAsync<ICollection<SecurityHeavy>>(Format.Heavy, exchange, market, includeOld, limit, offset, includeNonBaseBoards, _cancellationTokenSource.Token);

        public Task<SecuritySimple> MdV2SecuritiesExchangeSymbolGetSimpleAsync(Exchange exchange, string symbol, string? instrumentGroup = null) =>
            MdV2SecuritiesExchangeSymbolGetAsync<SecuritySimple>(Format.Simple, exchange, symbol, instrumentGroup, _cancellationTokenSource.Token);

        public Task<SecuritySlim> MdV2SecuritiesExchangeSymbolGetSlimAsync(Exchange exchange, string symbol, string? instrumentGroup = null) =>
            MdV2SecuritiesExchangeSymbolGetAsync<SecuritySlim>(Format.Slim, exchange, symbol, instrumentGroup, _cancellationTokenSource.Token);

        public Task<SecurityHeavy> MdV2SecuritiesExchangeSymbolGetHeavyAsync(Exchange exchange, string symbol, string? instrumentGroup = null) =>
            MdV2SecuritiesExchangeSymbolGetAsync<SecurityHeavy>(Format.Heavy, exchange, symbol, instrumentGroup, _cancellationTokenSource.Token);

        public Task<ICollection<string>> MdV2SecuritiesExchangeSymbolAvailableBoardsGetAsync(Exchange exchange, string symbol) =>
            MdV2SecuritiesExchangeSymbolAvailableBoardsGetAsync(exchange, symbol, _cancellationTokenSource.Token);

        public Task<ICollection<SymbolSimple>> MdV2SecuritiesSymbolsQuotesGetSimpleAsync(string? symbols) =>
            MdV2SecuritiesSymbolsQuotesGetAsync<ICollection<SymbolSimple>>(Format.Simple, symbols, _cancellationTokenSource.Token);

        public Task<ICollection<SymbolSlim>> MdV2SecuritiesSymbolsQuotesGetSlimAsync(string? symbols) =>
            MdV2SecuritiesSymbolsQuotesGetAsync<ICollection<SymbolSlim>>(Format.Slim, symbols, _cancellationTokenSource.Token);

        public Task<ICollection<SymbolHeavy>> MdV2SecuritiesSymbolsQuotesGetHeavyAsync(string? symbols) =>
            MdV2SecuritiesSymbolsQuotesGetAsync<ICollection<SymbolHeavy>>(Format.Heavy, symbols, _cancellationTokenSource.Token);

        public Task<OrderbookSimple> MdV2OrderbooksExchangeSymbolGetSimpleAsync(Exchange exchange, string symbol, string? instrumentGroup = null, int? depth = null) =>
            MdV2OrderbooksExchangeSymbolGetAsync<OrderbookSimple>(Format.Simple, exchange, symbol, instrumentGroup, depth, _cancellationTokenSource.Token);

        public Task<OrderbookSlim> MdV2OrderbooksExchangeSymbolGetSlimAsync(Exchange exchange, string symbol, string? instrumentGroup = null, int? depth = null) =>
            MdV2OrderbooksExchangeSymbolGetAsync<OrderbookSlim>(Format.Slim, exchange, symbol, instrumentGroup, depth, _cancellationTokenSource.Token);

        public Task<OrderbookHeavy> MdV2OrderbooksExchangeSymbolGetHeavyAsync(Exchange exchange, string symbol, string? instrumentGroup = null, int? depth = null) =>
            MdV2OrderbooksExchangeSymbolGetAsync<OrderbookHeavy>(Format.Heavy, exchange, symbol, instrumentGroup, depth, _cancellationTokenSource.Token);

        public Task<ICollection<AllTradeSimple>> MdV2SecuritiesExchangeSymbolAlltradesGetSimpleAsync(Exchange exchange, string symbol, string? instrumentGroup = null,
            DateTime? from = null, DateTime? to = null, long? fromId = null, long? toId = null, int? qtyFrom = null, int? qtyTo = null, decimal? priceFrom = null,
            decimal? priceTo = null, Side? side = null, int? offset = null, int? take = null,
            bool? descending = null, bool? includeVirtualTrades = null) =>
            MdV2SecuritiesExchangeSymbolAlltradesGetAsync<ICollection<AllTradeSimple>>(Format.Simple, exchange, symbol, instrumentGroup, from, to, fromId, toId, qtyFrom, qtyTo, priceFrom, priceTo, side, offset, take, descending,
                includeVirtualTrades, _cancellationTokenSource.Token);

        public Task<ICollection<AllTradeSlim>> MdV2SecuritiesExchangeSymbolAlltradesGetSlimAsync(Exchange exchange, string symbol, string? instrumentGroup = null,
            DateTime? from = null, DateTime? to = null, long? fromId = null, long? toId = null, int? qtyFrom = null, int? qtyTo = null, decimal? priceFrom = null,
            decimal? priceTo = null, Side? side = null, int? offset = null, int? take = null,
            bool? descending = null, bool? includeVirtualTrades = null) =>
            MdV2SecuritiesExchangeSymbolAlltradesGetAsync<ICollection<AllTradeSlim>>(Format.Slim, exchange, symbol, instrumentGroup, from, to, fromId, toId, qtyFrom, qtyTo, priceFrom, priceTo, side, offset, take, descending,
                includeVirtualTrades, _cancellationTokenSource.Token);

        public Task<ICollection<AllTradeHeavy>> MdV2SecuritiesExchangeSymbolAlltradesGetHeavyAsync(Exchange exchange, string symbol, string? instrumentGroup = null,
            DateTime? from = null, DateTime? to = null, long? fromId = null, long? toId = null, int? qtyFrom = null, int? qtyTo = null, decimal? priceFrom = null,
            decimal? priceTo = null, Side? side = null, int? offset = null, int? take = null,
            bool? descending = null, bool? includeVirtualTrades = null) =>
            MdV2SecuritiesExchangeSymbolAlltradesGetAsync<ICollection<AllTradeHeavy>>(Format.Heavy, exchange, symbol, instrumentGroup, from, to, fromId, toId, qtyFrom, qtyTo, priceFrom, priceTo, side, offset, take, descending,
                includeVirtualTrades, _cancellationTokenSource.Token);

        public Task<AllTradesHistorySimple> MdV2SecuritiesExchangeSymbolAlltradesHistoryGetSimpleAsync(Exchange exchange, string symbol, int limit, string? instrumentGroup = null, DateTime? from = null, DateTime? to = null, int? offset = null) =>
            MdV2SecuritiesExchangeSymbolAlltradesHistoryGetAsync<AllTradesHistorySimple>(Format.Simple, exchange, symbol, limit, instrumentGroup, from, to, offset, _cancellationTokenSource.Token);

        public Task<AllTradesHistorySlim> MdV2SecuritiesExchangeSymbolAlltradesHistoryGetSlimAsync(Exchange exchange, string symbol, int limit, string? instrumentGroup, DateTime? from = null, DateTime? to = null, int? offset = null) =>
            MdV2SecuritiesExchangeSymbolAlltradesHistoryGetAsync<AllTradesHistorySlim>(Format.Slim, exchange, symbol, limit, instrumentGroup, from, to, offset, _cancellationTokenSource.Token);

        public Task<AllTradesHistoryHeavy> MdV2SecuritiesExchangeSymbolAlltradesHistoryGetHeavyAsync(Exchange exchange, string symbol, int limit, string? instrumentGroup = null, DateTime? from = null, DateTime? to = null, int? offset = null) =>
            MdV2SecuritiesExchangeSymbolAlltradesHistoryGetAsync<AllTradesHistoryHeavy>(Format.Heavy, exchange, symbol, limit, instrumentGroup, from, to, offset, _cancellationTokenSource.Token);

        public Task<FuturesSimple> MdV2SecuritiesExchangeSymbolActualFuturesQuoteGetSimpleAsync(Exchange exchange, string symbol) =>
            MdV2SecuritiesExchangeSymbolActualFuturesQuoteGetAsync<FuturesSimple>(Format.Simple, exchange, symbol, _cancellationTokenSource.Token);

        public Task<FuturesSlim> MdV2SecuritiesExchangeSymbolActualFuturesQuoteGetSlimAsync(Exchange exchange, string symbol) =>
            MdV2SecuritiesExchangeSymbolActualFuturesQuoteGetAsync<FuturesSlim>(Format.Slim, exchange, symbol, _cancellationTokenSource.Token);

        public Task<FuturesHeavy> MdV2SecuritiesExchangeSymbolActualFuturesQuoteGetHeavyAsync(Exchange exchange, string symbol) =>
            MdV2SecuritiesExchangeSymbolActualFuturesQuoteGetAsync<FuturesHeavy>(Format.Heavy, exchange, symbol, _cancellationTokenSource.Token);

        public Task<RiskRates> MdV2RiskRatesGetAsync(Exchange exchange, string? ticker = null,
            int? riskCategoryId = null, string? search = null, int? limit = null, int? offset = null) =>
            MdV2RiskRatesGetAsync(exchange, ticker, riskCategoryId, search, limit, offset, _cancellationTokenSource.Token);

        public Task<HistorySimple> MdV2HistoryGetSimpleAsync(string symbol, Exchange exchange, string tf, DateTime from, DateTime to, string? instrumentGroup = null, int? countBack = null, bool? untraded = null, bool? splitAdjust = null, CandleSliceMode? sliceMode = null) =>
            MdV2HistoryGetAsync<HistorySimple>(Format.Simple, symbol, exchange, tf, from, to, instrumentGroup, countBack, untraded, splitAdjust, sliceMode, _cancellationTokenSource.Token);

        public Task<HistorySlim> MdV2HistoryGetSlimAsync(string symbol, Exchange exchange, string tf, DateTime from, DateTime to, string? instrumentGroup = null, int? countBack = null, bool? untraded = null, bool? splitAdjust = null, CandleSliceMode? sliceMode = null) =>
            MdV2HistoryGetAsync<HistorySlim>(Format.Slim, symbol, exchange, tf, from, to, instrumentGroup, countBack, untraded, splitAdjust, sliceMode, _cancellationTokenSource.Token);

        public Task<HistoryHeavy> MdV2HistoryGetHeavyAsync(string symbol, Exchange exchange, string tf, DateTime from, DateTime to, string? instrumentGroup = null, int? countBack = null, bool? untraded = null, bool? splitAdjust = null, CandleSliceMode? sliceMode = null) =>
            MdV2HistoryGetAsync<HistoryHeavy>(Format.Heavy, symbol, exchange, tf, from, to, instrumentGroup, countBack, untraded, splitAdjust, sliceMode, _cancellationTokenSource.Token);

        public Task<ICollection<CurrencyPair>> MdV2SecuritiesCurrencyPairsGetAsync() =>
            MdV2SecuritiesCurrencyPairsGetAsync(_cancellationTokenSource.Token);
        #endregion

        #region Instruments Methods
        private Task<T> MdV2SecuritiesGetAsync<T>(Format format, string? query, int? limit, int? offset,
            Sector? sector, string? cficode, Exchange? exchange, string? instrumentGroup, bool? includeNonBaseBoards,
            CancellationToken cancellationToken)
        {
            var uriBuilder = new UriBuilder(_baseUrl)
                             {
                                 Path = $"{_baseUrl.AbsolutePath.TrimEnd('/')}/md/v2/securities"
                             };

            var urlBuilder = new StringBuilder();

            urlBuilder.Append($"format={format}&");

            Utilities.Utilities.AppendQueryParam(urlBuilder, "query", query);
            Utilities.Utilities.AppendQueryParam(urlBuilder, "limit", limit);
            Utilities.Utilities.AppendQueryParam(urlBuilder, "offset", offset);
            Utilities.Utilities.AppendQueryParam(urlBuilder, "sector", sector);
            Utilities.Utilities.AppendQueryParam(urlBuilder, "cficode", cficode);
            Utilities.Utilities.AppendQueryParam(urlBuilder, "exchange", exchange);
            Utilities.Utilities.AppendQueryParam(urlBuilder, "instrumentGroup", instrumentGroup);
            Utilities.Utilities.AppendQueryParam(urlBuilder, "includeNonBaseBoards", includeNonBaseBoards);

            urlBuilder.Length--;
            uriBuilder.Query = urlBuilder.ToString();

            return _apiHttpClient.ProcessRequest<T>(HttpMethod.Get, uriBuilder.Uri, cancellationToken);
        }

        private Task<T> MdV2SecuritiesExchangeGetAsync<T>(Format format, Exchange exchange, Market? market,
            bool? includeOld, int? limit, int? offset, bool? includeNonBaseBoards, CancellationToken cancellationToken)
        {
            var uriBuilder = new UriBuilder(_baseUrl)
                             {
                                 Path = $"{_baseUrl.AbsolutePath.TrimEnd('/')}/md/v2/securities/{exchange}"
                             };


            var urlBuilder = new StringBuilder();

            urlBuilder.Append($"format={format}&");

            Utilities.Utilities.AppendQueryParam(urlBuilder, "market", market);
            Utilities.Utilities.AppendQueryParam(urlBuilder, "includeOld", includeOld);
            Utilities.Utilities.AppendQueryParam(urlBuilder, "limit", limit);
            Utilities.Utilities.AppendQueryParam(urlBuilder, "offset", offset);
            Utilities.Utilities.AppendQueryParam(urlBuilder, "includeNonBaseBoards", includeNonBaseBoards);

            urlBuilder.Length--;
            uriBuilder.Query = urlBuilder.ToString();

            return _apiHttpClient.ProcessRequest<T>(HttpMethod.Get, uriBuilder.Uri, cancellationToken, needAuthorization: true);
        }

        private Task<T> MdV2SecuritiesExchangeSymbolGetAsync<T>(Format format, Exchange exchange, string symbol,
            string? instrumentGroup, CancellationToken cancellationToken)
        {
            if (string.IsNullOrEmpty(symbol))
                throw new ArgumentNullException(nameof(symbol));

            var uriBuilder = new UriBuilder(_baseUrl)
                             {
                                 Path = $"{_baseUrl.AbsolutePath.TrimEnd('/')}/md/v2/securities/{exchange}/{Uri.EscapeDataString(symbol)}"
                             };


            var urlBuilder = new StringBuilder();

            urlBuilder.Append($"format={format}&");

            Utilities.Utilities.AppendQueryParam(urlBuilder, "instrumentGroup", instrumentGroup);

            urlBuilder.Length--;
            uriBuilder.Query = urlBuilder.ToString();

            return _apiHttpClient.ProcessRequest<T>(HttpMethod.Get, uriBuilder.Uri, cancellationToken, needAuthorization: true);
        }

        private Task<ICollection<string>> MdV2SecuritiesExchangeSymbolAvailableBoardsGetAsync(Exchange exchange,
            string? symbol, CancellationToken cancellationToken)
        {
            if (string.IsNullOrEmpty(symbol))
                throw new ArgumentNullException(nameof(symbol));

            var uriBuilder = new UriBuilder(_baseUrl)
                             {
                                 Path = $"{_baseUrl.AbsolutePath.TrimEnd('/')}/md/v2/securities/{exchange}/{Uri.EscapeDataString(symbol)}/availableBoards"
                             };

            return _apiHttpClient.ProcessRequest<ICollection<string>>(HttpMethod.Get, uriBuilder.Uri, cancellationToken);
        }

        private Task<T> MdV2SecuritiesSymbolsQuotesGetAsync<T>(Format format, string? symbols,
            CancellationToken cancellationToken)
        {
            if (string.IsNullOrEmpty(symbols))
                throw new ArgumentNullException(nameof(symbols));

            var uriBuilder = new UriBuilder(_baseUrl)
                             {
                                 Path = $"{_baseUrl.AbsolutePath.TrimEnd('/')}/md/v2/securities/{Uri.EscapeDataString(symbols)}/quotes",
                                 Query = $"format={format}"
            };

            return _apiHttpClient.ProcessRequest<T>(HttpMethod.Get, uriBuilder.Uri, cancellationToken);
        }

        private Task<T> MdV2OrderbooksExchangeSymbolGetAsync<T>(Format format, Exchange exchange, string? symbol,
            string? instrumentGroup, int? depth, CancellationToken cancellationToken)
        {
            if (string.IsNullOrEmpty(symbol))
                throw new ArgumentNullException(nameof(symbol));

            var uriBuilder = new UriBuilder(_baseUrl)
                             {
                                 Path = $"{_baseUrl.AbsolutePath.TrimEnd('/')}/md/v2/orderbooks/{exchange}/{Uri.EscapeDataString(symbol)}"
                             };


            var urlBuilder = new StringBuilder();

            urlBuilder.Append($"format={format}&");

            Utilities.Utilities.AppendQueryParam(urlBuilder, "instrumentGroup", instrumentGroup);
            Utilities.Utilities.AppendQueryParam(urlBuilder, "depth", depth);

            urlBuilder.Length--;
            uriBuilder.Query = urlBuilder.ToString();

            return _apiHttpClient.ProcessRequest<T>(HttpMethod.Get, uriBuilder.Uri, cancellationToken, needAuthorization: true);
        }

        private Task<T> MdV2SecuritiesExchangeSymbolAlltradesGetAsync<T>(Format format, Exchange exchange,
            string? symbol, string? instrumentGroup, DateTime? from, DateTime? to, long? fromId, long? toId, int? qtyFrom,
            int? qtyTo, decimal? priceFrom, decimal? priceTo, Side? side, int? offset, int? take, bool? descending, 
            bool? includeVirtualTrades, CancellationToken cancellationToken)
        {
            if (string.IsNullOrEmpty(symbol))
                throw new ArgumentNullException(nameof(symbol));

            var uriBuilder = new UriBuilder(_baseUrl)
                             {
                                 Path = $"{_baseUrl.AbsolutePath.TrimEnd('/')}/md/v2/securities/{exchange}/{Uri.EscapeDataString(symbol)}/alltrades"
                             };


            var urlBuilder = new StringBuilder();

            urlBuilder.Append($"format={format}&");

            Utilities.Utilities.AppendQueryParam(urlBuilder, "instrumentGroup", instrumentGroup);
            Utilities.Utilities.AppendQueryParam(urlBuilder, "from", from?.GetUnixTimestampSecondsFromDateTime());
            Utilities.Utilities.AppendQueryParam(urlBuilder, "to", to?.GetUnixTimestampSecondsFromDateTime());
            Utilities.Utilities.AppendQueryParam(urlBuilder, "fromId", fromId);
            Utilities.Utilities.AppendQueryParam(urlBuilder, "toId", toId);
            Utilities.Utilities.AppendQueryParam(urlBuilder, "qtyFrom", qtyFrom);
            Utilities.Utilities.AppendQueryParam(urlBuilder, "qtyTo", qtyTo);
            Utilities.Utilities.AppendQueryParam(urlBuilder, "priceFrom", priceFrom);
            Utilities.Utilities.AppendQueryParam(urlBuilder, "priceTo", priceTo);
            Utilities.Utilities.AppendQueryParam(urlBuilder, "side", side);
            Utilities.Utilities.AppendQueryParam(urlBuilder, "offset", offset);
            Utilities.Utilities.AppendQueryParam(urlBuilder, "take", take);
            Utilities.Utilities.AppendQueryParam(urlBuilder, "descending", descending);
            Utilities.Utilities.AppendQueryParam(urlBuilder, "includeVirtualTrades", includeVirtualTrades);

            urlBuilder.Length--;
            uriBuilder.Query = urlBuilder.ToString();

            return _apiHttpClient.ProcessRequest<T>(HttpMethod.Get, uriBuilder.Uri, cancellationToken, needAuthorization: true);
        }

        private Task<T> MdV2SecuritiesExchangeSymbolAlltradesHistoryGetAsync<T>(Format format, Exchange exchange,
            string? symbol, int? limit, string? instrumentGroup, DateTime? from, DateTime? to, int? offset,
            CancellationToken cancellationToken)
        {
            if (string.IsNullOrEmpty(symbol))
                throw new ArgumentNullException(nameof(symbol));

            if (limit == null)
                throw new ArgumentNullException(nameof(limit));

            var uriBuilder = new UriBuilder(_baseUrl)
                             {
                                 Path = $"{_baseUrl.AbsolutePath.TrimEnd('/')}/md/v2/securities/{exchange}/{Uri.EscapeDataString(symbol)}/alltrades/history"
                             };

            var urlBuilder = new StringBuilder();

            urlBuilder.Append($"format={format}&");

            Utilities.Utilities.AppendQueryParam(urlBuilder, "instrumentGroup", instrumentGroup);
            Utilities.Utilities.AppendQueryParam(urlBuilder, "from", from?.GetUnixTimestampSecondsFromDateTime());
            Utilities.Utilities.AppendQueryParam(urlBuilder, "to", to?.GetUnixTimestampSecondsFromDateTime());
            Utilities.Utilities.AppendQueryParam(urlBuilder, "limit", limit);
            Utilities.Utilities.AppendQueryParam(urlBuilder, "offset", offset);

            urlBuilder.Length--;
            uriBuilder.Query = urlBuilder.ToString();

            return _apiHttpClient.ProcessRequest<T>(HttpMethod.Get, uriBuilder.Uri, cancellationToken, needAuthorization: true);
        }

        private Task<T> MdV2SecuritiesExchangeSymbolActualFuturesQuoteGetAsync<T>(Format format, Exchange exchange,
            string? symbol, CancellationToken cancellationToken)
        {
            if (string.IsNullOrEmpty(symbol))
                throw new ArgumentNullException(nameof(symbol));
            
            var uriBuilder = new UriBuilder(_baseUrl)
                             {
                                 Path = $"{_baseUrl.AbsolutePath.TrimEnd('/')}/md/v2/securities/{exchange}/{Uri.EscapeDataString(symbol)}/actualFuturesQuote",
                                 Query = $"format={format}"
                             };

            return _apiHttpClient.ProcessRequest<T>(HttpMethod.Get, uriBuilder.Uri, cancellationToken, needAuthorization: true);
        }

        private Task<RiskRates> MdV2RiskRatesGetAsync(Exchange exchange, string? ticker, int? riskCategoryId,
            string? search, int? limit, int? offset, CancellationToken cancellationToken)
        {
            var uriBuilder = new UriBuilder(_baseUrl)
                             {
                                 Path = $"{_baseUrl.AbsolutePath.TrimEnd('/')}/md/v2/risk/rates"
                             };

            var urlBuilder = new StringBuilder();

            Utilities.Utilities.AppendQueryParam(urlBuilder, "exchange", exchange);
            Utilities.Utilities.AppendQueryParam(urlBuilder, "ticker", ticker);
            Utilities.Utilities.AppendQueryParam(urlBuilder, "riskCategoryId", riskCategoryId);
            Utilities.Utilities.AppendQueryParam(urlBuilder, "search", search);
            Utilities.Utilities.AppendQueryParam(urlBuilder, "limit", limit);
            Utilities.Utilities.AppendQueryParam(urlBuilder, "offset", offset);

            urlBuilder.Length--;
            uriBuilder.Query = urlBuilder.ToString();

            return _apiHttpClient.ProcessRequest<RiskRates>(HttpMethod.Get, uriBuilder.Uri, cancellationToken);
        }

        private Task<T> MdV2HistoryGetAsync<T>(Format format, string? symbol, Exchange exchange, string? tf,
            DateTime from, DateTime to, string? instrumentGroup, int? countBack, bool? untraded, bool? splitAdjust, CandleSliceMode? sliceMode, CancellationToken cancellationToken)
        {
            if (string.IsNullOrEmpty(symbol))
                throw new ArgumentNullException(nameof(symbol));

            if (string.IsNullOrEmpty(tf))
                throw new ArgumentNullException(nameof(tf));

            var uriBuilder = new UriBuilder(_baseUrl)
                             {
                                 Path = $"{_baseUrl.AbsolutePath.TrimEnd('/')}/md/v2/history"
                             };

            var urlBuilder = new StringBuilder();

            urlBuilder.Append($"format={format}&symbol={Uri.EscapeDataString(symbol)}&exchange={exchange}&tf={Uri.EscapeDataString(tf)}&from={from.GetUnixTimestampSecondsFromDateTime()}&to={to.GetUnixTimestampSecondsFromDateTime()}&");

            Utilities.Utilities.AppendQueryParam(urlBuilder, "instrumentGroup", instrumentGroup);
            Utilities.Utilities.AppendQueryParam(urlBuilder, "countBack", countBack);
            Utilities.Utilities.AppendQueryParam(urlBuilder, "untraded", untraded);
            Utilities.Utilities.AppendQueryParam(urlBuilder, "splitAdjust", splitAdjust);
            Utilities.Utilities.AppendQueryParam(urlBuilder, "sliceMode", sliceMode);

            urlBuilder.Length--;
            uriBuilder.Query = urlBuilder.ToString();

            return _apiHttpClient.ProcessRequest<T>(HttpMethod.Get, uriBuilder.Uri, cancellationToken);
        }

        private Task<ICollection<CurrencyPair>> MdV2SecuritiesCurrencyPairsGetAsync(CancellationToken cancellationToken)
        {
            var uriBuilder = new UriBuilder(_baseUrl)
                             {
                                 Path = $"{_baseUrl.AbsolutePath.TrimEnd('/')}/md/v2/securities/Currencypairs"
                             };
            
            return _apiHttpClient.ProcessRequest<ICollection<CurrencyPair>>(HttpMethod.Get, uriBuilder.Uri,
                cancellationToken);
        }
        #endregion
    }
}
