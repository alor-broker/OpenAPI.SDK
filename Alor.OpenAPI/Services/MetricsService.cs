using Alor.OpenAPI.Extensions;
using Alor.OpenAPI.Interfaces;
using Alor.OpenAPI.Managers;
using Alor.OpenAPI.Models;
using Alor.OpenAPI.Utilities;
using App.Metrics;
using App.Metrics.Formatters.Json;
using App.Metrics.Gauge;
using Serilog;
using SpanJson;
using System.Collections.Concurrent;
using System.Net.NetworkInformation;

namespace Alor.OpenAPI.Services
{
    internal class MetricsService : IMetricsService
    {
        private AlarmClock? _clockSocketsRate;
        private readonly Uri? _baseUrl;
        private readonly ILogger _logger;
        private readonly ILogger _metricsLogger;
        private readonly CancellationTokenSource _cancellationTokenSource;
        private readonly List<IWebSocketsPoolManager> _webSocketPoolManagers;
        private readonly IMetricsRegistry _metricsRegistry;
        private readonly IMetricsRoot _metrics;
        private readonly ConcurrentDictionary<string, WsPingStats> _wsPingCache;
        private readonly ConcurrentDictionary<string, WsPingStats> _wsPingCacheUnsubscribe;

        public void UpdatePingStatsUserDelegate(Action<PingStats?>? pingStatsChangedFromUser) =>
            _pingStatsChangedToUser = pingStatsChangedFromUser;

        public void UpdateWsPingStatsUserDelegate(Action<WsPingStats?>? wsPingStatsChangedFromUser) =>
            _wsPingStatsChangedToUser = wsPingStatsChangedFromUser;

        private Action<PingStats?>? _pingStatsChangedToUser;
        private Action<WsPingStats?>? _wsPingStatsChangedToUser;

        internal MetricsService(ILogger logger, Uri baseUrl, List<IWebSocketsPoolManager> webSocketPoolManagers, bool isMetricsCollectionEnabled, CancellationTokenSource cancellationTokenSource)
        {
            _logger = logger;
            _baseUrl = baseUrl;
            _webSocketPoolManagers = webSocketPoolManagers;
            _cancellationTokenSource = cancellationTokenSource;

            if (!Directory.Exists("metrics")) Directory.CreateDirectory("metrics");

            _metricsLogger = new LoggerConfiguration()
                .WriteTo.Async(a => a.File("metrics/metrics-AlorOpenApiClient_.json", rollingInterval: RollingInterval.Hour,
                    outputTemplate: "{Message:lj}", flushToDiskInterval: TimeSpan.FromSeconds(5)))
                .CreateLogger();

            _metrics = new MetricsBuilder().Build();

            _metricsRegistry = new MetricsRegistry(_metrics, isMetricsCollectionEnabled);

            _wsPingCache = new ConcurrentDictionary<string, WsPingStats>();
            _wsPingCacheUnsubscribe = new ConcurrentDictionary<string, WsPingStats>();

            SetupMetrics();
        }

        public void Dispose()
        {
            _clockSocketsRate?.Dispose();
            _pingStatsChangedToUser = null;
            _wsPingStatsChangedToUser = null;
        }

        private void SetupMetrics()
        {
            _metricsRegistry.MetricsOptions.TryAdd("gaugeOptionPing",
                new GaugeOptions { Name = $"Ping to {_baseUrl?.Host}" });
            _metricsRegistry.MetricsOptions.TryAdd("gaugeOptionWsPing",
                new GaugeOptions { Name = $"Ping to {_baseUrl?.Host} (wss)" });
            _metricsRegistry.MetricsOptions.TryAdd("gaugeOptionActiveConnects",
                new GaugeOptions { Name = "Active websockets connects count" });

            // Замер пинга в фоновом потоке
            _ = MeasurePing(_metricsRegistry);

            // Запуск цикла отчетов
            _ = UpdateAndReportMetrics();
        }

        public void UpdateSocketsCounterMetric(int socketsConuter)
        {
            _metricsRegistry.UpdateGauge("gaugeOptionActiveConnects", socketsConuter);
        }

