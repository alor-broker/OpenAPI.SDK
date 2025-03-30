using Alor.OpenAPI.Core;
using Alor.OpenAPI.Enums;
using Alor.OpenAPI.Models.Simple;
using Alor.OpenAPI.Services;
using FluentAssertions;
using Moq;
using Moq.Protected;
using Serilog;
using SpanJson;
using System.Net;
using System.Text;

namespace Alor.OpenAPI.Tests
{
    public class ApiHttpClientServiceTests
    {
        [Fact]
        public async Task ProcessRequest_ReturnsExpectedObject_OnSuccess()
        {
            // Arrange
            var mockHandler = new Mock<HttpMessageHandler>();
            mockHandler
                .Protected() // указываем, что нужно мокировать защищенный метод
                .Setup<Task<HttpResponseMessage>>(
                    "SendAsync",
                    ItExpr.IsAny<HttpRequestMessage>(),
                    ItExpr.IsAny<CancellationToken>()
                )
                .ReturnsAsync(new HttpResponseMessage
                              {
                                  StatusCode = HttpStatusCode.OK,
                                  Content = new StringContent("{ \"key\": \"value\" }")
                              });

            var httpClient = new HttpClient(mockHandler.Object);
            var loggerMock = new Mock<ILogger>();

            var service = new ApiHttpClientService(httpClient, loggerMock.Object, Utilities.AlorOpenApiLogLevel.Fatal);

            // Act
            var result = await service.ProcessRequest<Dictionary<string, string>>(
                HttpMethod.Get,
                new Uri("https://example.com"),
                CancellationToken.None,
                needAuthorization: false
            );

            // Assert
            Assert.NotNull(result);
            Assert.Equal("value", result["key"]);
        }

        [Fact]
        public async Task ProcessRequest_ThrowsApiException_OnFailureResponse()
        {
            // Arrange
            var httpClientHandlerMock = new Mock<HttpMessageHandler>();
            var httpResponseMessage = new HttpResponseMessage()
                                      {
                                          StatusCode = HttpStatusCode.BadRequest,
                                          Content = new StringContent("Bad Request Error")
                                      };

            httpClientHandlerMock
                .Protected()
                .Setup<Task<HttpResponseMessage>>(
                    "SendAsync",
                    ItExpr.IsAny<HttpRequestMessage>(),
                    ItExpr.IsAny<CancellationToken>()
                )
                .ReturnsAsync(httpResponseMessage);

            var httpClient = new HttpClient(httpClientHandlerMock.Object);
            var loggerMock = new Mock<ILogger>();

            var service = new ApiHttpClientService(httpClient, loggerMock.Object, Utilities.AlorOpenApiLogLevel.Fatal);

            // Act & Assert
            var exception = await Assert.ThrowsAsync<ApiException>(
                async () => await service.ProcessRequest<object>(
                    HttpMethod.Get,
                    new Uri("https://example.com"),
                    CancellationToken.None,
                    needAuthorization: false
                )
            );

            Assert.NotNull(exception);
            Assert.Equal(HttpStatusCode.BadRequest, (HttpStatusCode)exception.StatusCode);
            Assert.Contains("Bad Request Error", exception.Response);
        }

        [Theory]
        [InlineData(HttpStatusCode.BadRequest)]
        [InlineData(HttpStatusCode.Unauthorized)]
        [InlineData(HttpStatusCode.Forbidden)]
        [InlineData(HttpStatusCode.NotFound)]
        [InlineData(HttpStatusCode.InternalServerError)]
        public async Task ProcessRequest_ThrowsApiException_WhenErrorStatusCodeReturned(HttpStatusCode statusCode)
        {
            // Arrange
            var httpClientHandlerMock = new Mock<HttpMessageHandler>();
            httpClientHandlerMock
                .Protected()
                .Setup<Task<HttpResponseMessage>>(
                    "SendAsync",
                    ItExpr.IsAny<HttpRequestMessage>(),
                    ItExpr.IsAny<CancellationToken>()
                )
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = statusCode,
                    Content = new StringContent("Error")
                });

            var httpClient = new HttpClient(httpClientHandlerMock.Object) { BaseAddress = new Uri("https://example.com") };
            var apiHttpClientService = new ApiHttpClientService(httpClient, Mock.Of<ILogger>(), Utilities.AlorOpenApiLogLevel.Fatal);

