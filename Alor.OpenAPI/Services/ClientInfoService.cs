using Alor.OpenAPI.Enums;
using Alor.OpenAPI.Interfaces;
using Alor.OpenAPI.Models.Heavy;
using Alor.OpenAPI.Models.Simple;
using Alor.OpenAPI.Models.Slim;
using System.Text;

namespace Alor.OpenAPI.Services
{
    internal class ClientInfoService : IClientInfoService
    {
        private readonly IApiHttpClientService _apiHttpClient;
        private readonly Uri _baseUrl;
        private readonly CancellationTokenSource _cancellationTokenSource;


        internal ClientInfoService(IApiHttpClientService apiHttpClient, Uri baseUrl,
            CancellationTokenSource cancellationTokenSource)
        {
            _apiHttpClient = apiHttpClient;
            _baseUrl = baseUrl;
            _cancellationTokenSource = cancellationTokenSource;
        }

        #region ClientInfo Headers
        public Task<SummarySimple> MdV2ClientsExchangePortfolioSummaryGetSimpleAsync(Exchange exchange, string portfolio) =>
            MdV2ClientsExchangePortfolioSummaryGetAsync<SummarySimple>(Format.Simple, exchange, portfolio, _cancellationTokenSource.Token);

        public Task<SummarySlim> MdV2ClientsExchangePortfolioSummaryGetSlimAsync(Exchange exchange, string portfolio) =>
            MdV2ClientsExchangePortfolioSummaryGetAsync<SummarySlim>(Format.Slim, exchange, portfolio, _cancellationTokenSource.Token);

        public Task<SummaryHeavy> MdV2ClientsExchangePortfolioSummaryGetHeavyAsync(Exchange exchange, string portfolio) =>
            MdV2ClientsExchangePortfolioSummaryGetAsync<SummaryHeavy>(Format.Heavy, exchange, portfolio, _cancellationTokenSource.Token);

        public Task<ICollection<PositionSimple>> MdV2ClientsExchangePortfolioPositionsGetSimpleAsync(Exchange exchange, string portfolio, bool? withoutCurrency = null) =>
            MdV2ClientsExchangePortfolioPositionsGetAsync<ICollection<PositionSimple>>(Format.Simple, exchange, portfolio, withoutCurrency, _cancellationTokenSource.Token);

        public Task<ICollection<PositionSlim>> MdV2ClientsExchangePortfolioPositionsGetSlimAsync(Exchange exchange, string portfolio, bool? withoutCurrency = null) =>
            MdV2ClientsExchangePortfolioPositionsGetAsync<ICollection<PositionSlim>>(Format.Slim, exchange, portfolio, withoutCurrency, _cancellationTokenSource.Token);

        public Task<ICollection<PositionHeavy>> MdV2ClientsExchangePortfolioPositionsGetHeavyAsync(Exchange exchange, string portfolio, bool? withoutCurrency = null) =>
            MdV2ClientsExchangePortfolioPositionsGetAsync<ICollection<PositionHeavy>>(Format.Heavy, exchange, portfolio, withoutCurrency, _cancellationTokenSource.Token);

        public Task<ICollection<PositionSimple>> MdV2ClientsExchangePortfolioPositionsSymbolGetSimpleAsync(Exchange exchange, string portfolio, string symbol) =>
            MdV2ClientsExchangePortfolioPositionsSymbolGetAsync<ICollection<PositionSimple>>(Format.Simple, exchange, portfolio, symbol, _cancellationTokenSource.Token);

        public Task<ICollection<PositionSlim>> MdV2ClientsExchangePortfolioPositionsSymbolGetSlimAsync(Exchange exchange, string portfolio, string symbol) =>
            MdV2ClientsExchangePortfolioPositionsSymbolGetAsync<ICollection<PositionSlim>>(Format.Slim, exchange, portfolio, symbol, _cancellationTokenSource.Token);

        public Task<ICollection<PositionHeavy>> MdV2ClientsExchangePortfolioPositionsSymbolGetHeavyAsync(Exchange exchange, string portfolio, string symbol) =>
            MdV2ClientsExchangePortfolioPositionsSymbolGetAsync<ICollection<PositionHeavy>>(Format.Heavy, exchange, portfolio, symbol, _cancellationTokenSource.Token);

