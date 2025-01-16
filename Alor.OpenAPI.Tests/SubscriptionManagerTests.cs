using Alor.OpenAPI.Enums;
using Alor.OpenAPI.Managers;
using Alor.OpenAPI.Models;
using Alor.OpenAPI.Models.Simple;
using Moq;
using System.Collections.Concurrent;

namespace Alor.OpenAPI.Tests
{
    public class SubscriptionManagerTests
    {
        [Fact]
        public void OrderBookGetAndSubscribeSimpleAsync_CallsUpdateDelegateCorrectly()
        {
            // Arrange
            var updateMock = new Mock<Action<Action<WsOrderBookSimple>>>();
            var parameters = new ConcurrentDictionary<string, Parameters>();
            var msgUpdateMock = new Mock<Func<Dictionary<string, string>, Task<bool[]>>>();
            var msgDeleteMock = new Mock<Func<Dictionary<string, string>, Task<bool[]>>>();

            var manager = new SubscriptionManager(
                parameters,
                msgUpdateMock.Object,
                msgDeleteMock.Object,
                updateMock.Object,
                _ => {}, _ => {}, _ => {}, _ => {}, _ => {}, _ => {}, _ => {}, _ => {}, _ => {}, _ => {}, _ => {},
                _ => {}, _ => {}, _ => {}, _ => {}, _ => {}, _ => {}, _ => {}, _ => {}, _ => {}, _ => {}, _ => {},
                _ => {}, _ => {}, _ => {}, _ => {}, _ => {}, _ => {}, _ => {}, _ => {}, _ => {}, _ => {}, _ => {}, _ => {}, _ => {});

            var action = new Action<WsOrderBookSimple>((ob) => { });

            // Act
            manager.OrderBookGetAndSubscribeSimpleAsync(action, new[] { "BTCUSD" }, Exchange.SPBX);

            // Assert
            updateMock.Verify(u => u(It.IsAny<Action<WsOrderBookSimple>>()), Times.Once);
        }

        [Fact]
        public Task OrderBookGetAndSubscribeSimpleAsync_ThrowsArgumentNullExceptionWhenTickerListIsNull()
        {
            // Arrange
            var manager = CreateSubscriptionManagerWithMocks();

            // Act & Assert
            return Assert.ThrowsAsync<ArgumentNullException>(async () => await
                manager.OrderBookGetAndSubscribeSimpleAsync(ob => { }, null!, Exchange.SPBX));
        }

        [Fact]
        public Task OrderBookGetAndSubscribeSimpleAsyncThrowsArgumentNullExceptionWhenActionIsNull()
        {
            // Arrange
            var manager = CreateSubscriptionManagerWithMocks();

            // Act & Assert
            return Assert.ThrowsAsync<ArgumentNullException>(async () => await
                manager.OrderBookGetAndSubscribeSimpleAsync(null!, ["BTCUSD"], Exchange.MOEX));
        }
        
        private static SubscriptionManager CreateSubscriptionManagerWithMocks(Mock<Func<Dictionary<string, string>, Task<bool[]>>>? msgUpdateMock = null,
            Mock<Func<Dictionary<string, string>, Task<bool[]>>>? msgDeleteMock = null)
        {
            var parameters = new ConcurrentDictionary<string, Parameters>();
            var updateMock = msgUpdateMock ?? new Mock<Func<Dictionary<string, string>, Task<bool[]>>>();
            var deleteMock = msgDeleteMock ?? new Mock<Func<Dictionary<string, string>, Task<bool[]>>>();

            return new SubscriptionManager(
                parameters,
                updateMock.Object,
                deleteMock.Object,
                _ => { }, _ => { }, _ => { },
                _ => { }, _ => { }, _ => { },
                _ => { }, _ => { }, _ => { },
                _ => { }, _ => { }, _ => { },
                _ => { }, _ => { }, _ => { },
                _ => { }, _ => { }, _ => { },
                _ => { }, _ => { }, _ => { },
                _ => { }, _ => { }, _ => { },
                _ => { }, _ => { }, _ => { },
                _ => { }, _ => { }, _ => { },
                _ => { }, _ => { }, _ => { },
                _ => { }, _ => { }, _ => { });
        }

        [Fact]
        public async Task SubscriptionManager_HandlesConcurrentSubscriptionsCorrectly()
        {
            // Arrange
            var manager = CreateSubscriptionManagerWithMocks();
            var tickers = new[] { "AFLT", "TSLA", "ORUP" };
            var numberOfTasks = 100;
            var tasks = new List<Task<Dictionary<string, string>>>();

            // Act
            for (var i = 0; i < numberOfTasks; i++)
            {
                var task = manager.OrderBookGetAndSubscribeSimpleAsync(ob => { }, tickers, Exchange.MOEX);
                tasks.Add(task);
            }

            var results = await Task.WhenAll(tasks);

            var keys = results.SelectMany(x => x.Keys).ToList();

            // Assert
            Assert.Equal(numberOfTasks * tickers.Length, keys.Distinct().Count());  // Проверяем, что все GUID уникальны
        }

        [Fact]
        public async Task SubscriptionManager_CorrectlyFormatsAndSendsUpdateMessages()
        {
            // Arrange
            var mockMsgDictionaryUpdate = new Mock<Func<Dictionary<string, string>, Task<bool[]>>>();
            mockMsgDictionaryUpdate.Setup(x => x(It.IsAny<Dictionary<string, string>>()))
                .ReturnsAsync([true]);

            var subscriptionManager = CreateSubscriptionManagerWithMocks(mockMsgDictionaryUpdate);
            var updateAction = new Action<WsOrderBookSimple>(_ => { });

            // Act
            await subscriptionManager.OrderBookGetAndSubscribeSimpleAsync(
                updateAction,
                ["AAPL"],
                Exchange.SPBX);

            // Assert
            mockMsgDictionaryUpdate.Verify(x => x(It.Is<Dictionary<string, string>>(dic =>
                    dic.Values.Any(message => message.Contains("AAPL") && message.Contains("OrderBookGetAndSubscribe") && message.Contains("SPBX")))),
                Times.Once);
        }

