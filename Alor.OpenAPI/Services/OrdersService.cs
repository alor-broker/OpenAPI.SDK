using Alor.OpenAPI.Enums;
using Alor.OpenAPI.Interfaces;
using Alor.OpenAPI.Models;
using Alor.OpenAPI.Models.Heavy;
using Alor.OpenAPI.Models.Simple;
using Alor.OpenAPI.Models.Slim;
using SpanJson;
using System.Text;

namespace Alor.OpenAPI.Services
{
    internal class OrdersService : IOrdersService
    {
        private readonly IApiHttpClientService _apiHttpClient;
        private readonly Uri _baseUrl;
        private readonly CancellationTokenSource _cancellationTokenSource;


        internal OrdersService(IApiHttpClientService apiHttpClient, Uri baseUrl,
            CancellationTokenSource cancellationTokenSource)
        {
            _apiHttpClient = apiHttpClient;
            _baseUrl = baseUrl;
            _cancellationTokenSource = cancellationTokenSource;
        }

        #region Orders Headers
        public Task<OrderSimple> MdV2ClientsExchangePortfolioOrdersOrderIdGetSimpleAsync(Exchange exchange, string portfolio, int orderId) =>
            MdV2ClientsExchangePortfolioOrdersOrderIdGetAsync<OrderSimple>(Format.Simple, exchange, portfolio, orderId, _cancellationTokenSource.Token);

        public Task<OrderSlim> MdV2ClientsExchangePortfolioOrdersOrderIdGetSlimAsync(Exchange exchange, string portfolio, int orderId) =>
            MdV2ClientsExchangePortfolioOrdersOrderIdGetAsync<OrderSlim>(Format.Slim, exchange, portfolio, orderId, _cancellationTokenSource.Token);

        public Task<OrderHeavy> MdV2ClientsExchangePortfolioOrdersOrderIdGetHeavyAsync(Exchange exchange, string portfolio, int orderId) =>
            MdV2ClientsExchangePortfolioOrdersOrderIdGetAsync<OrderHeavy>(Format.Heavy, exchange, portfolio, orderId, _cancellationTokenSource.Token);

        public Task<ICollection<OrderSimple>> MdV2ClientsExchangePortfolioOrdersGetSimpleAsync(Exchange exchange, string portfolio) =>
            MdV2ClientsExchangePortfolioOrdersGetAsync<ICollection<OrderSimple>>(Format.Simple, exchange, portfolio, _cancellationTokenSource.Token);

        public Task<ICollection<OrderSlim>> MdV2ClientsExchangePortfolioOrdersGetSlimAsync(Exchange exchange, string portfolio) =>
            MdV2ClientsExchangePortfolioOrdersGetAsync<ICollection<OrderSlim>>(Format.Slim, exchange, portfolio, _cancellationTokenSource.Token);

        public Task<ICollection<OrderHeavy>> MdV2ClientsExchangePortfolioOrdersGetHeavyAsync(Exchange exchange, string portfolio) =>
            MdV2ClientsExchangePortfolioOrdersGetAsync<ICollection<OrderHeavy>>(Format.Heavy, exchange, portfolio, _cancellationTokenSource.Token);

        public Task<OrderActionLimitMarket> CommandapiWarptransTradeV2ClientOrdersActionsMarketPostAsync(string portfolio, Side side, int quantity, string symbol, Exchange exchange, string? instrumentGroup = null, string? comment = null, TimeInForce timeInForce = TimeInForce.OneDay, bool? allowMargin = null) =>
            CommandapiWarptransTradeV2ClientOrdersActionsMarketPostAsync(side, quantity, symbol, exchange, instrumentGroup, portfolio, timeInForce, comment, allowMargin, _cancellationTokenSource.Token);

        public Task<OrderActionLimitMarket> CommandapiWarptransTradeV2ClientOrdersActionsLimitPostAsync(string portfolio, Side side, int quantity, decimal price, string symbol, Exchange exchange, string? instrumentGroup = null, string? comment = null, TimeInForce timeInForce = TimeInForce.OneDay, int? icebergFixed = null, decimal? icebergVariance = null, bool? allowMargin = null) =>
            CommandapiWarptransTradeV2ClientOrdersActionsLimitPostAsync(side, quantity, price, symbol, exchange, instrumentGroup, portfolio, comment, timeInForce, icebergFixed, icebergVariance, allowMargin, _cancellationTokenSource.Token);

