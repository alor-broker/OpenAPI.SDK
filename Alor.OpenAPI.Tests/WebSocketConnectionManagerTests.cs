using Alor.OpenAPI.Interfaces;
using Alor.OpenAPI.Managers;
using Alor.OpenAPI.Websocket;
using Moq;
using Serilog;
using System.Collections.Concurrent;
using System.Reflection;
using System.Text;

namespace Alor.OpenAPI.Tests
{
    public class WebSocketConnectionManagerTests
    {
        [Fact]
        public void WebSocketConnectionManager_InitializesCorrectly()
        {
            // Arrange
            var loggerMock = new Mock<ILogger>();
            var metricsRegistryMock = new Mock<IMetricsRegistry>();
            metricsRegistryMock.Setup(x => x.MetricsOptions).Returns(new ConcurrentDictionary<string, object>());
            var uri = new Uri("wss://test.websocket.com");
            var jwtToken = "testToken";
            var incrementCounter = new Action(() => { });
            var decrementCounter = new Action(() => { });
            var onMessageReceived = new Action<(byte[], int, DateTime), string>((data, name) => { });

            // Act
            var manager = new WebSocketConnectionManager(loggerMock.Object, uri, jwtToken, metricsRegistryMock.Object,
                incrementCounter, decrementCounter, 1, "TestSocket", onMessageReceived);

            // Assert
            Assert.NotNull(manager);
        }

        [Fact]
        public void WebSocketConnectionManager_ThrowsErrorOnInvalidParameters()
        {
            // Arrange
            var loggerMock = new Mock<ILogger>();
            var metricsRegistryMock = new Mock<IMetricsRegistry>();
            metricsRegistryMock.Setup(x => x.MetricsOptions).Returns(new ConcurrentDictionary<string, object>());
            var uri = new Uri("wss://test.websocket.com");
            var jwtToken = "testToken";
            var incrementCounter = new Action(() => { });
            var decrementCounter = new Action(() => { });
            var onMessageReceived = new Action<(byte[], int, DateTime), string>((data, name) => { });

            // Act and Assert
            // Проверка на null URI
            Assert.Throws<ArgumentNullException>(() => new WebSocketConnectionManager(loggerMock.Object, null!,
                jwtToken,
                metricsRegistryMock.Object, incrementCounter, decrementCounter, 1, "TestSocket", onMessageReceived));

            // Проверка на null Logger
            Assert.Throws<ArgumentNullException>(() => new WebSocketConnectionManager(null!, uri, jwtToken,
                metricsRegistryMock.Object, incrementCounter, decrementCounter, 1, "TestSocket", onMessageReceived));

            // Проверка на null MetricsRegistry
            Assert.Throws<ArgumentNullException>(() => new WebSocketConnectionManager(loggerMock.Object, uri, jwtToken,
                null!, incrementCounter, decrementCounter, 1, "TestSocket", onMessageReceived));

            // Проверка на null Action Delegate
            Assert.Throws<ArgumentNullException>(() => new WebSocketConnectionManager(loggerMock.Object, uri, jwtToken,
                metricsRegistryMock.Object, null!, decrementCounter, 1, "TestSocket", onMessageReceived));

            // Проверка на null Action Delegate
            Assert.Throws<ArgumentNullException>(() => new WebSocketConnectionManager(loggerMock.Object, uri, jwtToken,
                metricsRegistryMock.Object, incrementCounter, null!, 1, "TestSocket", onMessageReceived));

            // Проверка на null Action Delegate
            Assert.Throws<ArgumentNullException>(() => new WebSocketConnectionManager(loggerMock.Object, uri, jwtToken,
                metricsRegistryMock.Object, incrementCounter, decrementCounter, 1, "TestSocket", null!));

        }