        public Task<ICollection<TradeSimple>> MdV2ClientsExchangePortfolioTradesGetSimpleAsync(Exchange exchange, string portfolio, bool? withRepo = null) =>
            MdV2ClientsExchangePortfolioTradesGetAsync<ICollection<TradeSimple>>(Format.Simple, exchange, portfolio, withRepo, _cancellationTokenSource.Token);

        public Task<ICollection<TradeSlim>> MdV2ClientsExchangePortfolioTradesGetSlimAsync(Exchange exchange, string portfolio, bool? withRepo = null) =>
            MdV2ClientsExchangePortfolioTradesGetAsync<ICollection<TradeSlim>>(Format.Slim, exchange, portfolio, withRepo, _cancellationTokenSource.Token);

        public Task<ICollection<TradeHeavy>> MdV2ClientsExchangePortfolioTradesGetHeavyAsync(Exchange exchange, string portfolio, bool? withRepo = null) =>
            MdV2ClientsExchangePortfolioTradesGetAsync<ICollection<TradeHeavy>>(Format.Heavy, exchange, portfolio, withRepo, _cancellationTokenSource.Token);

        public Task<ICollection<TradeSimple>> MdV2ClientsExchangePortfolioSymbolTradesGetSimpleAsync(Exchange exchange, string portfolio, string symbol, string instrumentGroup) =>
            MdV2ClientsExchangePortfolioSymbolTradesGetAsync<ICollection<TradeSimple>>(Format.Simple, exchange, portfolio, symbol, instrumentGroup, _cancellationTokenSource.Token);

        public Task<ICollection<TradeSlim>> MdV2ClientsExchangePortfolioSymbolTradesGetSlimAsync(Exchange exchange, string portfolio, string symbol, string instrumentGroup) =>
            MdV2ClientsExchangePortfolioSymbolTradesGetAsync<ICollection<TradeSlim>>(Format.Slim, exchange, portfolio, symbol, instrumentGroup, _cancellationTokenSource.Token);

        public Task<ICollection<TradeHeavy>> MdV2ClientsExchangePortfolioSymbolTradesGetHeavyAsync(Exchange exchange, string portfolio, string symbol, string instrumentGroup) =>
            MdV2ClientsExchangePortfolioSymbolTradesGetAsync<ICollection<TradeHeavy>>(Format.Heavy, exchange, portfolio, symbol, instrumentGroup, _cancellationTokenSource.Token);

        public Task<FortsriskSimple> MdV2ClientsExchangePortfolioFortsriskGetSimpleAsync(Exchange exchange, string portfolio) =>
            MdV2ClientsExchangePortfolioFortsriskGetAsync<FortsriskSimple>(Format.Simple, exchange, portfolio, _cancellationTokenSource.Token);

        public Task<FortsriskSlim> MdV2ClientsExchangePortfolioFortsriskGetSlimAsync(Exchange exchange, string portfolio) =>
            MdV2ClientsExchangePortfolioFortsriskGetAsync<FortsriskSlim>(Format.Slim, exchange, portfolio, _cancellationTokenSource.Token);

        public Task<FortsriskHeavy> MdV2ClientsExchangePortfolioFortsriskGetHeavyAsync(Exchange exchange, string portfolio) =>
            MdV2ClientsExchangePortfolioFortsriskGetAsync<FortsriskHeavy>(Format.Heavy, exchange, portfolio, _cancellationTokenSource.Token);

        public Task<RiskSimple> MdV2ClientsExchangePortfolioRiskGetSimpleAsync(Exchange exchange, string portfolio) =>
            MdV2ClientsExchangePortfolioRiskGetAsync<RiskSimple>(Format.Simple, exchange, portfolio, _cancellationTokenSource.Token);

        public Task<RiskSlim> MdV2ClientsExchangePortfolioRiskGetSlimAsync(Exchange exchange, string portfolio) =>
            MdV2ClientsExchangePortfolioRiskGetAsync<RiskSlim>(Format.Slim, exchange, portfolio, _cancellationTokenSource.Token);