        public Task<OrderActionLimitMarket> CommandapiWarptransTradeV2ClientOrdersActionsMarketOrderIdPutAsync(int orderId, string portfolio, Side side, int quantity, string symbol, Exchange exchange, string? instrumentGroup = null, string? comment = null, TimeInForce timeInForce = TimeInForce.OneDay, bool? allowMargin = null) =>
            CommandapiWarptransTradeV2ClientOrdersActionsMarketOrderIdPutAsync(orderId, side, quantity, symbol, exchange, instrumentGroup, portfolio, comment, timeInForce, allowMargin, _cancellationTokenSource.Token);

        public Task<OrderActionLimitMarket> CommandapiWarptransTradeV2ClientOrdersActionsLimitOrderIdPutAsync(int orderId, string portfolio, Side side, int quantity, decimal price, string symbol, Exchange exchange, string? instrumentGroup = null, string? comment = null, int? icebergFixed = null, bool? allowMargin = null) =>
            CommandapiWarptransTradeV2ClientOrdersActionsLimitOrderIdPutAsync(orderId, side, quantity, price, symbol, exchange, instrumentGroup, portfolio, comment, icebergFixed, allowMargin, _cancellationTokenSource.Token);

        public Task<ResponseEstimateOrder> CommandapiWarptransTradeV2ClientOrdersEstimatePostAsync(string portfolio, string ticker, Exchange exchange, decimal? price, int? lotQuantity, decimal? budget, string? board, bool? includeLimitOrders) =>
            CommandapiWarptransTradeV2ClientOrdersEstimatePostAsync(portfolio, ticker, exchange, price, lotQuantity, budget, board, includeLimitOrders, _cancellationTokenSource.Token);

        public Task<ICollection<ResponseEstimateOrder>> CommandapiWarptransTradeV2ClientOrdersEstimateAllPostAsync(ICollection<RequestEstimateOrder> collectionEstimateOrders) =>
            CommandapiWarptransTradeV2ClientOrdersEstimateAllPostAsync(collectionEstimateOrders, _cancellationTokenSource.Token);

        public Task<string> CommandapiWarptransTradeV2ClientOrdersOrderIdDeleteAsync(int orderId, string? portfolio, Exchange exchange, bool stop) =>
            CommandapiWarptransTradeV2ClientOrdersOrderIdDeleteAsync(orderId, portfolio, exchange, stop, _cancellationTokenSource.Token);

        public Task<string> CommandapiWarptransTradeV2ClientOrdersAllDeleteAsync(string? portfolio, Exchange exchange, bool stop) =>
            CommandapiWarptransTradeV2ClientOrdersAllDeleteAsync(portfolio, exchange, stop, _cancellationTokenSource.Token);
        #endregion

        #region Orders Methods
        private Task<T> MdV2ClientsExchangePortfolioOrdersGetAsync<T>(Format format, Exchange exchange, string? portfolio, CancellationToken cancellationToken)
        {
            if (string.IsNullOrEmpty(portfolio))
                throw new ArgumentNullException(nameof(portfolio));

            var uriBuilder = new UriBuilder(_baseUrl)
                             {
                                 Path = $"{_baseUrl.AbsolutePath.TrimEnd('/')}/md/v2/clients/{exchange}/{Uri.EscapeDataString(portfolio)}/orders",
                                 Query = $"format={format}"
                             };

            return _apiHttpClient.ProcessRequest<T>(HttpMethod.Get, uriBuilder.Uri, cancellationToken, needAuthorization: true);
        }

        private Task<T> MdV2ClientsExchangePortfolioOrdersOrderIdGetAsync<T>(Format format, Exchange exchange, string? portfolio, int orderId, CancellationToken cancellationToken)
        {
            if (string.IsNullOrEmpty(portfolio))
                throw new ArgumentNullException(nameof(portfolio));

            var uriBuilder = new UriBuilder(_baseUrl)
                             {
                                 Path = $"{_baseUrl.AbsolutePath.TrimEnd('/')}/md/v2/clients/{exchange}/{Uri.EscapeDataString(portfolio)}/orders/{orderId}",
                                 Query = $"format={format}"
                             };

            return _apiHttpClient.ProcessRequest<T>(HttpMethod.Get, uriBuilder.Uri, cancellationToken, needAuthorization: true);
        }

