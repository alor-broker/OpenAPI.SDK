using Alor.OpenAPI.Managers;
using Alor.OpenAPI.Models;
using Alor.OpenAPI.Models.Heavy;
using Alor.OpenAPI.Models.Simple;
using Alor.OpenAPI.Models.Slim;
using Moq;
using Serilog;
using System.Collections.Concurrent;
using System.Reflection;
using System.Text;

namespace Alor.OpenAPI.Tests
{
    public class WebSocketMessageHandlerTests
    {
        [Fact]
        public void Constructor_Initializes_All_Required_Properties_Correctly()
        {
            // Arrange
            var loggerMock = new Mock<ILogger>();
            var commandLoggerMock = new Mock<ILogger>();
            var parameters = new ConcurrentDictionary<string, Parameters>();

            // Act
            var handler =
                new WebSocketMessageHandler(loggerMock.Object, commandLoggerMock.Object, Utilities.AlorOpenApiLogLevel.Fatal, parameters, null, null);

            // Assert
            Assert.NotNull(handler);
            Assert.Equal(loggerMock.Object,
                handler.GetType().GetField("_logger", BindingFlags.NonPublic | BindingFlags.Instance)
                    ?.GetValue(handler));
            Assert.Equal(commandLoggerMock.Object,
                handler.GetType().GetField("_commandLogger", BindingFlags.NonPublic | BindingFlags.Instance)
                    ?.GetValue(handler));
            Assert.Equal(parameters,
                handler.GetType().GetField("_parameters", BindingFlags.NonPublic | BindingFlags.Instance)
                    ?.GetValue(handler));

            // Assert - проверяем инициализацию всех делегатов
            var handlerType = handler.GetType();
            var delegateFields = handlerType.GetFields(BindingFlags.NonPublic | BindingFlags.Instance)
                .Where(f => f.FieldType.BaseType == typeof(MulticastDelegate));

            foreach (var delegateField in delegateFields)
            {
                var delegateValue = delegateField.GetValue(handler);
                Assert.Null(delegateValue);
            }
        }

        public static IEnumerable<object[]> GetDelegateUpdateMethods()
        {
            yield return ["UpdateWsOrderBookSimpleUserDelegate", typeof(WsOrderBookSimple)];
            yield return ["UpdateWsOrderBookSlimUserDelegate", typeof(WsOrderBookSlim)];
            yield return ["UpdateWsOrderBookHeavyUserDelegate", typeof(WsOrderBookHeavy)];
            yield return ["UpdateWsCandleSimpleUserDelegate", typeof(WsCandleSimple)];
            yield return ["UpdateWsCandleSlimUserDelegate", typeof(WsCandleSlim)];
            yield return ["UpdateWsCandleHeavyUserDelegate", typeof(WsCandleHeavy)];
            yield return ["UpdateWsSymbolSimpleUserDelegate", typeof(WsSymbolSimple)];
            yield return ["UpdateWsSymbolSlimUserDelegate", typeof(WsSymbolSlim)];
            yield return ["UpdateWsSymbolHeavyUserDelegate", typeof(WsSymbolHeavy)];
            yield return ["UpdateWsAllTradeSimpleUserDelegate", typeof(WsAllTradeSimple)];
            yield return ["UpdateWsAllTradeSlimUserDelegate", typeof(WsAllTradeSlim)];
            yield return ["UpdateWsAllTradeHeavyUserDelegate", typeof(WsAllTradeHeavy)];
            yield return ["UpdateWsPositionSimpleUserDelegate", typeof(WsPositionSimple)];
            yield return ["UpdateWsPositionSlimUserDelegate", typeof(WsPositionSlim)];
            yield return ["UpdateWsPositionHeavyUserDelegate", typeof(WsPositionHeavy)];
            yield return ["UpdateWsSummarySimpleUserDelegate", typeof(WsSummarySimple)];
            yield return ["UpdateWsSummarySlimUserDelegate", typeof(WsSummarySlim)];
            yield return ["UpdateWsSummaryHeavyUserDelegate", typeof(WsSummaryHeavy)];
            yield return ["UpdateWsRiskSimpleUserDelegate", typeof(WsRiskSimple)];
            yield return ["UpdateWsRiskSlimUserDelegate", typeof(WsRiskSlim)];
            yield return ["UpdateWsRiskHeavyUserDelegate", typeof(WsRiskHeavy)];
            yield return ["UpdateWsFortsriskSimpleUserDelegate", typeof(WsFortsriskSimple)];
            yield return ["UpdateWsFortsriskSlimUserDelegate", typeof(WsFortsriskSlim)];
            yield return ["UpdateWsFortsriskHeavyUserDelegate", typeof(WsFortsriskHeavy)];
            yield return ["UpdateWsTradeSimpleUserDelegate", typeof(WsTradeSimple)];
            yield return ["UpdateWsTradeSlimUserDelegate", typeof(WsTradeSlim)];
            yield return ["UpdateWsTradeHeavyUserDelegate", typeof(WsTradeHeavy)];
            yield return ["UpdateWsOrderSimpleUserDelegate", typeof(WsOrderSimple)];
            yield return ["UpdateWsOrderSlimUserDelegate", typeof(WsOrderSlim)];
            yield return ["UpdateWsOrderHeavyUserDelegate", typeof(WsOrderHeavy)];
            yield return ["UpdateWsSecurityFromWsSimpleUserDelegate", typeof(WsSecurityFromWsSimple)];
            yield return ["UpdateWsSecurityFromWsSlimUserDelegate", typeof(WsSecurityFromWsSlim)];
            yield return ["UpdateWsSecurityFromWsHeavyUserDelegate", typeof(WsSecurityFromWsHeavy)];
            yield return ["UpdateWsStopOrderSimpleUserDelegate", typeof(WsStopOrderSimple)];
            yield return ["UpdateWsStopOrderSlimUserDelegate", typeof(WsStopOrderSlim)];
            yield return ["UpdateWsStopOrderHeavyUserDelegate", typeof(WsStopOrderHeavy)];
        }