        [Fact]
        public async Task WebSocketConnectionManager_HandlesMessagesCorrectly()
        {
            // Arrange
            var loggerMock = new Mock<ILogger>();
            var metricsRegistryMock = new Mock<IMetricsRegistry>();
            metricsRegistryMock.Setup(x => x.MetricsOptions).Returns(new ConcurrentDictionary<string, object>());
            var uri = new Uri("wss://test.websocket.com");
            var jwtToken = "testToken";
            var incrementCounter = new Action(() => { });
            var decrementCounter = new Action(() => { });
            var messageReceived = false;
            var receivedData = Array.Empty<byte>();
            var receivedName = string.Empty;

            void OnMessageReceived((byte[] data, int len, DateTime timestamp) message, string name)
            {
                messageReceived = true;
                receivedData = message.data;
                receivedName = name;
            }

            var webSocketInfoMock = new Mock<IWebSocketInfo>();
            webSocketInfoMock.Setup(ws => ws.Name).Returns("TestSocket");
            webSocketInfoMock.Setup(ws => ws.SendAsync(It.IsAny<string>())).Returns(Task.FromResult(true));

            // Инициализация WebSocketConnectionManager с подменой _webSocketInfo
            var manager = new WebSocketConnectionManager(loggerMock.Object, uri, jwtToken, metricsRegistryMock.Object,
                incrementCounter, decrementCounter, 1, "TestSocket", OnMessageReceived);
            var webSocketInfoField =
                typeof(WebSocketConnectionManager).GetField("_webSocketInfo",
                    BindingFlags.NonPublic | BindingFlags.Instance);
            webSocketInfoField?.SetValue(manager, webSocketInfoMock.Object);

            // Подготовка имитированного сообщения
            var fakeMessage = "Test message"u8.ToArray();
            var messageLength = fakeMessage.Length;

            // Act
            // Вызов события Message на моке
            await manager.SendOrStartAndSend(Encoding.UTF8.GetString(fakeMessage));

#pragma warning disable PH_S019 // Blocking Method in Async Method
            webSocketInfoMock.Raise(ws => ws.Message += null, webSocketInfoMock.Object, (fakeMessage, messageLength, DateTime.UtcNow));
#pragma warning restore PH_S019 // Blocking Method in Async Method

            // Assert
            Assert.True(messageReceived, "Message received delegate was not invoked.");
            Assert.Equal("Test message", Encoding.UTF8.GetString(receivedData));
            Assert.Equal("TestSocket", receivedName);
        }

        [Fact]
        public void AddAndRemoveSubscription_Successful()
        {
            // Arrange
            var loggerMock = new Mock<ILogger>();
            var metricsRegistryMock = new Mock<IMetricsRegistry>();
            metricsRegistryMock.Setup(x => x.MetricsOptions).Returns(new ConcurrentDictionary<string, object>());
            var uri = new Uri("wss://test.websocket.com");
            var jwtToken = "testToken";

            void IncrementCounter()
            {
            }

            void DecrementCounter()
            {
            }

            void OnMessageReceived((byte[], int, DateTime) data, string name)
            {
            }

            var manager = new WebSocketConnectionManager(loggerMock.Object, uri, jwtToken, metricsRegistryMock.Object,
                IncrementCounter, DecrementCounter, 1, "TestSocket", OnMessageReceived);

            var guid = Guid.NewGuid().ToString();
            var message = "Test Message";

            // Act
            var addResult = manager.AddToOpcodes(guid, message);
            var removeResult = manager.TryToRemoveFromOpcodes(guid);

            // Assert
            Assert.True(addResult, "Failed to add subscription");
            Assert.True(removeResult, "Failed to remove subscription");
        }

        [Fact]
        public void RemoveNonExistentSubscription_ReturnsFalse()
        {
            // Arrange
            var loggerMock = new Mock<ILogger>();
            var metricsRegistryMock = new Mock<IMetricsRegistry>();
            metricsRegistryMock.Setup(x => x.MetricsOptions).Returns(new ConcurrentDictionary<string, object>());
            var uri = new Uri("wss://test.websocket.com");
            var jwtToken = "testToken";

            void IncrementCounter()
            {
            }

            void DecrementCounter()
            {
            }

            void OnMessageReceived((byte[], int, DateTime) data, string name)
            {
            }

            var manager = new WebSocketConnectionManager(loggerMock.Object, uri, jwtToken, metricsRegistryMock.Object,
                IncrementCounter, DecrementCounter, 1, "TestSocket", OnMessageReceived);

            var guid = Guid.NewGuid().ToString();

            // Act
            var removeResult = manager.TryToRemoveFromOpcodes(guid);

            // Assert
            Assert.False(removeResult, "Incorrectly removed a non-existent subscription");
        }

