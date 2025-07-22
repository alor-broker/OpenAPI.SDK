using Alor.OpenAPI.Enums;
using Alor.OpenAPI.Extensions;
using Alor.OpenAPI.Interfaces;
using Alor.OpenAPI.Models;

namespace Alor.OpenAPI.Managers
{
    public class CwsManager : ICwsManager
    {
        private long _messageCount;
        private bool _isInitialized;
        private Func<string, Task<bool>>? _commandMsgUpdate;
        private Func<Task>? _cwsAuthorizeAndSetRefreshTimer;

        internal CwsManager(Func<string, Task<bool>> commandMsgUpdate, Func<Task> cwsAuthorizeAndSetRefreshTimer)
        {
            _commandMsgUpdate = commandMsgUpdate;
            _cwsAuthorizeAndSetRefreshTimer = cwsAuthorizeAndSetRefreshTimer;
        }

        private async Task EnsureInitialized()
        {
            if (!_isInitialized)
            {
                await (_cwsAuthorizeAndSetRefreshTimer?.Invoke() ?? Task.CompletedTask);
                _isInitialized = true;
            }
        }

        public async Task<string> CreateMarketOrderAsync(string portfolio, Side side, int quantity, string symbol,
            Exchange exchange, string? board = null, TimeInForce timeInForce = TimeInForce.OneDay,
            string? comment = null, bool checkDuplicates = true, bool? allowMargin = null)
        {
            if (string.IsNullOrEmpty(portfolio))
                throw new ArgumentNullException(nameof(portfolio));

            await EnsureInitialized();

            var guid = Utilities.Utilities.GuidFormatter("a", Interlocked.Increment(ref _messageCount));

            var message = new CwsRequestOrderMarket("create:market", guid, null, side, quantity,
                new Instrument(symbol, exchange), null, comment, board, new User(portfolio), timeInForce,
                checkDuplicates, allowMargin).ToJson();

            await (_commandMsgUpdate?.Invoke(message) ?? Task.CompletedTask);

            return guid;
        }

        public async Task<string> CreateLimitOrderAsync(string portfolio, Side side, int quantity, decimal price,
            string symbol, Exchange exchange, string? board = null, string? comment = null,
            TimeInForce timeInForce = TimeInForce.OneDay, int? icebergFixed = null,
            decimal? icebergVariance = null, bool checkDuplicates = true, bool? allowMargin = null)
        {
            if (string.IsNullOrEmpty(portfolio))
                throw new ArgumentNullException(nameof(portfolio));

            await EnsureInitialized();

            var guid = Utilities.Utilities.GuidFormatter("a", Interlocked.Increment(ref _messageCount));

            var message = new CwsRequestOrderLimit("create:limit", guid, null, side, quantity, price,
                new Instrument(symbol, exchange), null, comment, board, new User(portfolio), timeInForce,
                icebergFixed, icebergVariance, checkDuplicates, allowMargin).ToJson();

            await (_commandMsgUpdate?.Invoke(message) ?? Task.CompletedTask);

            return guid;
        }

        public async Task<string> CreateStopOrderAsync(string portfolio, Side side,
            Condition condition, decimal triggerPrice, DateTime stopEndUtcTime, int quantity,
            string symbol, Exchange exchange, string? board = null, bool checkDuplicates = true,
            int? protectingSeconds = null, bool? activate = null, bool? allowMargin = null)
        {
            if (string.IsNullOrEmpty(portfolio))
                throw new ArgumentNullException(nameof(portfolio));

            await EnsureInitialized();

            var guid = Utilities.Utilities.GuidFormatter("a", Interlocked.Increment(ref _messageCount));

            var message = new CwsRequestOrderStop("create:stop", guid, null, side, condition, triggerPrice,
                stopEndUtcTime.GetUnixTimestampSecondsFromDateTime(), quantity,
                new Instrument(symbol, exchange), null, board, new User(portfolio), checkDuplicates, protectingSeconds,
                activate, allowMargin).ToJson();

            await (_commandMsgUpdate?.Invoke(message) ?? Task.CompletedTask);

            return guid;
        }

