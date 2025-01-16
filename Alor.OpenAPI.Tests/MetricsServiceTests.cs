using Alor.OpenAPI.Interfaces;
using Alor.OpenAPI.Services;
using Alor.OpenAPI.Utilities;
using Alor.OpenAPI.Websocket;
using App.Metrics;
using App.Metrics.Gauge;
using Moq;
using Serilog;
using System.Collections.Concurrent;
using System.Reflection;
using Timer = System.Timers.Timer;

namespace Alor.OpenAPI.Tests
{
    public class MetricsServiceTests
    {
        [Fact]
        public void Dispose_DisposesAllResourcesCorrectly()
        {
            // Arrange
            var loggerMock = new Mock<ILogger>();
            var cancellationTokenSource = new CancellationTokenSource();
            var webSocketPoolManagers = new List<IWebSocketsPoolManager>();
            var metricsService = new MetricsService(loggerMock.Object, new Uri("https://example.com"), webSocketPoolManagers, true, cancellationTokenSource);

            // Act
            metricsService.Dispose();

            // Assert
            // Проверяем, что после вызова Dispose внутренний таймер был остановлен и свойство _enabled установлено в false
            var clockField = typeof(MetricsService).GetField("_clockSocketsRate", BindingFlags.NonPublic | BindingFlags.Instance);
            var clock = (AlarmClock?)clockField?.GetValue(metricsService);
            var enabledField = typeof(AlarmClock).GetField("_enabled", BindingFlags.NonPublic | BindingFlags.Instance);
            var timerEnabled = (bool?)enabledField?.GetValue(clock);
            Assert.False(timerEnabled, "Timer should be disabled after dispose.");

            // Убедимся, что AlarmClock больше не активен
            var timerField = typeof(AlarmClock).GetField("_timer", BindingFlags.NonPublic | BindingFlags.Instance);
            var timer = (Timer?)timerField?.GetValue(clock);
            Assert.Throws<ObjectDisposedException>(() => { timer?.Start(); });

        }

        [Fact]
        public void SetupMetrics_InitializesMetricsCorrectly()
        {
            // Arrange
            var loggerMock = new Mock<ILogger>();
            var metricsRegistryMock = new Mock<IMetricsRegistry>();
            var cancellationTokenSource = new CancellationTokenSource();
            var webSocketPoolManagers = new List<IWebSocketsPoolManager>();

            // Настройка мока metricsRegistry
            metricsRegistryMock.Setup(x => x.MetricsOptions).Returns(new ConcurrentDictionary<string, object>());

            // Создание экземпляра MetricsService
            var service = new MetricsService(loggerMock.Object, new Uri("https://example.com"), webSocketPoolManagers, true, cancellationTokenSource);

            // Внедрение мока IMetricsRegistry через рефлексию
            var metricsRegistryField = typeof(MetricsService).GetField("_metricsRegistry", BindingFlags.NonPublic | BindingFlags.Instance);
            metricsRegistryField?.SetValue(service, metricsRegistryMock.Object);

            // Act
            // Имитация вызова приватного метода SetupMetrics
            var setupMetricsMethod = typeof(MetricsService).GetMethod("SetupMetrics", BindingFlags.NonPublic | BindingFlags.Instance);
            setupMetricsMethod?.Invoke(service, null);

            // Assert
            // Проверяем, что метрики были добавлены
            Assert.True(metricsRegistryMock.Object.MetricsOptions.ContainsKey("gaugeOptionPing"), "Ping gauge should be registered.");
            Assert.True(metricsRegistryMock.Object.MetricsOptions.ContainsKey("gaugeOptionActiveConnects"), "Active connects gauge should be registered.");
        }

        [Fact]
        public void EnableMetricsCollection_SetsCollectionEnabledTrue()
        {
            // Arrange
            var metricsMock = new Mock<IMetrics>();
            var metricsRegistry = new MetricsRegistry(metricsMock.Object, false);

            // Act
            metricsRegistry.EnableMetricsCollection();

            // Assert
            Assert.True(metricsRegistry.CurrentStatusMetricsCollection, "Metrics collection should be enabled.");
        }

        [Fact]
        public void DisableMetricsCollection_SetsCollectionEnabledFalse()
        {
            // Arrange
            var metricsMock = new Mock<IMetrics>();
            var metricsRegistry = new MetricsRegistry(metricsMock.Object, true);

            // Act
            metricsRegistry.DisableMetricsCollection();

            // Assert
            Assert.False(metricsRegistry.CurrentStatusMetricsCollection, "Metrics collection should be disabled.");
        }