        [Fact]
        public async Task SendMessage_Successful()
        {
            // Arrange
            var loggerMock = new Mock<ILogger>();
            var metricsRegistryMock = new Mock<IMetricsRegistry>();
            metricsRegistryMock.Setup(x => x.MetricsOptions).Returns(new ConcurrentDictionary<string, object>());
            var uri = new Uri("wss://test.websocket.com");
            var jwtToken = "testToken";

            void IncrementCounter()
            {
            }

            void DecrementCounter()
            {
            }

            void OnMessageReceived((byte[], int, DateTime) data, string name)
            {
            }

            var webSocketInfoMock = new Mock<IWebSocketInfo>();
            webSocketInfoMock.Setup(ws => ws.IsConnected).Returns(true);
            webSocketInfoMock.Setup(ws => ws.SendAsync(It.IsAny<string>())).Returns(Task.FromResult(true));

            var manager = new WebSocketConnectionManager(loggerMock.Object, uri, jwtToken, metricsRegistryMock.Object,
                IncrementCounter, DecrementCounter, 1, "TestSocket", OnMessageReceived);

            typeof(WebSocketConnectionManager)
                .GetField("_webSocketInfo", BindingFlags.NonPublic | BindingFlags.Instance)
                ?.SetValue(manager, webSocketInfoMock.Object);

            var message = "Hello World! JwtToken";

            // Act
            var result = await manager.SendOrStartAndSend(message);

            // Assert
            Assert.True(result, "Message was not sent successfully");
            webSocketInfoMock.Verify(ws => ws.SendAsync("Hello World! testToken"), Times.Once());
        }

        [Fact]
        public async Task SendMessage_FailsWithoutConnection()
        {
            // Arrange
            var loggerMock = new Mock<ILogger>();
            var metricsRegistryMock = new Mock<IMetricsRegistry>();
            metricsRegistryMock.Setup(x => x.MetricsOptions).Returns(new ConcurrentDictionary<string, object>());
            var uri = new Uri("wss://test.websocket.com");
            var jwtToken = "testToken";

            void IncrementCounter()
            {
            }

            void DecrementCounter()
            {
            }

            void OnMessageReceived((byte[], int, DateTime) data, string name)
            {
            }

            var webSocketInfoMock = new Mock<IWebSocketInfo>();
            webSocketInfoMock.Setup(ws => ws.IsConnected).Returns(false);
            webSocketInfoMock.Setup(ws => ws.StartAsync()).Returns(Task.CompletedTask);
            webSocketInfoMock.Setup(ws => ws.SendAsync(It.IsAny<string>())).Returns(Task.FromResult(true));

            var manager = new WebSocketConnectionManager(loggerMock.Object, uri, jwtToken, metricsRegistryMock.Object,
                IncrementCounter, DecrementCounter, 1, "TestSocket", OnMessageReceived);

            typeof(WebSocketConnectionManager)
                .GetField("_webSocketInfo", BindingFlags.NonPublic | BindingFlags.Instance)
                ?.SetValue(manager, webSocketInfoMock.Object);

            var message = "Hello World! JwtToken";

            // Act
            var result = await manager.SendOrStartAndSend(message);

            // Assert
            Assert.True(result, "Message was not sent successfully");
            webSocketInfoMock.Verify(ws => ws.StartAsync(), Times.Once());
            webSocketInfoMock.Verify(ws => ws.SendAsync("Hello World! testToken"), Times.Once());
        }

