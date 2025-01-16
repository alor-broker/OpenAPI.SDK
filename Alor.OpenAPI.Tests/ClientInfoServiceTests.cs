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
    public class ClientInfoServiceTests
    {
        [Fact]
        public async Task MdV2ClientsExchangePortfolioSummaryGetSimpleAsync_CallsProcessRequestWithCorrectParameters()
        {
            // Arrange
            var apiHttpClientMock = new Mock<IApiHttpClientService>();
            var expectedResponse = new SummarySimple();
            var expectedUri = new Uri("https://example.com/md/v2/clients/MOEX/portfolioName/summary?format=Simple");
            apiHttpClientMock
                .Setup(x => x.ProcessRequest<SummarySimple>(
                    HttpMethod.Get,
                    It.Is<Uri>(uri => uri == expectedUri),
                    It.IsAny<CancellationToken>(),
                    true, null, false))
                .ReturnsAsync(expectedResponse)
                .Verifiable();

            var clientInfoService = new ClientInfoService(
                apiHttpClientMock.Object,
                new Uri("https://example.com"),
                new CancellationTokenSource());

            // Act
            var result = await clientInfoService.MdV2ClientsExchangePortfolioSummaryGetSimpleAsync(Exchange.MOEX, "portfolioName");

            // Assert
            result.Should().BeEquivalentTo(expectedResponse);
            apiHttpClientMock.Verify(); // Проверяем, что вызвался метод с нужными параметрами
        }

        [Fact]
        public async Task MdV2ClientsExchangePortfolioSummaryGetSimpleAsync_ThrowsArgumentNullException_IfPortfolioIsNull()
        {
            // Arrange
            var apiHttpClientMock = new Mock<IApiHttpClientService>();
            var clientInfoService = new ClientInfoService(
                apiHttpClientMock.Object,
                new Uri("https://example.com"),
                new CancellationTokenSource());

            // Act & Assert
            var response = await Assert.ThrowsAsync<ArgumentNullException>(
                () => clientInfoService.MdV2ClientsExchangePortfolioSummaryGetSimpleAsync(Exchange.MOEX, ""));
        }

        [Fact]
        public async Task MdV2ClientsExchangePortfolioSummaryGetSimpleAsync_HandlesServerErrorProperly()
        {
            // Arrange
            var apiHttpClientMock = new Mock<IApiHttpClientService>();

            apiHttpClientMock
                .Setup(x => x.ProcessRequest<SummarySimple>(
                    HttpMethod.Get,
                    It.IsAny<Uri>(),
                    It.IsAny<CancellationToken>(),
                    true, null, false))
                .ReturnsAsync(() => throw new ApiException(new LoggerConfiguration().CreateLogger(), "Server error", 500, "Internal Server Error", new Dictionary<string, IEnumerable<string>> { { "headers", new List<string> { "head" }  } }, null));

            var clientInfoService = new ClientInfoService(
                apiHttpClientMock.Object,
                new Uri("https://example.com"),
                new CancellationTokenSource());

            // Act & Assert
            var response = await Assert.ThrowsAsync<ApiException>(
                () => clientInfoService.MdV2ClientsExchangePortfolioSummaryGetSimpleAsync(Exchange.MOEX, "portfolioName"));
        }

        [Fact]
        public async Task ClientInfoService_ProcessesApiResponsesCorrectly()
        {
            // Arrange
            var apiHttpClientMock = new Mock<IApiHttpClientService>();
            var expectedResponse = new SummarySimple(0,0,0,0,0,0,0,0,0);

            // Настраиваем мок для возврата предсказуемого ответа
            apiHttpClientMock.Setup(x =>
                x.ProcessRequest<SummarySimple>(HttpMethod.Get, It.IsAny<Uri>(), It.IsAny<CancellationToken>(), It.IsAny<bool>(), It.IsAny<string>(), It.IsAny<bool>())
            ).ReturnsAsync(expectedResponse);

            var clientInfoService = new ClientInfoService(
                apiHttpClientMock.Object,
                new Uri("https://example.com"),
                new CancellationTokenSource());

            // Act
            var result = await clientInfoService.MdV2ClientsExchangePortfolioSummaryGetSimpleAsync(Exchange.MOEX, "portfolioName");

            // Assert
            result.Should().BeEquivalentTo(expectedResponse, options => options.ComparingByMembers<SummarySimple>());
            apiHttpClientMock.Verify(x => x.ProcessRequest<SummarySimple>(HttpMethod.Get, It.IsAny<Uri>(), It.IsAny<CancellationToken>(), It.IsAny<bool>(), It.IsAny<string>(), It.IsAny<bool>()), Times.Once());
        }

        [Fact]
        public async Task ClientInfoService_CancelsRequest_WhenCancellationTokenIsCancelled()
        {
            // Arrange
            var cancellationTokenSource = new CancellationTokenSource();
            var apiHttpClientMock = new Mock<IApiHttpClientService>();

            apiHttpClientMock
                .Setup(x => x.ProcessRequest<SummarySimple>(
                    HttpMethod.Get,
                    It.IsAny<Uri>(),
                    It.IsAny<CancellationToken>(),
                    true, null, false))
                .Returns(async (HttpMethod method, Uri uri, CancellationToken token, bool needAuth, string body, bool needXAlor) =>
                {
                    // Эмуляция ожидания перед тем как отмена будет вызвана
                    await Task.Delay(500, token);
                    token.ThrowIfCancellationRequested();
                    return new SummarySimple(); // Возвращаем значение, если отмена не была вызвана
                })
                .Verifiable();

            var clientInfoService = new ClientInfoService(
                apiHttpClientMock.Object,
                new Uri("https://example.com"),
                cancellationTokenSource);

            // Act
            var task = clientInfoService.MdV2ClientsExchangePortfolioSummaryGetSimpleAsync(Exchange.MOEX, "portfolioName");

            // Активируем отмену после небольшой задержки, чтобы ProcessRequest начал исполнение
            await Task.Delay(100, CancellationToken.None);
            await cancellationTokenSource.CancelAsync();

            // Assert
            await Assert.ThrowsAsync<TaskCanceledException>(() => task);
            apiHttpClientMock.Verify();
        }

    }
}
