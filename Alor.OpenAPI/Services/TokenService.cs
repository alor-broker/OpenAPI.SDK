using Alor.OpenAPI.Interfaces;
using Alor.OpenAPI.Utilities;
using Serilog;
using System.Net;
using System.Text.Json;

namespace Alor.OpenAPI.Services
{
    internal sealed class TokenService : ITokenService
    {
        private AlarmClock? _clockObtainToken;
        private readonly Uri? _authUrl;
        private readonly HttpClient _httpClient;
        private readonly ILogger _logger;
        private readonly string? _refreshToken;
        private readonly CancellationTokenSource _cancellationTokenSource;

        internal TokenService(HttpClient httpClient, ILogger logger, Uri? authUrl, string? refreshToken, CancellationTokenSource cancellationTokenSource)
        {
            _httpClient = httpClient;
            _logger = logger;
            _authUrl = authUrl;
            _refreshToken = refreshToken;
            _cancellationTokenSource = cancellationTokenSource;
        }

        public void Dispose()
        {
            _clockObtainToken?.Dispose();
            JwtUpdated = null;
        }
        public async Task RefreshTokenAndSetRefreshTimer()
        {
            while (true)
            {
                try
                {
                    JwtUpdated?.Invoke(await ObtainAccessToken(_refreshToken));
                    break;
                }
                catch (Exception ex)
                {
                    _logger.Error(
                        $"Сокет ордеров: Ошибка получения токена. {ex.Message}{Environment.NewLine}Пробую повторить через 5 сек...");
                    await Task.Delay(5000, _cancellationTokenSource.Token);
                }
            }

            _clockObtainToken = new AlarmClock(DateTime.Now.AddMinutes(10));
            _clockObtainToken.Alarm += (sender, e) =>
            {
                (sender as AlarmClock)?.Dispose();
                Task.Run(async () =>
                {
                    try
                    {
                        await RefreshTokenAndSetRefreshTimer();
                    }
                    catch (Exception ex)
                    {
                        _logger.Error($"Ошибка: {ex.Message}");
                    }
                });
            };
        }

        private async Task<string?> ObtainAccessToken(string? refreshToken)
        {
            var accessToken = string.Empty;
            if (string.IsNullOrEmpty(refreshToken))
                return accessToken;
            using var request =
            new HttpRequestMessage(HttpMethod.Post, $"{_authUrl}{refreshToken}");

            using var response = await _httpClient.SendAsync(request, _cancellationTokenSource.Token);
            if (response.StatusCode != HttpStatusCode.OK)
            {
                throw new Exception($"Unable to obtain access token{Environment.NewLine}{await response.Content.ReadAsStringAsync(_cancellationTokenSource.Token)}");
            }

            var resp = await response.Content.ReadAsStringAsync(_cancellationTokenSource.Token);
            if (string.IsNullOrEmpty(resp)) return string.Empty;
            using var doc = JsonDocument.Parse(resp);
            var root = doc.RootElement;

            //подумать нужно ли кидать exception если не смогли распарсить ответ
            if (!root.TryGetProperty("AccessToken", out var accessTokenElement))
            {
                _logger.Error("\"AccessToken\" is not present in the response.");
                return string.Empty;
            }

            accessToken = accessTokenElement.GetString();

            _logger.Verbose($"AccessToken: {accessToken}");
            return accessToken;
        }

        public Action<string?>? JwtUpdated { get; set; }

    }
}
