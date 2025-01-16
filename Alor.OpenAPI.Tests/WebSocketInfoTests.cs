using Alor.OpenAPI.Websocket;
using FluentAssertions;
using Moq;
using System.Net.WebSockets;
using System.Reflection;
using Xunit.Abstractions;

namespace Alor.OpenAPI.Tests
{
    public class WebSocketInfoTests(ITestOutputHelper _testOutput)
    {
        [Fact]
        public async Task StartAsync_ConnectsAndStartsListenerAndMultiplexerTasks()
        {
            // Arrange
            var webSocketClientMock = new Mock<IWebSocketClient>();

            webSocketClientMock.Setup(ws => ws.ConnectAsync(It.IsAny<CancellationToken>()))
                .Returns(Task.CompletedTask)
                .Verifiable();

            var webSocketInfo = new WebSocketInfo(1, "TestSocket", () => webSocketClientMock.Object);

            // Act
            await webSocketInfo.StartAsync();

            // Assert
            webSocketClientMock.Verify(ws => ws.ConnectAsync(It.IsAny<CancellationToken>()), Times.Once);

            webSocketInfo.Dispose();
        }

        [Fact]
        public async Task SendAsync_SendsMessageAndIncrementsSentCount()
        {
            // Arrange
            var webSocketClientMock = new Mock<IWebSocketClient>();

            webSocketClientMock.Setup(ws => ws.State).Returns(WebSocketState.Open);

            webSocketClientMock.Setup(ws => ws.ConnectAsync(It.IsAny<CancellationToken>()))
                .Returns(Task.CompletedTask)
                .Verifiable();

            webSocketClientMock.Setup(ws => ws.SendAsync(
                    It.IsAny<ArraySegment<byte>>(),
                    WebSocketMessageType.Text,
                    true,
                    It.IsAny<CancellationToken>()))
                .Returns(Task.CompletedTask)
                .Verifiable();

            var webSocketInfo = new WebSocketInfo(1, "TestSocket", () => webSocketClientMock.Object);

            // Act
            await webSocketInfo.StartAsync();
            var result = await webSocketInfo.SendAsync("Test message");

            // Assert
            Assert.True(result, "SendAsync should return true when WebSocket is connected.");
            Assert.Equal(1, webSocketInfo.SentCount);
            webSocketClientMock.Verify(ws => ws.SendAsync(
                It.IsAny<ArraySegment<byte>>(),
                WebSocketMessageType.Text,
                true,
                It.IsAny<CancellationToken>()), Times.Once);
            webSocketClientMock.Verify(ws => ws.ConnectAsync(It.IsAny<CancellationToken>()), Times.Once);

            webSocketInfo.Dispose();
        }

        [Fact]
        public async Task CloseSocketAndResetCounters_ClosesSocketAndResetsCounters()
        {
            // Arrange
            var webSocketClientMock = new Mock<IWebSocketClient>();
            var webSocketInfo = new WebSocketInfo(1, "TestSocket", () => webSocketClientMock.Object);

            // Допустим, что было отправлено и получено несколько сообщений
            await webSocketInfo.SendAsync("Test message");
            // Имитируем получение сообщения (можно добавить в интерфейс методы для получения и обработки входящих сообщений)

            // Act
            await webSocketInfo.CloseSocketAndResetCounters();

            // Assert
            Assert.Equal(0, webSocketInfo.ReceivedCount);
            Assert.Equal(0, webSocketInfo.SentCount);
            Assert.False(webSocketInfo.IsConnected);
           
            webSocketInfo.Dispose();
        }


