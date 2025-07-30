using Alor.OpenAPI.Core;
using Alor.OpenAPI.Enums;
using Alor.OpenAPI.Interfaces;
using Alor.OpenAPI.Models.Simple;
using Alor.OpenAPI.Services;
using FluentAssertions;
using Moq;
using Serilog;

namespace Alor.OpenAPI.Tests
{
    public class StopOrdersServiceTests
    {
        [Fact]
        public async Task MdV2ClientsExchangePortfolioStopOrdersOrderIdGetSimpleAsync_CallsProcessRequestWithCorrectParameters()
        {
            // Arrange
            var apiHttpClientMock = new Mock<IApiHttpClientService>();
            var expectedResponse = new StopOrderSimple();
            var expectedUri = new Uri("https://example.com/md/v2/clients/MOEX/D39004/stoporders/12345678?format=Simple");
            apiHttpClientMock
                .Setup(x => x.ProcessRequest<StopOrderSimple>(
                    HttpMethod.Get,
                    It.Is<Uri>(uri => uri == expectedUri),
                    It.IsAny<CancellationToken>(),
                    true, null, false))
                .ReturnsAsync(expectedResponse)
                .Verifiable();

            var stopOrdersService = new StopOrdersService(
                apiHttpClientMock.Object,
                new Uri("https://example.com"),
                new CancellationTokenSource());

            // Act
            var result = await stopOrdersService.MdV2ClientsExchangePortfolioStopOrdersOrderIdGetSimpleAsync(Exchange.MOEX, "D39004", 12345678);

            // Assert
            result.Should().BeEquivalentTo(expectedResponse);
            apiHttpClientMock.Verify(); // Проверяем, что вызвался метод с нужными параметрами
        }

        [Fact]
        public async Task MdV2ClientsExchangePortfolioStopOrdersOrderIdGetSimpleAsync_ThrowsArgumentNullException_IfPortfolioIsNull()
        {
            // Arrange
            var apiHttpClientMock = new Mock<IApiHttpClientService>();
            var stopOrdersService = new StopOrdersService(
                apiHttpClientMock.Object,
                new Uri("https://example.com"),
                new CancellationTokenSource());

            // Act & Assert
            var response = await Assert.ThrowsAsync<ArgumentNullException>(
                () => stopOrdersService.MdV2ClientsExchangePortfolioStopOrdersOrderIdGetSimpleAsync(Exchange.MOEX, "", 12345678));
        }

        [Fact]
        public async Task MdV2ClientsExchangePortfolioStopOrdersOrderIdGetSimpleAsync_HandlesServerErrorProperly()
        {
            // Arrange
            var apiHttpClientMock = new Mock<IApiHttpClientService>();

            apiHttpClientMock
                .Setup(x => x.ProcessRequest<StopOrderSimple>(
                    HttpMethod.Get,
                    It.IsAny<Uri>(),
                    It.IsAny<CancellationToken>(),
                    true, null, false))
                .ReturnsAsync(() => throw new ApiException(new LoggerConfiguration().CreateLogger(), "Server error", 500, "Internal Server Error", new Dictionary<string, IEnumerable<string>> { { "headers", new List<string> { "head" } } }, null));

            var stopOrdersService = new StopOrdersService(
                apiHttpClientMock.Object,
                new Uri("https://example.com"),
                new CancellationTokenSource());

            // Act & Assert
            var response = await Assert.ThrowsAsync<ApiException>(
                () => stopOrdersService.MdV2ClientsExchangePortfolioStopOrdersOrderIdGetSimpleAsync(Exchange.MOEX, "D39004", 12345678));
        }

        [Fact]
        public async Task StopOrdersService_ProcessesApiResponsesCorrectly()
        {
            // Arrange
            var apiHttpClientMock = new Mock<IApiHttpClientService>();
            var expectedResponse = new StopOrderSimple("347499", 425242362, "SBER", "MOEX:LKOH", "D39004", Exchange.MOEX, "TQBR", OrderTypeStopLimit.Stop,
                Side.Buy, Condition.LessOrEqual, OrderStatus.Working, DateTime.Parse("2020-05-16T23:59:59.9990000Z"), null, DateTime.Parse("2020-06-16T23:59:59.9990000Z"),
                null, 10m, 1, 1, 0, 0, 0, 0, 0, true, TimeInForce.OneDay, null, 2086.1m);

            // Настраиваем мок для возврата предсказуемого ответа
            apiHttpClientMock.Setup(x =>
                x.ProcessRequest<StopOrderSimple>(HttpMethod.Get, It.IsAny<Uri>(), It.IsAny<CancellationToken>(), It.IsAny<bool>(), It.IsAny<string>(), It.IsAny<bool>())
            ).ReturnsAsync(expectedResponse);

            var stopOrdersService = new StopOrdersService(
                apiHttpClientMock.Object,
                new Uri("https://example.com"),
                new CancellationTokenSource());

            // Act
            var result = await stopOrdersService.MdV2ClientsExchangePortfolioStopOrdersOrderIdGetSimpleAsync(Exchange.MOEX, "12345678", 12345678);

            // Assert
            result.Should().BeEquivalentTo(expectedResponse, options => options.ComparingByMembers<StopOrderSimple>());
            apiHttpClientMock.Verify(x => x.ProcessRequest<StopOrderSimple>(HttpMethod.Get, It.IsAny<Uri>(), It.IsAny<CancellationToken>(), It.IsAny<bool>(), It.IsAny<string>(), It.IsAny<bool>()), Times.Once());
        }

        [Fact]
        public async Task StopOrdersService_CancelsRequest_WhenCancellationTokenIsCancelled()
        {
            // Arrange
            var cancellationTokenSource = new CancellationTokenSource();
            var apiHttpClientMock = new Mock<IApiHttpClientService>();

            apiHttpClientMock
                .Setup(x => x.ProcessRequest<StopOrderSimple>(
                    HttpMethod.Get,
                    It.IsAny<Uri>(),
                    It.IsAny<CancellationToken>(),
                    true, null, false))
                .Returns(async (HttpMethod method, Uri uri, CancellationToken token, bool needAuth, string body, bool needXAlor) =>
                {
                    // Эмуляция ожидания перед тем как отмена будет вызвана
                    await Task.Delay(500, token);
                    token.ThrowIfCancellationRequested();
                    return new StopOrderSimple(); // Возвращаем значение, если отмена не была вызвана
                })
                .Verifiable();

            var stopOrdersService = new StopOrdersService(
                apiHttpClientMock.Object,
                new Uri("https://example.com"),
                cancellationTokenSource);

            // Act
            var task = stopOrdersService.MdV2ClientsExchangePortfolioStopOrdersOrderIdGetSimpleAsync(Exchange.MOEX, "D39004", 12345678);

            // Активируем отмену после небольшой задержки, чтобы ProcessRequest начал исполнение
            await Task.Delay(100, CancellationToken.None);
            await cancellationTokenSource.CancelAsync();

            // Assert
            await Assert.ThrowsAsync<TaskCanceledException>(() => task);
            apiHttpClientMock.Verify();
        }

    }
}