        public async Task<string> CreateStopLimitOrderAsync(string portfolio, Side side,
            Condition condition, decimal triggerPrice, DateTime stopEndUtcTime, int quantity, decimal price,
            string symbol, Exchange exchange, string? board = null,
            TimeInForce timeInForce = TimeInForce.OneDay, int? icebergFixed = null, decimal? icebergVariance = null,
            bool checkDuplicates = true, int? protectingSeconds = null, bool? activate = null, bool? allowMargin = null)
        {
            if (string.IsNullOrEmpty(portfolio))
                throw new ArgumentNullException(nameof(portfolio));

            await EnsureInitialized();

            var guid = Utilities.Utilities.GuidFormatter("a", Interlocked.Increment(ref _messageCount));

            var message = new CwsRequestOrderStopLimit("create:stopLimit", guid, null, side, condition, triggerPrice,
                stopEndUtcTime.GetUnixTimestampSecondsFromDateTime(), price, quantity,
                new Instrument(symbol, exchange), null, board, new User(portfolio), timeInForce,
                icebergFixed, icebergVariance, checkDuplicates,
                protectingSeconds, activate, allowMargin).ToJson();

            await (_commandMsgUpdate?.Invoke(message) ?? Task.CompletedTask);

            return guid;
        }

        public async Task<string> UpdateMarketOrderAsync(string portfolio, string orderId, Side side, int quantity, string symbol,
            Exchange exchange, string? board = null, TimeInForce timeInForce = TimeInForce.OneDay,
            string? comment = null, bool checkDuplicates = true, bool? allowMargin = null)
        {
            if (string.IsNullOrEmpty(portfolio))
                throw new ArgumentNullException(nameof(portfolio));
            if (string.IsNullOrEmpty(orderId))
                throw new ArgumentNullException(nameof(orderId));

            await EnsureInitialized();

            var guid = Utilities.Utilities.GuidFormatter("a", Interlocked.Increment(ref _messageCount));

            var message = new CwsRequestOrderMarket("update:market", guid, orderId, side, quantity,
                new Instrument(symbol, exchange), null, comment, board, new User(portfolio), timeInForce, checkDuplicates, allowMargin).ToJson();

            await (_commandMsgUpdate?.Invoke(message) ?? Task.CompletedTask);

            return guid;
        }

        public async Task<string> UpdateLimitOrderAsync(string portfolio, string orderId, Side side, int quantity, decimal price,
            string symbol, Exchange exchange, string? board = null, string? comment = null,
            TimeInForce timeInForce = TimeInForce.OneDay, int? icebergFixed = null,
            decimal? icebergVariance = null, bool checkDuplicates = true, bool? allowMargin = null)
        {
            if (string.IsNullOrEmpty(portfolio))
                throw new ArgumentNullException(nameof(portfolio));
            if (string.IsNullOrEmpty(orderId))
                throw new ArgumentNullException(nameof(orderId));

            await EnsureInitialized();

            var guid = Utilities.Utilities.GuidFormatter("a", Interlocked.Increment(ref _messageCount));

            var message = new CwsRequestOrderLimit("update:limit", guid, orderId, side, quantity, price,
                new Instrument(symbol, exchange), null, comment, board, new User(portfolio), timeInForce,
                icebergFixed, icebergVariance, checkDuplicates, allowMargin).ToJson();

            await (_commandMsgUpdate?.Invoke(message) ?? Task.CompletedTask);

            return guid;
        }

        public async Task<string> UpdateStopOrderAsync(string portfolio, string orderId, Side side,
            Condition condition, decimal triggerPrice, DateTime stopEndUtcTime, int quantity,
            string symbol, Exchange exchange, string? board = null, bool checkDuplicates = true,
            int? protectingSeconds = null, bool? activate = null, bool? allowMargin = null)
        {
            if (string.IsNullOrEmpty(portfolio))
                throw new ArgumentNullException(nameof(portfolio));
            if (string.IsNullOrEmpty(orderId))
                throw new ArgumentNullException(nameof(orderId));

            await EnsureInitialized();

            var guid = Utilities.Utilities.GuidFormatter("a", Interlocked.Increment(ref _messageCount));

            var message = new CwsRequestOrderStop("update:stop", guid, orderId, side, condition, triggerPrice,
                stopEndUtcTime.GetUnixTimestampSecondsFromDateTime(), quantity,
                new Instrument(symbol, exchange), null, board, new User(portfolio), checkDuplicates, protectingSeconds,
                activate, allowMargin).ToJson();

            await (_commandMsgUpdate?.Invoke(message) ?? Task.CompletedTask);

            return guid;
        }

