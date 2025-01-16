using Alor.OpenAPI.Enums;
using Alor.OpenAPI.Interfaces;
using Alor.OpenAPI.Managers;
using Alor.OpenAPI.Models;
using Alor.OpenAPI.Utilities;
using Alor.OpenAPI.Websocket;
using Moq;
using Serilog;
using System.Collections.Concurrent;
using System.Reflection;
using System.Text;

namespace Alor.OpenAPI.Tests
{
    public class WebSocketsPoolManagerTests
    {
        [Fact]
        public void WebSocketsPoolManager_Initializes_With_Default_Parameters_Correctly()
        {
            // Arrange
            var metricsRegistryMock = new Mock<IMetricsRegistry>();
            metricsRegistryMock.Setup(x => x.MetricsOptions).Returns(new ConcurrentDictionary<string, object>());
            var jwtToken = "testJwtToken";
            var webSocketUri = new Uri("ws://test.websocket.com");
            var commandWebSocketUri = new Uri("ws://command.websocket.com");

            // Act
            var webSocketsPoolManager = new WebSocketsPoolManager(
                new ConcurrentDictionary<string, Parameters>(), 
                () => { },
                () => { },
                jwtToken,
                metricsRegistryMock.Object,
                webSocketUri,
                commandWebSocketUri,
                AlorOpenApiLogLevel.Information);

            var webSocketConnectionsField = typeof(WebSocketsPoolManager)
                .GetField("_webSocketConnections", BindingFlags.NonPublic | BindingFlags.Instance);
            var webSocketConnectionsValue = webSocketConnectionsField?.GetValue(webSocketsPoolManager);

            var commandWebSocketField = typeof(WebSocketsPoolManager)
                .GetField("_commandWebSocket", BindingFlags.NonPublic | BindingFlags.Instance);
            var commandWebSocketValue = commandWebSocketField?.GetValue(webSocketsPoolManager);

            // Assert
            Assert.NotNull(webSocketsPoolManager);
            Assert.NotNull(webSocketConnectionsValue);
            Assert.NotNull(commandWebSocketValue);
        }

        [Fact]
        public void JwtUpdate_UpdatesTokenInAllConnections()
        {
            // Arrange
            var initialToken = "initialJwtToken";
            var newToken = "newJwtToken";
            var metricsRegistryMock = new Mock<IMetricsRegistry>();
            metricsRegistryMock.Setup(x => x.MetricsOptions).Returns(new ConcurrentDictionary<string, object>());
            var webSocketUri = new Uri("ws://test.websocket.com");
            var commandWebSocketUri = new Uri("ws://command.websocket.com");
            string? updatedToken = null;
            
            var webSocketConnectionManagerMock = new Mock<IWebSocketConnectionManager>();
            webSocketConnectionManagerMock.Setup(manager => manager.JwtUpdate(It.IsAny<string?>()))
                                          .Callback<string?>(token => updatedToken = token);

            var webSocketsPoolManager = new WebSocketsPoolManager(
                new ConcurrentDictionary<string, Parameters>(),
                () => { },
                () => { },
                initialToken,
                metricsRegistryMock.Object,
                webSocketUri,
                commandWebSocketUri,
                AlorOpenApiLogLevel.Information);

            var connectionManagerField = typeof(WebSocketsPoolManager)
                .GetField("_webSocketConnections", BindingFlags.NonPublic | BindingFlags.Instance);
            var commandManagerField = typeof(WebSocketsPoolManager)
                .GetField("_commandWebSocket", BindingFlags.NonPublic | BindingFlags.Instance);

            var connectionManagers = new List<IWebSocketConnectionManager> { webSocketConnectionManagerMock.Object };
            connectionManagerField?.SetValue(webSocketsPoolManager, connectionManagers);
            commandManagerField?.SetValue(webSocketsPoolManager, webSocketConnectionManagerMock.Object);

            // Act
            webSocketsPoolManager.JwtUpdate(newToken);

            // Assert
            Assert.Equal(newToken, updatedToken); 
            webSocketConnectionManagerMock.Verify(manager => manager.JwtUpdate(newToken), Times.Exactly(connectionManagers.Count + 1));
        }