        [Theory]
        [MemberData(nameof(GetDelegateUpdateMethods))]
        public void UpdateDelegateMethods_Set_Delegates_Correctly(string methodName, Type delegateType)
        {
            // Arrange
            var loggerMock = new Mock<ILogger>();
            var commandLoggerMock = new Mock<ILogger>();
            var parameters = new ConcurrentDictionary<string, Parameters>();
            var handler =
                new WebSocketMessageHandler(loggerMock.Object, commandLoggerMock.Object, Utilities.AlorOpenApiLogLevel.Fatal, parameters, null, null);

            var delegateMethod = GetType()
                .GetMethod(nameof(DummyMethod), BindingFlags.Instance | BindingFlags.NonPublic)
                ?.MakeGenericMethod(delegateType);
            if (delegateMethod == null) return;
            var delegateInstance =
                Delegate.CreateDelegate(typeof(Action<>).MakeGenericType(delegateType), this, delegateMethod);

            // Act
            var methodInfo = handler.GetType().GetMethod(methodName, BindingFlags.Public | BindingFlags.Instance);
            methodInfo?.Invoke(handler, [delegateInstance]);

            // Assert
            var baseName = methodName["Update".Length..];
            baseName = baseName[..^"UserDelegate".Length];
            var fieldName = "_" + char.ToLowerInvariant(baseName[0]) + baseName[1..] + "ChangedToUser";
            var fieldInfo = handler.GetType().GetField(fieldName, BindingFlags.NonPublic | BindingFlags.Instance);
            var actualDelegate = fieldInfo?.GetValue(handler);
            Assert.Equal(delegateInstance, actualDelegate);
        }


        private void DummyMethod<T>(T obj)
        {
            // Этот метод будет использоваться как заглушка для делегатов.
            // Его тело остаётся пустым, так как в тесте нам не нужно выполнять реальные действия.
        }


        [Fact]
        public void MessageReceived_Handles_Messages_Correctly()
        {
            // Arrange
            var loggerMock = new Mock<ILogger>();
            var commandLoggerMock = new Mock<ILogger>();
            var parameters = new ConcurrentDictionary<string, Parameters>();
            var handler =
                new WebSocketMessageHandler(loggerMock.Object, commandLoggerMock.Object, Utilities.AlorOpenApiLogLevel.Fatal, parameters, null, null);
            var fakeMessage =
                "{\"data\":{\"snapshot\":true,\"bids\":[],\"asks\":[],\"timestamp\":1710881402,\"ms_timestamp\":1710881402182,\"depth\":20,\"existing\":true},\"guid\":\"b0_3\"}"u8.ToArray();
            var messageHandlerMock = new Mock<Action<WsOrderBookSimple>>();
            handler.UpdateWsOrderBookSimpleUserDelegate(messageHandlerMock.Object);

            // Act
            handler.MessageReceived((fakeMessage, fakeMessage.Length, DateTime.UtcNow), "TestSocket");

            // Assert
            messageHandlerMock.Verify(m => m(It.IsAny<WsOrderBookSimple>()), Times.Once);
            loggerMock.Verify(log => log.Error(It.IsAny<string>()), Times.Never);
        }

