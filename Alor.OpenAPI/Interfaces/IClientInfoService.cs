using Alor.OpenAPI.Core;
using Alor.OpenAPI.Enums;
using Alor.OpenAPI.Models.Heavy;
using Alor.OpenAPI.Models.Simple;
using Alor.OpenAPI.Models.Slim;

namespace Alor.OpenAPI.Interfaces
{
    public interface IClientInfoService
    {
        /// <include file='../XmlDocs/IClientInfoService.xml' path='Docs/Members[@name="IClientInfoService"]/Member[@name="MdV2ClientsExchangePortfolioSummaryGetSimpleAsync"]/*' />
        public Task<SummarySimple> MdV2ClientsExchangePortfolioSummaryGetSimpleAsync(Exchange exchange,
            string portfolio);

        /// <include file='../XmlDocs/IClientInfoService.xml' path='Docs/Members[@name="IClientInfoService"]/Member[@name="MdV2ClientsExchangePortfolioSummaryGetSlimAsync"]/*' />
        public Task<SummarySlim>
            MdV2ClientsExchangePortfolioSummaryGetSlimAsync(Exchange exchange, string portfolio);

        /// <include file='../XmlDocs/IClientInfoService.xml' path='Docs/Members[@name="IClientInfoService"]/Member[@name="MdV2ClientsExchangePortfolioSummaryGetHeavyAsync"]/*' />
        public Task<SummaryHeavy>
            MdV2ClientsExchangePortfolioSummaryGetHeavyAsync(Exchange exchange, string portfolio);

        /// <include file='../XmlDocs/IClientInfoService.xml' path='Docs/Members[@name="IClientInfoService"]/Member[@name="MdV2ClientsExchangePortfolioPositionsGetSimpleAsync"]/*' />
        public Task<ICollection<PositionSimple>> MdV2ClientsExchangePortfolioPositionsGetSimpleAsync(Exchange exchange,
            string portfolio, bool? withoutCurrency = null);

        /// <include file='../XmlDocs/IClientInfoService.xml' path='Docs/Members[@name="IClientInfoService"]/Member[@name="MdV2ClientsExchangePortfolioPositionsGetSlimAsync"]/*' />
        public Task<ICollection<PositionSlim>> MdV2ClientsExchangePortfolioPositionsGetSlimAsync(Exchange exchange,
            string portfolio, bool? withoutCurrency = null);

        /// <include file='../XmlDocs/IClientInfoService.xml' path='Docs/Members[@name="IClientInfoService"]/Member[@name="MdV2ClientsExchangePortfolioPositionsGetHeavyAsync"]/*' />
        public Task<ICollection<PositionHeavy>> MdV2ClientsExchangePortfolioPositionsGetHeavyAsync(Exchange exchange,
            string portfolio, bool? withoutCurrency = null);

        /// <include file='../XmlDocs/IClientInfoService.xml' path='Docs/Members[@name="IClientInfoService"]/Member[@name="MdV2ClientsExchangePortfolioPositionsSymbolGetSimpleAsync"]/*' />
        public Task<ICollection<PositionSimple>> MdV2ClientsExchangePortfolioPositionsSymbolGetSimpleAsync(
            Exchange exchange, string portfolio, string symbol);

        /// <include file='../XmlDocs/IClientInfoService.xml' path='Docs/Members[@name="IClientInfoService"]/Member[@name="MdV2ClientsExchangePortfolioPositionsSymbolGetSlimAsync"]/*' />
        public Task<ICollection<PositionSlim>> MdV2ClientsExchangePortfolioPositionsSymbolGetSlimAsync(
            Exchange exchange, string portfolio, string symbol);

        /// <include file='../XmlDocs/IClientInfoService.xml' path='Docs/Members[@name="IClientInfoService"]/Member[@name="MdV2ClientsExchangePortfolioPositionsSymbolGetHeavyAsync"]/*' />
        public Task<ICollection<PositionHeavy>> MdV2ClientsExchangePortfolioPositionsSymbolGetHeavyAsync(
            Exchange exchange, string portfolio, string symbol);

        /// <include file='../XmlDocs/IClientInfoService.xml' path='Docs/Members[@name="IClientInfoService"]/Member[@name="MdV2ClientsExchangePortfolioTradesGetSimpleAsync"]/*' />
        public Task<ICollection<TradeSimple>> MdV2ClientsExchangePortfolioTradesGetSimpleAsync(Exchange exchange,
            string portfolio, bool? withRepo = null);