        [Fact]
        public void WebSocketsPoolManager_CreatesAndConfiguresInternalObjectsCorrectly()
        {
            // Arrange
            var initialToken = "initialJwtToken";
            var webSocketUri = new Uri("ws://test.websocket.com");
            var commandWebSocketUri = new Uri("ws://command.websocket.com");
            var metricsRegistryMock = new Mock<IMetricsRegistry>();
            metricsRegistryMock.Setup(x => x.MetricsOptions).Returns(new ConcurrentDictionary<string, object>());
            var names = new List<string> { "Socket1", "Socket2" };

            var webSocketsPoolManager = new WebSocketsPoolManager(
                new ConcurrentDictionary<string, Parameters>(),
                () => { },
                () => { },
                initialToken,
                metricsRegistryMock.Object,
                webSocketUri,
                commandWebSocketUri,
                AlorOpenApiLogLevel.Information,
                names,
                "CommandSocket", 
                names.Count,
                "logSuffix",
                msg => { },
                cmdMsg => { });

            // Act
            var webSocketConnectionsField = typeof(WebSocketsPoolManager)
                .GetField("_webSocketConnections", BindingFlags.NonPublic | BindingFlags.Instance);
            var webSocketConnections = (List<IWebSocketConnectionManager>?)webSocketConnectionsField?.GetValue(webSocketsPoolManager);

            var commandWebSocketField = typeof(WebSocketsPoolManager)
                .GetField("_commandWebSocket", BindingFlags.NonPublic | BindingFlags.Instance);
            var commandWebSocket = (IWebSocketConnectionManager?)commandWebSocketField?.GetValue(webSocketsPoolManager);

            var subscriptionsField = typeof(WebSocketsPoolManager)
                .GetProperty("Subscriptions", BindingFlags.Public | BindingFlags.Instance);
            var subscriptions = (ISubscriptionManager?)subscriptionsField?.GetValue(webSocketsPoolManager);

            // Assert
            Assert.NotNull(webSocketConnections);
            Assert.Equal(names.Count, webSocketConnections.Count);
            Assert.NotNull(commandWebSocket);
            Assert.NotNull(subscriptions);

            foreach (var webSocketConnection in webSocketConnections)
            {
                var jwtTokenField = webSocketConnection.GetType().GetField("_jwtToken", BindingFlags.NonPublic | BindingFlags.Instance);
                var jwtToken = (string?)jwtTokenField?.GetValue(webSocketConnection);
                Assert.Equal(initialToken, jwtToken);
            }
        }

