using Alor.OpenAPI.Interfaces;
using Alor.OpenAPI.Managers;
using Alor.OpenAPI.Models;
using Alor.OpenAPI.Services;
using Alor.OpenAPI.Utilities;
using Serilog;
using Serilog.Core;
using System.Collections.Concurrent;
using System.Net;

namespace Alor.OpenAPI.Core
{
    public sealed class AlorOpenApiClient : IAlorOpenApiClient
    {
        private readonly Configuration.Config _config;

        internal readonly ConcurrentDictionary<string, Parameters> Parameters = [];

        private readonly CancellationTokenSource _cancellationTokenSource;

        private int _disposed;
        private int _socketsCounter;
        private string? _jwtToken;
        private readonly object _webSocketsPoolManagersLock = new();
        private readonly List<IWebSocketsPoolManager> _webSocketsPoolManagers;
        private readonly Action<WsResponseMessage>? _wsResponseMessageHandler;
        private readonly Action<WsResponseCommandMessage>? _wsResponseCommandMessageHandler;

        private readonly HttpClient _httpClientForApi;
        private readonly HttpClient _httpClientForAuth;

        private readonly IApiHttpClientService _apiHttpClient;
        private readonly ITokenService _token;
        private readonly IMetricsService _metrics;

        public IWebSocketsPoolManager WsPoolManager { get; }
        public IInstrumentsService Instruments { get; }
        public IClientInfoService ClientInfo { get; }
        public IOthersService Others { get; }
        public IOrdersService Orders { get; }
        public IStopOrdersService StopOrders { get; }
        public IOrderGroupsService OrderGroups { get; }

        public void Dispose()
        {
            if (Interlocked.Exchange(ref _disposed, 1) == 1)
                return;

            _cancellationTokenSource.Cancel();
            _cancellationTokenSource.Dispose();
            Parameters.Clear();
            _httpClientForApi.Dispose();
            _httpClientForAuth.Dispose();
            _token.Dispose();
            _metrics.Dispose();

            lock (_webSocketsPoolManagersLock)
            {
                foreach (var webSocketsPoolManager in _webSocketsPoolManagers)
                {
                    webSocketsPoolManager.Dispose();
                }
                _webSocketsPoolManagers.Clear();
            }

            _webSocketsPoolManagers.Clear();
        }

        private AlorOpenApiClient(Configuration.Config configuration, HttpClient httpClientForApi, HttpClient httpClientForAuth, AlorOpenApiLogLevel logLevel, CancellationTokenSource cancellationTokenSource,
            IApiHttpClientService apiHttpClient, ITokenService tokenService, IMetricsService metricsService, List<IWebSocketsPoolManager> webSocketsPoolManagers,
            IInstrumentsService instrumentsService, IClientInfoService clientInfoService, IOthersService othersService,
            IOrdersService ordersService, IStopOrdersService stopOrdersService, IOrderGroupsService orderGroupsService, IWebSocketsPoolManager? webSocketsPoolManager,
            Action<WsResponseMessage>? wsResponseMessageHandler = null,
            Action<WsResponseCommandMessage>? wsResponseCommandMessageHandler = null)
        {
            _cancellationTokenSource = cancellationTokenSource;
            _config = configuration;
            _token = tokenService;
            _webSocketsPoolManagers = webSocketsPoolManagers ?? [];

            _wsResponseMessageHandler = wsResponseMessageHandler;
            _wsResponseCommandMessageHandler = wsResponseCommandMessageHandler;

            _metrics = metricsService;
            _httpClientForApi = httpClientForApi;
            _httpClientForAuth = httpClientForAuth;
            _apiHttpClient = apiHttpClient;

            Instruments = instrumentsService;
            ClientInfo = clientInfoService;
            Others = othersService;
            Orders = ordersService;
            StopOrders = stopOrdersService;
            OrderGroups = orderGroupsService;

            WsPoolManager = webSocketsPoolManager ?? new WebSocketsPoolManager(Parameters, IncrementSocketsCounter,
                DecrementSocketsCounter, _jwtToken, _metrics.GetMetricsRegistry(), configuration.WsUrl,
                configuration.CwsUrl, logLevel,
                wsResponseMessageHandlerFromUser: _wsResponseMessageHandler,
                wsResponseCommandMessageHandlerFromUser: _wsResponseCommandMessageHandler,
                webSocketHeaders: configuration.WsUrlHeaders, commandWebSocketHeaders: configuration.CwsUrlHeaders);

            _webSocketsPoolManagers.Add(WsPoolManager);
            _token.JwtUpdated = OnJwtUpdated;

        }

