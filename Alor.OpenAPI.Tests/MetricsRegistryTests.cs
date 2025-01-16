using Alor.OpenAPI.Services;
using App.Metrics;
using App.Metrics.Counter;
using App.Metrics.Gauge;
using App.Metrics.Meter;
using App.Metrics.Timer;
using Moq;

namespace Alor.OpenAPI.Tests
{
    public class MetricsRegistryTests
    {
        [Fact]
        public void EnableMetricsCollection_ShouldEnableMetricsCollection()
        {
            // Arrange
            var metricsMock = new Mock<IMetrics>();
            var registry = new MetricsRegistry(metricsMock.Object, false);

            // Act
            registry.EnableMetricsCollection();

            // Assert
            Assert.True(registry.CurrentStatusMetricsCollection);
        }

        [Fact]
        public void UpdateGauge_ShouldNotUpdateWhenDisabled()
        {
            // Arrange
            var metricsMock = new Mock<IMetrics>();
            var registry = new MetricsRegistry(metricsMock.Object, false);
            var gaugeOptions = new GaugeOptions();
            registry.MetricsOptions.TryAdd("testGauge", gaugeOptions);
            
            // Act
            registry.UpdateGauge("testGauge", 10.0);

            // Assert
            metricsMock.Verify(x => x.Measure.Gauge.SetValue(It.IsAny<GaugeOptions>(), It.IsAny<double>()), Times.Never());
        }

        [Fact]
        public void UpdateGauge_UpdatesWhenEnabled()
        {
            // Arrange
            var metricsMock = new Mock<IMetrics>();
            var measureMock = new Mock<IMeasureMetrics>();
            var gaugeMock = new Mock<IMeasureGaugeMetrics>();

            metricsMock.Setup(x => x.Measure).Returns(measureMock.Object);
            measureMock.Setup(x => x.Gauge).Returns(gaugeMock.Object);

            var registry = new MetricsRegistry(metricsMock.Object, true);
            var gaugeOptions = new GaugeOptions();
            registry.MetricsOptions.TryAdd("testGauge", gaugeOptions);

            // Act
            registry.UpdateGauge("testGauge", 10.0);

            // Assert
            gaugeMock.Verify(x => x.SetValue(gaugeOptions, 10.0), Times.Once());
        }


        [Fact]
        public void UpdateCounter_UpdatesWhenEnabled()
        {
            // Arrange
            var metricsMock = new Mock<IMetrics>();
            var measureMock = new Mock<IMeasureMetrics>();
            var counterMock = new Mock<IMeasureCounterMetrics>();

            metricsMock.Setup(x => x.Measure).Returns(measureMock.Object);
            measureMock.Setup(x => x.Counter).Returns(counterMock.Object);

            var registry = new MetricsRegistry(metricsMock.Object, true);
            var counterOptions = new CounterOptions();
            registry.MetricsOptions.TryAdd("testCounter", counterOptions);

            // Act
            registry.UpdateCounter("testCounter", 5);

            // Assert
            counterMock.Verify(x => x.Increment(counterOptions, 5), Times.Once());
        }


        [Fact]
        public void MarkMeter_MarksWhenEnabled()
        {
            // Arrange
            var metricsMock = new Mock<IMetrics>();
            var measureMock = new Mock<IMeasureMetrics>();
            var meterMock = new Mock<IMeasureMeterMetrics>();

            metricsMock.Setup(x => x.Measure).Returns(measureMock.Object);
            measureMock.Setup(x => x.Meter).Returns(meterMock.Object);

            var registry = new MetricsRegistry(metricsMock.Object, true);
            var meterOptions = new MeterOptions();
            registry.MetricsOptions.TryAdd("testMeter", meterOptions);

            // Act
            registry.MarkMeter("testMeter");

            // Assert
            meterMock.Verify(x => x.Mark(meterOptions), Times.Once());
        }


        [Fact]
        public void RecordTimer_RecordsWhenEnabled()
        {
            // Arrange
            var metricsMock = new Mock<IMetrics>();
            var measureMock = new Mock<IMeasureMetrics>();
            var timerMock = new Mock<IMeasureTimerMetrics>();

            metricsMock.Setup(x => x.Measure).Returns(measureMock.Object);
            measureMock.Setup(x => x.Timer).Returns(timerMock.Object);

            var registry = new MetricsRegistry(metricsMock.Object, true);

            var timerOptions = new TimerOptions();
            registry.MetricsOptions.TryAdd("testTimer", timerOptions);

            bool operationInvoked = false;

            // Настраиваем мок timerMock для вызова переданной операции при вызове метода Time
            timerMock.Setup(x => x.Time(It.IsAny<TimerOptions>(), It.IsAny<Action>()))
                .Callback<TimerOptions, Action>((opts, action) => action());

            // Act
            registry.RecordTimer("testTimer", () => operationInvoked = true);

            // Assert
            timerMock.Verify(x => x.Time(It.IsAny<TimerOptions>(), It.IsAny<Action>()), Times.Once());
            Assert.True(operationInvoked, "The operation should be invoked.");
        }



    }
}
