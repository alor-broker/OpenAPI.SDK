using Alor.OpenAPI.Core;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Alor.OpenAPI.DI;

public sealed class OpenApiClientHostedInitializer<THolder>(
    OpenApiClientOptions options,
    THolder holder,
    ILogger logger,
    string? name = null)
    : IHostedService
    where THolder : BaseOpenApiClientHolder
{
    private readonly OpenApiClientOptions _options = options ?? throw new ArgumentNullException(nameof(options));
    private readonly THolder _holder = holder ?? throw new ArgumentNullException(nameof(holder));
    private readonly ILogger _logger = logger ?? throw new ArgumentNullException(nameof(logger));

    public async Task StartAsync(CancellationToken cancellationToken)
    {
        var prefix = name is not null ? $"({name}) " : "";
        try
        {
            _options.Validate();

            _logger.LogInformation("Initializing AlorOpenApiClient {Prefix}...", prefix);
            var config = _options.UseCustomConfig
                ? Configuration.Create(
                    _options.BaseUrl!, _options.WsUrl!, _options.CwsUrl!, _options.AuthUrl!, // checked by Validate()
                    _options.BaseUrlHeaders, _options.WsUrlHeaders, _options.CwsUrlHeaders, _options.AuthUrlHeaders)
                : _options.Contour.ToLowerInvariant() switch
                {
                    "dev" => Configuration.Dev,
                    "prod" => Configuration.Prod,
                    _ => throw new InvalidOperationException($"Unknown contour: {_options.Contour}")
                };

            var client = await AlorOpenApiClient.CreateAsync(config, _options.RefreshToken, _options.LogLevel,
                _options.IsMetricsCollectionEnabled, _options.LogFileNameSuffix, _options.WsResponseMessageHandler,
                _options.WsResponseCommandMessageHandler);
            _holder.SetClient(client);
            _logger.LogInformation("AlorOpenApiClient {Prefix}initialized successfully.", prefix);
        }
        catch (Exception ex)
        {
            _logger.LogCritical(ex, "Failed to initialize AlorOpenApiClient {Prefix}", prefix);
            throw;
        }
    }

    public Task StopAsync(CancellationToken cancellationToken) => Task.CompletedTask;
}