        [Fact]
        public async Task WebSocketsPoolManager_AddsNewSubscriptionsCorrectly()
        {
            // Arrange
            var metricsRegistryMock = new Mock<IMetricsRegistry>();
            metricsRegistryMock.Setup(x => x.MetricsOptions).Returns(new ConcurrentDictionary<string, object>());
            var jwtToken = "testJwtToken";
            var webSocketUri = new Uri("ws://test.websocket.com");
            var commandWebSocketUri = new Uri("ws://command.websocket.com");
            var newSubscriptionKey = "newKey";
            var newSubscriptionValue = "newValue";

            var webSocketConnectionManagerMock = new Mock<IWebSocketConnectionManager>();

            var webSocketsPoolManager = new WebSocketsPoolManager(
                new ConcurrentDictionary<string, Parameters>(),
                () => { },
                () => { },
                jwtToken,
                metricsRegistryMock.Object,
                webSocketUri,
                commandWebSocketUri,
                AlorOpenApiLogLevel.Information);
            
            var connectionManagerField = typeof(WebSocketsPoolManager)
                .GetField("_webSocketConnections", BindingFlags.NonPublic | BindingFlags.Instance);
            var commandManagerField = typeof(WebSocketsPoolManager)
                .GetField("_commandWebSocket", BindingFlags.NonPublic | BindingFlags.Instance);

            var connectionManagers = new List<IWebSocketConnectionManager> { webSocketConnectionManagerMock.Object };
            connectionManagerField?.SetValue(webSocketsPoolManager, connectionManagers);
            commandManagerField?.SetValue(webSocketsPoolManager, webSocketConnectionManagerMock.Object);

            var method = typeof(WebSocketsPoolManager)
                .GetMethod("OnMsgDictionaryUpdatedAsync", BindingFlags.NonPublic | BindingFlags.Instance);

            // Act
            var updateTask = (Task?)method?.Invoke(webSocketsPoolManager, [new Dictionary<string, string> { { newSubscriptionKey, newSubscriptionValue } }]);
            await (updateTask ?? Task.CompletedTask);  

            // Assert
            var guidAndSocketsDictField = typeof(WebSocketsPoolManager)
                .GetField("_guidAndSocketsDict", BindingFlags.NonPublic | BindingFlags.Instance);
            var guidAndSocketsDict = (ConcurrentDictionary<string, IWebSocketConnectionManager>?)guidAndSocketsDictField?.GetValue(webSocketsPoolManager);

            Assert.True(guidAndSocketsDict?.ContainsKey(newSubscriptionKey), "The new subscription key should be added to _guidAndSocketsDict.");
            webSocketConnectionManagerMock.Verify(x => x.SendOrStartAndSend(It.Is<IReadOnlyCollection<string>>(msgs => msgs.Contains(newSubscriptionValue))), Times.Once(), "SendOrStartAndSend should be called with the value corresponding to the key.");

        }

        [Fact]
        public async Task WebSocketsPoolManager_RemovesSubscriptionsCorrectly()
        {
            // Arrange
            var metricsRegistryMock = new Mock<IMetricsRegistry>();
            metricsRegistryMock.Setup(x => x.MetricsOptions).Returns(new ConcurrentDictionary<string, object>());
            var jwtToken = "testJwtToken";
            var webSocketUri = new Uri("ws://test.websocket.com");
            var commandWebSocketUri = new Uri("ws://command.websocket.com");
            var existingSubscriptionKey = "existingKey";
            var existingSubscriptionValue = "existingValue";

            var webSocketConnectionManagerMock = new Mock<IWebSocketConnectionManager>();

            var webSocketsPoolManager = new WebSocketsPoolManager(
                new ConcurrentDictionary<string, Parameters>(),
                () => { },
                () => { },
                jwtToken,
                metricsRegistryMock.Object,
                webSocketUri,
                commandWebSocketUri,
                AlorOpenApiLogLevel.Information);

            var guidAndSocketsDict = new ConcurrentDictionary<string, IWebSocketConnectionManager>();
            guidAndSocketsDict.TryAdd(existingSubscriptionKey, webSocketConnectionManagerMock.Object);

            var guidAndSocketsDictField = typeof(WebSocketsPoolManager)
                .GetField("_guidAndSocketsDict", BindingFlags.NonPublic | BindingFlags.Instance);
            guidAndSocketsDictField?.SetValue(webSocketsPoolManager, guidAndSocketsDict);

            var method = typeof(WebSocketsPoolManager)
                .GetMethod("OnMsgDeleteRequestAsync", BindingFlags.NonPublic | BindingFlags.Instance);

            // Act
            var deleteTask = (Task?)method?.Invoke(webSocketsPoolManager, [new Dictionary<string, string> { { existingSubscriptionKey, existingSubscriptionValue } }]);
            await (deleteTask ?? Task.CompletedTask);

            // Assert
            webSocketConnectionManagerMock.Verify(x => x.TryToRemoveFromOpcodes(existingSubscriptionKey), Times.Once());
            webSocketConnectionManagerMock.Verify(x => x.SendOrStartAndSend(It.Is<IReadOnlyCollection<string>>(msgs => msgs.Contains(existingSubscriptionValue))), Times.Once(), "SendOrStartAndSend should be called with the value corresponding to the key.");
        }