        private Task<OrderActionLimitMarket> CommandapiWarptransTradeV2ClientOrdersActionsMarketPostAsync(Side side,
            int quantity, string? symbol, Exchange exchange, string? instrumentGroup, string? portfolio, TimeInForce timeInForce, string? comment,
            bool? allowMargin, CancellationToken cancellationToken)
        {
            if (string.IsNullOrEmpty(symbol))
                throw new ArgumentNullException(nameof(symbol));
            if (string.IsNullOrEmpty(portfolio))
                throw new ArgumentNullException(nameof(portfolio));

            var order = new RequestOrdersActionsMarketTv(side, quantity, new Instrument(symbol, exchange, instrumentGroup), comment,
                new User(portfolio), timeInForce, allowMargin);
            var body = order.ToJson();

            var uriBuilder = new UriBuilder(_baseUrl)
                             {
                                 Path = $"{_baseUrl.AbsolutePath.TrimEnd('/')}commandapi/warptrans/TRADE/v2/client/orders/actions/market",
                             };

            return _apiHttpClient.ProcessRequest<OrderActionLimitMarket>(HttpMethod.Post, uriBuilder.Uri, cancellationToken, body: body, needXReqid: true, needAuthorization: true);
        }

        private Task<OrderActionLimitMarket> CommandapiWarptransTradeV2ClientOrdersActionsLimitPostAsync(Side side, int quantity, decimal price, string? symbol,
            Exchange exchange, string? instrumentGroup, string? portfolio, string? comment, TimeInForce timeInForce, int? icebergFixed, decimal? icebergVariance,
            bool? allowMargin, CancellationToken cancellationToken)
        {
            if (string.IsNullOrEmpty(symbol))
                throw new ArgumentNullException(nameof(symbol));
            if (string.IsNullOrEmpty(portfolio))
                throw new ArgumentNullException(nameof(portfolio));

            var order = new RequestOrdersActionsLimitTv(side, quantity, price, new Instrument(symbol, exchange, instrumentGroup),
                comment, new User(portfolio), timeInForce, icebergFixed, icebergVariance, allowMargin);
            var body = order.ToJson();

            var uriBuilder = new UriBuilder(_baseUrl)
                             {
                                 Path = $"{_baseUrl.AbsolutePath.TrimEnd('/')}/commandapi/warptrans/TRADE/v2/client/orders/actions/limit",
                             };

            return _apiHttpClient.ProcessRequest<OrderActionLimitMarket>(HttpMethod.Post, uriBuilder.Uri, cancellationToken, body: body, needXReqid: true, needAuthorization: true);
        }

        private Task<OrderActionLimitMarket> CommandapiWarptransTradeV2ClientOrdersActionsMarketOrderIdPutAsync(
            int orderId, Side side, int quantity, string? symbol, Exchange exchange, string? instrumentGroup, string? portfolio, string? comment, TimeInForce timeInForce,
            bool? allowMargin, CancellationToken cancellationToken)
        {
            if (string.IsNullOrEmpty(symbol))
                throw new ArgumentNullException(nameof(symbol));
            if (string.IsNullOrEmpty(portfolio))
                throw new ArgumentNullException(nameof(portfolio));

            var order = new RequestOrdersActionsMarketTv(side, quantity, new Instrument(symbol, exchange, instrumentGroup), comment,
                new User(portfolio), timeInForce, allowMargin);
            var body = order.ToJson();

            var uriBuilder = new UriBuilder(_baseUrl)
                             {
                                 Path = $"{_baseUrl.AbsolutePath.TrimEnd('/')}/commandapi/warptrans/TRADE/v2/client/orders/actions/market/{orderId}",
                             };

            return _apiHttpClient.ProcessRequest<OrderActionLimitMarket>(HttpMethod.Put, uriBuilder.Uri, cancellationToken, body: body, needXReqid: true, needAuthorization: true);
        }