        [Fact]
        public async Task SubscriptionManager_CorrectlyFormatsAndSendsDeleteMessages()
        {
            // Arrange
            var mockMsgDeleteRequest = new Mock<Func<Dictionary<string, string>, Task<bool[]>>>();
            mockMsgDeleteRequest.Setup(x => x(It.IsAny<Dictionary<string, string>>()))
                .ReturnsAsync([true]);

            var subscriptionManager = CreateSubscriptionManagerWithMocks(null, mockMsgDeleteRequest);
            var guids = new[] { "guid1", "guid2", "guid3" };

            // Act
            await subscriptionManager.UnsubscribeAsync(guids);

            // Assert
            mockMsgDeleteRequest.Verify(x => x(It.Is<Dictionary<string, string>>(dic =>
                    dic.Keys.Count == 3 && dic.Keys.All(guid => guids.Contains(guid)))),
                Times.Once);
        }

        [Fact]
        public void SubscriptionManager_DisposesAllResourcesCorrectly()
        {
            // Arrange
            var subscriptionManager = CreateSubscriptionManagerWithMocks();

            // Act
            subscriptionManager.Dispose();

            // Assert
            Assert.Null(subscriptionManager.UpdateWsMessageHandlerWsOrderBookSimpleDelegat);
            Assert.Null(subscriptionManager.UpdateWsMessageHandlerWsOrderBookSlimDelegat);
            Assert.Null(subscriptionManager.UpdateWsMessageHandlerWsOrderBookHeavyDelegat);
            Assert.Null(subscriptionManager.UpdateWsMessageHandlerWsCandleSimpleDelegat);
            Assert.Null(subscriptionManager.UpdateWsMessageHandlerWsCandleSlimDelegat);
            Assert.Null(subscriptionManager.UpdateWsMessageHandlerWsCandleHeavyDelegat);
            Assert.Null(subscriptionManager.UpdateWsMessageHandlerWsSymbolSimpleDelegat);
            Assert.Null(subscriptionManager.UpdateWsMessageHandlerWsSymbolSlimDelegat);
            Assert.Null(subscriptionManager.UpdateWsMessageHandlerWsSymbolHeavyDelegat);
            Assert.Null(subscriptionManager.UpdateWsMessageHandlerWsAllTradeSimpleDelegat);
            Assert.Null(subscriptionManager.UpdateWsMessageHandlerWsAllTradeSlimDelegat);
            Assert.Null(subscriptionManager.UpdateWsMessageHandlerWsAllTradeHeavyDelegat);
            Assert.Null(subscriptionManager.UpdateWsMessageHandlerWsPositionSimpleDelegat);
            Assert.Null(subscriptionManager.UpdateWsMessageHandlerWsPositionSlimDelegat);
            Assert.Null(subscriptionManager.UpdateWsMessageHandlerWsPositionHeavyDelegat);
            Assert.Null(subscriptionManager.UpdateWsMessageHandlerWsSummarySimpleDelegat);
            Assert.Null(subscriptionManager.UpdateWsMessageHandlerWsSummarySlimDelegat);
            Assert.Null(subscriptionManager.UpdateWsMessageHandlerWsSummaryHeavyDelegat);
            Assert.Null(subscriptionManager.UpdateWsMessageHandlerWsRiskSimpleDelegat);
            Assert.Null(subscriptionManager.UpdateWsMessageHandlerWsRiskSlimDelegat);
            Assert.Null(subscriptionManager.UpdateWsMessageHandlerWsRiskHeavyDelegat);
            Assert.Null(subscriptionManager.UpdateWsMessageHandlerWsFortsriskSimpleDelegat);
            Assert.Null(subscriptionManager.UpdateWsMessageHandlerWsFortsriskSlimDelegat);
            Assert.Null(subscriptionManager.UpdateWsMessageHandlerWsFortsriskHeavyDelegat);
            Assert.Null(subscriptionManager.UpdateWsMessageHandlerWsTradeSimpleDelegat);
            Assert.Null(subscriptionManager.UpdateWsMessageHandlerWsTradeSlimDelegat);
            Assert.Null(subscriptionManager.UpdateWsMessageHandlerWsTradeHeavyDelegat);
            Assert.Null(subscriptionManager.UpdateWsMessageHandlerWsOrderSimpleDelegat);
            Assert.Null(subscriptionManager.UpdateWsMessageHandlerWsOrderSlimDelegat);
            Assert.Null(subscriptionManager.UpdateWsMessageHandlerWsOrderHeavyDelegat);
            Assert.Null(subscriptionManager.UpdateWsMessageHandlerWsSecurityFromWsSimpleDelegat);
            Assert.Null(subscriptionManager.UpdateWsMessageHandlerWsSecurityFromWsSlimDelegat);
            Assert.Null(subscriptionManager.UpdateWsMessageHandlerWsSecurityFromWsHeavyDelegat);
            Assert.Null(subscriptionManager.UpdateWsMessageHandlerWsStopOrderSimpleDelegat);
            Assert.Null(subscriptionManager.UpdateWsMessageHandlerWsStopOrderSlimDelegat);
            Assert.Null(subscriptionManager.UpdateWsMessageHandlerWsStopOrderHeavyDelegat);
        }
    }
}