        /// <include file='../XmlDocs/AlorOpenAPIClient.xml' path='Docs/Members[@name="AlorOpenAPIClient"]/Member[@name="CreateWsPool"]/*' />
        public IWebSocketsPoolManager CreateWsPool(IReadOnlyList<string>? names = null,
            string? commandSocketName = null, int sockets = 1,
            AlorOpenApiLogLevel logLevel = AlorOpenApiLogLevel.Error, string? logFileNameSuffix = null)
        {
            var wsPoolManager = new WebSocketsPoolManager(Parameters, IncrementSocketsCounter,
                DecrementSocketsCounter, _jwtToken, _metrics.GetMetricsRegistry(), _config.WsUrl, _config.CwsUrl,
                logLevel, names, commandSocketName, sockets, logFileNameSuffix, _wsResponseMessageHandler,
                _wsResponseCommandMessageHandler, _config.WsUrlHeaders, _config.CwsUrlHeaders);
            
            lock (_webSocketsPoolManagersLock)
            {
                _webSocketsPoolManagers.Add(wsPoolManager);
            }

            return wsPoolManager;
        }

        /// <include file='../XmlDocs/AlorOpenAPIClient.xml' path='Docs/Members[@name="AlorOpenAPIClient"]/Member[@name="CreateAsync"]/*' />
        public static async Task<IAlorOpenApiClient> CreateAsync(Configuration.Config configuration,
            string? refreshToken = null, AlorOpenApiLogLevel logLevel = AlorOpenApiLogLevel.Error,
            bool isMetricsCollectionEnabled = true,
            string? logFileNameSuffix = null,
            Action<WsResponseMessage>? wsResponseMessageHandler = null,
            Action<WsResponseCommandMessage>? wsResponseCommandMessageHandler = null)
        {
            var cancellationTokenSource = new CancellationTokenSource();

            var baseUrl = configuration.BaseUrl;
            var baseUrlHeaders = configuration.BaseUrlHeaders;
            var authUrl = configuration.AuthUrl;
            var authUrlHeaders = configuration.AuthUrlHeaders;

            var handlerWithDisabledCertificatValidation = new HttpClientHandler
                                                          {
                                                              ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => true
                                                          };

            var httpClientForApi = IPAddress.TryParse(baseUrl.Host, out _)
                ? new HttpClient(handlerWithDisabledCertificatValidation)
                : new HttpClient();

            var httpClientForAuth = IPAddress.TryParse(authUrl.Host, out _)
                ? new HttpClient(handlerWithDisabledCertificatValidation)
                : new HttpClient();

            if (baseUrlHeaders != null)
            {
                foreach (var header in baseUrlHeaders)
                {
                    httpClientForApi.DefaultRequestHeaders.Add(header.Key, header.Value);
                }
            }

            if (authUrlHeaders != null)
            {
                foreach (var header in authUrlHeaders)
                {
                    httpClientForAuth.DefaultRequestHeaders.Add(header.Key, header.Value);
                }
            }

            if (!Directory.Exists("logs")) Directory.CreateDirectory("logs");

            var levelSwitch = new LoggingLevelSwitch(logLevel.ToSerilogLevel());
            var logger = new LoggerConfiguration().MinimumLevel.ControlledBy(levelSwitch)
                //.WriteTo.Console(outputTemplate: "[{Timestamp:HH:mm:ss.ffff} {Level:u3}] {Message:lj}{NewLine}{Exception}")
                .WriteTo.Async(a => a.File($"logs/log-AlorOpenApiClient{(!string.IsNullOrEmpty(logFileNameSuffix) ? "-" + logFileNameSuffix : logFileNameSuffix)}_.txt", rollingInterval: RollingInterval.Day,
                    outputTemplate: "[{Timestamp:HH:mm:ss.ffff} {Level:u3}] {Message:lj}{NewLine}{Exception}",
                    flushToDiskInterval: TimeSpan.FromSeconds(5)))
                .CreateLogger();

            var webSocketsPoolManagers = new List<IWebSocketsPoolManager>();
            var metricsService = new MetricsService(logger, baseUrl, webSocketsPoolManagers, isMetricsCollectionEnabled,
                cancellationTokenSource);
            var apiHttpClient = new ApiHttpClientService(httpClientForApi, logger, logLevel);

            var instrumentsService = new InstrumentsService(apiHttpClient, baseUrl, cancellationTokenSource);
            var clientInfoService = new ClientInfoService(apiHttpClient, baseUrl, cancellationTokenSource);
            var othersService = new OthersService(apiHttpClient, baseUrl, cancellationTokenSource);
            var ordersService = new OrdersService(apiHttpClient, baseUrl, cancellationTokenSource);
            var stopOrdersService = new StopOrdersService(apiHttpClient, baseUrl, cancellationTokenSource);
            var orderGroupsService = new OrderGroupsService(apiHttpClient, baseUrl, cancellationTokenSource);

            var tokenService = new TokenService(httpClientForAuth, logger, configuration.AuthUrl, refreshToken,
                cancellationTokenSource);

            var client = new AlorOpenApiClient(configuration, httpClientForApi, httpClientForAuth, logLevel, cancellationTokenSource,
                apiHttpClient, tokenService, metricsService,
                webSocketsPoolManagers, instrumentsService, clientInfoService, othersService, ordersService,
                stopOrdersService, orderGroupsService, null,
                wsResponseMessageHandler, wsResponseCommandMessageHandler);

            await client._token.RefreshTokenAndSetRefreshTimer();

            return client;
        }

