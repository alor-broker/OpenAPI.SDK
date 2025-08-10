using Alor.OpenAPI.Enums;
using Alor.OpenAPI.Extensions;
using Alor.OpenAPI.Interfaces;
using Alor.OpenAPI.Models;
using Alor.OpenAPI.Models.Heavy;
using Alor.OpenAPI.Models.Simple;
using Alor.OpenAPI.Models.Slim;

namespace Alor.OpenAPI.Services
{
    internal class StopOrdersService : IStopOrdersService
    {
        private readonly IApiHttpClientService _apiHttpClient;
        private readonly Uri _baseUrl;
        private readonly CancellationTokenSource _cancellationTokenSource;


        internal StopOrdersService(IApiHttpClientService apiHttpClient, Uri baseUrl,
            CancellationTokenSource cancellationTokenSource)
        {
            _apiHttpClient = apiHttpClient;
            _baseUrl = baseUrl;
            _cancellationTokenSource = cancellationTokenSource;
        }

        #region StopOrders Headers

        public Task<StopOrderSimple> MdV2ClientsExchangePortfolioStopOrdersOrderIdGetSimpleAsync(Exchange exchange,
            string portfolio, int orderId) =>
            MdV2ClientsExchangePortfolioStopOrdersOrderIdGetAsync<StopOrderSimple>(Format.Simple, exchange, portfolio,
                orderId, _cancellationTokenSource.Token);

        public Task<StopOrderSlim> MdV2ClientsExchangePortfolioStopOrdersOrderIdGetSlimAsync(Exchange exchange,
            string portfolio, int orderId) =>
            MdV2ClientsExchangePortfolioStopOrdersOrderIdGetAsync<StopOrderSlim>(Format.Slim, exchange, portfolio,
                orderId, _cancellationTokenSource.Token);

        public Task<StopOrderHeavy> MdV2ClientsExchangePortfolioStopOrdersOrderIdGetHeavyAsync(Exchange exchange,
            string portfolio, int orderId) =>
            MdV2ClientsExchangePortfolioStopOrdersOrderIdGetAsync<StopOrderHeavy>(Format.Heavy, exchange, portfolio,
                orderId, _cancellationTokenSource.Token);

        public Task<ICollection<StopOrderSimple>> MdV2ClientsExchangePortfolioStopOrdersGetSimpleAsync(
            Exchange exchange, string portfolio) =>
            MdV2ClientsExchangePortfolioStopOrdersGetAsync<ICollection<StopOrderSimple>>(Format.Simple, exchange,
                portfolio, _cancellationTokenSource.Token);

        public Task<ICollection<StopOrderSlim>> MdV2ClientsExchangePortfolioStopOrdersGetSlimAsync(Exchange exchange,
            string portfolio) =>
            MdV2ClientsExchangePortfolioStopOrdersGetAsync<ICollection<StopOrderSlim>>(Format.Slim, exchange, portfolio,
                _cancellationTokenSource.Token);

        public Task<ICollection<StopOrderHeavy>> MdV2ClientsExchangePortfolioStopOrdersGetHeavyAsync(Exchange exchange,
            string portfolio) =>
            MdV2ClientsExchangePortfolioStopOrdersGetAsync<ICollection<StopOrderHeavy>>(Format.Heavy, exchange,
                portfolio, _cancellationTokenSource.Token);

        public Task<OrderActionLimitMarket> CommandapiWarptransTradeV2ClientOrdersActionsStopPostAsync(string portfolio,
            Side side, Condition condition, decimal triggerPrice, DateTime stopEndUtcTime, int quantity,
            string symbol, Exchange exchange, string? instrumentGroup = null, int? protectingSeconds = null,
            bool? activate = null, bool? allowMargin = null, string? comment = null) =>
            CommandapiWarptransTradeV2ClientOrdersActionsStopPostAsync(side, condition, triggerPrice,
                stopEndUtcTime, quantity, symbol, exchange, portfolio, instrumentGroup, protectingSeconds, activate,
                allowMargin,
                comment, _cancellationTokenSource.Token);

        public Task<OrderActionLimitMarket> CommandapiWarptransTradeV2ClientOrdersActionsStopLimitPostAsync(
            string portfolio, Side side, Condition condition, decimal triggerPrice, DateTime stopEndUtcTime,
            int quantity, decimal price, string symbol, Exchange exchange, string? instrumentGroup = null,
            TimeInForce timeInForce = TimeInForce.OneDay, int? icebergFixed = null, decimal? icebergVariance = null,
            int? protectingSeconds = null, bool? activate = null, bool? allowMargin = null, string? comment = null) =>
            CommandapiWarptransTradeV2ClientOrdersActionsStopLimitPostAsync(side, condition, triggerPrice,
                stopEndUtcTime, quantity, price, symbol, exchange, portfolio, instrumentGroup, timeInForce,
                icebergFixed, icebergVariance, protectingSeconds, activate, allowMargin, comment,
                _cancellationTokenSource.Token);