        [Fact]
        public async Task StartListenerLoop_IncrementsReceivedCountOnMessageReceived()
        {
            // Arrange
            var webSocketClientMock = new Mock<IWebSocketClient>();
            var webSocketInfo = new WebSocketInfo(1, "TestSocket", () => webSocketClientMock.Object);
            var fakeData = new ArraySegment<byte>("Test message"u8.ToArray());
            var receiveResult = new WebSocketReceiveResult(fakeData.Count, WebSocketMessageType.Text, true);

            var ctsField =
                typeof(WebSocketInfo).GetField("_cts", BindingFlags.NonPublic | BindingFlags.Instance);

            webSocketClientMock
                .SetupSequence(ws => ws.ReceiveAsync(It.IsAny<ArraySegment<byte>>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(receiveResult)
                                //.Callback(() => ((CancellationTokenSource?)ctsField?.GetValue(webSocketInfo))?.CancelAsync());
                .Throws(new OperationCanceledException());

            // Act
            await webSocketInfo.StartAsync();

            // Assert
            Assert.Equal(1, webSocketInfo.ReceivedCount); // Проверяем, что счётчик полученных сообщений инкрементировался

            webSocketInfo.Dispose();
        }


        [Fact]
        public async Task MessageEvent_InvokedOnMessageReceived()
        {
            // Arrange
            var webSocketClientMock = new Mock<IWebSocketClient>();
            var webSocketInfo = new WebSocketInfo(1, "TestSocket", () => webSocketClientMock.Object);
            var fakeData = new ArraySegment<byte>("Test message"u8.ToArray());
            var receiveResult = new WebSocketReceiveResult(fakeData.Count, WebSocketMessageType.Text, true);
            var messageReceived = false;

            webSocketInfo.Message += (sender, data) =>
            {
                messageReceived = true;
            };

            webSocketClientMock
                .Setup(ws => ws.ReceiveAsync(It.IsAny<ArraySegment<byte>>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(receiveResult);


            // Act
            var task = Task.Run(webSocketInfo.StartAsync);
            await Task.Delay(100);
            await webSocketInfo.CloseSocketAndResetCounters();

            // Assert
            Assert.True(messageReceived, "Message event should be invoked on message received.");
            
            webSocketInfo.Dispose();
        }

        [Fact]
        public async Task ErrorEvent_InvokedOnException()
        {
            // Arrange
            var webSocketClientMock = new Mock<IWebSocketClient>();
            var webSocketInfo = new WebSocketInfo(1, "TestSocket", () => webSocketClientMock.Object);
            var exception = new InvalidOperationException("Test exception");

            var errorInvoked = false;
            Exception? receivedException = null;

            var tcs = new TaskCompletionSource<bool>();

            webSocketInfo.Error += (sender, ex) =>
            {
                errorInvoked = true;
                receivedException = ex;
                tcs.SetResult(true);
                return Task.CompletedTask;
            };

            webSocketClientMock
                .Setup(ws => ws.ReceiveAsync(It.IsAny<ArraySegment<byte>>(), It.IsAny<CancellationToken>()))
                .ThrowsAsync(exception);

            // Act
            await webSocketInfo.StartAsync();

            // Ждем, пока событие Error не будет вызвано, или тайм-аут через 2 секунды
            var taskCompleted = await Task.WhenAny(tcs.Task, Task.Delay(2000));
            if (taskCompleted != tcs.Task)
            {
                Assert.Fail("Error event was not invoked within the timeout period.");
            }

            // Assert
            Assert.True(errorInvoked, "Error event should have been invoked.");
            Assert.NotNull(receivedException);
            Assert.IsType<InvalidOperationException>(receivedException);
            Assert.Equal(exception, receivedException);

            webSocketInfo.Dispose();
        }


        [Fact]
        public async Task WarningEvent_InvokedOnSlowConsumption()
        {
            // Arrange
            var webSocketClientMock = new Mock<IWebSocketClient>();
            var webSocketInfo = new WebSocketInfo(1, "TestSocket", () => webSocketClientMock.Object);
            var slowWarningInvoked = false;

            webSocketInfo.Warning += (sender, message) =>
            {
                slowWarningInvoked = true;
                Assert.Contains("consumers are too slow", message);
            };

            webSocketInfo.Message += async (sender, byteMsg) =>
            {
                await Task.Delay(50); //имитация длительной обработки, чтобы заполнился буфер
            };

            var fakeData = new ArraySegment<byte>("Test message"u8.ToArray());
            var receiveResult = new WebSocketReceiveResult(fakeData.Count, WebSocketMessageType.Text, true);

            webSocketClientMock
                .Setup(ws => ws.ReceiveAsync(It.IsAny<ArraySegment<byte>>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(receiveResult);

            // Act
            var task = Task.Run(webSocketInfo.StartAsync);
            await Task.Delay(12000); //ожидаем заполнения ресив буфера и выдачу предупреждения о переполнении
            await webSocketInfo.CloseSocketAndResetCounters();

            // Assert
            Assert.True(slowWarningInvoked, "Warning event should be invoked on slow consumption.");

            webSocketInfo.Dispose();
        }

        [Fact]
        public async Task ClosedEvent_InvokedOnSocketClosure()
        {
            // Arrange
            var webSocketClientMock = new Mock<IWebSocketClient>();

            webSocketClientMock.Setup(ws => ws.CloseAsync(
                    It.IsAny<WebSocketCloseStatus>(),
                    It.IsAny<string>(),
                    It.IsAny<CancellationToken>()))
                .Returns(Task.CompletedTask)
                .Verifiable();

            webSocketClientMock.Setup(ws => ws.State).Returns(WebSocketState.Open);

            webSocketClientMock.Setup(ws => ws.ConnectAsync(It.IsAny<CancellationToken>()))
                .Returns(Task.CompletedTask)
                .Verifiable();

            webSocketClientMock.Setup(ws => ws.Dispose()).Verifiable();

            var webSocketInfo = new WebSocketInfo(1, "TestSocket", () => webSocketClientMock.Object);
            var closedEventInvoked = false;

            webSocketInfo.Closed += (sender) =>
            {
                closedEventInvoked = true;
                return Task.CompletedTask;
            };

            // Act
            await webSocketInfo.StartAsync();
            await webSocketInfo.CloseSocketAndResetCounters();

            // Assert
            Assert.True(closedEventInvoked, "Closed event should be invoked on socket closure.");
            webSocketClientMock.Verify(ws => ws.CloseAsync(
                It.IsAny<WebSocketCloseStatus>(),
                It.IsAny<string>(),
                It.IsAny<CancellationToken>()), Times.Once());

            webSocketClientMock.Verify(ws => ws.Dispose(), Times.Once());

            webSocketInfo.Dispose();
        }


        [Fact]
        public void Dispose_DisposesAllResources()
        {
            // Arrange
            var webSocketClientMock = new Mock<IWebSocketClient>();
            var webSocketInfo = new WebSocketInfo(1, "TestSocket", () => webSocketClientMock.Object);

            var closedEventInvoked = false;
            webSocketInfo.Closed += (info) => {
                closedEventInvoked = true;
                return Task.CompletedTask;
            };

            // Act
            var task = Task.Run(webSocketInfo.StartAsync);
            webSocketInfo.Dispose();

            // Assert
            Assert.True(closedEventInvoked, "Closed event should be invoked on dispose.");
            Assert.Equal(WebSocketState.None, webSocketInfo.State);
            webSocketInfo.Warning?.GetInvocationList().Should().BeNull("Warning should have no subscribers after dispose.");
            webSocketInfo.Error?.GetInvocationList().Should().BeNull("Error should have no subscribers after dispose.");
            webSocketInfo.Closed?.GetInvocationList().Should().BeNull("Closed should have no subscribers after dispose.");
            webSocketInfo.SendSocketStatus?.GetInvocationList().Should().BeNull("Socket should have no subscribers after dispose.");
        }

        [Fact]
        public async Task CalculateSentRate_CalculatesCorrectly()
        {
            // Arrange
            var webSocketClientMock = new Mock<IWebSocketClient>();
            var webSocketInfo = new WebSocketInfo(1, "TestSocket", () => webSocketClientMock.Object);
            var sentMessage = "Test message";

            // Отправляем три сообщения для изменения счетчика SentCount
            for (var i = 0; i < 3; i++)
            {
                await webSocketInfo.SendAsync(sentMessage);
            }

            // Запоминаем значение SentCount перед вызовом CalculateSentRate
            var initialSentCount = webSocketInfo.SentCount;

            // Ждем 1 секунду, чтобы было различие во времени для расчета скорости
            await Task.Delay(1000);

            // Act
            webSocketInfo.CalculateSentRate();

            // Assert
            // Проверяем, что скорость отправки (SentRate) была рассчитана корректно
            Assert.Equal(initialSentCount, webSocketInfo.SentRate);

            webSocketInfo.Dispose();
        }

        [Fact]
        public async Task CalculateReceiveRate_CalculatesCorrectly()
        {
            // Arrange
            var webSocketClientMock = new Mock<IWebSocketClient>();
            var webSocketInfo = new WebSocketInfo(1, "TestSocket", () => webSocketClientMock.Object);
            var fakeReceivedData = new ArraySegment<byte>("Fake data"u8.ToArray());
            var receiveResult = new WebSocketReceiveResult(fakeReceivedData.Count, WebSocketMessageType.Text, true);

            webSocketClientMock
                .SetupSequence(ws => ws.ReceiveAsync(It.IsAny<ArraySegment<byte>>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(receiveResult) // Первое сообщение
                .ReturnsAsync(receiveResult) // Второе сообщение
                .ReturnsAsync(receiveResult) // Третье сообщение
                .Throws(new OperationCanceledException());
            
            // Act
            var task = Task.Run(webSocketInfo.StartAsync);
            // Ждем 1 секунду, чтобы было различие во времени для расчета скорости
            await Task.Delay(1000);
            // Запоминаем значение ReceivedCount перед вызовом CalculateReceiveRate
            var initialReceivedCount = webSocketInfo.ReceivedCount;

            webSocketInfo.CalculateReceiveRate();

            // Assert
            // Проверяем, что скорость получения (ReceiveRate) была рассчитана корректно
            Assert.Equal(initialReceivedCount, webSocketInfo.ReceiveRate);

            webSocketInfo.Dispose();
        }
    }
}