        public async Task<string> UpdateStopLimitOrderAsync(string portfolio, string orderId, Side side,
            Condition condition, decimal triggerPrice, DateTime stopEndUtcTime, int quantity, decimal price,
            string symbol, Exchange exchange, string? board = null,
            TimeInForce timeInForce = TimeInForce.OneDay, int? icebergFixed = null, decimal? icebergVariance = null,
            bool checkDuplicates = true, int? protectingSeconds = null, bool? activate = null, bool? allowMargin = null)
        {
            if (string.IsNullOrEmpty(portfolio))
                throw new ArgumentNullException(nameof(portfolio));
            if (string.IsNullOrEmpty(orderId))
                throw new ArgumentNullException(nameof(orderId));

            await EnsureInitialized();

            var guid = Utilities.Utilities.GuidFormatter("a", Interlocked.Increment(ref _messageCount));

            var message = new CwsRequestOrderStopLimit("update:stopLimit", guid, orderId, side, condition, triggerPrice,
                stopEndUtcTime.GetUnixTimestampSecondsFromDateTime(), price, quantity,
                new Instrument(symbol, exchange), null, board, new User(portfolio), timeInForce,
                icebergFixed, icebergVariance, checkDuplicates,
                protectingSeconds, activate, allowMargin).ToJson();

            await (_commandMsgUpdate?.Invoke(message) ?? Task.CompletedTask);

            return guid;
        }

        public async Task<string> DeleteMarketOrderAsync(string portfolio, string orderId, Exchange exchange, bool checkDuplicates = true)
        {
            if (string.IsNullOrEmpty(portfolio))
                throw new ArgumentNullException(nameof(portfolio));
            if (string.IsNullOrEmpty(orderId))
                throw new ArgumentNullException(nameof(orderId));

            await EnsureInitialized();

            var guid = Utilities.Utilities.GuidFormatter("a", Interlocked.Increment(ref _messageCount));

            var message = new CwsRequestOrderMarket("delete:market", guid, orderId, exchange: exchange, user: new User(portfolio), checkDuplicates: checkDuplicates).ToJson();

            await (_commandMsgUpdate?.Invoke(message) ?? Task.CompletedTask);

            return guid;
        }

        public async Task<string> DeleteLimitOrderAsync(string portfolio, string orderId, Exchange exchange, bool checkDuplicates = true)
        {
            if (string.IsNullOrEmpty(portfolio))
                throw new ArgumentNullException(nameof(portfolio));
            if (string.IsNullOrEmpty(orderId))
                throw new ArgumentNullException(nameof(orderId));

            await EnsureInitialized();

            var guid = Utilities.Utilities.GuidFormatter("a", Interlocked.Increment(ref _messageCount));

            var message = new CwsRequestOrderLimit("delete:limit", guid, orderId, exchange: exchange, user: new User(portfolio), checkDuplicates: checkDuplicates).ToJson();

            await (_commandMsgUpdate?.Invoke(message) ?? Task.CompletedTask);

            return guid;
        }

        public async Task<string> DeleteStopOrderAsync(string portfolio, string orderId, Exchange exchange, bool checkDuplicates = true)
        {
            if (string.IsNullOrEmpty(portfolio))
                throw new ArgumentNullException(nameof(portfolio));
            if (string.IsNullOrEmpty(orderId))
                throw new ArgumentNullException(nameof(orderId));

            await EnsureInitialized();

            var guid = Utilities.Utilities.GuidFormatter("a", Interlocked.Increment(ref _messageCount));

            var message = new CwsRequestOrderStop("delete:stop", guid, orderId, exchange: exchange, user: new User(portfolio), checkDuplicates: checkDuplicates).ToJson();

            await (_commandMsgUpdate?.Invoke(message) ?? Task.CompletedTask);

            return guid;
        }

        public async Task<string> DeleteStopLimitOrderAsync(string portfolio, string orderId, Exchange exchange, bool checkDuplicates = true)
        {
            if (string.IsNullOrEmpty(portfolio))
                throw new ArgumentNullException(nameof(portfolio));
            if (string.IsNullOrEmpty(orderId))
                throw new ArgumentNullException(nameof(orderId));

            await EnsureInitialized();

            var guid = Utilities.Utilities.GuidFormatter("a", Interlocked.Increment(ref _messageCount));

            var message = new CwsRequestOrderStopLimit("delete:stopLimit", guid, orderId, exchange: exchange, user: new User(portfolio), checkDuplicates: checkDuplicates).ToJson();

            await (_commandMsgUpdate?.Invoke(message) ?? Task.CompletedTask);

            return guid;
        }


        public void Dispose()
        {
            _commandMsgUpdate = null;
            _cwsAuthorizeAndSetRefreshTimer = null;
        }
    }
}
