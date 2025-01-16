using Alor.OpenAPI.Services;
using Alor.OpenAPI.Utilities;
using FluentAssertions;
using Moq;
using Moq.Protected;
using Serilog;
using System.Net;
using System.Reflection;
using Timer = System.Timers.Timer;

namespace Alor.OpenAPI.Tests
{
    public class TokenServiceTests
    {
        [Fact]
        public async Task RefreshTokenAndSetRefreshTimer_UpdatesTokenOnSuccess()
        {
            // Arrange
            var handlerMock = new Mock<HttpMessageHandler>();
            var loggerMock = new Mock<ILogger>();
            var cancellationTokenSource = new CancellationTokenSource();
            var expectedToken = "newToken";
            var refreshToken = "refreshToken";
            var authUrl = new Uri("https://api.example.com/refresh?token=");
            var responseBody = $"{{\"AccessToken\":\"{expectedToken}\"}}";

            handlerMock
                .Protected()
                .Setup<Task<HttpResponseMessage>>(
                    "SendAsync",
                    ItExpr.IsAny<HttpRequestMessage>(),
                    ItExpr.IsAny<CancellationToken>()
                )
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent(responseBody)
                })
                .Verifiable();

            var httpClient = new HttpClient(handlerMock.Object);

            var tokenService = new TokenService(
                httpClient,
                loggerMock.Object,
                authUrl,
                refreshToken,
                cancellationTokenSource
            );

            string? actualToken = null;
            tokenService.JwtUpdated += (token) => actualToken = token;

            // Act
            await tokenService.RefreshTokenAndSetRefreshTimer();

            // Assert
            Assert.Equal(expectedToken, actualToken);
            handlerMock.Protected().Verify(
                "SendAsync",
                Times.Once(),
                ItExpr.IsAny<HttpRequestMessage>(),
                ItExpr.IsAny<CancellationToken>()
            );
        }

        [Fact]
        public Task TokenService_HandlesCancellationCorrectly()
        {
            // Arrange
            var httpClientMock = new Mock<HttpMessageHandler>();
            var cancellationTokenSource = new CancellationTokenSource();
            var loggerMock = new Mock<ILogger>();

            httpClientMock.Protected()
                .Setup<Task<HttpResponseMessage>>(
                    "SendAsync",
                    ItExpr.IsAny<HttpRequestMessage>(),
                    ItExpr.IsAny<CancellationToken>())
                .Returns(async() => {
                    // Имитация долгого ответа
                    await Task.Delay(10000, CancellationToken.None);
                    return new HttpResponseMessage(HttpStatusCode.OK);
                });

            var httpClient = new HttpClient(httpClientMock.Object);
            var tokenService = new TokenService(httpClient, loggerMock.Object, new Uri("https://example.com"), "refreshToken", cancellationTokenSource);
            tokenService.JwtUpdated = delegate { };

            // Act
            var task = Task.Run(() => tokenService.RefreshTokenAndSetRefreshTimer(), CancellationToken.None);

            // Отменяем запрос через временя, меньшее, чем задержка имитации ответа
            cancellationTokenSource.CancelAfter(100);

            // Assert
            return Assert.ThrowsAsync<TaskCanceledException>(() => task);
        }

        [Fact]
        public async Task RefreshTokenAndSetRefreshTimer_LogsErrorAndExitsOnFailure()
        {
            // Arrange
            var handlerMock = new Mock<HttpMessageHandler>();
            var loggerMock = new Mock<ILogger>();
            var cancellationTokenSource = new CancellationTokenSource();
            var refreshToken = "refreshToken";
            var authUrl = new Uri("https://api.example.com/refresh?token=");
            var responseBody = "Error: Unable to refresh token";

            handlerMock
                .Protected()
                .Setup<Task<HttpResponseMessage>>(
                    "SendAsync",
                    ItExpr.IsAny<HttpRequestMessage>(),
                    ItExpr.IsAny<CancellationToken>()
                )
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.InternalServerError,
                    Content = new StringContent(responseBody)
                });

            var httpClient = new HttpClient(handlerMock.Object);

            var tokenService = new TokenService(
                httpClient,
                loggerMock.Object,
                authUrl,
                refreshToken,
                cancellationTokenSource
            );

            tokenService.JwtUpdated = delegate { };

            loggerMock.Setup(x => x.Error(It.IsAny<string>()));

            // Act
            var task = Task.Run(() => tokenService.RefreshTokenAndSetRefreshTimer(), CancellationToken.None);
            await Task.Delay(1000, CancellationToken.None);
            await cancellationTokenSource.CancelAsync();

            try
            {
                await task;
            }
            catch (OperationCanceledException)
            {
                
            }

            // Assert
            loggerMock.Verify(x => x.Error(
                It.Is<string>(s => s.Contains("Ошибка получения токена"))),
                Times.AtLeastOnce()
            );
        }

        [Fact]
        public void Dispose_DisposesAllResourcesCorrectly()
        {
            // Arrange
            var httpClient = new HttpClient();
            var loggerMock = new Mock<ILogger>();
            var cancellationTokenSource = new CancellationTokenSource();
            var tokenService = new TokenService(httpClient, loggerMock.Object, new Uri("https://example.com/auth"),
                "refreshToken", cancellationTokenSource);

            // Создаем экземпляр AlarmClock и используем рефлексию для вставки его в TokenService
            var clock = new AlarmClock(DateTime.Now.AddMilliseconds(100));
            var clockField =
                typeof(TokenService).GetField("_clockObtainToken", BindingFlags.NonPublic | BindingFlags.Instance);
            clockField?.SetValue(tokenService, clock);

            // Устанавливаем тестовый делегат для JwtUpdated
            var jwtUpdatedCalled = false;
            void JwtUpdatedTestDelegate(string? _) => jwtUpdatedCalled = true;
            tokenService.JwtUpdated = JwtUpdatedTestDelegate;

            // Act
            tokenService.Dispose();
            tokenService.JwtUpdated?.Invoke(null); // Попытка вызвать делегат после Dispose

            // Assert
            // Проверяем, что таймер был остановлен и свойство _enabled установлено в false
            var enabledField = typeof(AlarmClock).GetField("_enabled", BindingFlags.NonPublic | BindingFlags.Instance);
            var timerEnabled = (bool?)enabledField?.GetValue(clock);
            Assert.False(timerEnabled, "Timer should be disabled after dispose.");

            // Проверяем, что обработчик JwtUpdated не содержит подписок
            Assert.False(jwtUpdatedCalled, "JwtUpdated should not be called after dispose.");
            tokenService.JwtUpdated?.GetInvocationList().Should().BeNull("JwtUpdated should have no subscribers after dispose.");


            // Убедимся, что AlarmClock больше не активен
            var timerField = typeof(AlarmClock).GetField("_timer", BindingFlags.NonPublic | BindingFlags.Instance);
            var timer = (Timer?)timerField?.GetValue(clock);
            Assert.Throws<ObjectDisposedException>(() => { timer?.Start(); });

        }

    }
}