        [Fact]
        public void MessageReceived_Handles_Exceptions_Correctly()
        {
            // Arrange
            var loggerMock = new Mock<ILogger>();
            var commandLoggerMock = new Mock<ILogger>();
            var parameters = new ConcurrentDictionary<string, Parameters>();
            var handler =
                new WebSocketMessageHandler(loggerMock.Object, commandLoggerMock.Object, Utilities.AlorOpenApiLogLevel.Fatal, parameters, null, null);
            var fakeMessage =
                "{\"data\"{\"snapshot\":true,\"bids\":[],\"asks\":[],\"timestamp\":1710881402,\"ms_timestamp\":1710881402182,\"depth\":20,\"existing\":true},\"guid\":\"b0_3\"}"u8.ToArray();
            var messageHandlerMock = new Mock<Action<WsOrderBookSimple>>();
            handler.UpdateWsOrderBookSimpleUserDelegate(messageHandlerMock.Object);

            // Act
            handler.MessageReceived((fakeMessage, fakeMessage.Length, DateTime.UtcNow), "TestSocket");

            // Assert
            messageHandlerMock.Verify(m => m(It.IsAny<WsOrderBookSimple>()), Times.Never);
            loggerMock.Verify(log => log.Error(It.IsAny<string>()), Times.AtLeastOnce());
        }

        [Fact]
        public void MessageReceived_Logs_Correctly()
        {
            // Arrange
            var loggerMock = new Mock<ILogger>();
            var commandLoggerMock = new Mock<ILogger>();
            var parameters = new ConcurrentDictionary<string, Parameters>();
            var handler =
                new WebSocketMessageHandler(loggerMock.Object, commandLoggerMock.Object, Utilities.AlorOpenApiLogLevel.Verbose, parameters, null, null);
            var fakeMessage = "{\"type\":\"test-type\",\"data\":\"test-data\"}"u8.ToArray();

            // Act
            handler.MessageReceived((fakeMessage, fakeMessage.Length, DateTime.UtcNow), "TestSocket");

            // Assert
            loggerMock.Verify(log => log.Verbose(It.IsAny<string>()), Times.Once);
        }