        [Fact]
        public void GetWebSocketsInfoDetail_Returns_Correct_Information()
        {
            // Arrange
            var metricsRegistryMock = new Mock<IMetricsRegistry>();
            metricsRegistryMock.Setup(x => x.MetricsOptions).Returns(new ConcurrentDictionary<string, object>());
            var jwtToken = "testJwtToken";
            var webSocketUri = new Uri("ws://test.websocket.com");
            var commandWebSocketUri = new Uri("ws://command.websocket.com");

            var webSocketConnectionManagerMock = new Mock<IWebSocketConnectionManager>();
            webSocketConnectionManagerMock.Setup(x => x.GetSocketInfoDetails())
                                          .Returns(new WebSocketInfoDetails("TestSocket", 100, 200, DateTime.Now, 1, 10, 20.0, 5));

            var commandWebSocketMock = new Mock<IWebSocketConnectionManager>();
            commandWebSocketMock.Setup(x => x.GetSocketInfoDetails())
                                .Returns(new WebSocketInfoDetails("CommandSocket", 150, 250, DateTime.Now, 2, 15, 25.0, 10));

            var webSocketsPoolManager = new WebSocketsPoolManager(
                new ConcurrentDictionary<string, Parameters>(),
                () => { },
                () => { },
                jwtToken,
                metricsRegistryMock.Object,
                webSocketUri,
                commandWebSocketUri,
                AlorOpenApiLogLevel.Information);

            var connectionManagers = new List<IWebSocketConnectionManager> { webSocketConnectionManagerMock.Object };
            var connectionManagerField = typeof(WebSocketsPoolManager)
                .GetField("_webSocketConnections", BindingFlags.NonPublic | BindingFlags.Instance);
            connectionManagerField?.SetValue(webSocketsPoolManager, connectionManagers);

            var commandManagerField = typeof(WebSocketsPoolManager)
                .GetField("_commandWebSocket", BindingFlags.NonPublic | BindingFlags.Instance);
            commandManagerField?.SetValue(webSocketsPoolManager, commandWebSocketMock.Object);

            // Act
            var details = ((IInternalWebSocketsPoolManagerActions)webSocketsPoolManager).GetWebSocketsInfoDetail().ToList();

            // Assert
            Assert.Equal(2, details.Count);
            Assert.Contains(details, d => d is { Name: "TestSocket", ReceivedCount: 200 });
            Assert.Contains(details, d => d is { Name: "CommandSocket", ReceivedCount: 250 });
        }

        [Fact]
        public void WebSocketsPoolManager_Invokes_wsResponseMessageChangedFromUser_On_MessageReceived()
        {
            // Arrange
            var loggerMock = new Mock<ILogger>();
            var metricsRegistryMock = new Mock<IMetricsRegistry>();
            metricsRegistryMock.Setup(x => x.MetricsOptions).Returns(new ConcurrentDictionary<string, object>());
            var jwtToken = "testToken";
            var parameters = new ConcurrentDictionary<string, Parameters>();
            var wsResponseMessageChangedMock = new Mock<Action<WsResponseMessage>>();

            var webSocketMessageHandler = new WebSocketMessageHandler(
                loggerMock.Object,
                loggerMock.Object,
                AlorOpenApiLogLevel.Fatal,
                parameters,
                wsResponseMessageChangedMock.Object,
                null
            );

            var wsManager = new WebSocketsPoolManager(
                parameters,
                () => { },
                () => { },
                jwtToken,
                metricsRegistryMock.Object,
                new Uri("ws://fake.uri"),
                new Uri("wss://fake.uri"),
                AlorOpenApiLogLevel.Information,
                wsResponseMessageHandlerFromUser: wsResponseMessageChangedMock.Object
            );

            var webSocketMessageHandlerField = typeof(WebSocketsPoolManager)
                .GetField("_webSocketMessageHandler", BindingFlags.NonPublic | BindingFlags.Instance);
            webSocketMessageHandlerField?.SetValue(wsManager, webSocketMessageHandler);

            var testJsonMessage = "{\"requestGuid\":\"123\",\"httpCode\":200,\"message\":\"Handled successfully\"}";
            var messageBytes = Encoding.UTF8.GetBytes(testJsonMessage);

            // Act
            webSocketMessageHandler.MessageReceived((messageBytes, messageBytes.Length, DateTime.UtcNow), "TestSocket");

            // Assert
            wsResponseMessageChangedMock.Verify(handler => handler(It.Is<WsResponseMessage>(msg =>
                msg.RequestGuid == "123" &&
                msg.HttpCode == 200 &&
                msg.Message == "Handled successfully")),
                Times.Once);
        }

