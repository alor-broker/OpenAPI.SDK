using Alor.OpenAPI.Core;
using Alor.OpenAPI.Enums;
using Alor.OpenAPI.Interfaces;
using Alor.OpenAPI.Models;
using Alor.OpenAPI.Services;
using FluentAssertions;
using Moq;
using Serilog;

namespace Alor.OpenAPI.Tests
{
    public class OrderGroupsServiceTests
    {
        [Fact]
        public async Task CommandapiApiOrderGroupsOrderGroupIdGetAsync_CallsProcessRequestWithCorrectParameters()
        {
            // Arrange
            var apiHttpClientMock = new Mock<IApiHttpClientService>();
            var expectedResponse = new ResponseOrderGroupInfo();
            var expectedUri = new Uri("https://example.com/commandapi/api/orderGroups/12345678");
            apiHttpClientMock
                .Setup(x => x.ProcessRequest<ResponseOrderGroupInfo>(
                    HttpMethod.Get,
                    It.Is<Uri>(uri => uri == expectedUri),
                    It.IsAny<CancellationToken>(),
                    true, null, false))
                .ReturnsAsync(expectedResponse)
                .Verifiable();

            var orderGroupsService = new OrderGroupsService(
                apiHttpClientMock.Object,
                new Uri("https://example.com"),
                new CancellationTokenSource());

            // Act
            var result = await orderGroupsService.CommandapiApiOrderGroupsOrderGroupIdGetAsync("12345678");

            // Assert
            result.Should().BeEquivalentTo(expectedResponse);
            apiHttpClientMock.Verify(); // Проверяем, что вызвался метод с нужными параметрами
        }

        [Fact]
        public async Task CommandapiApiOrderGroupsOrderGroupIdGetAsync_ThrowsArgumentNullException_IfPortfolioIsNull()
        {
            // Arrange
            var apiHttpClientMock = new Mock<IApiHttpClientService>();
            var orderGroupsService = new OrderGroupsService(
                apiHttpClientMock.Object,
                new Uri("https://example.com"),
                new CancellationTokenSource());

            // Act & Assert
            var response = await Assert.ThrowsAsync<ArgumentNullException>(
                () => orderGroupsService.CommandapiApiOrderGroupsOrderGroupIdGetAsync(""));
        }

        [Fact]
        public async Task CommandapiApiOrderGroupsOrderGroupIdGetAsync_HandlesServerErrorProperly()
        {
            // Arrange
            var apiHttpClientMock = new Mock<IApiHttpClientService>();

            apiHttpClientMock
                .Setup(x => x.ProcessRequest<ResponseOrderGroupInfo>(
                    HttpMethod.Get,
                    It.IsAny<Uri>(),
                    It.IsAny<CancellationToken>(),
                    true, null, false))
                .ReturnsAsync(() => throw new ApiException(new LoggerConfiguration().CreateLogger(), "Server error", 500, "Internal Server Error", new Dictionary<string, IEnumerable<string>> { { "headers", new List<string> { "head" }  } }, null));

            var orderGroupsService = new OrderGroupsService(
                apiHttpClientMock.Object,
                new Uri("https://example.com"),
                new CancellationTokenSource());

            // Act & Assert
            var response = await Assert.ThrowsAsync<ApiException>(
                () => orderGroupsService.CommandapiApiOrderGroupsOrderGroupIdGetAsync("12345678"));
        }

        [Fact]
        public async Task OrderGroupsService_ProcessesApiResponsesCorrectly()
        {
            // Arrange
            var apiHttpClientMock = new Mock<IApiHttpClientService>();
            var expectedResponse = new ResponseOrderGroupInfo(new Guid("daf88a4b-4393-4710-bff0-db98e679b375"),
                "P039004",
                new List<ResponseOrderGroupItem>
                { new("33977952408") }, ExecutionPolicy.TriggerBracketOrders,
                OrderGroupStatus.Active, DateTime.Parse("2023-10-30T05:26:25.1177405Z"), null);

            // Настраиваем мок для возврата предсказуемого ответа
            apiHttpClientMock.Setup(x =>
                x.ProcessRequest<ResponseOrderGroupInfo>(HttpMethod.Get, It.IsAny<Uri>(), It.IsAny<CancellationToken>(), It.IsAny<bool>(), It.IsAny<string>(), It.IsAny<bool>())
            ).ReturnsAsync(expectedResponse);

            var orderGroupsService = new OrderGroupsService(
                apiHttpClientMock.Object,
                new Uri("https://example.com"),
                new CancellationTokenSource());

            // Act
            var result = await orderGroupsService.CommandapiApiOrderGroupsOrderGroupIdGetAsync("12345678");

            // Assert
            result.Should().BeEquivalentTo(expectedResponse, options => options.ComparingByMembers<ResponseOrderGroupInfo>());
            apiHttpClientMock.Verify(x => x.ProcessRequest<ResponseOrderGroupInfo>(HttpMethod.Get, It.IsAny<Uri>(), It.IsAny<CancellationToken>(), It.IsAny<bool>(), It.IsAny<string>(), It.IsAny<bool>()), Times.Once());
        }

        [Fact]
        public async Task OrderGroupsService_CancelsRequest_WhenCancellationTokenIsCancelled()
        {
            // Arrange
            var cancellationTokenSource = new CancellationTokenSource();
            var apiHttpClientMock = new Mock<IApiHttpClientService>();

            apiHttpClientMock
                .Setup(x => x.ProcessRequest<ResponseOrderGroupInfo>(
                    HttpMethod.Get,
                    It.IsAny<Uri>(),
                    It.IsAny<CancellationToken>(),
                    true, null, false))
                .Returns(async (HttpMethod method, Uri uri, CancellationToken token, bool needAuth, string body, bool needXAlor) =>
                {
                    // Эмуляция ожидания перед тем как отмена будет вызвана
                    await Task.Delay(500, token);
                    token.ThrowIfCancellationRequested();
                    return new ResponseOrderGroupInfo(); // Возвращаем значение, если отмена не была вызвана
                })
                .Verifiable();

            var orderGroupsService = new OrderGroupsService(
                apiHttpClientMock.Object,
                new Uri("https://example.com"),
                cancellationTokenSource);

            // Act
            var task = orderGroupsService.CommandapiApiOrderGroupsOrderGroupIdGetAsync("12345678");

            // Активируем отмену после небольшой задержки, чтобы ProcessRequest начал исполнение
            await Task.Delay(100, CancellationToken.None);
            await cancellationTokenSource.CancelAsync();

            // Assert
            await Assert.ThrowsAsync<TaskCanceledException>(() => task);
            apiHttpClientMock.Verify();
        }

    }
}
