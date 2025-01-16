using Alor.OpenAPI.Core;
using Alor.OpenAPI.Enums;
using Alor.OpenAPI.Interfaces;
using Alor.OpenAPI.Models;
using Alor.OpenAPI.Models.Simple;
using Alor.OpenAPI.Utilities;
using Moq;
using System.Collections.Concurrent;

namespace Alor.OpenAPI.Tests
{
    public class AlorOpenAPIClientTests
    {
        [Fact]
        public async Task AlorOpenApiClient_EnableMetricsCollection_InvokesMetricsService()
        {
            // Arrange
            var config = Configuration.Create("https://api.example.com", "https://auth.example.com",
                "wss://ws.example.com", "wss://cws.example.com");
            var logLevel = AlorOpenApiLogLevel.Fatal;
            var cancellationTokenSource = new CancellationTokenSource();
            var httpClientForApi = new HttpClient();
            var httpClientForAuth = new HttpClient();

            var apiHttpClientMock = new Mock<IApiHttpClientService>();
            var tokenServiceMock = new Mock<ITokenService>();
            var metricsRegistryMock = new Mock<IMetricsRegistry>();
            metricsRegistryMock.Setup(m => m.EnableMetricsCollection());
            metricsRegistryMock.Setup(m => m.DisableMetricsCollection());
            metricsRegistryMock.Setup(m => m.MetricsOptions).Returns(new ConcurrentDictionary<string, object>());
            var metricsServiceMock = new Mock<IMetricsService>();
            metricsServiceMock.Setup(m => m.GetMetricsRegistry()).Returns(metricsRegistryMock.Object);

            var webSocketsPoolManagers = new List<IWebSocketsPoolManager>();
            var instrumentsServiceMock = new Mock<IInstrumentsService>();
            var clientInfoServiceMock = new Mock<IClientInfoService>();
            var othersServiceMock = new Mock<IOthersService>();
            var ordersServiceMock = new Mock<IOrdersService>();
            var stopOrdersServiceMock = new Mock<IStopOrdersService>();
            var orderGroupsServiceMock = new Mock<IOrderGroupsService>();
            var webSocketsPoolManagerMock = new Mock<IWebSocketsPoolManager>();

            // Используем метод CreateForTestingAsync для создания экземпляра AlorOpenApiClient с мокированными зависимостями
            var client = await AlorOpenApiClient.CreateForTestingAsync(config, httpClientForApi, httpClientForAuth, logLevel, cancellationTokenSource,
                apiHttpClientMock.Object, tokenServiceMock.Object, metricsServiceMock.Object, webSocketsPoolManagers,
                instrumentsServiceMock.Object, clientInfoServiceMock.Object, othersServiceMock.Object,
                ordersServiceMock.Object,
                stopOrdersServiceMock.Object, orderGroupsServiceMock.Object, webSocketsPoolManagerMock.Object, null,
                null);

            // Act
            client.EnableMetricsCollection();
            client.DisableMetricsCollection();

            // Assert
            metricsServiceMock.Verify(m => m.EnableMetricsCollection(), Times.Once);
            metricsServiceMock.Verify(m => m.DisableMetricsCollection(), Times.Once);
        }

