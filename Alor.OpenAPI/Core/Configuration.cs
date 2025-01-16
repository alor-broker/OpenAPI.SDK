namespace Alor.OpenAPI.Core
{
    public abstract class Configuration
    {
        public static readonly Config Dev = new("https://apidev.alor.ru", "wss://apidev.alor.ru/ws", "wss://apidev.alor.ru/cws", "https://oauthdev.alor.ru/refresh?token=");
        public static readonly Config Prod = new("https://api.alor.ru", "wss://api.alor.ru/ws", "wss://api.alor.ru/cws", "https://oauth.alor.ru/refresh?token=");

        /// <include file='../XmlDocs/Configuration.xml' path='Docs/Members[@name="Configuration"]/Member[@name="Create"]/*' />
        public static Config Create(string baseUrl, string wsUrl, string cwsUrl, string authUrl,
            Dictionary<string, string>? baseUrlHeaders = null, Dictionary<string, string>? wsUrlHeaders = null,
            Dictionary<string, string>? cwsUrlHeaders = null, Dictionary<string, string>? authUrlHeaders = null)
        {
            if (string.IsNullOrEmpty(baseUrl)) throw new ArgumentNullException(nameof(baseUrl));
            if (string.IsNullOrEmpty(wsUrl)) throw new ArgumentNullException(nameof(wsUrl));
            if (string.IsNullOrEmpty(cwsUrl)) throw new ArgumentNullException(nameof(cwsUrl));
            if (string.IsNullOrEmpty(authUrl)) throw new ArgumentNullException(nameof(authUrl));

            return new Config(baseUrl, wsUrl, cwsUrl, authUrl, baseUrlHeaders, wsUrlHeaders, cwsUrlHeaders, authUrlHeaders);
        }

        /// <include file='../XmlDocs/Configuration.xml' path='Docs/Members[@name="Configuration"]/Member[@name="Config"]/*' />
        public class Config
        {
            internal readonly Uri BaseUrl;
            internal readonly Uri WsUrl;
            internal readonly Uri CwsUrl;
            internal readonly Uri AuthUrl;
            internal readonly Dictionary<string, string>? BaseUrlHeaders;
            internal readonly Dictionary<string, string>? WsUrlHeaders;
            internal readonly Dictionary<string, string>? CwsUrlHeaders;
            internal readonly Dictionary<string, string>? AuthUrlHeaders;

            internal Config(string? baseUrl, string? wsUrl, string? cwsUrl, string? authUrl,
                    Dictionary<string, string>? baseUrlHeaders = null, Dictionary<string, string>? wsUrlHeaders = null,
                    Dictionary<string, string>? cwsUrlHeaders = null, Dictionary<string, string>? authUrlHeaders = null)
            {
                BaseUrl = string.IsNullOrEmpty(baseUrl) ? throw new ArgumentNullException(nameof(baseUrl)) : new Uri(baseUrl);
                WsUrl = string.IsNullOrEmpty(wsUrl) ? throw new ArgumentNullException(nameof(wsUrl)) : new Uri(wsUrl);
                CwsUrl = string.IsNullOrEmpty(cwsUrl) ? throw new ArgumentNullException(nameof(cwsUrl)) : new Uri(cwsUrl);
                AuthUrl = string.IsNullOrEmpty(authUrl) ? throw new ArgumentNullException(nameof(authUrl)) : new Uri(authUrl);
                BaseUrlHeaders = baseUrlHeaders;
                WsUrlHeaders = wsUrlHeaders;
                CwsUrlHeaders = cwsUrlHeaders;
                AuthUrlHeaders = authUrlHeaders;
            }
        }
    }
}