        [Fact]
        public async Task Reconnection_OnDisconnect()
        {
            // Arrange
            var loggerMock = new Mock<ILogger>();
            var metricsRegistryMock = new Mock<IMetricsRegistry>();
            metricsRegistryMock.Setup(x => x.MetricsOptions).Returns(new ConcurrentDictionary<string, object>());
            var uri = new Uri("wss://test.websocket.com");
            var jwtToken = "testToken";
            var incrementCount = 0;
            var decrementCount = 0;

            void IncrementCounter()
            {
                incrementCount++;
            }

            void DecrementCounter()
            {
                decrementCount++;
            }

            void OnMessageReceived((byte[], int, DateTime) data, string name)
            {
            }

            var webSocketInfoMock = new Mock<IWebSocketInfo>();
            webSocketInfoMock.SetupProperty(ws => ws.Closed);
            webSocketInfoMock.Setup(ws => ws.Name).Returns("TestSocket");
            webSocketInfoMock.Setup(ws => ws.IsConnected).Returns(false);
            webSocketInfoMock.Setup(ws => ws.SendAsync(It.IsAny<string>())).ReturnsAsync(true);
            webSocketInfoMock.Setup(ws => ws.StartAsync()).Returns(Task.CompletedTask);
            webSocketInfoMock.Setup(ws => ws.CloseSocketAndResetCounters()).Returns(Task.CompletedTask);
            webSocketInfoMock.Setup(ws => ws.Opcodes).Returns(new ConcurrentDictionary<string, string>()
                                                              {
                                                                  ["someKey"] = "someValue"
                                                              });

            // Creating WebSocketConnectionManager
            var manager = new WebSocketConnectionManager(loggerMock.Object, uri, jwtToken, metricsRegistryMock.Object,
                IncrementCounter, DecrementCounter, 1, "TestSocket", OnMessageReceived);

            // Emulating private field assignment
            typeof(WebSocketConnectionManager)
                .GetField("_webSocketInfo", BindingFlags.NonPublic | BindingFlags.Instance)
                ?.SetValue(manager, webSocketInfoMock.Object);

            // Act
            await manager.SendOrStartAndSend("Test message");

            await (webSocketInfoMock.Object.Closed?.Invoke(webSocketInfoMock.Object) ?? Task.CompletedTask);

            // Assert
            Assert.Equal(2, incrementCount);
            Assert.Equal(1, decrementCount);
            webSocketInfoMock.Verify(ws => ws.StartAsync(), Times.Exactly(2));
            webSocketInfoMock.Verify(ws => ws.CloseSocketAndResetCounters(), Times.Once());
        }

        [Fact]
        public async Task Websocket_ErrorIsHandledCorrectly()
        {
            // Arrange
            var loggerMock = new Mock<ILogger>();
            var metricsRegistryMock = new Mock<IMetricsRegistry>();
            metricsRegistryMock.Setup(x => x.MetricsOptions).Returns(new ConcurrentDictionary<string, object>());
            var uri = new Uri("wss://test.websocket.com");
            var jwtToken = "testToken";
            var exception = new Exception("Test exception");

            void IncrementCounter()
            {
            }

            void DecrementCounter()
            {
            }

            void OnMessageReceived((byte[], int, DateTime) data, string name)
            {
            }

            var webSocketInfoMock = new Mock<IWebSocketInfo>();
            webSocketInfoMock.SetupProperty(ws => ws.Error);
            webSocketInfoMock.Setup(ws => ws.IsConnected).Returns(false);
            webSocketInfoMock.Setup(ws => ws.SendAsync(It.IsAny<string>())).Returns(Task.FromResult(true));

            var manager = new WebSocketConnectionManager(loggerMock.Object, uri, jwtToken, metricsRegistryMock.Object,
                IncrementCounter, DecrementCounter, 1, "TestSocket", OnMessageReceived);

            // Emulating private field assignment
            typeof(WebSocketConnectionManager)
                .GetField("_webSocketInfo", BindingFlags.NonPublic | BindingFlags.Instance)
                ?.SetValue(manager, webSocketInfoMock.Object);

            // Act
            await manager.SendOrStartAndSend("Test message");

            webSocketInfoMock.Object.Error?.Invoke(webSocketInfoMock.Object, exception);

            // Assert
            loggerMock.Verify(
                log => log.Error(It.Is<string>(msg => msg.Contains($"Поймали еррор: {exception.Message}"))),
                Times.Once());
        }