        public Task<RiskHeavy> MdV2ClientsExchangePortfolioRiskGetHeavyAsync(Exchange exchange, string portfolio) =>
            MdV2ClientsExchangePortfolioRiskGetAsync<RiskHeavy>(Format.Heavy, exchange, portfolio, _cancellationTokenSource.Token);

        public Task<ICollection<TradeSimple>> MdV2StatsExchangePortfolioHistoryTradesGetSimpleAsync(Exchange exchange,
            string portfolio, string? instrumentGroup = null, string? dateFrom = null, string? ticker = null, int? from = null, int? limit = null, bool? orderByTradeDate = null, bool? descending = null, bool? withRepo = null, Side? side = null) =>
            MdV2StatsExchangePortfolioHistoryTradesGetAsync<ICollection<TradeSimple>>(Format.Simple, exchange, portfolio, instrumentGroup, dateFrom, ticker, from, limit, orderByTradeDate, descending, withRepo, side, _cancellationTokenSource.Token);

        public Task<ICollection<TradeSlim>> MdV2StatsExchangePortfolioHistoryTradesGetSlimAsync(Exchange exchange,
            string portfolio, string? instrumentGroup = null, string? dateFrom = null, string? ticker = null, int? from = null, int? limit = null, bool? orderByTradeDate = null, bool? descending = null, bool? withRepo = null, Side? side = null) =>
            MdV2StatsExchangePortfolioHistoryTradesGetAsync<ICollection<TradeSlim>>(Format.Slim, exchange, portfolio, instrumentGroup, dateFrom, ticker, from, limit, orderByTradeDate, descending, withRepo, side, _cancellationTokenSource.Token);

        public Task<ICollection<TradeHeavy>> MdV2StatsExchangePortfolioHistoryTradesGetHeavyAsync(Exchange exchange,
            string portfolio, string? instrumentGroup = null, string? dateFrom = null, string? ticker = null, int? from = null, int? limit = null, bool? orderByTradeDate = null, bool? descending = null, bool? withRepo = null, Side? side = null) =>
            MdV2StatsExchangePortfolioHistoryTradesGetAsync<ICollection<TradeHeavy>>(Format.Heavy, exchange, portfolio, instrumentGroup, dateFrom, ticker, from, limit, orderByTradeDate, descending, withRepo, side, _cancellationTokenSource.Token);

        public Task<ICollection<TradeSimple>> MdV2StatsExchangePortfolioHistoryTradesSymbolGetSimpleAsync(Exchange exchange,
            string portfolio, string symbol, string? instrumentGroup = null, string? dateFrom = null, int? from = null, int? limit = null, bool? orderByTradeDate = null, bool? descending = null, bool? withRepo = null, Side? side = null) =>
            MdV2StatsExchangePortfolioHistoryTradesSymbolGetAsync<ICollection<TradeSimple>>(Format.Simple, exchange, portfolio, instrumentGroup, symbol, dateFrom, from, limit,
                orderByTradeDate, descending, withRepo, side, _cancellationTokenSource.Token);

        public Task<ICollection<TradeSlim>> MdV2StatsExchangePortfolioHistoryTradesSymbolGetSlimAsync(Exchange exchange,
            string portfolio, string symbol, string? instrumentGroup = null, string? dateFrom = null, int? from = null, int? limit = null, bool? orderByTradeDate = null, bool? descending = null, bool? withRepo = null, Side? side = null) =>
            MdV2StatsExchangePortfolioHistoryTradesSymbolGetAsync<ICollection<TradeSlim>>(Format.Slim, exchange, portfolio, instrumentGroup, symbol, dateFrom, from, limit,
                orderByTradeDate, descending, withRepo, side, _cancellationTokenSource.Token);

        public Task<ICollection<TradeHeavy>> MdV2StatsExchangePortfolioHistoryTradesSymbolGetHeavyAsync(Exchange exchange,
            string portfolio, string symbol, string? instrumentGroup = null, string? dateFrom = null, int? from = null, int? limit = null, bool? orderByTradeDate = null, bool? descending = null, bool? withRepo = null, Side? side = null) =>
            MdV2StatsExchangePortfolioHistoryTradesSymbolGetAsync<ICollection<TradeHeavy>>(Format.Heavy, exchange, portfolio, instrumentGroup, symbol, dateFrom, from, limit,
                orderByTradeDate, descending, withRepo, side, _cancellationTokenSource.Token);