        [Fact]
        public void UpdateSocketsCounterMetric_UpdatesGaugeWhenMetricsCollectionEnabled()
        {
            // Arrange
            var metricsMock = new Mock<IMetrics>();
            var gaugeMock = new Mock<IMeasureGaugeMetrics>();

            metricsMock.Setup(x => x.Measure.Gauge).Returns(gaugeMock.Object);

            var metricsRegistry = new MetricsRegistry(metricsMock.Object, true);
            metricsRegistry.MetricsOptions.TryAdd("gaugeOptionActiveConnects", new GaugeOptions { Name = "Active websockets connects count" });

            // Act
            metricsRegistry.EnableMetricsCollection();
            metricsRegistry.UpdateGauge("gaugeOptionActiveConnects", 5);

            // Assert
            gaugeMock.Verify(x => x.SetValue(It.IsAny<GaugeOptions>(), 5), Times.Once());
        }

        [Fact]
        public void UpdateSocketsCounterMetric_DoesNotUpdateGaugeWhenMetricsCollectionDisabled()
        {
            // Arrange
            var metricsMock = new Mock<IMetrics>();
            var gaugeMock = new Mock<IMeasureGaugeMetrics>();

            metricsMock.Setup(x => x.Measure.Gauge).Returns(gaugeMock.Object);

            var metricsRegistry = new MetricsRegistry(metricsMock.Object, false);
            metricsRegistry.MetricsOptions.TryAdd("gaugeOptionActiveConnects", new GaugeOptions { Name = "Active websockets connects count" });

            // Act
            metricsRegistry.DisableMetricsCollection();
            metricsRegistry.UpdateGauge("gaugeOptionActiveConnects", 5);

            // Assert
            gaugeMock.Verify(x => x.SetValue(It.IsAny<GaugeOptions>(), 5), Times.Never());
        }

        [Fact]
        public async Task ReportMetricsAsync_CorrectlyFormatsAndLogsMetrics()
        {
            // Arrange
            var loggerMock = new Mock<ILogger>();
            var metricsRootMock = new Mock<IMetricsRoot>();
            var metricsDataValueSource = new MetricsDataValueSource(DateTime.UtcNow, new List<MetricsContextValueSource>());

            metricsRootMock.Setup(m => m.Snapshot.Get()).Returns(metricsDataValueSource);

            var cancellationTokenSource = new CancellationTokenSource();

            var metricsService = new MetricsService(loggerMock.Object, new Uri("https://example.com"),
                [], false, cancellationTokenSource);

            // Инжекция зависимости IMetricsRoot в приватное поле _metrics через рефлексию
            var metricsFieldInfo = typeof(MetricsService).GetField("_metrics", BindingFlags.NonPublic | BindingFlags.Instance);
            metricsFieldInfo?.SetValue(metricsService, metricsRootMock.Object);

            // Инжекция мока ILogger в приватное поле _metricsLogger через рефлексию
            var metricsLoggerFieldInfo = typeof(MetricsService).GetField("_metricsLogger", BindingFlags.NonPublic | BindingFlags.Instance);
            metricsLoggerFieldInfo?.SetValue(metricsService, loggerMock.Object);

            // Получение приватного метода ReportMetricsAsync и вызов через рефлексию
            var reportMetricsMethod = typeof(MetricsService).GetMethod("ReportMetricsAsync", BindingFlags.NonPublic | BindingFlags.Instance);
            var task = (Task?)reportMetricsMethod?.Invoke(metricsService, [metricsRootMock.Object]);

            if (task != null)
            {
                await task;
            }

            // Assert
            // Проверяем, что информация о метриках была залогирована
            loggerMock.Verify(l => l.Information(It.IsAny<string>()), Times.Once());
        }

        [Fact]
        public async Task UpdateAndReportMetrics_PerformsCorrectMetricsUpdates()
        {
            // Arrange
            var loggerMock = new Mock<ILogger>();
            var webSocketPoolManagers = new List<IWebSocketsPoolManager>();
            var cancellationTokenSource = new CancellationTokenSource();

            var metricsService = new MetricsService(loggerMock.Object, new Uri("https://example.com"), webSocketPoolManagers, true, cancellationTokenSource);

            var webSocketsPoolManagerMock = new Mock<IWebSocketsPoolManager>();
            webSocketsPoolManagerMock.As<IInternalWebSocketsPoolManagerActions>()
                .Setup(m => m.GetWebSocketsInfoDetail())
                .Returns(new List<WebSocketInfoDetails>());

            webSocketPoolManagers.Add(webSocketsPoolManagerMock.Object);

            var fieldInfo = typeof(MetricsService).GetField("_webSocketPoolManagers", BindingFlags.NonPublic | BindingFlags.Instance);
            fieldInfo?.SetValue(metricsService, webSocketPoolManagers);

            var reportMetricsMethod = typeof(MetricsService).GetMethod("UpdateAndReportMetrics", BindingFlags.NonPublic | BindingFlags.Instance);

            // Act
            _ = (Task?)reportMetricsMethod?.Invoke(metricsService, null);

            // Даем время для инициализации и выполнения асинхронных операций
            await Task.Delay(500, CancellationToken.None);
            await cancellationTokenSource.CancelAsync();

            // Assert
            webSocketsPoolManagerMock.As<IInternalWebSocketsPoolManagerActions>().Verify(m => m.GetWebSocketsInfoDetail(), Times.AtLeastOnce());
        }



    }
}