        public void EnableMetricsCollection() => _metricsRegistry.EnableMetricsCollection();

        public void DisableMetricsCollection() => _metricsRegistry.DisableMetricsCollection();

        public IMetricsRegistry GetMetricsRegistry() => _metricsRegistry;

        private Task MeasurePing(IMetricsRegistry metricsRegistry)
        {
            var tcs = new TaskCompletionSource();

            var t1 = new Task<Task>(async () =>
            {
                var ping = new Ping();

                while (!_cancellationTokenSource.Token.IsCancellationRequested)
                {
                    try
                    {
                        if (metricsRegistry.CurrentStatusMetricsCollection && !string.IsNullOrEmpty(_baseUrl?.Host))
                        {
                            var reply = ping.Send(_baseUrl.Host);
                            if (reply.Status == IPStatus.Success)
                            {
                                metricsRegistry.UpdateGauge("gaugeOptionPing", reply.RoundtripTime);
                                _pingStatsChangedToUser?.Invoke(new PingStats(reply.RoundtripTime));
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        _pingStatsChangedToUser?.Invoke(null);
                        _logger.Error($"Ошибка при пинге: {ex.Message}");
                    }

                    await Task.Delay(5000, _cancellationTokenSource.Token); // Замер каждые 5 секунд
                }
            }, _cancellationTokenSource.Token);

            var t2 = new Task<Task>(async () =>
            {
                while (!_cancellationTokenSource.Token.IsCancellationRequested)
                {
                    if (metricsRegistry.CurrentStatusMetricsCollection)
                    {
                        foreach (var pm in _webSocketPoolManagers)
                        {
                            if (pm.Subscriptions != null)
                            {
                                var t2s1 = new Task<Task>(async () =>
                                {
                                    try
                                    {
                                        string guid = ((SubscriptionManager)pm.Subscriptions).SendPingAsync(true).GetAwaiter().GetResult();
                                        _wsPingCache.TryAdd(guid, new WsPingStats(null, DateTime.UtcNow, null, false));
                                        await Task.Delay(5000, _cancellationTokenSource.Token);
                                        _wsPingCacheUnsubscribe.TryAdd(guid, new WsPingStats(null, DateTime.UtcNow, null, true));
                                        string[] keysUnsubscribe = _wsPingCacheUnsubscribe.Select(x => x.Key).ToArray();
                                        await pm.Subscriptions.UnsubscribeAsync(keysUnsubscribe);

                                        // Получение ответа на пинг в методе WsResponseRawHandler
                                    }
                                    catch (Exception ex)
                                    {
                                        _logger.Error($"Ошибка при пинге WS: {ex.Message}");
                                    }
                                }, _cancellationTokenSource.Token);
                                t2s1.Start();
                            }
                        }
                    }

                    await Task.Delay(5000, _cancellationTokenSource.Token); // Замер каждые 5 секунд
                }
            }, _cancellationTokenSource.Token);

            t1.Start();
            t2.Start();

            return tcs.Task;
        }

        private Task UpdateAndReportMetrics()
        {
            var tcs = new TaskCompletionSource();

            var t1 = new Task<Task>(async () =>
            {
                while (!_cancellationTokenSource.Token.IsCancellationRequested)
                {
                    if (_metricsRegistry.CurrentStatusMetricsCollection)
                    {
                        foreach (var webSocketDetail in _webSocketPoolManagers.SelectMany(webSocketsPoolManager =>
                                     ((IInternalWebSocketsPoolManagerActions)webSocketsPoolManager).GetWebSocketsInfoDetail()))
                        {
                            _metricsRegistry.UpdateGauge($"gaugeOption{webSocketDetail.Name}SentCount",
                                webSocketDetail.SentCount);
                            _metricsRegistry.UpdateGauge($"gaugeOption{webSocketDetail.Name}RecievedCount",
                                webSocketDetail.ReceivedCount);
                            _metricsRegistry.UpdateGauge($"gaugeOption{webSocketDetail.Name}LastUpdate",
                                webSocketDetail.LastUpdate.GetUnixTimestampMillis() ?? 0);
                            _metricsRegistry.UpdateGauge($"gaugeOption{webSocketDetail.Name}ReconnectCount",
                                webSocketDetail.ReconnectCount);
                            _metricsRegistry.UpdateGauge($"gaugeOption{webSocketDetail.Name}SentRate",
                                webSocketDetail.SentRate);
                            _metricsRegistry.UpdateGauge($"gaugeOption{webSocketDetail.Name}ReceiveRate",
                                webSocketDetail.ReceiveRate);
                            _metricsRegistry.UpdateGauge($"gaugeOption{webSocketDetail.Name}ReceiveBufferCount",
                                webSocketDetail.RecieveBufferCount);
                        }

                        await ReportMetricsAsync(_metrics);
                    }

                    await Task.Delay(TimeSpan.FromSeconds(10), _cancellationTokenSource.Token); // Интервал отчетов
                }
            }, _cancellationTokenSource.Token);

            t1.Start();
            SetAlarmForSocketsRateCalculation();

            return tcs.Task;
        }

        private void SetAlarmForSocketsRateCalculation()
        {
            _clockSocketsRate = new AlarmClock(DateTime.Now.AddSeconds(1));
            _clockSocketsRate.Alarm += (sender, e) =>
            {
                (sender as AlarmClock)?.Dispose();
                Task.Run(() =>
                {
                    try
                    {
                        if (_metricsRegistry.CurrentStatusMetricsCollection)
                        {
                            foreach (var webSocketsPoolManager in _webSocketPoolManagers)
                            {
                                ((IInternalWebSocketsPoolManagerActions)webSocketsPoolManager).CalculateWebSocketsInfoSentRecieveRates();
                            }
                        }
                        SetAlarmForSocketsRateCalculation();
                    }
                    catch (Exception ex)
                    {
                        _logger.Error($"Ошибка: {ex.Message}");
                    }
                });
            };
        }

        private async Task ReportMetricsAsync(IMetrics metricsRoot)
        {
            var formatter = new MetricsJsonOutputFormatter();
            //var formatter = new MetricsTextOutputFormatter();
            var snapshot = metricsRoot.Snapshot.Get();
            await using var stream = new MemoryStream();
            await formatter.WriteAsync(stream, snapshot, _cancellationTokenSource.Token);
            stream.Seek(0, SeekOrigin.Begin);
            using var reader = new StreamReader(stream);
            var metricsData = await reader.ReadToEndAsync(_cancellationTokenSource.Token);
            _metricsLogger.Information(metricsData);
        }

        internal void WsResponseRawHandler((byte[] data, int len, DateTime timestamp, string wsName) byteMsg)
        {
            // Проверяем, что сообщение поступило по подписке ping_
            if (Utilities.Utilities.StartsWithPattern(byteMsg.data.AsSpan(0, byteMsg.len), "{\"requestGuid\":\"ping_"u8.ToArray()))
            {
                var obj = JsonSerializer.Generic.Utf8.Deserialize<WsResponseMessage>(
                    byteMsg.data.AsSpan(0, byteMsg.len)) with
                { SocketName = byteMsg.wsName };
                if (obj != null && obj.RequestGuid != null && obj.RequestGuid.StartsWith("ping"))
                {
                    if (_wsPingCache.TryRemove(obj.RequestGuid, out var ping))
                    {
                        ping.Status = obj;
                        ping.ReciveTime = byteMsg.timestamp;
                        var delay = ping.GetDelay();
                        if (delay != null)
                        {
                            _metricsRegistry.UpdateGauge("gaugeOptionWsPing", (double)delay);
                            _wsPingStatsChangedToUser?.Invoke(ping);
                            return;
                        }
                    }

                    if (_wsPingCacheUnsubscribe.TryRemove(obj.RequestGuid, out var pingUnsub))
                    {
                        pingUnsub.Status = obj;
                        pingUnsub.ReciveTime = byteMsg.timestamp;
                        var delay = pingUnsub.GetDelay();
                        if (delay != null)
                        {
                            _wsPingStatsChangedToUser?.Invoke(pingUnsub);
                            return;
                        }
                    }
                    _wsPingStatsChangedToUser?.Invoke(null);
                }
            }
        }
    }
}