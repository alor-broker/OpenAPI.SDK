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
    public class InstrumentsServiceTests
    {
        [Fact]
        public async Task MdV2SecuritiesExchangeSymbolGetSimpleAsync_CallsProcessRequestWithCorrectParameters()
        {
            // Arrange
            var apiHttpClientMock = new Mock<IApiHttpClientService>();
            var expectedResponse = new SecuritySimple();
            var expectedUri = new Uri("https://example.com/md/v2/securities/MOEX/SBER?format=Simple");
            apiHttpClientMock
                .Setup(x => x.ProcessRequest<SecuritySimple>(
                    HttpMethod.Get,
                    It.Is<Uri>(uri => uri == expectedUri),
                    It.IsAny<CancellationToken>(),
                    true, null, false))
                .ReturnsAsync(expectedResponse)
                .Verifiable();

            var instrumentsService = new InstrumentsService(
                apiHttpClientMock.Object,
                new Uri("https://example.com"),
                new CancellationTokenSource());

            // Act
            var result = await instrumentsService.MdV2SecuritiesExchangeSymbolGetSimpleAsync(Exchange.MOEX, "SBER");

            // Assert
            result.Should().BeEquivalentTo(expectedResponse);
            apiHttpClientMock.Verify(); // Проверяем, что вызвался метод с нужными параметрами
        }

        [Fact]
        public async Task MdV2SecuritiesExchangeSymbolGetSimpleAsync_ThrowsArgumentNullException_IfPortfolioIsNull()
        {
            // Arrange
            var apiHttpClientMock = new Mock<IApiHttpClientService>();
            var instrumentsService = new InstrumentsService(
                apiHttpClientMock.Object,
                new Uri("https://example.com"),
                new CancellationTokenSource());

            // Act & Assert
            var response = await Assert.ThrowsAsync<ArgumentNullException>(
                () => instrumentsService.MdV2SecuritiesExchangeSymbolGetSimpleAsync(Exchange.MOEX, ""));
        }

        [Fact]
        public async Task MdV2SecuritiesExchangeSymbolGetSimpleAsync_HandlesServerErrorProperly()
        {
            // Arrange
            var apiHttpClientMock = new Mock<IApiHttpClientService>();

            apiHttpClientMock
                .Setup(x => x.ProcessRequest<SecuritySimple>(
                    HttpMethod.Get,
                    It.IsAny<Uri>(),
                    It.IsAny<CancellationToken>(),
                    true, null, false))
                .ReturnsAsync(() => throw new ApiException(new LoggerConfiguration().CreateLogger(), "Server error", 500, "Internal Server Error", new Dictionary<string, IEnumerable<string>> { { "headers", new List<string> { "head" }  } }, null));

            var instrumentsService = new InstrumentsService(
                apiHttpClientMock.Object,
                new Uri("https://example.com"),
                new CancellationTokenSource());

            // Act & Assert
            var response = await Assert.ThrowsAsync<ApiException>(
                () => instrumentsService.MdV2SecuritiesExchangeSymbolGetSimpleAsync(Exchange.MOEX, "SBER"));
        }

        [Fact]
        public async Task InstrumentsService_ProcessesApiResponsesCorrectly()
        {
            // Arrange
            var apiHttpClientMock = new Mock<IApiHttpClientService>();
            var expectedResponse = new SecuritySimple("SBER", "Сбербанк", "Сбербанк России ПАО ао", Exchange.MOEX, Market.FOND, "CS", 10, 3,
                "ESXXXX", "9999-12-31T23:59:59.9999999", 0.01m, 4729689, 0, 0, 0, 0, 279.96m, 228.78m, 0, 0, 0, "RUB",
                "RU0009029540", null, "TQBR", "TQBR", 17, "нормальный период торгов", "", 1, 1);

            // Настраиваем мок для возврата предсказуемого ответа
            apiHttpClientMock.Setup(x =>
                x.ProcessRequest<SecuritySimple>(HttpMethod.Get, It.IsAny<Uri>(), It.IsAny<CancellationToken>(), It.IsAny<bool>(), It.IsAny<string>(), It.IsAny<bool>())
            ).ReturnsAsync(expectedResponse);

            var instrumentsService = new InstrumentsService(
                apiHttpClientMock.Object,
                new Uri("https://example.com"),
                new CancellationTokenSource());

            // Act
            var result = await instrumentsService.MdV2SecuritiesExchangeSymbolGetSimpleAsync(Exchange.MOEX, "SBER");

            // Assert
            result.Should().BeEquivalentTo(expectedResponse, options => options.ComparingByMembers<SecuritySimple>());
            apiHttpClientMock.Verify(x => x.ProcessRequest<SecuritySimple>(HttpMethod.Get, It.IsAny<Uri>(), It.IsAny<CancellationToken>(), It.IsAny<bool>(), It.IsAny<string>(), It.IsAny<bool>()), Times.Once());
        }

        [Fact]
        public async Task InstrumentsService_CancelsRequest_WhenCancellationTokenIsCancelled()
        {
            // Arrange
            var cancellationTokenSource = new CancellationTokenSource();
            var apiHttpClientMock = new Mock<IApiHttpClientService>();

            apiHttpClientMock
                .Setup(x => x.ProcessRequest<SecuritySimple>(
                    HttpMethod.Get,
                    It.IsAny<Uri>(),
                    It.IsAny<CancellationToken>(),
                    true, null, false))
                .Returns(async (HttpMethod method, Uri uri, CancellationToken token, bool needAuth, string body, bool needXAlor) =>
                {
                    // Эмуляция ожидания перед тем как отмена будет вызвана
                    await Task.Delay(500, token);
                    token.ThrowIfCancellationRequested();
                    return new SecuritySimple(); // Возвращаем значение, если отмена не была вызвана
                })
                .Verifiable();

            var instrumentsService = new InstrumentsService(
                apiHttpClientMock.Object,
                new Uri("https://example.com"),
                cancellationTokenSource);

            // Act
            var task = instrumentsService.MdV2SecuritiesExchangeSymbolGetSimpleAsync(Exchange.MOEX, "SBER");

            // Активируем отмену после небольшой задержки, чтобы ProcessRequest начал исполнение
            await Task.Delay(100, CancellationToken.None);
            await cancellationTokenSource.CancelAsync();

            // Assert
            await Assert.ThrowsAsync<TaskCanceledException>(() => task);
            apiHttpClientMock.Verify();

        }

    }
}
