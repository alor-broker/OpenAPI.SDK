using Alor.OpenAPI.Core;
using Alor.OpenAPI.Enums;
using Alor.OpenAPI.Models;
using Alor.OpenAPI.Models.Heavy;
using Alor.OpenAPI.Models.Simple;
using Alor.OpenAPI.Models.Slim;

namespace Alor.OpenAPI.Interfaces
{
    public interface IOrdersService
    {
        /// <include file='../XmlDocs/IOrdersService.xml' path='Docs/Members[@name="IOrdersService"]/Member[@name="MdV2ClientsExchangePortfolioOrdersOrderIdGetSimpleAsync"]/*' />
        public Task<OrderSimple> MdV2ClientsExchangePortfolioOrdersOrderIdGetSimpleAsync(Exchange exchange,
            string portfolio, int orderId);

        /// <include file='../XmlDocs/IOrdersService.xml' path='Docs/Members[@name="IOrdersService"]/Member[@name="MdV2ClientsExchangePortfolioOrdersOrderIdGetSlimAsync"]/*' />
        public Task<OrderSlim> MdV2ClientsExchangePortfolioOrdersOrderIdGetSlimAsync(Exchange exchange,
            string portfolio, int orderId);

        /// <include file='../XmlDocs/IOrdersService.xml' path='Docs/Members[@name="IOrdersService"]/Member[@name="MdV2ClientsExchangePortfolioOrdersOrderIdGetHeavyAsync"]/*' />
        public Task<OrderHeavy> MdV2ClientsExchangePortfolioOrdersOrderIdGetHeavyAsync(Exchange exchange,
            string portfolio, int orderId);

        /// <include file='../XmlDocs/IOrdersService.xml' path='Docs/Members[@name="IOrdersService"]/Member[@name="MdV2ClientsExchangePortfolioOrdersGetSimpleAsync"]/*' />
        public Task<ICollection<OrderSimple>> MdV2ClientsExchangePortfolioOrdersGetSimpleAsync(Exchange exchange,
            string portfolio);

        /// <include file='../XmlDocs/IOrdersService.xml' path='Docs/Members[@name="IOrdersService"]/Member[@name="MdV2ClientsExchangePortfolioOrdersGetSlimAsync"]/*' />
        public Task<ICollection<OrderSlim>> MdV2ClientsExchangePortfolioOrdersGetSlimAsync(Exchange exchange,
            string portfolio);

        /// <include file='../XmlDocs/IOrdersService.xml' path='Docs/Members[@name="IOrdersService"]/Member[@name="MdV2ClientsExchangePortfolioOrdersGetHeavyAsync"]/*' />
        public Task<ICollection<OrderHeavy>> MdV2ClientsExchangePortfolioOrdersGetHeavyAsync(Exchange exchange,
            string portfolio);

        /// <include file='../XmlDocs/IOrdersService.xml' path='Docs/Members[@name="IOrdersService"]/Member[@name="CommandapiWarptransTradeV2ClientOrdersActionsMarketPostAsync"]/*' />
        public Task<OrderActionLimitMarket> CommandapiWarptransTradeV2ClientOrdersActionsMarketPostAsync(
            string portfolio, Side side, int quantity, string symbol, Exchange exchange, string? instrumentGroup = null, string? comment = null,
            TimeInForce timeInForce = TimeInForce.OneDay);

        /// <include file='../XmlDocs/IOrdersService.xml' path='Docs/Members[@name="IOrdersService"]/Member[@name="CommandapiWarptransTradeV2ClientOrdersActionsLimitPostAsync"]/*' />
        public Task<OrderActionLimitMarket> CommandapiWarptransTradeV2ClientOrdersActionsLimitPostAsync(
            string portfolio, Side side, int quantity, decimal price, string symbol, Exchange exchange,
            string? instrumentGroup = null, string? comment = null, TimeInForce timeInForce = TimeInForce.OneDay,
            int? icebergFixed = null, decimal? icebergVariance = null);

        /// <include file='../XmlDocs/IOrdersService.xml' path='Docs/Members[@name="IOrdersService"]/Member[@name="CommandapiWarptransTradeV2ClientOrdersActionsMarketOrderIdPutAsync"]/*' />
        public Task<OrderActionLimitMarket> CommandapiWarptransTradeV2ClientOrdersActionsMarketOrderIdPutAsync(
            int orderId, string portfolio, Side side, int quantity, string symbol, Exchange exchange,
            string? instrumentGroup = null, string? comment = null, TimeInForce timeInForce = TimeInForce.OneDay);

        /// <include file='../XmlDocs/IOrdersService.xml' path='Docs/Members[@name="IOrdersService"]/Member[@name="CommandapiWarptransTradeV2ClientOrdersActionsLimitOrderIdPutAsync"]/*' />
        public Task<OrderActionLimitMarket> CommandapiWarptransTradeV2ClientOrdersActionsLimitOrderIdPutAsync(
            int orderId, string portfolio, Side side, int quantity, decimal price, string symbol, Exchange exchange,
            string? instrumentGroup = null, string? comment = null, TimeInForce timeInForce = TimeInForce.OneDay,
            int? icebergFixed = null, decimal? icebergVariance = null);

        /// <include file='../XmlDocs/IOrdersService.xml' path='Docs/Members[@name="IOrdersService"]/Member[@name="CommandapiWarptransTradeV2ClientOrdersEstimatePostAsync"]/*' />
        public Task<ResponseEstimateOrder> CommandapiWarptransTradeV2ClientOrdersEstimatePostAsync(string portfolio,
            string ticker, Exchange exchange, decimal? price, int? lotQuantity, decimal? budget, string? board, bool? includeLimitOrders);

        /// <include file='../XmlDocs/IOrdersService.xml' path='Docs/Members[@name="IOrdersService"]/Member[@name="CommandapiWarptransTradeV2ClientOrdersEstimateAllPostAsync"]/*' />
        public Task<ICollection<ResponseEstimateOrder>> CommandapiWarptransTradeV2ClientOrdersEstimateAllPostAsync(
            ICollection<RequestEstimateOrder> collectionEstimateOrders);

        /// <include file='../XmlDocs/IOrdersService.xml' path='Docs/Members[@name="IOrdersService"]/Member[@name="CommandapiWarptransTradeV2ClientOrdersOrderIdDeleteAsync"]/*' />
        public Task<string> CommandapiWarptransTradeV2ClientOrdersOrderIdDeleteAsync(int orderId, string? portfolio,
            Exchange exchange, bool stop);

        /// <include file='../XmlDocs/IOrdersService.xml' path='Docs/Members[@name="IOrdersService"]/Member[@name="CommandapiWarptransTradeV2ClientOrdersAllDeleteAsync"]/*' />
        public Task<string> CommandapiWarptransTradeV2ClientOrdersAllDeleteAsync(string? portfolio, Exchange exchange,
            bool stop);
    }
}