        public Task<ICollection<PositionSimple>> MdV2ClientsLoginPositionsGetSimpleAsync(string login, bool? withoutCurrency = null) =>
            MdV2ClientsLoginPositionsGetAsync<ICollection<PositionSimple>>(Format.Simple, login, withoutCurrency, _cancellationTokenSource.Token);

        public Task<ICollection<PositionSlim>> MdV2ClientsLoginPositionsGetSlimAsync(string login, bool? withoutCurrency = null) =>
            MdV2ClientsLoginPositionsGetAsync<ICollection<PositionSlim>>(Format.Slim, login, withoutCurrency, _cancellationTokenSource.Token);

        public Task<ICollection<PositionHeavy>> MdV2ClientsLoginPositionsGetHeavyAsync(string login, bool? withoutCurrency = null) =>
            MdV2ClientsLoginPositionsGetAsync<ICollection<PositionHeavy>>(Format.Heavy, login, withoutCurrency, _cancellationTokenSource.Token);
        #endregion

        #region ClientInfo Methods
        private Task<T> MdV2ClientsExchangePortfolioSummaryGetAsync<T>(Format format, Exchange exchange, string? portfolio,
            CancellationToken cancellationToken) where T : class
        {
            if (string.IsNullOrEmpty(portfolio))
                throw new ArgumentNullException(nameof(portfolio));

            var uriBuilder = new UriBuilder(_baseUrl)
            {
                Path = $"{_baseUrl.AbsolutePath.TrimEnd('/')}/md/v2/clients/{exchange}/{Uri.EscapeDataString(portfolio)}/summary",
                Query = $"format={format}",
            };

            return _apiHttpClient.ProcessRequest<T>(HttpMethod.Get, uriBuilder.Uri, cancellationToken, needAuthorization: true);
        }

        private Task<T> MdV2ClientsExchangePortfolioPositionsGetAsync<T>(Format format, Exchange exchange,
            string? portfolio, bool? withoutCurrency, CancellationToken cancellationToken) where T : class
        {
            if (string.IsNullOrEmpty(portfolio))
                throw new ArgumentNullException(nameof(portfolio));

            var uriBuilder = new UriBuilder(_baseUrl)
            {
                Path = $"{_baseUrl.AbsolutePath.TrimEnd('/')}/md/v2/clients/{exchange}/{Uri.EscapeDataString(portfolio)}/positions",
            };

            var urlBuilder = new StringBuilder();

            urlBuilder.Append($"format={format}&");

            Utilities.Utilities.AppendQueryParam(urlBuilder, "withoutCurrency", withoutCurrency);

            urlBuilder.Length--;
            uriBuilder.Query = urlBuilder.ToString();

            return _apiHttpClient.ProcessRequest<T>(HttpMethod.Get, uriBuilder.Uri, cancellationToken, needAuthorization: true);
        }

        private Task<T> MdV2ClientsExchangePortfolioPositionsSymbolGetAsync<T>(Format format, Exchange exchange,
            string? portfolio, string? symbol, CancellationToken cancellationToken)
        {
            if (string.IsNullOrEmpty(portfolio))
                throw new ArgumentNullException(nameof(portfolio));

            if (string.IsNullOrEmpty(symbol))
                throw new ArgumentNullException(nameof(symbol));

            var uriBuilder = new UriBuilder(_baseUrl)
            {
                Path = $"{_baseUrl.AbsolutePath.TrimEnd('/')}/md/v2/clients/{exchange}/{Uri.EscapeDataString(portfolio)}/positions/{Uri.EscapeDataString(symbol)}",
                Query = $"format={format}",
            };

            return _apiHttpClient.ProcessRequest<T>(HttpMethod.Get, uriBuilder.Uri, cancellationToken, needAuthorization: true);
        }