        [Fact]
        public void Dispose_Sets_All_Delegates_To_Null()
        {
            // Arrange
            var loggerMock = new Mock<ILogger>();
            var commandLoggerMock = new Mock<ILogger>();
            var parameters = new ConcurrentDictionary<string, Parameters>();
            var handler = new WebSocketMessageHandler(loggerMock.Object, commandLoggerMock.Object, Utilities.AlorOpenApiLogLevel.Fatal, parameters, _ => { },
                _ => { });

            // Act
            handler.UpdateWsOrderBookSimpleUserDelegate(_ => { });
            handler.UpdateWsOrderBookSlimUserDelegate(_ => { });
            handler.UpdateWsOrderBookHeavyUserDelegate(_ => { });
            handler.UpdateWsCandleSimpleUserDelegate(_ => { });
            handler.UpdateWsCandleSlimUserDelegate(_ => { });
            handler.UpdateWsCandleHeavyUserDelegate(_ => { });
            handler.UpdateWsSymbolSimpleUserDelegate(_ => { });
            handler.UpdateWsSymbolSlimUserDelegate(_ => { });
            handler.UpdateWsSymbolHeavyUserDelegate(_ => { });
            handler.UpdateWsAllTradeSimpleUserDelegate(_ => { });
            handler.UpdateWsAllTradeSlimUserDelegate(_ => { });
            handler.UpdateWsAllTradeHeavyUserDelegate(_ => { });
            handler.UpdateWsPositionSimpleUserDelegate(_ => { });
            handler.UpdateWsPositionSlimUserDelegate(_ => { });
            handler.UpdateWsPositionHeavyUserDelegate(_ => { });
            handler.UpdateWsSummarySimpleUserDelegate(_ => { });
            handler.UpdateWsSummarySlimUserDelegate(_ => { });
            handler.UpdateWsSummaryHeavyUserDelegate(_ => { });
            handler.UpdateWsRiskSimpleUserDelegate(_ => { });
            handler.UpdateWsRiskSlimUserDelegate(_ => { });
            handler.UpdateWsRiskHeavyUserDelegate(_ => { });
            handler.UpdateWsFortsriskSimpleUserDelegate(_ => { });
            handler.UpdateWsFortsriskSlimUserDelegate(_ => { });
            handler.UpdateWsFortsriskHeavyUserDelegate(_ => { });
            handler.UpdateWsTradeSimpleUserDelegate(_ => { });
            handler.UpdateWsTradeSlimUserDelegate(_ => { });
            handler.UpdateWsTradeHeavyUserDelegate(_ => { });
            handler.UpdateWsOrderSimpleUserDelegate(_ => { });
            handler.UpdateWsOrderSlimUserDelegate(_ => { });
            handler.UpdateWsOrderHeavyUserDelegate(_ => { });
            handler.UpdateWsSecurityFromWsSimpleUserDelegate(_ => { });
            handler.UpdateWsSecurityFromWsSlimUserDelegate(_ => { });
            handler.UpdateWsSecurityFromWsHeavyUserDelegate(_ => { });
            handler.UpdateWsStopOrderSimpleUserDelegate(_ => { });
            handler.UpdateWsStopOrderSlimUserDelegate(_ => { });
            handler.UpdateWsStopOrderHeavyUserDelegate(_ => { });

            handler.Dispose();

            // Assert
            var handlerType = handler.GetType();
            var delegateFields = handlerType.GetFields(BindingFlags.NonPublic | BindingFlags.Instance)
                .Where(f => f.FieldType.BaseType == typeof(MulticastDelegate));

            foreach (var delegateField in delegateFields)
            {
                var delegateValue = delegateField.GetValue(handler);
                Assert.Null(delegateValue);
            }
        }

        [Fact]
        public void FindSubscriptionTypeMarker_Returns_Correct_Marker()
        {
            // Arrange
            var loggerMock = new Mock<ILogger>();
            var commandLoggerMock = new Mock<ILogger>();
            var parameters = new ConcurrentDictionary<string, Parameters>();
            var handler = new WebSocketMessageHandler(loggerMock.Object, commandLoggerMock.Object, Utilities.AlorOpenApiLogLevel.Fatal, parameters, _ => { },
                _ => { });
            var methodInfo = handler.GetType()
                .GetMethod("FindSubscriptionTypeMarker", BindingFlags.NonPublic | BindingFlags.Static);

            var message =
                "{\"data\":{\"snapshot\":true,\"bids\":[],\"asks\":[],\"timestamp\":1710881402,\"ms_timestamp\":1710881402182,\"depth\":20,\"existing\":true},\"guid\":\"b0_3\"}";
            var startPattern = "\"guid\":\""u8.ToArray();
            var endPattern = "_"u8.ToArray();
            var expected = "b0"u8.ToArray();


            // Act
            var marker =
                (ReadOnlyMemory<byte>?)methodInfo?.Invoke(null,
                    [(Encoding.UTF8.GetBytes(message), message.Length, DateTime.UtcNow), startPattern, endPattern]) ??
                ReadOnlyMemory<byte>.Empty;

            // Assert
            Assert.True(marker.Span.SequenceEqual(expected));
        }

        [Fact]
        public void MessageReceived_StartsWithPattern_Returns_Correct_Result()
        {
            // Arrange
            var loggerMock = new Mock<ILogger>();
            var commandLoggerMock = new Mock<ILogger>();
            var parameters = new ConcurrentDictionary<string, Parameters>();
            var messageHandlerMock = new Mock<Action<WsResponseMessage>>();

            var handler = new WebSocketMessageHandler(loggerMock.Object, commandLoggerMock.Object, Utilities.AlorOpenApiLogLevel.Fatal, parameters, messageHandlerMock.Object,
                null);

            var message = "{\"requestGuid\":\"b0_2\",\"httpCode\":200,\"message\":\"Handled successfully\"}";
            var messageBytes = Encoding.UTF8.GetBytes(message);

            // Act
            handler.MessageReceived((messageBytes, message.Length, DateTime.UtcNow), "TestSocket");

            // Assert
            messageHandlerMock.Verify(m => m(It.IsAny<WsResponseMessage>()), Times.Once);
        }
    }
}