        private Task<OrderActionLimitMarket> CommandapiWarptransTradeV2ClientOrdersActionsLimitOrderIdPutAsync(
            int orderId, Side side, int quantity, decimal price, string? symbol, Exchange exchange,
            string? instrumentGroup, string? portfolio, string? comment, int? icebergFixed,
            bool? allowMargin, CancellationToken cancellationToken)
        {
            if (string.IsNullOrEmpty(symbol))
                throw new ArgumentNullException(nameof(symbol));
            if (string.IsNullOrEmpty(portfolio))
                throw new ArgumentNullException(nameof(portfolio));

            var order = new RequestOrdersActionsLimitTv(side, quantity, price,
                new Instrument(symbol, exchange, instrumentGroup),
                comment, new User(portfolio), null, icebergFixed, null, allowMargin);
            var body = order.ToJson();

            var uriBuilder = new UriBuilder(_baseUrl)
            {
                Path =
                    $"{_baseUrl.AbsolutePath.TrimEnd('/')}/commandapi/warptrans/TRADE/v2/client/orders/actions/limit/{orderId}",
            };

            return _apiHttpClient.ProcessRequest<OrderActionLimitMarket>(HttpMethod.Put, uriBuilder.Uri,
                cancellationToken, body: body, needXReqid: true, needAuthorization: true);
        }

        private Task<ResponseEstimateOrder> CommandapiWarptransTradeV2ClientOrdersEstimatePostAsync(string? portfolio,
            string? ticker, Exchange exchange, decimal? price, int? lotQuantity, decimal? budget, string? board, bool? includeLimitOrders,
            CancellationToken cancellationToken)
        {
            if (string.IsNullOrEmpty(ticker))
                throw new ArgumentNullException(nameof(ticker));
            if (string.IsNullOrEmpty(portfolio))
                throw new ArgumentNullException(nameof(portfolio));

            var estimateOrder = new RequestEstimateOrder(portfolio, ticker, exchange, price, lotQuantity, budget, board,
                includeLimitOrders);
            var body = estimateOrder.ToJson();

            var uriBuilder = new UriBuilder(_baseUrl)
                             {
                                 Path = $"{_baseUrl.AbsolutePath.TrimEnd('/')}/commandapi/warptrans/TRADE/v2/client/orders/estimate",
                             };

            return _apiHttpClient.ProcessRequest<ResponseEstimateOrder>(HttpMethod.Post, uriBuilder.Uri, cancellationToken, body: body, needAuthorization: true);
        }

        private Task<ICollection<ResponseEstimateOrder>> CommandapiWarptransTradeV2ClientOrdersEstimateAllPostAsync(
            ICollection<RequestEstimateOrder> collectionEstimateOrders, CancellationToken cancellationToken)
        {
            var body = Encoding.UTF8.GetString(
                JsonSerializer.Generic.Utf8.Serialize(collectionEstimateOrders));

            var uriBuilder = new UriBuilder(_baseUrl)
                             {
                                 Path = $"{_baseUrl.AbsolutePath.TrimEnd('/')}/commandapi/warptrans/TRADE/v2/client/orders/estimate/all",
                             };

            return _apiHttpClient.ProcessRequest<ICollection<ResponseEstimateOrder>>(HttpMethod.Post, uriBuilder.Uri,
                cancellationToken, body: body, needAuthorization: true);
        }

        private Task<string> CommandapiWarptransTradeV2ClientOrdersOrderIdDeleteAsync(int orderId, string? portfolio, Exchange exchange, bool stop, CancellationToken cancellationToken)
        {
            if (string.IsNullOrEmpty(portfolio))
                throw new ArgumentNullException(nameof(portfolio));

            var uriBuilder = new UriBuilder(_baseUrl)
                             {
                                 Path = $"{_baseUrl.AbsolutePath.TrimEnd('/')}/commandapi/warptrans/TRADE/v2/client/orders/{orderId}",
                                 Query = $"portfolio={Uri.EscapeDataString(portfolio)}&exchange={exchange}&stop={stop}"
                             };

            return _apiHttpClient.ProcessRequest<string>(HttpMethod.Delete, uriBuilder.Uri, cancellationToken, needAuthorization: true);
        }

        private Task<string> CommandapiWarptransTradeV2ClientOrdersAllDeleteAsync(string? portfolio, Exchange exchange, bool stop, CancellationToken cancellationToken)
        {
            if (string.IsNullOrEmpty(portfolio))
                throw new ArgumentNullException(nameof(portfolio));

            var uriBuilder = new UriBuilder(_baseUrl)
                             {
                                 Path = $"{_baseUrl.AbsolutePath.TrimEnd('/')}/commandapi/warptrans/TRADE/v2/client/orders/all",
                                 Query = $"portfolio={Uri.EscapeDataString(portfolio)}&exchange={exchange}&stop={stop}"
                             };

            return _apiHttpClient.ProcessRequest<string>(HttpMethod.Delete, uriBuilder.Uri, cancellationToken, needAuthorization: true);
        }
        #endregion
    }
}