        private Task<T> MdV2ClientsExchangePortfolioTradesGetAsync<T>(Format format, Exchange exchange, string? portfolio, bool? withRepo, CancellationToken cancellationToken)
        {
            if (string.IsNullOrEmpty(portfolio))
                throw new ArgumentNullException(nameof(portfolio));

            var uriBuilder = new UriBuilder(_baseUrl)
                             {
                                 Path = $"{_baseUrl.AbsolutePath.TrimEnd('/')}/md/v2/clients/{exchange}/{Uri.EscapeDataString(portfolio)}/trades",
                             };

            var urlBuilder = new StringBuilder();

            urlBuilder.Append($"format={format}&");

            Utilities.Utilities.AppendQueryParam(urlBuilder, "withRepo", withRepo);

            urlBuilder.Length--;
            uriBuilder.Query = urlBuilder.ToString();

            return _apiHttpClient.ProcessRequest<T>(HttpMethod.Get, uriBuilder.Uri, cancellationToken, needAuthorization: true);
        }

        private Task<T> MdV2ClientsExchangePortfolioSymbolTradesGetAsync<T>(Format format, Exchange exchange, string? portfolio, string? symbol, string? instrumentGroup, CancellationToken cancellationToken)
        {
            if (string.IsNullOrEmpty(portfolio))
                throw new ArgumentNullException(nameof(portfolio));

            if (string.IsNullOrEmpty(symbol))
                throw new ArgumentNullException(nameof(symbol));

            var uriBuilder = new UriBuilder(_baseUrl)
                             {
                                 Path = $"{_baseUrl.AbsolutePath.TrimEnd('/')}/md/v2/clients/{exchange}/{Uri.EscapeDataString(portfolio)}/{Uri.EscapeDataString(symbol)}/trades",
                             };

            var urlBuilder = new StringBuilder();

            urlBuilder.Append($"format={format}&");

            Utilities.Utilities.AppendQueryParam(urlBuilder, "instrumentGroup", instrumentGroup);

            urlBuilder.Length--;
            uriBuilder.Query = urlBuilder.ToString();

            return _apiHttpClient.ProcessRequest<T>(HttpMethod.Get, uriBuilder.Uri, cancellationToken, needAuthorization: true);
        }

        private Task<T> MdV2ClientsExchangePortfolioFortsriskGetAsync<T>(Format format, Exchange exchange, string? portfolio, CancellationToken cancellationToken)
        {
            if (string.IsNullOrEmpty(portfolio))
                throw new ArgumentNullException(nameof(portfolio));

            var uriBuilder = new UriBuilder(_baseUrl)
                             {
                                 Path = $"{_baseUrl.AbsolutePath.TrimEnd('/')}/md/v2/clients/{exchange}/{Uri.EscapeDataString(portfolio)}/fortsrisk",
                                 Query = $"format={format}"
                             };

            return _apiHttpClient.ProcessRequest<T>(HttpMethod.Get, uriBuilder.Uri, cancellationToken, needAuthorization: true);
        }

        private Task<T> MdV2ClientsExchangePortfolioRiskGetAsync<T>(Format format, Exchange exchange, string? portfolio, CancellationToken cancellationToken)
        {
            if (string.IsNullOrEmpty(portfolio))
                throw new ArgumentNullException(nameof(portfolio));

            var uriBuilder = new UriBuilder(_baseUrl)
                             {
                                 Path = $"{_baseUrl.AbsolutePath.TrimEnd('/')}/md/v2/clients/{exchange}/{Uri.EscapeDataString(portfolio)}/risk",
                                 Query = $"format={format}"
                             };

            return _apiHttpClient.ProcessRequest<T>(HttpMethod.Get, uriBuilder.Uri, cancellationToken, needAuthorization: true);
        }