        [Fact]
        public void WebSocketsPoolManager_Invokes_wsResponseCommandMessageChangedFromUser_On_MessageReceived()
        {
            // Arrange
            var loggerMock = new Mock<ILogger>();
            var metricsRegistryMock = new Mock<IMetricsRegistry>();
            metricsRegistryMock.Setup(x => x.MetricsOptions).Returns(new ConcurrentDictionary<string, object>());
            var jwtToken = "testToken";
            var parameters = new ConcurrentDictionary<string, Parameters>();
            var wsResponseCommandMessageChangedMock = new Mock<Action<WsResponseCommandMessage>>();

            var webSocketMessageHandler = new WebSocketMessageHandler(
                loggerMock.Object,
                loggerMock.Object,
                AlorOpenApiLogLevel.Fatal,
                parameters,
                null,
                wsResponseCommandMessageChangedMock.Object
            );

            var wsManager = new WebSocketsPoolManager(
                parameters,
                () => { },
                () => { },
                jwtToken,
                metricsRegistryMock.Object,
                new Uri("ws://fake.uri"),
                new Uri("wss://fake.uri"),
                AlorOpenApiLogLevel.Information,
                wsResponseCommandMessageHandlerFromUser: wsResponseCommandMessageChangedMock.Object
            );

            var webSocketMessageHandlerField = typeof(WebSocketsPoolManager)
                .GetField("_webSocketMessageHandler", BindingFlags.NonPublic | BindingFlags.Instance);
            webSocketMessageHandlerField?.SetValue(wsManager, webSocketMessageHandler);

            var testJsonMessage = "{\"requestGuid\":\"a_123\",\"httpCode\":200,\"message\":\"Handled successfully\"}";
            var messageBytes = Encoding.UTF8.GetBytes(testJsonMessage);

            // Act
            webSocketMessageHandler.MessageReceived((messageBytes, messageBytes.Length, DateTime.UtcNow), "TestSocket");

            // Assert
            wsResponseCommandMessageChangedMock.Verify(handler => handler(It.Is<WsResponseCommandMessage>(msg =>
                msg.RequestGuid == "a_123" &&
                msg.HttpCode == 200 &&
                msg.Message == "Handled successfully")),
                Times.Once);
        }

