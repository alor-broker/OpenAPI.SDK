using Alor.OpenAPI.Models;
using Alor.OpenAPI.Utilities;

namespace Alor.OpenAPI.DI;

public sealed class OpenApiClientOptions
{
    public string? RefreshToken { get; init; } = null;
    public AlorOpenApiLogLevel LogLevel { get; init; } = AlorOpenApiLogLevel.Error;
    public string Contour { get; init; } = "Dev";
    public bool UseCustomConfig { get; init; }

    public string? BaseUrl { get; init; }
    public string? WsUrl { get; init; }
    public string? CwsUrl { get; init; }
    public string? AuthUrl { get; init; }

    public Dictionary<string, string>? BaseUrlHeaders { get; init; }
    public Dictionary<string, string>? WsUrlHeaders { get; init; }
    public Dictionary<string, string>? CwsUrlHeaders { get; init; }
    public Dictionary<string, string>? AuthUrlHeaders { get; init; }

    public bool IsMetricsCollectionEnabled { get; init; }
    public string? LogFileNameSuffix { get; init; }

    /// <summary>
    /// Делегат задается только вручную в коде, при конфигурировании из JSON будет null!
    /// </summary>
    public Action<WsResponseMessage>? WsResponseMessageHandler { get; init; } = null;
    
    /// <summary>
    /// Делегат задается только вручную в коде, при конфигурировании из JSON будет null!
    /// </summary>
    public Action<WsResponseCommandMessage>? WsResponseCommandMessageHandler { get; init; } = null;

    public void Validate()
    {
        if (UseCustomConfig)
        {
            if (string.IsNullOrEmpty(BaseUrl)) throw new InvalidOperationException("OpenApiClientOptions: BaseUrl is required for custom config.");
            if (string.IsNullOrEmpty(WsUrl)) throw new InvalidOperationException("OpenApiClientOptions: WsUrl is required for custom config.");
            if (string.IsNullOrEmpty(CwsUrl)) throw new InvalidOperationException("OpenApiClientOptions: CwsUrl is required for custom config.");
            if (string.IsNullOrEmpty(AuthUrl)) throw new InvalidOperationException("OpenApiClientOptions: AuthUrl is required for custom config.");
        }
        else
        {
            if (string.IsNullOrEmpty(Contour) || (Contour.ToLowerInvariant() != "prod" && Contour.ToLowerInvariant() != "dev"))
                throw new InvalidOperationException("OpenApiClientOptions: Contour must be 'Prod' or 'Dev'.");
        }
    }
}