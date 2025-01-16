using Alor.OpenAPI.Enums;
using Alor.OpenAPI.Managers;
using Moq;
using System.Reflection;
using System.Text.RegularExpressions;

namespace Alor.OpenAPI.Tests
{
    public class CwsManagerTests
    {
        [Fact]
        public void EnsureInitialized_CallsAuthorizationOnlyOnce()
        {
            // Arrange
            var commandMsgUpdateMock = new Mock<Func<string, Task<bool>>>();
            commandMsgUpdateMock.Setup(f => f.Invoke(It.IsAny<string>())).ReturnsAsync(true);

            var mockAuthFunc = new Mock<Func<Task>>();
            mockAuthFunc.Setup(m => m.Invoke()).Returns(Task.CompletedTask);

            var cwsManager = new CwsManager(commandMsgUpdateMock.Object, mockAuthFunc.Object);
            var ensureInitializedMethod = typeof(CwsManager).GetMethod("EnsureInitialized", BindingFlags.NonPublic | BindingFlags.Instance);

            // Act
            // Первый вызов - должна произойти авторизация
            ensureInitializedMethod?.Invoke(cwsManager, []);

            // Второй вызов - авторизация не должна происходить
            ensureInitializedMethod?.Invoke(cwsManager, []);

            // Assert
            mockAuthFunc.Verify(m => m.Invoke(), Times.Once()); // Проверяем, что авторизация была вызвана только один раз

            cwsManager.Dispose();
        }

        [Fact]
        public async Task CreateMarketOrderAsync_SendsCorrectMessageAndReturnsGuid()
        {
            // Arrange
            var commandMsgUpdateMock = new Mock<Func<string, Task<bool>>>();
            commandMsgUpdateMock.Setup(f => f.Invoke(It.IsAny<string>())).ReturnsAsync(true);

            var mockAuthFunc = new Mock<Func<Task>>();
            mockAuthFunc.Setup(m => m.Invoke()).Returns(Task.CompletedTask);

            var cwsManager = new CwsManager(commandMsgUpdateMock.Object, mockAuthFunc.Object);
            var portfolio = "testPortfolio";
            var side = Side.Buy;
            var quantity = 100;
            var symbol = "AAPL";
            var exchange = Exchange.SPBX;

            // Используем рефлексию для вызова EnsureInitialized
            var ensureInitializedMethod = typeof(CwsManager).GetMethod("EnsureInitialized", BindingFlags.NonPublic | BindingFlags.Instance);

            // Act
            var resultGuid = await cwsManager.CreateMarketOrderAsync(portfolio, side, quantity, symbol, exchange);

            // Assert
            ensureInitializedMethod?.Invoke(cwsManager, []); // Убедимся, что инициализация была вызвана
            commandMsgUpdateMock.Verify(f => f.Invoke(It.IsAny<string>()), Times.Once()); // Убедимся, что сообщение было отправлено

            // Проверяем формат GUID
            Assert.Matches(new Regex("^a_[0-9]+$"), resultGuid);

            // Проверяем, что GUID в сообщении и возвращенный GUID совпадают
            commandMsgUpdateMock.Verify(f => f.Invoke(It.Is<string>(s => s.Contains(resultGuid))), Times.Once());

            cwsManager.Dispose();
        }

        [Fact]
        public async Task GuidsAreUniqueForDifferentRequests()
        {
            var commandMock = new Mock<Func<string, Task<bool>>>();
            commandMock.Setup(cmd => cmd(It.IsAny<string>())).ReturnsAsync(true);

            var refreshMock = new Mock<Func<Task>>();
            refreshMock.Setup(r => r()).Returns(Task.CompletedTask);

            var cwsManager = new CwsManager(commandMock.Object, refreshMock.Object);

            var guid1 = await cwsManager.CreateMarketOrderAsync("portfolio", Side.Buy, 100, "AAPL", Exchange.SPBX);
            var guid2 = await cwsManager.CreateLimitOrderAsync("portfolio", Side.Sell, 100, 150.00m, "AAPL", Exchange.MOEX);

            Assert.NotEqual(guid1, guid2);

            cwsManager.Dispose();
        }

        [Fact]
        public async Task HandlesErrorsDuringCommandUpdate()
        {
            var commandMock = new Mock<Func<string, Task<bool>>>();
            commandMock.Setup(cmd => cmd(It.IsAny<string>())).ThrowsAsync(new InvalidOperationException("Command failed"));

            var refreshMock = new Mock<Func<Task>>();
            refreshMock.Setup(r => r()).Returns(Task.CompletedTask);

            var cwsManager = new CwsManager(commandMock.Object, refreshMock.Object);

            await Assert.ThrowsAsync<InvalidOperationException>(() => cwsManager.CreateMarketOrderAsync("portfolio", Side.Buy, 100, "AAPL", Exchange.SPBX));

            cwsManager.Dispose();
        }

        [Fact]
        public async Task ConcurrentCallsMaintainConsistentState()
        {
            // Arrange
            var commandMock = new Mock<Func<string, Task<bool>>>();
            commandMock.Setup(cmd => cmd(It.IsAny<string>())).ReturnsAsync(true);

            var refreshMock = new Mock<Func<Task>>();
            refreshMock.Setup(r => r()).Returns(Task.CompletedTask);

            var cwsManager = new CwsManager(commandMock.Object, refreshMock.Object);

            var tasks = new List<Task<string>>();

            // Act
            for (var i = 0; i < 100; i++)
            {
                tasks.Add(cwsManager.CreateMarketOrderAsync("portfolio", Side.Buy, 100, "AAPL", Exchange.SPBX));
            }

            var results = await Task.WhenAll(tasks);
            
            //Assert
            Assert.Equal(100, results.Distinct().Count());  // Проверяем, что все GUID уникальны

            cwsManager.Dispose();
        }

        [Fact]
        public void Dispose_ClearsAllResources()
        {
            // Arrange
            var commandMock = new Mock<Func<string, Task<bool>>>();
            commandMock.Setup(cmd => cmd(It.IsAny<string>())).ReturnsAsync(true);

            var refreshMock = new Mock<Func<Task>>();
            refreshMock.Setup(r => r()).Returns(Task.CompletedTask);

            var cwsManager = new CwsManager(commandMock.Object, refreshMock.Object);

            // Act
            cwsManager.Dispose();

            // Assert
            // Проверяем, что все делегаты были обнулены после вызова Dispose
            var commandMsgUpdateField = typeof(CwsManager).GetField("_commandMsgUpdate", BindingFlags.NonPublic | BindingFlags.Instance);
            var cwsAuthorizeAndSetRefreshTimerField = typeof(CwsManager).GetField("_cwsAuthorizeAndSetRefreshTimer", BindingFlags.NonPublic | BindingFlags.Instance);

            Assert.Null(commandMsgUpdateField?.GetValue(cwsManager));
            Assert.Null(cwsAuthorizeAndSetRefreshTimerField?.GetValue(cwsManager));
        }
    }
}