        /// <include file='../XmlDocs/AlorOpenAPIClient.xml' path='Docs/Members[@name="AlorOpenAPIClient"]/Member[@name="CreateAsync"]/*' />
        public static Task<IAlorOpenApiClient> CreateAsync(Configuration.Config configuration,
            AlorOpenApiLogLevel logLevel = AlorOpenApiLogLevel.Error,
            bool isMetricsCollectionEnabled = true,
            string? logFileNameSuffix = null,
            Action<WsResponseMessage>? wsResponseMessageHandler = null,
            Action<WsResponseCommandMessage>? wsResponseCommandMessageHandler = null, string? refreshToken = null) =>
            CreateAsync(configuration, refreshToken, logLevel, isMetricsCollectionEnabled, logFileNameSuffix,
                wsResponseMessageHandler,
                wsResponseCommandMessageHandler);

        internal static async Task<IAlorOpenApiClient> CreateForTestingAsync(Configuration.Config configuration, HttpClient httpClientForApi, HttpClient httpClientForAuth,
            AlorOpenApiLogLevel logLevel, CancellationTokenSource cancellationTokenSource,
            IApiHttpClientService apiHttpClient, ITokenService tokenService, IMetricsService metricsService, List<IWebSocketsPoolManager> webSocketsPoolManagers,
            IInstrumentsService instrumentsService, IClientInfoService clientInfoService, IOthersService othersService,
            IOrdersService ordersService, IStopOrdersService stopOrdersService, IOrderGroupsService orderGroupsService, IWebSocketsPoolManager webSocketsPoolManager,
            Action<WsResponseMessage>? wsResponseMessageHandler = null,
            Action<WsResponseCommandMessage>? wsResponseCommandMessageHandler = null)
        {
            var client = new AlorOpenApiClient(configuration, httpClientForApi, httpClientForAuth, logLevel, cancellationTokenSource,
                apiHttpClient, tokenService, metricsService,
                webSocketsPoolManagers, instrumentsService, clientInfoService, othersService, ordersService,
                stopOrdersService, orderGroupsService, webSocketsPoolManager,
                wsResponseMessageHandler, wsResponseCommandMessageHandler);

            await client._token.RefreshTokenAndSetRefreshTimer();

            return client;
        }

        private void OnJwtUpdated(string? newToken)
        {
            _jwtToken = newToken;
            _apiHttpClient.JwtUpdate(newToken);
            ((IInternalWebSocketsPoolManagerActions)WsPoolManager).JwtUpdate(newToken);
            foreach (var webSocketsPoolManager in _webSocketsPoolManagers)
            {
               ((IInternalWebSocketsPoolManagerActions)webSocketsPoolManager).JwtUpdate(newToken);
            }
        }

        private void IncrementSocketsCounter()
        {
            var interlockedCounter = Interlocked.Increment(ref _socketsCounter);
            _metrics.UpdateSocketsCounterMetric(interlockedCounter);
        }

        private void DecrementSocketsCounter()
        {
            var interlockedCounter = Interlocked.Decrement(ref _socketsCounter);
            _metrics.UpdateSocketsCounterMetric(interlockedCounter);
        }


        public void EnableMetricsCollection() => _metrics.EnableMetricsCollection();
        public void DisableMetricsCollection() => _metrics.DisableMetricsCollection();

        public void SetWsResponseMessageHandler(Action<WsResponseMessage>? handler)
            => ((IInternalWebSocketsPoolManagerActions)WsPoolManager).SetWsResponseMessageHandler(handler);
        public void SetWsResponseCommandMessageHandler(Action<WsResponseCommandMessage>? handler)
            => ((IInternalWebSocketsPoolManagerActions)WsPoolManager).SetWsResponseCommandMessageHandler(handler);
    }
}