        public Task<OrderActionLimitMarket> CommandapiWarptransTradeV2ClientOrdersActionsStopStopOrderIdPutAsync(
            int stopOrderId, string portfolio, Side side, Condition condition, decimal triggerPrice,
            DateTime stopEndUtcTime, int quantity, string symbol, Exchange exchange, string? instrumentGroup = null,
            int? protectingSeconds = null, bool? activate = null, bool? allowMargin = null, string? comment = null) =>
            CommandapiWarptransTradeV2ClientOrdersActionsStopStopOrderIdPutAsync(stopOrderId, side, condition,
                triggerPrice, stopEndUtcTime, quantity, symbol, exchange, portfolio, instrumentGroup, protectingSeconds,
                activate, allowMargin, comment, _cancellationTokenSource.Token);

        public Task<OrderActionLimitMarket> CommandapiWarptransTradeV2ClientOrdersActionsStopLimitStopOrderIdPutAsync(
            int stopOrderId, string portfolio, Side side, Condition condition, decimal triggerPrice,
            DateTime stopEndUtcTime, int quantity, decimal price, string symbol, Exchange exchange,
            string? instrumentGroup = null, TimeInForce timeInForce = TimeInForce.OneDay, int? icebergFixed = null,
            int? protectingSeconds = null, bool? activate = null, bool? allowMargin = null, string? comment = null) =>
            CommandapiWarptransTradeV2ClientOrdersActionsStopLimitStopOrderIdPutAsync(stopOrderId, side, condition,
                triggerPrice, stopEndUtcTime, quantity, price, symbol, exchange, portfolio, instrumentGroup,
                icebergFixed, protectingSeconds, activate, allowMargin, comment, _cancellationTokenSource.Token);

        #endregion

        #region StopOrders Methods

        private Task<T> MdV2ClientsExchangePortfolioStopOrdersGetAsync<T>(Format format, Exchange exchange,
            string? portfolio, CancellationToken cancellationToken)
        {
            if (string.IsNullOrEmpty(portfolio))
                throw new ArgumentNullException(nameof(portfolio));

            var uriBuilder = new UriBuilder(_baseUrl)
            {
                Path =
                    $"{_baseUrl.AbsolutePath.TrimEnd('/')}/md/v2/clients/{exchange}/{Uri.EscapeDataString(portfolio)}/stoporders",
                Query = $"format={format}"
            };

            return _apiHttpClient.ProcessRequest<T>(HttpMethod.Get, uriBuilder.Uri, cancellationToken,
                needAuthorization: true);
        }

        private Task<T> MdV2ClientsExchangePortfolioStopOrdersOrderIdGetAsync<T>(Format format, Exchange exchange,
            string? portfolio, int orderId, CancellationToken cancellationToken)
        {
            if (string.IsNullOrEmpty(portfolio))
                throw new ArgumentNullException(nameof(portfolio));

            var uriBuilder = new UriBuilder(_baseUrl)
            {
                Path =
                    $"{_baseUrl.AbsolutePath.TrimEnd('/')}/md/v2/clients/{exchange}/{Uri.EscapeDataString(portfolio)}/stoporders/{orderId}",
                Query = $"format={format}"
            };

            return _apiHttpClient.ProcessRequest<T>(HttpMethod.Get, uriBuilder.Uri, cancellationToken,
                needAuthorization: true);
        }

        private Task<OrderActionLimitMarket> CommandapiWarptransTradeV2ClientOrdersActionsStopPostAsync(
            Side side, Condition condition, decimal triggerPrice, DateTime stopEndUtcTime, int quantity,
            string? symbol, Exchange exchange, string? portfolio, string? instrumentGroup, int? protectingSeconds,
            bool? activate, bool? allowMargin, string? comment, CancellationToken cancellationToken)
        {
            if (string.IsNullOrEmpty(symbol))
                throw new ArgumentNullException(nameof(symbol));
            if (string.IsNullOrEmpty(portfolio))
                throw new ArgumentNullException(nameof(portfolio));

            var order = new RequestOrdersActionsStopMarketTvWarp(side, condition, triggerPrice,
                stopEndUtcTime.GetUnixTimestampSecondsFromDateTime(), quantity,
                new Instrument(symbol, exchange, instrumentGroup),
                new User(portfolio), protectingSeconds, comment, activate, allowMargin);
            var body = order.ToJson();

            var uriBuilder = new UriBuilder(_baseUrl)
            {
                Path = $"{_baseUrl.AbsolutePath.TrimEnd('/')}/commandapi/warptrans/TRADE/v2/client/orders/actions/stop",
            };

            return _apiHttpClient.ProcessRequest<OrderActionLimitMarket>(HttpMethod.Post, uriBuilder.Uri,
                cancellationToken, body: body, needXReqid: true, needAuthorization: true);
        }

