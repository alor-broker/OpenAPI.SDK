using Alor.OpenAPI.Core;
using Alor.OpenAPI.Enums;
using Alor.OpenAPI.Models;
using Alor.OpenAPI.Models.Heavy;
using Alor.OpenAPI.Models.Simple;
using Alor.OpenAPI.Models.Slim;

namespace Alor.OpenAPI.Interfaces
{
    public interface IStopOrdersService
    {
        /// <include file='../XmlDocs/IStopOrdersService.xml' path='Docs/Members[@name="IStopOrdersService"]/Member[@name="MdV2ClientsExchangePortfolioStopOrdersOrderIdGetSimpleAsync"]/*' />
        public Task<StopOrderSimple> MdV2ClientsExchangePortfolioStopOrdersOrderIdGetSimpleAsync(Exchange exchange,
            string portfolio, int orderId);

        /// <include file='../XmlDocs/IStopOrdersService.xml' path='Docs/Members[@name="IStopOrdersService"]/Member[@name="MdV2ClientsExchangePortfolioStopOrdersOrderIdGetSlimAsync"]/*' />
        public Task<StopOrderSlim> MdV2ClientsExchangePortfolioStopOrdersOrderIdGetSlimAsync(Exchange exchange,
            string portfolio, int orderId);

        /// <include file='../XmlDocs/IStopOrdersService.xml' path='Docs/Members[@name="IStopOrdersService"]/Member[@name="MdV2ClientsExchangePortfolioStopOrdersOrderIdGetHeavyAsync"]/*' />
        public Task<StopOrderHeavy> MdV2ClientsExchangePortfolioStopOrdersOrderIdGetHeavyAsync(Exchange exchange,
            string portfolio, int orderId);

        /// <include file='../XmlDocs/IStopOrdersService.xml' path='Docs/Members[@name="IStopOrdersService"]/Member[@name="MdV2ClientsExchangePortfolioStopOrdersGetSimpleAsync"]/*' />
        public Task<ICollection<StopOrderSimple>> MdV2ClientsExchangePortfolioStopOrdersGetSimpleAsync(
            Exchange exchange, string portfolio);

        /// <include file='../XmlDocs/IStopOrdersService.xml' path='Docs/Members[@name="IStopOrdersService"]/Member[@name="MdV2ClientsExchangePortfolioStopOrdersGetSlimAsync"]/*' />
        public Task<ICollection<StopOrderSlim>> MdV2ClientsExchangePortfolioStopOrdersGetSlimAsync(Exchange exchange,
            string portfolio);

        /// <include file='../XmlDocs/IStopOrdersService.xml' path='Docs/Members[@name="IStopOrdersService"]/Member[@name="MdV2ClientsExchangePortfolioStopOrdersGetHeavyAsync"]/*' />
        public Task<ICollection<StopOrderHeavy>> MdV2ClientsExchangePortfolioStopOrdersGetHeavyAsync(Exchange exchange,
            string portfolio);

        /// <include file='../XmlDocs/IStopOrdersService.xml' path='Docs/Members[@name="IStopOrdersService"]/Member[@name="CommandapiWarptransTradeV2ClientOrdersActionsStopPostAsync"]/*' />
        public Task<OrderActionLimitMarket> CommandapiWarptransTradeV2ClientOrdersActionsStopPostAsync(
            string portfolio, Side side,
            Condition condition, decimal triggerPrice, DateTime stopEndUtcTime, int quantity,
            string symbol, Exchange exchange, string? instrumentGroup = null, int? protectingSeconds = null, bool? activate = null);

        /// <include file='../XmlDocs/IStopOrdersService.xml' path='Docs/Members[@name="IStopOrdersService"]/Member[@name="CommandapiWarptransTradeV2ClientOrdersActionsStopLimitPostAsync"]/*' />
        public Task<OrderActionLimitMarket> CommandapiWarptransTradeV2ClientOrdersActionsStopLimitPostAsync(
            string portfolio, Side side,
            Condition condition, decimal triggerPrice, DateTime stopEndUtcTime, int quantity, decimal price,
            string symbol, Exchange exchange, string? instrumentGroup = null,
            TimeInForce timeInForce = TimeInForce.OneDay, int? icebergFixed = null, decimal? icebergVariance = null,
            int? protectingSeconds = null, bool? activate = null);

        /// <include file='../XmlDocs/IStopOrdersService.xml' path='Docs/Members[@name="IStopOrdersService"]/Member[@name="CommandapiWarptransTradeV2ClientOrdersActionsStopStopOrderIdPutAsync"]/*' />
        public Task<OrderActionLimitMarket> CommandapiWarptransTradeV2ClientOrdersActionsStopStopOrderIdPutAsync(
            int stopOrderId, string portfolio, Side side,
            Condition condition, decimal triggerPrice, DateTime stopEndUtcTime, int quantity,
            string symbol, Exchange exchange, string? instrumentGroup = null, int? protectingSeconds = null, bool? activate = null);

        /// <include file='../XmlDocs/IStopOrdersService.xml' path='Docs/Members[@name="IStopOrdersService"]/Member[@name="CommandapiWarptransTradeV2ClientOrdersActionsStopLimitStopOrderIdPutAsync"]/*' />
        public Task<OrderActionLimitMarket> CommandapiWarptransTradeV2ClientOrdersActionsStopLimitStopOrderIdPutAsync(
            int stopOrderId, string portfolio, Side side,
            Condition condition, decimal triggerPrice, DateTime stopEndUtcTime, int quantity, decimal price,
            string symbol, Exchange exchange, string? instrumentGroup = null,
            TimeInForce timeInForce = TimeInForce.OneDay, int? icebergFixed = null, decimal? icebergVariance = null,
            int? protectingSeconds = null, bool? activate = null);

    }
}
