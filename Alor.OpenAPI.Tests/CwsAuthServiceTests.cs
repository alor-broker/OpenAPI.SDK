using Alor.OpenAPI.Services;
using Alor.OpenAPI.Utilities;
using FluentAssertions;
using Moq;
using Serilog;
using System.Reflection;
using Timer = System.Timers.Timer;

namespace Alor.OpenAPI.Tests
{
    public class CwsAuthServiceTests
    {
        [Fact]
        public async Task CwsAuthorizeAndSetRefreshTimer_CallsAuthMsgUpdateWithCorrectParams()
        {
            // Arrange
            var loggerMock = new Mock<ILogger>();
            var authMsgUpdateMock = new Mock<Func<string, Task<bool>>>();
            var service = new CwsAuthService(loggerMock.Object, authMsgUpdateMock.Object);

            // Act
            await service.CwsAuthorizeAndSetRefreshTimer();

            // Assert
            authMsgUpdateMock.Verify(x => x.Invoke(It.IsAny<string>()), Times.Once());
            // Тут можно добавить проверку на корректность переданной строки, если это важно для логики работы
        }

        [Fact]
        public async Task CwsAuthorizeAndSetRefreshTimer_LogsErrorOnException()
        {
            // Arrange
            var loggerMock = new Mock<ILogger>();
            var authMsgUpdateMock = new Mock<Func<string, Task<bool>>>();
            authMsgUpdateMock.Setup(x => x(It.IsAny<string>())).ThrowsAsync(new Exception("Test exception"));
            var service = new CwsAuthService(loggerMock.Object, authMsgUpdateMock.Object);

            // Act
            await service.CwsAuthorizeAndSetRefreshTimer();

            // Assert
            loggerMock.Verify(x => x.Error(It.Is<string>(s => s.Contains("Ошибка: Test exception"))), Times.Once());
        }

        [Fact]
        public void Dispose_DisposesAlarmClockAndClearsDelegates()
        {
            // Arrange
            var loggerMock = new Mock<ILogger>();
            var authMsgUpdate = new Func<string, Task<bool>>(s => Task.FromResult(true));
            var service = new CwsAuthService(loggerMock.Object, authMsgUpdate);
            // Имитация создания AlarmClock
            var clock = new AlarmClock(DateTime.Now.AddMilliseconds(100));
            var clockField =
                typeof(CwsAuthService).GetField("_clockAuthorize", BindingFlags.NonPublic | BindingFlags.Instance);
            clockField?.SetValue(service, clock);

            // Act
            service.Dispose();
            // Получаем доступ к приватному полю
            var fieldInfo = service.GetType().GetField("_authMsgUpdate", BindingFlags.NonPublic | BindingFlags.Instance);
            var delegateValue = (Func<string, Task<bool>>?)fieldInfo?.GetValue(service);

            // Assert
            // Проверяем, что таймер был остановлен и свойство _enabled установлено в false
            var enabledField = typeof(AlarmClock).GetField("_enabled", BindingFlags.NonPublic | BindingFlags.Instance);
            var timerEnabled = (bool?)enabledField?.GetValue(clock);
            Assert.False(timerEnabled, "Timer should be disabled after dispose.");

            // Убедимся, что делегат обнулен
            delegateValue?.GetInvocationList().Should().BeNull("Socket should have no subscribers after dispose.");

            // Убедимся, что AlarmClock больше не активен
            var timerField = typeof(AlarmClock).GetField("_timer", BindingFlags.NonPublic | BindingFlags.Instance);
            var timer = (Timer?)timerField?.GetValue(clock);
            Assert.Throws<ObjectDisposedException>(() => { timer?.Start(); });

        }

    }
}