        private Task<OrderActionLimitMarket> CommandapiWarptransTradeV2ClientOrdersActionsStopLimitPostAsync(
            Side side, Condition condition, decimal triggerPrice, DateTime stopEndUtcTime, int quantity,
            decimal price, string? symbol, Exchange exchange, string? portfolio, string? instrumentGroup,
            TimeInForce timeInForce, int? icebergFixed, decimal? icebergVariance, int? protectingSeconds,
            bool? activate, bool? allowMargin, string? comment, CancellationToken cancellationToken)
        {
            if (string.IsNullOrEmpty(symbol))
                throw new ArgumentNullException(nameof(symbol));
            if (string.IsNullOrEmpty(portfolio))
                throw new ArgumentNullException(nameof(portfolio));

            var order = new RequestOrdersActionsStopLimitTvWarp(side, condition, triggerPrice,
                stopEndUtcTime.GetUnixTimestampSecondsFromDateTime(), price, quantity,
                new Instrument(symbol, exchange, instrumentGroup),
                new User(portfolio), timeInForce, icebergFixed, icebergVariance, protectingSeconds, comment, activate,
                allowMargin);
            var body = order.ToJson();

            var uriBuilder = new UriBuilder(_baseUrl)
            {
                Path =
                    $"{_baseUrl.AbsolutePath.TrimEnd('/')}/commandapi/warptrans/TRADE/v2/client/orders/actions/stopLimit",
            };

            return _apiHttpClient.ProcessRequest<OrderActionLimitMarket>(HttpMethod.Post, uriBuilder.Uri,
                cancellationToken, body: body, needXReqid: true, needAuthorization: true);
        }

        private Task<OrderActionLimitMarket> CommandapiWarptransTradeV2ClientOrdersActionsStopStopOrderIdPutAsync(
            int stopOrderId, Side side, Condition condition, decimal triggerPrice, DateTime stopEndUtcTime,
            int quantity, string? symbol, Exchange exchange, string? portfolio, string? instrumentGroup,
            int? protectingSeconds, bool? activate, bool? allowMargin, string? comment,
            CancellationToken cancellationToken)
        {
            if (string.IsNullOrEmpty(symbol))
                throw new ArgumentNullException(nameof(symbol));
            if (string.IsNullOrEmpty(portfolio))
                throw new ArgumentNullException(nameof(portfolio));

            var order = new RequestOrdersActionsStopMarketTvWarp(side, condition, triggerPrice,
                stopEndUtcTime.GetUnixTimestampSecondsFromDateTime(), quantity,
                new Instrument(symbol, exchange, instrumentGroup),
                new User(portfolio), protectingSeconds, comment, activate, allowMargin);
            var body = order.ToJson();

            var uriBuilder = new UriBuilder(_baseUrl)
            {
                Path =
                    $"{_baseUrl.AbsolutePath.TrimEnd('/')}/commandapi/warptrans/TRADE/v2/client/orders/actions/stop/{stopOrderId}",
            };

            return _apiHttpClient.ProcessRequest<OrderActionLimitMarket>(HttpMethod.Post, uriBuilder.Uri,
                cancellationToken, body: body, needXReqid: true, needAuthorization: true);
        }

        private Task<OrderActionLimitMarket> CommandapiWarptransTradeV2ClientOrdersActionsStopLimitStopOrderIdPutAsync(
            int stopOrderId, Side side, Condition condition, decimal triggerPrice, DateTime stopEndUtcTime,
            int quantity, decimal price, string? symbol, Exchange exchange, string? portfolio, string? instrumentGroup,
            int? icebergFixed, int? protectingSeconds, bool? activate, bool? allowMargin, string? comment,
            CancellationToken cancellationToken)
        {
            if (string.IsNullOrEmpty(symbol))
                throw new ArgumentNullException(nameof(symbol));
            if (string.IsNullOrEmpty(portfolio))
                throw new ArgumentNullException(nameof(portfolio));

            var order = new RequestOrdersActionsStopLimitTvWarp(side, condition, triggerPrice,
                stopEndUtcTime.GetUnixTimestampSecondsFromDateTime(), price, quantity,
                new Instrument(symbol, exchange, instrumentGroup),
                new User(portfolio), null, icebergFixed, null, protectingSeconds, comment, activate,
                allowMargin);
            var body = order.ToJson();

            var uriBuilder = new UriBuilder(_baseUrl)
            {
                Path =
                    $"{_baseUrl.AbsolutePath.TrimEnd('/')}/commandapi/warptrans/TRADE/v2/client/orders/actions/stopLimit/{stopOrderId}",
            };

            return _apiHttpClient.ProcessRequest<OrderActionLimitMarket>(HttpMethod.Post, uriBuilder.Uri,
                cancellationToken, body: body, needXReqid: true, needAuthorization: true);
        }

        #endregion
    }
}