        private Task<T> MdV2StatsExchangePortfolioHistoryTradesGetAsync<T>(Format format, Exchange exchange,
            string? portfolio, string? instrumentGroup, string? dateFrom, string? ticker, int? from, int? limit, bool? orderByTradeDate, bool? descending, bool? withRepo, Side? side, CancellationToken cancellationToken)
        {
            if (string.IsNullOrEmpty(portfolio))
                throw new ArgumentNullException(nameof(portfolio));

            var uriBuilder = new UriBuilder(_baseUrl)
                             {
                                 Path = $"{_baseUrl.AbsolutePath.TrimEnd('/')}/md/v2/stats/{exchange}/{Uri.EscapeDataString(portfolio)}/history/trades",
                             };

            var urlBuilder = new StringBuilder();

            urlBuilder.Append($"format={format}&");

            Utilities.Utilities.AppendQueryParam(urlBuilder, "instrumentGroup", instrumentGroup);
            Utilities.Utilities.AppendQueryParam(urlBuilder, "dateFrom", dateFrom);
            Utilities.Utilities.AppendQueryParam(urlBuilder, "ticker", ticker);
            Utilities.Utilities.AppendQueryParam(urlBuilder, "from", from);
            Utilities.Utilities.AppendQueryParam(urlBuilder, "limit", limit);
            Utilities.Utilities.AppendQueryParam(urlBuilder, "orderByTradeDate", orderByTradeDate);
            Utilities.Utilities.AppendQueryParam(urlBuilder, "descending", descending);
            Utilities.Utilities.AppendQueryParam(urlBuilder, "withRepo", withRepo);
            Utilities.Utilities.AppendQueryParam(urlBuilder, "side", side);

            urlBuilder.Length--;
            uriBuilder.Query = urlBuilder.ToString();
            
            return _apiHttpClient.ProcessRequest<T>(HttpMethod.Get, uriBuilder.Uri, cancellationToken, needAuthorization: true);
        }

        private Task<T> MdV2StatsExchangePortfolioHistoryTradesSymbolGetAsync<T>(Format format, Exchange exchange,
            string? portfolio, string? instrumentGroup, string? symbol, string? dateFrom, int? from, int? limit, bool? orderByTradeDate, bool? descending, bool? withRepo, Side? side, CancellationToken cancellationToken)
        {
            if (string.IsNullOrEmpty(portfolio))
                throw new ArgumentNullException(nameof(portfolio));

            if (string.IsNullOrEmpty(symbol))
                throw new ArgumentNullException(nameof(symbol));

            var uriBuilder = new UriBuilder(_baseUrl)
                             {
                                 Path = $"{_baseUrl.AbsolutePath.TrimEnd('/')}/md/v2/stats/{exchange}/{Uri.EscapeDataString(portfolio)}/history/trades/{Uri.EscapeDataString(symbol)}",
                             };

            var urlBuilder = new StringBuilder();

            urlBuilder.Append($"format={format}&");

            Utilities.Utilities.AppendQueryParam(urlBuilder, "instrumentGroup", instrumentGroup);
            Utilities.Utilities.AppendQueryParam(urlBuilder, "dateFrom", dateFrom);
            Utilities.Utilities.AppendQueryParam(urlBuilder, "from", from);
            Utilities.Utilities.AppendQueryParam(urlBuilder, "limit", limit);
            Utilities.Utilities.AppendQueryParam(urlBuilder, "orderByTradeDate", orderByTradeDate);
            Utilities.Utilities.AppendQueryParam(urlBuilder, "descending", descending);
            Utilities.Utilities.AppendQueryParam(urlBuilder, "withRepo", withRepo);
            Utilities.Utilities.AppendQueryParam(urlBuilder, "side", side);

            urlBuilder.Length--;
            uriBuilder.Query = urlBuilder.ToString();

            return _apiHttpClient.ProcessRequest<T>(HttpMethod.Get, uriBuilder.Uri, cancellationToken, needAuthorization: true);
        }

        private Task<T> MdV2ClientsLoginPositionsGetAsync<T>(Format format, string? login, bool? withoutCurrency, CancellationToken cancellationToken)
        {

            if (string.IsNullOrEmpty(login))
                throw new ArgumentNullException(nameof(login));

            var uriBuilder = new UriBuilder(_baseUrl)
                             {
                                 Path = $"{_baseUrl.AbsolutePath.TrimEnd('/')}/md/v2/clients/{Uri.EscapeDataString(login)}/positions",
                             };

            var urlBuilder = new StringBuilder();

            urlBuilder.Append($"format={format}&");

            Utilities.Utilities.AppendQueryParam(urlBuilder, "withoutCurrency", withoutCurrency);

            urlBuilder.Length--;
            uriBuilder.Query = urlBuilder.ToString();

            return _apiHttpClient.ProcessRequest<T>(HttpMethod.Get, uriBuilder.Uri, cancellationToken, needAuthorization: true);
        }
        #endregion
    }
}