        /// <include file='../XmlDocs/IClientInfoService.xml' path='Docs/Members[@name="IClientInfoService"]/Member[@name="MdV2ClientsExchangePortfolioTradesGetSlimAsync"]/*' />
        public Task<ICollection<TradeSlim>> MdV2ClientsExchangePortfolioTradesGetSlimAsync(Exchange exchange,
            string portfolio, bool? withRepo = null);

        /// <include file='../XmlDocs/IClientInfoService.xml' path='Docs/Members[@name="IClientInfoService"]/Member[@name="MdV2ClientsExchangePortfolioTradesGetHeavyAsync"]/*' />
        public Task<ICollection<TradeHeavy>> MdV2ClientsExchangePortfolioTradesGetHeavyAsync(Exchange exchange,
            string portfolio, bool? withRepo = null);

        /// <include file='../XmlDocs/IClientInfoService.xml' path='Docs/Members[@name="IClientInfoService"]/Member[@name="MdV2ClientsExchangePortfolioSymbolTradesGetSimpleAsync"]/*' />
        public Task<ICollection<TradeSimple>> MdV2ClientsExchangePortfolioSymbolTradesGetSimpleAsync(Exchange exchange,
            string portfolio, string symbol, string instrumentGroup);

        /// <include file='../XmlDocs/IClientInfoService.xml' path='Docs/Members[@name="IClientInfoService"]/Member[@name="MdV2ClientsExchangePortfolioSymbolTradesGetSlimAsync"]/*' />
        public Task<ICollection<TradeSlim>> MdV2ClientsExchangePortfolioSymbolTradesGetSlimAsync(Exchange exchange,
            string portfolio, string symbol, string instrumentGroup);

        /// <include file='../XmlDocs/IClientInfoService.xml' path='Docs/Members[@name="IClientInfoService"]/Member[@name="MdV2ClientsExchangePortfolioSymbolTradesGetHeavyAsync"]/*' />
        public Task<ICollection<TradeHeavy>> MdV2ClientsExchangePortfolioSymbolTradesGetHeavyAsync(Exchange exchange,
            string portfolio, string symbol, string instrumentGroup);

        /// <include file='../XmlDocs/IClientInfoService.xml' path='Docs/Members[@name="IClientInfoService"]/Member[@name="MdV2ClientsExchangePortfolioFortsriskGetSimpleAsync"]/*' />
        public Task<FortsriskSimple> MdV2ClientsExchangePortfolioFortsriskGetSimpleAsync(Exchange exchange,
            string portfolio);

        /// <include file='../XmlDocs/IClientInfoService.xml' path='Docs/Members[@name="IClientInfoService"]/Member[@name="MdV2ClientsExchangePortfolioFortsriskGetSlimAsync"]/*' />
        public Task<FortsriskSlim> MdV2ClientsExchangePortfolioFortsriskGetSlimAsync(Exchange exchange,
            string portfolio);

        /// <include file='../XmlDocs/IClientInfoService.xml' path='Docs/Members[@name="IClientInfoService"]/Member[@name="MdV2ClientsExchangePortfolioFortsriskGetHeavyAsync"]/*' />
        public Task<FortsriskHeavy> MdV2ClientsExchangePortfolioFortsriskGetHeavyAsync(Exchange exchange,
            string portfolio);

        /// <include file='../XmlDocs/IClientInfoService.xml' path='Docs/Members[@name="IClientInfoService"]/Member[@name="MdV2ClientsExchangePortfolioRiskGetSimpleAsync"]/*' />
        public Task<RiskSimple> MdV2ClientsExchangePortfolioRiskGetSimpleAsync(Exchange exchange, string portfolio);

        /// <include file='../XmlDocs/IClientInfoService.xml' path='Docs/Members[@name="IClientInfoService"]/Member[@name="MdV2ClientsExchangePortfolioRiskGetSlimAsync"]/*' />
        public Task<RiskSlim> MdV2ClientsExchangePortfolioRiskGetSlimAsync(Exchange exchange, string portfolio);

        /// <include file='../XmlDocs/IClientInfoService.xml' path='Docs/Members[@name="IClientInfoService"]/Member[@name="MdV2ClientsExchangePortfolioRiskGetHeavyAsync"]/*' />
        public Task<RiskHeavy> MdV2ClientsExchangePortfolioRiskGetHeavyAsync(Exchange exchange, string portfolio);