        [Fact]
        public async Task WebSocketsPoolManager_HandlesAuthenticationAndCommandMessages()
        {
            // Arrange
            var metricsRegistryMock = new Mock<IMetricsRegistry>();
            metricsRegistryMock.Setup(x => x.MetricsOptions).Returns(new ConcurrentDictionary<string, object>());

            var commandMsgUpdateMock = new Mock<Func<string, Task<bool>>>();
            commandMsgUpdateMock.Setup(f => f(It.IsAny<string>())).Returns(Task.FromResult(true));

            var cwsAuthorizeAndSetRefreshTimerMock = new Mock<Func<Task>>();
            cwsAuthorizeAndSetRefreshTimerMock.Setup(f => f()).Returns(Task.CompletedTask);

            var parameters = new ConcurrentDictionary<string, Parameters>();
            var wsManager = new WebSocketsPoolManager(
                parameters,
                () => { },
                () => { },
                "jwtToken",
                metricsRegistryMock.Object,
                new Uri("ws://fake.uri"),
                new Uri("wss://fake.uri"),
                AlorOpenApiLogLevel.Information
            );

            var cwsAuthorizeField = typeof(CwsManager).GetField("_cwsAuthorizeAndSetRefreshTimer", BindingFlags.NonPublic | BindingFlags.Instance);
            cwsAuthorizeField?.SetValue(wsManager.CommandWs, cwsAuthorizeAndSetRefreshTimerMock.Object);
            var commandMsgUpdateField = typeof(CwsManager).GetField("_commandMsgUpdate", BindingFlags.NonPublic | BindingFlags.Instance);
            commandMsgUpdateField?.SetValue(wsManager.CommandWs, commandMsgUpdateMock.Object);

            // Act
            await wsManager.CommandWs.CreateLimitOrderAsync("portfolio", Side.Buy, 100, 50.5m, "AAPL", Exchange.SPBX);

            // Assert
            cwsAuthorizeAndSetRefreshTimerMock.Verify(service => service.Invoke(), Times.Once);
            commandMsgUpdateMock.Verify(service => service.Invoke(It.IsAny<string>()), Times.Once);
        }

        [Fact]
        public void WebSocketsPoolManager_Dispose_ReleasesAllResources()
        {
            // Arrange
            var metricsRegistryMock = new Mock<IMetricsRegistry>();
            metricsRegistryMock.Setup(x => x.MetricsOptions).Returns(new ConcurrentDictionary<string, object>());
            var loggerMock = new Mock<ILogger>();

            var parameters = new ConcurrentDictionary<string, Parameters>();
            var wsManager = new WebSocketsPoolManager(
                parameters,
                () => { },
                () => { },
                "jwtToken",
                metricsRegistryMock.Object,
                new Uri("ws://fake.uri"),
                new Uri("wss://fake.uri"),
                AlorOpenApiLogLevel.Information
            );

            var loggerField = typeof(WebSocketsPoolManager).GetField("_logger", BindingFlags.NonPublic | BindingFlags.Instance);
            loggerField?.SetValue(wsManager, loggerMock.Object);

            var webSocketConnectionMock = new Mock<IWebSocketConnectionManager>();
            webSocketConnectionMock.Setup(manager => manager.Dispose());

            var connectionsField = typeof(WebSocketsPoolManager).GetField("_webSocketConnections", BindingFlags.NonPublic | BindingFlags.Instance);
            var commandWebSocketField = typeof(WebSocketsPoolManager).GetField("_commandWebSocket", BindingFlags.NonPublic | BindingFlags.Instance);
            var connections = new List<IWebSocketConnectionManager> { webSocketConnectionMock.Object, webSocketConnectionMock.Object };
            connectionsField?.SetValue(wsManager, connections);
            commandWebSocketField?.SetValue(wsManager, webSocketConnectionMock.Object);

            // Act
            wsManager.Dispose();

            // Assert
            webSocketConnectionMock.Verify(manager => manager.Dispose(), Times.Exactly(3));
            loggerMock.Verify(log => log.Information("Закрыли и уничтожили все сокеты."), Times.Once);

            var responseMessageDelegate = typeof(WebSocketsPoolManager).GetField("_wsResponseMessageChangedFromUser", BindingFlags.NonPublic | BindingFlags.Instance);
            var commandMessageDelegate = typeof(WebSocketsPoolManager).GetField("_wsResponseCommandMessageChangedFromUser", BindingFlags.NonPublic | BindingFlags.Instance);
            Assert.Null(responseMessageDelegate?.GetValue(wsManager));
            Assert.Null(commandMessageDelegate?.GetValue(wsManager));
        }

    }
}