            // Act & Assert
            var response = await Assert.ThrowsAsync<ApiException>(() =>
                apiHttpClientService.ProcessRequest<object>(
                    HttpMethod.Get, new Uri("https://example.com"), CancellationToken.None
                )
            );
        }

        [Fact]
        public async Task ProcessRequest_AddsAuthorizationHeader_WhenNeeded()
        {
            // Arrange
            var expectedToken = "expected_token";

            var httpClientHandlerMock = new Mock<HttpMessageHandler>();
            var httpResponseMessage = new HttpResponseMessage()
                                      {
                                          StatusCode = HttpStatusCode.OK,
                                          Content = new StringContent(
                                              "{\"buyingPowerAtMorning\":439844.15,\"buyingPower\":452404,\"profit\":12560,\"profitRate\":1.93,\"portfolioEvaluation\":651717,\"portfolioLiquidationValue\":651717,\"initialMargin\":199313,\"riskBeforeForcePositionClosing\":552061,\"commission\":24.21}")
                                      };

            httpClientHandlerMock
                .Protected()
                .Setup<Task<HttpResponseMessage>>(
                    "SendAsync",
                    ItExpr.Is<HttpRequestMessage>(request =>
                        request.Headers.Authorization != null &&
                        request.Headers.Authorization.Scheme == "Bearer" &&
                        request.Headers.Authorization.Parameter == expectedToken
                    ),
                    ItExpr.IsAny<CancellationToken>()
                )
                .ReturnsAsync(httpResponseMessage);

            var httpClient = new HttpClient(httpClientHandlerMock.Object);
            var loggerMock = new Mock<ILogger>();

            var service = new ApiHttpClientService(httpClient, loggerMock.Object, Utilities.AlorOpenApiLogLevel.Fatal);
            service.JwtUpdate(expectedToken); // Обновляем токен в сервисе.

            // Act
            var response = await service.ProcessRequest<object>(
                HttpMethod.Get,
                new Uri("https://example.com"),
                CancellationToken.None,
                needAuthorization: true
            );

            // Assert
            httpClientHandlerMock.Protected().Verify(
                "SendAsync",
                Times.Once(),
                ItExpr.Is<HttpRequestMessage>(request =>
                    request.Headers.Authorization != null &&
                    request.Headers.Authorization.Scheme == "Bearer" &&
                    request.Headers.Authorization.Parameter == expectedToken
                ),
                ItExpr.IsAny<CancellationToken>()
            );
        }

        [Fact]
        public async Task ProcessRequest_AddsXAlorReqidHeader_WhenNeedXAlorIsTrue()
        {
            // Arrange
            var httpMessageHandlerMock = new Mock<HttpMessageHandler>();
            httpMessageHandlerMock.Protected()
                .Setup<Task<HttpResponseMessage>>(
                    "SendAsync",
                    ItExpr.IsAny<HttpRequestMessage>(),
                    ItExpr.IsAny<CancellationToken>()
                )
                .ReturnsAsync(new HttpResponseMessage()
                              {
                                  StatusCode = HttpStatusCode.OK,
                                  Content = new StringContent("{\"message\":\"success\",\"orderNumber\":\"40912123153\"}")
                              })
                .Callback<HttpRequestMessage, CancellationToken>((request, cancellationToken) =>
                {
                    // Проверяем, что заголовок присутствует
                    Assert.True(request.Headers.Contains("X-REQID"));
                });

            var httpClient = new HttpClient(httpMessageHandlerMock.Object);
            var loggerMock = new Mock<ILogger>();

            var apiHttpClientService = new ApiHttpClientService(httpClient, loggerMock.Object, Utilities.AlorOpenApiLogLevel.Fatal);

            var body =
                "{\"side\":\"buy\",\"quantity\":1,\"instrument\":{\"symbol\":\"SBER\",\"exchange\":\"MOEX\",\"instrumentGroup\":\"TQBR\"},\"comment\":\"Первая заявка\",\"user\":{\"portfolio\":\"D39004\"},\"timeInForce\":\"oneday\"}";

            // Act
            var response = await apiHttpClientService.ProcessRequest<object>(
                HttpMethod.Post,
                new Uri("https://example.com"),
                CancellationToken.None,
                needAuthorization: false,
                body: body,
                needXReqid: true
            );

            // Assert - Проверки проводятся в Callback
        }

        [Fact]
        public async Task ProcessRequest_DeserializesResponseBodyCorrectly()
        {
            // Arrange
            var expectedObject = new RiskSimple("7500GHC", Exchange.MOEX, 646270.9m, 646270.9m, 15752.115m, 65177.0575m,
                15752.115m, 630518.785m, 638394.8425m, 2, ClientType.StandardRisk, false, false, RiskStatus.Ok);
            var jsonResponseBody = Encoding.UTF8.GetString(JsonSerializer.Generic.Utf8.Serialize(expectedObject));
            var httpMessageHandlerMock = new Mock<HttpMessageHandler>();

            httpMessageHandlerMock
                .Protected()
                .Setup<Task<HttpResponseMessage>>(
                    "SendAsync",
                    ItExpr.IsAny<HttpRequestMessage>(),
                    ItExpr.IsAny<CancellationToken>()
                )
                .ReturnsAsync(new HttpResponseMessage
                              {
                                  StatusCode = HttpStatusCode.OK,
                                  Content = new StringContent(jsonResponseBody, Encoding.UTF8, "application/json")
                              })
                .Verifiable();

            var httpClient = new HttpClient(httpMessageHandlerMock.Object)
                             {
                                 BaseAddress = new Uri("https://example.com")
                             };

            var loggerMock = new Mock<ILogger>();
            var service = new ApiHttpClientService(httpClient, loggerMock.Object, Utilities.AlorOpenApiLogLevel.Fatal);

            // Act
            var result = await service.ProcessRequest<RiskSimple>(HttpMethod.Get, new Uri("https://example.com"), CancellationToken.None);

            // Assert
            result.Should().BeEquivalentTo(expectedObject, options => options.ComparingByMembers<RiskSimple>());
            httpMessageHandlerMock.Protected().Verify(
                "SendAsync",
                Times.Once(),
                ItExpr.IsAny<HttpRequestMessage>(),
                ItExpr.IsAny<CancellationToken>()
            );
        }

    }
}