        /// <include file='../XmlDocs/IClientInfoService.xml' path='Docs/Members[@name="IClientInfoService"]/Member[@name="MdV2StatsExchangePortfolioHistoryTradesGetSimpleAsync"]/*' />
        public Task<ICollection<TradeSimple>> MdV2StatsExchangePortfolioHistoryTradesGetSimpleAsync(Exchange exchange,
            string portfolio, string? instrumentGroup = null, string? dateFrom = null, string? ticker = null, int? from = null, int? limit = null,
            bool? orderByTradeDate = null, bool? descending = null, bool? withRepo = null, Side? side = null);

        /// <include file='../XmlDocs/IClientInfoService.xml' path='Docs/Members[@name="IClientInfoService"]/Member[@name="MdV2StatsExchangePortfolioHistoryTradesGetSlimAsync"]/*' />
        public Task<ICollection<TradeSlim>> MdV2StatsExchangePortfolioHistoryTradesGetSlimAsync(Exchange exchange,
            string portfolio, string? instrumentGroup = null, string? dateFrom = null, string? ticker = null, int? from = null, int? limit = null,
            bool? orderByTradeDate = null, bool? descending = null, bool? withRepo = null, Side? side = null);

        /// <include file='../XmlDocs/IClientInfoService.xml' path='Docs/Members[@name="IClientInfoService"]/Member[@name="MdV2StatsExchangePortfolioHistoryTradesGetHeavyAsync"]/*' />
        public Task<ICollection<TradeHeavy>> MdV2StatsExchangePortfolioHistoryTradesGetHeavyAsync(Exchange exchange,
            string portfolio, string? instrumentGroup = null, string? dateFrom = null, string? ticker = null, int? from = null, int? limit = null,
            bool? orderByTradeDate = null, bool? descending = null, bool? withRepo = null, Side? side = null);

        /// <include file='../XmlDocs/IClientInfoService.xml' path='Docs/Members[@name="IClientInfoService"]/Member[@name="MdV2StatsExchangePortfolioHistoryTradesSymbolGetSimpleAsync"]/*' />
        public Task<ICollection<TradeSimple>> MdV2StatsExchangePortfolioHistoryTradesSymbolGetSimpleAsync(
            Exchange exchange,
            string portfolio, string symbol, string? instrumentGroup = null, string? dateFrom = null, int? from = null, int? limit = null,
            bool? orderByTradeDate = null, bool? descending = null, bool? withRepo = null, Side? side = null);

        /// <include file='../XmlDocs/IClientInfoService.xml' path='Docs/Members[@name="IClientInfoService"]/Member[@name="MdV2StatsExchangePortfolioHistoryTradesSymbolGetSlimAsync"]/*' />
        public Task<ICollection<TradeSlim>> MdV2StatsExchangePortfolioHistoryTradesSymbolGetSlimAsync(
            Exchange exchange,
            string portfolio, string symbol, string? instrumentGroup = null, string? dateFrom = null, int? from = null, int? limit = null,
            bool? orderByTradeDate = null, bool? descending = null, bool? withRepo = null, Side? side = null);

        /// <include file='../XmlDocs/IClientInfoService.xml' path='Docs/Members[@name="IClientInfoService"]/Member[@name="MdV2StatsExchangePortfolioHistoryTradesSymbolGetHeavyAsync"]/*' />
        public Task<ICollection<TradeHeavy>> MdV2StatsExchangePortfolioHistoryTradesSymbolGetHeavyAsync(
            Exchange exchange,
            string portfolio, string symbol, string? instrumentGroup = null, string? dateFrom = null, int? from = null, int? limit = null,
            bool? orderByTradeDate = null, bool? descending = null, bool? withRepo = null, Side? side = null);

        /// <include file='../XmlDocs/IClientInfoService.xml' path='Docs/Members[@name="IClientInfoService"]/Member[@name="MdV2ClientsLoginPositionsGetSimpleAsync"]/*' />
        public Task<ICollection<PositionSimple>> MdV2ClientsLoginPositionsGetSimpleAsync(string login,
            bool? withoutCurrency = null);

        /// <include file='../XmlDocs/IClientInfoService.xml' path='Docs/Members[@name="IClientInfoService"]/Member[@name="MdV2ClientsLoginPositionsGetSlimAsync"]/*' />
        public Task<ICollection<PositionSlim>> MdV2ClientsLoginPositionsGetSlimAsync(string login,
            bool? withoutCurrency = null);

        /// <include file='../XmlDocs/IClientInfoService.xml' path='Docs/Members[@name="IClientInfoService"]/Member[@name="MdV2ClientsLoginPositionsGetHeavyAsync"]/*' />
        public Task<ICollection<PositionHeavy>> MdV2ClientsLoginPositionsGetHeavyAsync(string login,
            bool? withoutCurrency = null);
    }
}
