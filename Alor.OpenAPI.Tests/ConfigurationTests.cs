using Alor.OpenAPI.Core;

namespace Alor.OpenAPI.Tests
{
    public class ConfigurationTests
    {
        [Fact]
        public void ConfigurationCreate_ReturnsConfigWithCorrectValues()
        {
            // Arrange
            string baseUrl = "https://example.com";
            string wsUrl = "wss://example.com/ws";
            string cwsUrl = "wss://example.com/cws";
            string authUrl = "https://example.com/auth";

            // Act
            var config = Configuration.Create(baseUrl, wsUrl, cwsUrl, authUrl);

            // Assert
            Assert.Equal(new Uri(baseUrl), config.BaseUrl);
            Assert.Equal(new Uri(wsUrl), config.WsUrl);
            Assert.Equal(new Uri(cwsUrl), config.CwsUrl);
            Assert.Equal(new Uri(authUrl), config.AuthUrl);
        }

        [Theory]
        [InlineData(null, "wss://example.com/ws", "wss://example.com/cws", "https://example.com/auth", "baseUrl")]
        [InlineData("https://example.com", null, "wss://example.com/cws", "https://example.com/auth", "wsUrl")]
        [InlineData("https://example.com", "wss://example.com/ws", null, "https://example.com/auth", "cwsUrl")]
        [InlineData("https://example.com", "wss://example.com/ws", "wss://example.com/cws", null, "authUrl")]
        public void ConfigurationCreate_ThrowsArgumentNullExceptionForInvalidParameters(
            string baseUrl, string? wsUrl, string cwsUrl, string authUrl, string expectedParamName)
        {
            var exception = Assert.Throws<ArgumentNullException>(() => Configuration.Create(baseUrl, wsUrl, cwsUrl, authUrl));

            Assert.Equal(expectedParamName, exception.ParamName);
        }

        [Fact]
        public void ConfigurationPredefinedConfigs_HaveCorrectValues()
        {
            // Проверяем конфигурацию для разработки
            Assert.Equal(new Uri("https://apidev.alor.ru"), Configuration.Dev.BaseUrl);
            Assert.Equal(new Uri("wss://apidev.alor.ru/ws"), Configuration.Dev.WsUrl);
            Assert.Equal(new Uri("wss://apidev.alor.ru/cws"), Configuration.Dev.CwsUrl);
            Assert.Equal(new Uri("https://oauthdev.alor.ru/refresh?token="), Configuration.Dev.AuthUrl);

            // Проверяем конфигурацию для продакшена
            Assert.Equal(new Uri("https://api.alor.ru"), Configuration.Prod.BaseUrl);
            Assert.Equal(new Uri("wss://api.alor.ru/ws"), Configuration.Prod.WsUrl);
            Assert.Equal(new Uri("wss://api.alor.ru/cws"), Configuration.Prod.CwsUrl);
            Assert.Equal(new Uri("https://oauth.alor.ru/refresh?token="), Configuration.Prod.AuthUrl);
        }
    }
}