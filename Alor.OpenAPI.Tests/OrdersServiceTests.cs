using Alor.OpenAPI.Core;
using Alor.OpenAPI.Enums;
using Alor.OpenAPI.Interfaces;
using Alor.OpenAPI.Models.Simple;
using Alor.OpenAPI.Services;
using FluentAssertions;
using Moq;
using Serilog;
using Type = Alor.OpenAPI.Enums.Type;

namespace Alor.OpenAPI.Tests
{
    public class OrdersServiceTests
    {
        [Fact]
        public async Task MdV2ClientsExchangePortfolioOrdersOrderIdGetSimpleAsync_CallsProcessRequestWithCorrectParameters()
        {
            // Arrange
            var apiHttpClientMock = new Mock<IApiHttpClientService>();
            var expectedResponse = new OrderSimple();
            var expectedUri = new Uri("https://example.com/md/v2/clients/MOEX/D39004/orders/12345678?format=Simple");
            apiHttpClientMock
                .Setup(x => x.ProcessRequest<OrderSimple>(
                    HttpMethod.Get,
                    It.Is<Uri>(uri => uri == expectedUri),
                    It.IsAny<CancellationToken>(),
                    true, null, false))
                .ReturnsAsync(expectedResponse)
                .Verifiable();

            var ordersService = new OrdersService(
                apiHttpClientMock.Object,
                new Uri("https://example.com"),
                new CancellationTokenSource());

            // Act
            var result = await ordersService.MdV2ClientsExchangePortfolioOrdersOrderIdGetSimpleAsync(Exchange.MOEX, "D39004", 12345678);

            // Assert
            result.Should().BeEquivalentTo(expectedResponse);
            apiHttpClientMock.Verify(); // Проверяем, что вызвался метод с нужными параметрами
        }

        [Fact]
        public async Task MdV2ClientsExchangePortfolioOrdersOrderIdGetSimpleAsync_ThrowsArgumentNullException_IfPortfolioIsNull()
        {
            // Arrange
            var apiHttpClientMock = new Mock<IApiHttpClientService>();
            var ordersService = new OrdersService(
                apiHttpClientMock.Object,
                new Uri("https://example.com"),
                new CancellationTokenSource());

            // Act & Assert
            var response = await Assert.ThrowsAsync<ArgumentNullException>(
                () => ordersService.MdV2ClientsExchangePortfolioOrdersOrderIdGetSimpleAsync(Exchange.MOEX, "", 12345678));
        }

        [Fact]
        public async Task MdV2ClientsExchangePortfolioOrdersOrderIdGetSimpleAsync_HandlesServerErrorProperly()
        {
            // Arrange
            var apiHttpClientMock = new Mock<IApiHttpClientService>();

            apiHttpClientMock
                .Setup(x => x.ProcessRequest<OrderSimple>(
                    HttpMethod.Get,
                    It.IsAny<Uri>(),
                    It.IsAny<CancellationToken>(),
                    true, null, false))
                .ReturnsAsync(() => throw new ApiException(new LoggerConfiguration().CreateLogger(), "Server error", 500, "Internal Server Error", new Dictionary<string, IEnumerable<string>> { { "headers", new List<string> { "head" } } }, null));

            var ordersService = new OrdersService(
                apiHttpClientMock.Object,
                new Uri("https://example.com"),
                new CancellationTokenSource());

            // Act & Assert
            var response = await Assert.ThrowsAsync<ApiException>(
                () => ordersService.MdV2ClientsExchangePortfolioOrdersOrderIdGetSimpleAsync(Exchange.MOEX, "D39004", 12345678));
        }

        [Fact]
        public async Task OrdersService_ProcessesApiResponsesCorrectly()
        {
            // Arrange
            var apiHttpClientMock = new Mock<IApiHttpClientService>();
            var expectedResponse = new OrderSimple("41423837024", "GAZP", "TQBR", "MOEX:GAZP", "D00013", Exchange.MOEX,
                "Приказ на продажу", Type.Limit, Side.Buy, OrderStatus.Working, DateTime.Parse("2023-12-11T07:02:48.0000000Z"),
                DateTime.Parse("2023-12-11T07:02:48.0000000Z"), DateTime.Parse("2023-12-11T23:59:59.9990000Z"), 10, 1,
                1, 0, 0, 0, 161.15m, true, TimeInForce.OneDay, null, 1611.5m);

            // Настраиваем мок для возврата предсказуемого ответа
            apiHttpClientMock.Setup(x =>
                x.ProcessRequest<OrderSimple>(HttpMethod.Get, It.IsAny<Uri>(), It.IsAny<CancellationToken>(), It.IsAny<bool>(), It.IsAny<string>(), It.IsAny<bool>())
            ).ReturnsAsync(expectedResponse);

            var ordersService = new OrdersService(
                apiHttpClientMock.Object,
                new Uri("https://example.com"),
                new CancellationTokenSource());

            // Act
            var result = await ordersService.MdV2ClientsExchangePortfolioOrdersOrderIdGetSimpleAsync(Exchange.MOEX, "12345678", 12345678);

            // Assert
            result.Should().BeEquivalentTo(expectedResponse, options => options.ComparingByMembers<OrderSimple>());
            apiHttpClientMock.Verify(x => x.ProcessRequest<OrderSimple>(HttpMethod.Get, It.IsAny<Uri>(), It.IsAny<CancellationToken>(), It.IsAny<bool>(), It.IsAny<string>(), It.IsAny<bool>()), Times.Once());
        }

        [Fact]
        public async Task OrdersService_CancelsRequest_WhenCancellationTokenIsCancelled()
        {
            // Arrange
            var cancellationTokenSource = new CancellationTokenSource();
            var apiHttpClientMock = new Mock<IApiHttpClientService>();

            apiHttpClientMock
                .Setup(x => x.ProcessRequest<OrderSimple>(
                    HttpMethod.Get,
                    It.IsAny<Uri>(),
                    It.IsAny<CancellationToken>(),
                    true, null, false))
                .Returns(async (HttpMethod method, Uri uri, CancellationToken token, bool needAuth, string body, bool needXAlor) =>
                {
                    // Эмуляция ожидания перед тем как отмена будет вызвана
                    await Task.Delay(500, token);
                    token.ThrowIfCancellationRequested();
                    return new OrderSimple(); // Возвращаем значение, если отмена не была вызвана
                })
                .Verifiable();

            var ordersService = new OrdersService(
                apiHttpClientMock.Object,
                new Uri("https://example.com"),
                cancellationTokenSource);

            // Act
            var task = ordersService.MdV2ClientsExchangePortfolioOrdersOrderIdGetSimpleAsync(Exchange.MOEX, "D39004", 12345678);

            // Активируем отмену после небольшой задержки, чтобы ProcessRequest начал исполнение
            await Task.Delay(100, CancellationToken.None);
            await cancellationTokenSource.CancelAsync();

            // Assert
            await Assert.ThrowsAsync<TaskCanceledException>(() => task);
            apiHttpClientMock.Verify();
        }

    }
}