        [Fact]
        public async Task Websocket_WarningIsHandledCorrectly()
        {
            // Arrange
            var loggerMock = new Mock<ILogger>();
            var metricsRegistryMock = new Mock<IMetricsRegistry>();
            metricsRegistryMock.Setup(x => x.MetricsOptions).Returns(new ConcurrentDictionary<string, object>());
            var uri = new Uri("wss://test.websocket.com");
            var jwtToken = "testToken";
            var warning = "Test warning";

            void IncrementCounter()
            {
            }

            void DecrementCounter()
            {
            }

            void OnMessageReceived((byte[], int, DateTime) data, string name)
            {
            }

            var webSocketInfoMock = new Mock<IWebSocketInfo>();
            webSocketInfoMock.SetupProperty(ws => ws.Warning);
            webSocketInfoMock.Setup(ws => ws.IsConnected).Returns(false);
            webSocketInfoMock.Setup(ws => ws.SendAsync(It.IsAny<string>())).Returns(Task.FromResult(true));

            var manager = new WebSocketConnectionManager(loggerMock.Object, uri, jwtToken, metricsRegistryMock.Object,
                IncrementCounter, DecrementCounter, 1, "TestSocket", OnMessageReceived);

            // Emulating private field assignment
            typeof(WebSocketConnectionManager)
                .GetField("_webSocketInfo", BindingFlags.NonPublic | BindingFlags.Instance)
                ?.SetValue(manager, webSocketInfoMock.Object);

            // Act
            await manager.SendOrStartAndSend("Test message");

            webSocketInfoMock.Object.Warning?.Invoke(webSocketInfoMock.Object, warning);

            // Assert
            loggerMock.Verify(log => log.Warning(It.Is<string>(msg => msg.Contains($"Предупреждение: {warning}"))),
                Times.Once());
        }

        [Fact]
        public void WebSocketConnectionManager_Disposes_Resources_Correctly()
        {
            // Arrange
            var loggerMock = new Mock<ILogger>();
            var metricsRegistryMock = new Mock<IMetricsRegistry>();
            metricsRegistryMock.Setup(x => x.MetricsOptions).Returns(new ConcurrentDictionary<string, object>());
            var uri = new Uri("wss://test.websocket.com");
            var jwtToken = "testToken";

            void IncrementCounter()
            {
            }

            void DecrementCounter()
            {
            }

            void OnMessageReceived((byte[], int, DateTime) data, string name)
            {
            }

            var webSocketInfoMock = new Mock<IWebSocketInfo>();

            var manager = new WebSocketConnectionManager(loggerMock.Object, uri, jwtToken, metricsRegistryMock.Object,
                IncrementCounter, DecrementCounter, 1, "TestSocket", OnMessageReceived);

            // Emulating private field assignment
            typeof(WebSocketConnectionManager)
                .GetField("_webSocketInfo", BindingFlags.NonPublic | BindingFlags.Instance)
                ?.SetValue(manager, webSocketInfoMock.Object);

            // Act
            manager.Dispose();

            // Assert
            // Проверяем, что все подписки и делегаты были обнулены или отписаны
            Assert.Null(manager.GetType().GetField("_incrementSocketsCounter", BindingFlags.NonPublic | BindingFlags.Instance)?.GetValue(manager));
            Assert.Null(manager.GetType().GetField("_decrementSocketsCounter", BindingFlags.NonPublic | BindingFlags.Instance)?.GetValue(manager));
            Assert.Null(manager.GetType().GetField("_onMessageReceived", BindingFlags.NonPublic | BindingFlags.Instance)?.GetValue(manager));

            webSocketInfoMock.Verify(ws => ws.Dispose(), Times.Once());
        }
    }
}