        [Fact]
        public async Task Dispose_InvokesDisposeOnDependencies()
        {
            // Arrange
            var config = Configuration.Create("https://api.example.com", "https://auth.example.com",
                "wss://ws.example.com", "wss://cws.example.com");
            var logLevel = AlorOpenApiLogLevel.Fatal;
            var cancellationTokenSource = new CancellationTokenSource();
            var httpClientForApi = new HttpClient();
            var httpClientForAuth = new HttpClient();

            var apiHttpClientMock = new Mock<IApiHttpClientService>();
            var tokenServiceMock = new Mock<ITokenService>();
            tokenServiceMock.Setup(x => x.Dispose());
            var metricsRegistryMock = new Mock<IMetricsRegistry>();
            metricsRegistryMock.Setup(m => m.MetricsOptions).Returns(new ConcurrentDictionary<string, object>());
            var metricsServiceMock = new Mock<IMetricsService>();
            metricsServiceMock.Setup(m => m.GetMetricsRegistry()).Returns(metricsRegistryMock.Object);
            metricsServiceMock.Setup(x => x.Dispose());
            var webSocketsPoolManagerMock = new Mock<IWebSocketsPoolManager>();
            webSocketsPoolManagerMock.Setup(x => x.Dispose());
            var instrumentsServiceMock = new Mock<IInstrumentsService>();
            var clientInfoServiceMock = new Mock<IClientInfoService>();
            var othersServiceMock = new Mock<IOthersService>();
            var ordersServiceMock = new Mock<IOrdersService>();
            var stopOrdersServiceMock = new Mock<IStopOrdersService>();
            var orderGroupsServiceMock = new Mock<IOrderGroupsService>();
            var webSocketsPoolManagers = new List<IWebSocketsPoolManager>();

            // Используем метод CreateForTestingAsync для создания экземпляра AlorOpenApiClient с мокированными зависимостями
            var client = await AlorOpenApiClient.CreateForTestingAsync(
                config, httpClientForApi, httpClientForAuth, logLevel, cancellationTokenSource,
                apiHttpClientMock.Object, tokenServiceMock.Object, metricsServiceMock.Object, webSocketsPoolManagers,
                instrumentsServiceMock.Object, clientInfoServiceMock.Object, othersServiceMock.Object,
                ordersServiceMock.Object,
                stopOrdersServiceMock.Object, orderGroupsServiceMock.Object, webSocketsPoolManagerMock.Object, null,
                null);

            // Act
            client.Dispose();

            // Assert
            tokenServiceMock.Verify(x => x.Dispose(), Times.Once);
            metricsServiceMock.Verify(x => x.Dispose(), Times.Once);
            webSocketsPoolManagerMock.Verify(x => x.Dispose(), Times.Once);

            // Убеждаемся, что для не-IDisposable моков метод Dispose не вызывается
            instrumentsServiceMock.VerifyNoOtherCalls();
            clientInfoServiceMock.VerifyNoOtherCalls();
            othersServiceMock.VerifyNoOtherCalls();
            ordersServiceMock.VerifyNoOtherCalls();
            stopOrdersServiceMock.VerifyNoOtherCalls();
            orderGroupsServiceMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task CreateAsync_CallsTokenServiceRefreshToken()
        {
            // Arrange
            var config = Configuration.Create("https://api.example.com", "https://auth.example.com",
                "wss://ws.example.com", "wss://cws.example.com");
            var logLevel = AlorOpenApiLogLevel.Fatal;
            var cancellationTokenSource = new CancellationTokenSource();
            var httpClientForApi = new HttpClient();
            var httpClientForAuth = new HttpClient();

            var apiHttpClientMock = new Mock<IApiHttpClientService>();
            var tokenServiceMock = new Mock<ITokenService>();
            tokenServiceMock.Setup(service => service.RefreshTokenAndSetRefreshTimer())
                .Returns(Task.CompletedTask)
                .Verifiable();
            var metricsRegistryMock = new Mock<IMetricsRegistry>();
            metricsRegistryMock.Setup(m => m.MetricsOptions).Returns(new ConcurrentDictionary<string, object>());
            var metricsServiceMock = new Mock<IMetricsService>();
            metricsServiceMock.Setup(m => m.GetMetricsRegistry()).Returns(metricsRegistryMock.Object);

            var webSocketsPoolManagers = new List<IWebSocketsPoolManager>();
            var instrumentsServiceMock = new Mock<IInstrumentsService>();
            var clientInfoServiceMock = new Mock<IClientInfoService>();
            var othersServiceMock = new Mock<IOthersService>();
            var ordersServiceMock = new Mock<IOrdersService>();
            var stopOrdersServiceMock = new Mock<IStopOrdersService>();
            var orderGroupsServiceMock = new Mock<IOrderGroupsService>();
            var webSocketsPoolManagerMock = new Mock<IWebSocketsPoolManager>();

            // Act
            var client = await AlorOpenApiClient.CreateForTestingAsync(config, httpClientForApi, httpClientForAuth, logLevel, cancellationTokenSource,
                apiHttpClientMock.Object, tokenServiceMock.Object, metricsServiceMock.Object, webSocketsPoolManagers,
                instrumentsServiceMock.Object, clientInfoServiceMock.Object, othersServiceMock.Object,
                ordersServiceMock.Object,
                stopOrdersServiceMock.Object, orderGroupsServiceMock.Object, webSocketsPoolManagerMock.Object, null,
                null);

            // Assert
            tokenServiceMock.Verify(service => service.RefreshTokenAndSetRefreshTimer(), Times.Once);
        }

        [Fact]
        public async Task GetInstruments_CallsMdV2SecuritiesGetSimpleAsyncWithCorrectParameters()
        {
            // Arrange
            var config = Configuration.Create("https://api.example.com", "https://auth.example.com",
                "wss://ws.example.com", "wss://cws.example.com");
            var logLevel = AlorOpenApiLogLevel.Fatal;
            var cancellationTokenSource = new CancellationTokenSource();
            var httpClientForApi = new HttpClient();
            var httpClientForAuth = new HttpClient();

            var apiHttpClientMock = new Mock<IApiHttpClientService>();
            var tokenServiceMock = new Mock<ITokenService>();
            var metricsRegistryMock = new Mock<IMetricsRegistry>();
            metricsRegistryMock.Setup(m => m.MetricsOptions).Returns(new ConcurrentDictionary<string, object>());
            var metricsServiceMock = new Mock<IMetricsService>();
            metricsServiceMock.Setup(m => m.GetMetricsRegistry()).Returns(metricsRegistryMock.Object);

            var webSocketsPoolManagers = new List<IWebSocketsPoolManager>();
            var instrumentsServiceMock = new Mock<IInstrumentsService>();
            instrumentsServiceMock
                .Setup(x => x.MdV2SecuritiesGetSimpleAsync(
                    It.IsAny<string>(), It.IsAny<int?>(), It.IsAny<int?>(),
                    It.IsAny<Sector?>(), It.IsAny<string>(), It.IsAny<Exchange?>(),
                    It.IsAny<string>(), It.IsAny<bool?>()))
                .ReturnsAsync(new List<SecuritySimple>())
                .Verifiable();
            var clientInfoServiceMock = new Mock<IClientInfoService>();
            var othersServiceMock = new Mock<IOthersService>();
            var ordersServiceMock = new Mock<IOrdersService>();
            var stopOrdersServiceMock = new Mock<IStopOrdersService>();
            var orderGroupsServiceMock = new Mock<IOrderGroupsService>();
            var webSocketsPoolManagerMock = new Mock<IWebSocketsPoolManager>();

            // Используем метод CreateForTestingAsync для создания экземпляра AlorOpenApiClient с мокированными зависимостями
            var client = await AlorOpenApiClient.CreateForTestingAsync(config, httpClientForApi, httpClientForAuth, logLevel, cancellationTokenSource,
                apiHttpClientMock.Object, tokenServiceMock.Object, metricsServiceMock.Object, webSocketsPoolManagers,
                instrumentsServiceMock.Object, clientInfoServiceMock.Object, othersServiceMock.Object,
                ordersServiceMock.Object,
                stopOrdersServiceMock.Object, orderGroupsServiceMock.Object, webSocketsPoolManagerMock.Object, null,
                null);

            var limit = 10000;
            var exchange = Exchange.MOEX;

            // Act
            var result = await client.Instruments.MdV2SecuritiesGetSimpleAsync(limit: limit, exchange: exchange);

            // Assert
            instrumentsServiceMock.Verify(
                x => x.MdV2SecuritiesGetSimpleAsync(null, limit, null, null, null, exchange, null, null), Times.Once());
        }

        [Fact]
        public async Task GetClientInfo_CallsMdV2ClientsExchangePortfolioSummaryGetSimpleAsyncWithCorrectParameters()
        {
            // Arrange
            var config = Configuration.Create("https://api.example.com", "https://auth.example.com",
                "wss://ws.example.com", "wss://cws.example.com");
            var logLevel = AlorOpenApiLogLevel.Fatal;
            var cancellationTokenSource = new CancellationTokenSource();
            var httpClientForApi = new HttpClient();
            var httpClientForAuth = new HttpClient();

            var apiHttpClientMock = new Mock<IApiHttpClientService>();
            var tokenServiceMock = new Mock<ITokenService>();
            var metricsRegistryMock = new Mock<IMetricsRegistry>();
            metricsRegistryMock.Setup(m => m.MetricsOptions).Returns(new ConcurrentDictionary<string, object>());
            var metricsServiceMock = new Mock<IMetricsService>();
            metricsServiceMock.Setup(m => m.GetMetricsRegistry()).Returns(metricsRegistryMock.Object);

            var webSocketsPoolManagers = new List<IWebSocketsPoolManager>();
            var instrumentsServiceMock = new Mock<IInstrumentsService>();
            var clientInfoServiceMock = new Mock<IClientInfoService>();
            clientInfoServiceMock
                .Setup(x => x.MdV2ClientsExchangePortfolioSummaryGetSimpleAsync(
                    It.IsAny<Exchange>(),
                    It.IsAny<string>()))
                .ReturnsAsync(new SummarySimple())
                .Verifiable();

            var othersServiceMock = new Mock<IOthersService>();
            var ordersServiceMock = new Mock<IOrdersService>();
            var stopOrdersServiceMock = new Mock<IStopOrdersService>();
            var orderGroupsServiceMock = new Mock<IOrderGroupsService>();
            var webSocketsPoolManagerMock = new Mock<IWebSocketsPoolManager>();

            // Используем метод CreateForTestingAsync для создания экземпляра AlorOpenApiClient с мокированными зависимостями
            var client = await AlorOpenApiClient.CreateForTestingAsync(config, httpClientForApi, httpClientForAuth, logLevel, cancellationTokenSource,
                apiHttpClientMock.Object, tokenServiceMock.Object, metricsServiceMock.Object, webSocketsPoolManagers,
                instrumentsServiceMock.Object, clientInfoServiceMock.Object, othersServiceMock.Object,
                ordersServiceMock.Object,
                stopOrdersServiceMock.Object, orderGroupsServiceMock.Object, webSocketsPoolManagerMock.Object, null,
                null);

            var portfolio = "D12345678";
            var exchange = Exchange.MOEX;

            // Act
            var result = await client.ClientInfo.MdV2ClientsExchangePortfolioSummaryGetSlimAsync(exchange, portfolio);

            // Assert
            clientInfoServiceMock.Verify(
                x => x.MdV2ClientsExchangePortfolioSummaryGetSlimAsync(exchange, portfolio), Times.Once());
        }

        [Fact]
        public async Task GetOthers_CallsMdV2TimeGetAsyncWithCorrectParameters()
        {
            // Arrange
            var config = Configuration.Create("https://api.example.com", "https://auth.example.com",
                "wss://ws.example.com", "wss://cws.example.com");
            var logLevel = AlorOpenApiLogLevel.Fatal;
            var cancellationTokenSource = new CancellationTokenSource();
            var httpClientForApi = new HttpClient();
            var httpClientForAuth = new HttpClient();

            var apiHttpClientMock = new Mock<IApiHttpClientService>();
            var tokenServiceMock = new Mock<ITokenService>();
            var metricsRegistryMock = new Mock<IMetricsRegistry>();
            metricsRegistryMock.Setup(m => m.MetricsOptions).Returns(new ConcurrentDictionary<string, object>());
            var metricsServiceMock = new Mock<IMetricsService>();
            metricsServiceMock.Setup(m => m.GetMetricsRegistry()).Returns(metricsRegistryMock.Object);

            var webSocketsPoolManagers = new List<IWebSocketsPoolManager>();
            var instrumentsServiceMock = new Mock<IInstrumentsService>();
            var clientInfoServiceMock = new Mock<IClientInfoService>();
            var othersServiceMock = new Mock<IOthersService>();
            othersServiceMock
                .Setup(x => x.MdV2TimeGetAsync())
                .ReturnsAsync(new long())
                .Verifiable();


            var ordersServiceMock = new Mock<IOrdersService>();
            var stopOrdersServiceMock = new Mock<IStopOrdersService>();
            var orderGroupsServiceMock = new Mock<IOrderGroupsService>();
            var webSocketsPoolManagerMock = new Mock<IWebSocketsPoolManager>();

            // Используем метод CreateForTestingAsync для создания экземпляра AlorOpenApiClient с мокированными зависимостями
            var client = await AlorOpenApiClient.CreateForTestingAsync(config, httpClientForApi, httpClientForAuth, logLevel, cancellationTokenSource,
                apiHttpClientMock.Object, tokenServiceMock.Object, metricsServiceMock.Object, webSocketsPoolManagers,
                instrumentsServiceMock.Object, clientInfoServiceMock.Object, othersServiceMock.Object,
                ordersServiceMock.Object,
                stopOrdersServiceMock.Object, orderGroupsServiceMock.Object, webSocketsPoolManagerMock.Object, null,
                null);

            // Act
            var result = await client.Others.MdV2TimeGetAsync();

            // Assert
            othersServiceMock.Verify(
                x => x.MdV2TimeGetAsync(), Times.Once());
        }

        [Fact]
        public async Task GetOrders_CallsMdV2ClientsExchangePortfolioOrdersGetSimpleAsyncWithCorrectParameters()
        {
            // Arrange
            var config = Configuration.Create("https://api.example.com", "https://auth.example.com",
                "wss://ws.example.com", "wss://cws.example.com");
            var logLevel = AlorOpenApiLogLevel.Fatal;
            var cancellationTokenSource = new CancellationTokenSource();
            var httpClientForApi = new HttpClient();
            var httpClientForAuth = new HttpClient();

            var apiHttpClientMock = new Mock<IApiHttpClientService>();
            var tokenServiceMock = new Mock<ITokenService>();
            var metricsRegistryMock = new Mock<IMetricsRegistry>();
            metricsRegistryMock.Setup(m => m.MetricsOptions).Returns(new ConcurrentDictionary<string, object>());
            var metricsServiceMock = new Mock<IMetricsService>();
            metricsServiceMock.Setup(m => m.GetMetricsRegistry()).Returns(metricsRegistryMock.Object);

            var webSocketsPoolManagers = new List<IWebSocketsPoolManager>();
            var instrumentsServiceMock = new Mock<IInstrumentsService>();
            var clientInfoServiceMock = new Mock<IClientInfoService>();
            var othersServiceMock = new Mock<IOthersService>();
            var ordersServiceMock = new Mock<IOrdersService>();
            ordersServiceMock
                .Setup(x => x.MdV2ClientsExchangePortfolioOrdersGetSimpleAsync(
                    It.IsAny<Exchange>(),
                    It.IsAny<string>()))
                .ReturnsAsync(new List<OrderSimple>())
                .Verifiable();

            var stopOrdersServiceMock = new Mock<IStopOrdersService>();
            var orderGroupsServiceMock = new Mock<IOrderGroupsService>();
            var webSocketsPoolManagerMock = new Mock<IWebSocketsPoolManager>();

            // Используем метод CreateForTestingAsync для создания экземпляра AlorOpenApiClient с мокированными зависимостями
            var client = await AlorOpenApiClient.CreateForTestingAsync(config, httpClientForApi, httpClientForAuth, logLevel, cancellationTokenSource,
                apiHttpClientMock.Object, tokenServiceMock.Object, metricsServiceMock.Object, webSocketsPoolManagers,
                instrumentsServiceMock.Object, clientInfoServiceMock.Object, othersServiceMock.Object,
                ordersServiceMock.Object,
                stopOrdersServiceMock.Object, orderGroupsServiceMock.Object, webSocketsPoolManagerMock.Object, null,
                null);

            var portfolio = "D12345678";
            var exchange = Exchange.MOEX;

            // Act
            var result = await client.Orders.MdV2ClientsExchangePortfolioOrdersGetSimpleAsync(exchange, portfolio);

            // Assert
            ordersServiceMock.Verify(
                x => x.MdV2ClientsExchangePortfolioOrdersGetSimpleAsync(exchange, portfolio), Times.Once());
        }

        [Fact]
        public async Task GetStopOrders_CallsMdV2ClientsExchangePortfolioStopOrdersGetSimpleAsyncWithCorrectParameters()
        {
            // Arrange
            var config = Configuration.Create("https://api.example.com", "https://auth.example.com",
                "wss://ws.example.com", "wss://cws.example.com");
            var logLevel = AlorOpenApiLogLevel.Fatal;
            var cancellationTokenSource = new CancellationTokenSource();
            var httpClientForApi = new HttpClient();
            var httpClientForAuth = new HttpClient();

            var apiHttpClientMock = new Mock<IApiHttpClientService>();
            var tokenServiceMock = new Mock<ITokenService>();
            var metricsRegistryMock = new Mock<IMetricsRegistry>();
            metricsRegistryMock.Setup(m => m.MetricsOptions).Returns(new ConcurrentDictionary<string, object>());
            var metricsServiceMock = new Mock<IMetricsService>();
            metricsServiceMock.Setup(m => m.GetMetricsRegistry()).Returns(metricsRegistryMock.Object);

            var webSocketsPoolManagers = new List<IWebSocketsPoolManager>();
            var instrumentsServiceMock = new Mock<IInstrumentsService>();
            var clientInfoServiceMock = new Mock<IClientInfoService>();
            var othersServiceMock = new Mock<IOthersService>();
            var ordersServiceMock = new Mock<IOrdersService>();
            var stopOrdersServiceMock = new Mock<IStopOrdersService>();
            stopOrdersServiceMock
                .Setup(x => x.MdV2ClientsExchangePortfolioStopOrdersGetSimpleAsync(
                    It.IsAny<Exchange>(),
                    It.IsAny<string>()))
                .ReturnsAsync(new List<StopOrderSimple>())
                .Verifiable();
            var orderGroupsServiceMock = new Mock<IOrderGroupsService>();
            var webSocketsPoolManagerMock = new Mock<IWebSocketsPoolManager>();

            // Используем метод CreateForTestingAsync для создания экземпляра AlorOpenApiClient с мокированными зависимостями
            var client = await AlorOpenApiClient.CreateForTestingAsync(config, httpClientForApi, httpClientForAuth, logLevel, cancellationTokenSource,
                apiHttpClientMock.Object, tokenServiceMock.Object, metricsServiceMock.Object, webSocketsPoolManagers,
                instrumentsServiceMock.Object, clientInfoServiceMock.Object, othersServiceMock.Object,
                ordersServiceMock.Object,
                stopOrdersServiceMock.Object, orderGroupsServiceMock.Object, webSocketsPoolManagerMock.Object, null,
                null);

            var portfolio = "D12345678";
            var exchange = Exchange.MOEX;

            // Act
            var result = await client.StopOrders.MdV2ClientsExchangePortfolioStopOrdersGetSimpleAsync(exchange, portfolio);

            // Assert
            stopOrdersServiceMock.Verify(
                x => x.MdV2ClientsExchangePortfolioStopOrdersGetSimpleAsync(exchange, portfolio), Times.Once());
        }

        [Fact]
        public async Task GetOrderGroups_CallsCommandapiApiOrderGroupsGetAsyncWithCorrectParameters()
        {
            // Arrange
            var config = Configuration.Create("https://api.example.com", "https://auth.example.com",
                "wss://ws.example.com", "wss://cws.example.com");
            var logLevel = AlorOpenApiLogLevel.Fatal;
            var cancellationTokenSource = new CancellationTokenSource();
            var httpClientForApi = new HttpClient();
            var httpClientForAuth = new HttpClient();

            var apiHttpClientMock = new Mock<IApiHttpClientService>();
            var tokenServiceMock = new Mock<ITokenService>();
            var metricsRegistryMock = new Mock<IMetricsRegistry>();
            metricsRegistryMock.Setup(m => m.MetricsOptions).Returns(new ConcurrentDictionary<string, object>());
            var metricsServiceMock = new Mock<IMetricsService>();
            metricsServiceMock.Setup(m => m.GetMetricsRegistry()).Returns(metricsRegistryMock.Object);

            var webSocketsPoolManagers = new List<IWebSocketsPoolManager>();
            var instrumentsServiceMock = new Mock<IInstrumentsService>();
            var clientInfoServiceMock = new Mock<IClientInfoService>();
            var othersServiceMock = new Mock<IOthersService>();
            var ordersServiceMock = new Mock<IOrdersService>();
            var stopOrdersServiceMock = new Mock<IStopOrdersService>();
            var orderGroupsServiceMock = new Mock<IOrderGroupsService>();
            orderGroupsServiceMock
                .Setup(x => x.CommandapiApiOrderGroupsGetAsync())
                .ReturnsAsync(new List<ResponseOrderGroupInfo>())
                .Verifiable();

            var webSocketsPoolManagerMock = new Mock<IWebSocketsPoolManager>();

            // Используем метод CreateForTestingAsync для создания экземпляра AlorOpenApiClient с мокированными зависимостями
            var client = await AlorOpenApiClient.CreateForTestingAsync(config, httpClientForApi, httpClientForAuth, logLevel, cancellationTokenSource,
                apiHttpClientMock.Object, tokenServiceMock.Object, metricsServiceMock.Object, webSocketsPoolManagers,
                instrumentsServiceMock.Object, clientInfoServiceMock.Object, othersServiceMock.Object,
                ordersServiceMock.Object,
                stopOrdersServiceMock.Object, orderGroupsServiceMock.Object, webSocketsPoolManagerMock.Object, null,
                null);

            // Act
            var result = await client.OrderGroups.CommandapiApiOrderGroupsGetAsync();

            // Assert
            orderGroupsServiceMock.Verify(x => x.CommandapiApiOrderGroupsGetAsync(), Times.Once());
        }

        [Fact]
        public async Task CreateWsPool_CreatesAndReturnsWebSocketsPoolManager()
        {
            // Arrange
            var config = Configuration.Create("https://api.example.com", "https://auth.example.com",
                "wss://ws.example.com", "wss://cws.example.com");
            var logLevel = AlorOpenApiLogLevel.Fatal;
            var cancellationTokenSource = new CancellationTokenSource();
            var httpClientForApi = new HttpClient();
            var httpClientForAuth = new HttpClient();

            var apiHttpClientMock = new Mock<IApiHttpClientService>();
            var tokenServiceMock = new Mock<ITokenService>();
            var metricsRegistryMock = new Mock<IMetricsRegistry>();
            metricsRegistryMock.Setup(m => m.MetricsOptions).Returns(new ConcurrentDictionary<string, object>());
            var metricsServiceMock = new Mock<IMetricsService>();
            metricsServiceMock.Setup(m => m.GetMetricsRegistry()).Returns(metricsRegistryMock.Object);

            var webSocketsPoolManagers = new List<IWebSocketsPoolManager>();
            var instrumentsServiceMock = new Mock<IInstrumentsService>();
            var clientInfoServiceMock = new Mock<IClientInfoService>();
            var othersServiceMock = new Mock<IOthersService>();
            var ordersServiceMock = new Mock<IOrdersService>();
            var stopOrdersServiceMock = new Mock<IStopOrdersService>();
            var orderGroupsServiceMock = new Mock<IOrderGroupsService>();
            var webSocketsPoolManagerMock = new Mock<IWebSocketsPoolManager>();

            // Используем метод CreateForTestingAsync для создания экземпляра AlorOpenApiClient с мокированными зависимостями
            var client = await AlorOpenApiClient.CreateForTestingAsync(config, httpClientForApi, httpClientForAuth, logLevel, cancellationTokenSource,
                apiHttpClientMock.Object, tokenServiceMock.Object, metricsServiceMock.Object, webSocketsPoolManagers,
                instrumentsServiceMock.Object, clientInfoServiceMock.Object, othersServiceMock.Object,
                ordersServiceMock.Object,
                stopOrdersServiceMock.Object, orderGroupsServiceMock.Object, webSocketsPoolManagerMock.Object, null,
                null);

            IReadOnlyList<string> names = new List<string> { "TestSocket" };
            var commandSocketName = "CommandSocket";
            var sockets = 1;
            var logFileNameSuffix = "TestLog";

            // Act
            var wsPool = client.CreateWsPool(names, commandSocketName, sockets, logLevel, logFileNameSuffix);

            // Assert
            Assert.NotNull(wsPool);
            Assert.IsAssignableFrom<IWebSocketsPoolManager>(wsPool);
        }
    }
}
