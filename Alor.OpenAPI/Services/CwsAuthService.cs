using Alor.OpenAPI.Interfaces;
using Alor.OpenAPI.Models;
using Alor.OpenAPI.Utilities;
using Serilog;

namespace Alor.OpenAPI.Services
{
    internal class CwsAuthService : ICwsAuthService
    {
        private AlarmClock? _clockAuthorize;
        private readonly ILogger _logger;
        private Func<string, Task<bool>>? _authMsgUpdate;
        private long _messageCount;

        internal CwsAuthService(ILogger logger, Func<string, Task<bool>> authMsgUpdate)
        {
            _logger = logger;
            _authMsgUpdate = authMsgUpdate;
        }

        public void Dispose()
        {
            _clockAuthorize?.Dispose();
            _authMsgUpdate = null;
        }
        public async Task CwsAuthorizeAndSetRefreshTimer()
        {
            try
            {
                await (_authMsgUpdate?.Invoke(new CwsRequestAuthorize(Utilities.Utilities.GuidFormatter<long>("auth", _messageCount++)).ToJson()) ?? Task.CompletedTask);
            }
            catch (Exception ex)
            {
                _logger.Error($"Ошибка: {ex.Message}");
            }

            _clockAuthorize = new AlarmClock(DateTime.Now.AddMinutes(10));
            _clockAuthorize.Alarm += (sender, e) =>
            {
                (sender as AlarmClock)?.Dispose();
                Task.Run(async () =>
                {
                    await CwsAuthorizeAndSetRefreshTimer();
                });
            };
        }
    }
}
