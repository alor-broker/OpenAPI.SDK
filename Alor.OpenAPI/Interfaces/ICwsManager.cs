using Alor.OpenAPI.Enums;

namespace Alor.OpenAPI.Interfaces
{
    public interface ICwsManager : IDisposable
    {
        /// <include file='../XmlDocs/ICwsManager.xml' path='Docs/Members[@name="ICwsManager"]/Member[@name="CreateMarketOrderAsync"]/*' />
        public Task<string> CreateMarketOrderAsync(string portfolio, Side side, int quantity, string symbol,
            Exchange exchange, string? instrumentGroup = null, TimeInForce timeInForce = TimeInForce.OneDay,
            string? comment = null, bool checkDuplicates = true, bool? allowMargin = null);

        /// <include file='../XmlDocs/ICwsManager.xml' path='Docs/Members[@name="ICwsManager"]/Member[@name="CreateLimitOrderAsync"]/*' />
        public Task<string> CreateLimitOrderAsync(string portfolio, Side side, int quantity, decimal price,
            string symbol, Exchange exchange, string? instrumentGroup = null, string? comment = null,
            TimeInForce timeInForce = TimeInForce.OneDay, int? icebergFixed = null,
            decimal? icebergVariance = null, bool checkDuplicates = true, bool? allowMargin = null);

        /// <include file='../XmlDocs/ICwsManager.xml' path='Docs/Members[@name="ICwsManager"]/Member[@name="CreateStopOrderAsync"]/*' />
        public Task<string> CreateStopOrderAsync(string portfolio, Side side,
            Condition condition, decimal triggerPrice, DateTime stopEndUtcTime, int quantity,
            string symbol, Exchange exchange, string? instrumentGroup = null, bool checkDuplicates = true,
            int? protectingSeconds = null, bool? activate = null, bool? allowMargin = null, string? comment = null);

        /// <include file='../XmlDocs/ICwsManager.xml' path='Docs/Members[@name="ICwsManager"]/Member[@name="CreateStopLimitOrderAsync"]/*' />
        public Task<string> CreateStopLimitOrderAsync(string portfolio, Side side,
            Condition condition, decimal triggerPrice, DateTime stopEndUtcTime, int quantity, decimal price,
            string symbol, Exchange exchange, string? instrumentGroup = null,
            TimeInForce timeInForce = TimeInForce.OneDay, int? icebergFixed = null, decimal? icebergVariance = null,
            bool checkDuplicates = true, int? protectingSeconds = null, bool? activate = null, bool? allowMargin = null,
            string? comment = null);

        /// <include file='../XmlDocs/ICwsManager.xml' path='Docs/Members[@name="ICwsManager"]/Member[@name="UpdateMarketOrderAsync"]/*' />
        public Task<string> UpdateMarketOrderAsync(string portfolio, string orderId, Side side, int quantity,
            string symbol,
            Exchange exchange, string? instrumentGroup = null, TimeInForce timeInForce = TimeInForce.OneDay,
            string? comment = null, bool checkDuplicates = true, bool? allowMargin = null);

        /// <include file='../XmlDocs/ICwsManager.xml' path='Docs/Members[@name="ICwsManager"]/Member[@name="UpdateLimitOrderAsync"]/*' />
        public Task<string> UpdateLimitOrderAsync(string portfolio, string orderId, Side side, int quantity,
            decimal price, string symbol, Exchange exchange, string? instrumentGroup = null, string? comment = null,
            int? icebergFixed = null, bool checkDuplicates = true, bool? allowMargin = null);

        /// <include file='../XmlDocs/ICwsManager.xml' path='Docs/Members[@name="ICwsManager"]/Member[@name="UpdateStopOrderAsync"]/*' />
        public Task<string> UpdateStopOrderAsync(string portfolio, string orderId, Side side,
            Condition condition, decimal triggerPrice, DateTime stopEndUtcTime, int quantity,
            string symbol, Exchange exchange, string? instrumentGroup = null, bool checkDuplicates = true,
            int? protectingSeconds = null, bool? activate = null, bool? allowMargin = null, 
            string? comment = null);

        /// <include file='../XmlDocs/ICwsManager.xml' path='Docs/Members[@name="ICwsManager"]/Member[@name="UpdateStopLimitOrderAsync"]/*' />
        public Task<string> UpdateStopLimitOrderAsync(string portfolio, string orderId, Side side, Condition condition,
            decimal triggerPrice, DateTime stopEndUtcTime, int quantity, decimal price, string symbol,
            Exchange exchange, string? instrumentGroup = null, TimeInForce timeInForce = TimeInForce.OneDay,
            int? icebergFixed = null, bool checkDuplicates = true, int? protectingSeconds = null, bool? activate = null,
            bool? allowMargin = null, string? comment = null);

        /// <include file='../XmlDocs/ICwsManager.xml' path='Docs/Members[@name="ICwsManager"]/Member[@name="DeleteMarketOrderAsync"]/*' />
        public Task<string> DeleteMarketOrderAsync(string portfolio, string orderId, Exchange exchange,
            bool checkDuplicates = true);

        /// <include file='../XmlDocs/ICwsManager.xml' path='Docs/Members[@name="ICwsManager"]/Member[@name="DeleteLimitOrderAsync"]/*' />
        public Task<string> DeleteLimitOrderAsync(string portfolio, string orderId, Exchange exchange,
            bool checkDuplicates = true);

        /// <include file='../XmlDocs/ICwsManager.xml' path='Docs/Members[@name="ICwsManager"]/Member[@name="DeleteStopOrderAsync"]/*' />
        public Task<string> DeleteStopOrderAsync(string portfolio, string orderId, Exchange exchange,
            bool checkDuplicates = true);

        /// <include file='../XmlDocs/ICwsManager.xml' path='Docs/Members[@name="ICwsManager"]/Member[@name="DeleteStopLimitOrderAsync"]/*' />
        public Task<string> DeleteStopLimitOrderAsync(string portfolio, string orderId, Exchange exchange,
            bool checkDuplicates = true);

    }
}
