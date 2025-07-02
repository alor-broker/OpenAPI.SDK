using Alor.OpenAPI.DI;
using Alor.OpenAPI.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Alor.OpenAPI.Extensions;

public static class ServiceCollectionExtensions
{
    /// <summary>
    /// Регистрирует одиночный (дефолтный) клиент, доступный как <see cref="IAlorOpenApiClient"/> и <see cref="AlorOpenApiClientHolder"/>.
    /// </summary>
    public static IServiceCollection AddOpenApiClient(this IServiceCollection services, OpenApiClientOptions? options)
    {
        if (options == null) throw new ArgumentNullException(nameof(options));
        options.Validate();

        services.AddSingleton<AlorOpenApiClientHolder>();
        services.AddSingleton<IAlorOpenApiClient>(sp => sp.GetRequiredService<AlorOpenApiClientHolder>());

        services.AddHostedService(sp =>
        {
            var logger = sp.GetRequiredService<ILogger<OpenApiClientHostedInitializer<AlorOpenApiClientHolder>>>();
            var holder = sp.GetRequiredService<AlorOpenApiClientHolder>();
            return new OpenApiClientHostedInitializer<AlorOpenApiClientHolder>(options, holder, logger);
        });
        return services;
    }

    /// <summary>
    /// Регистрирует дефолтного клиента через конфиг-секцию.
    /// </summary>
    public static IServiceCollection AddOpenApiClient(this IServiceCollection services, IConfiguration configuration)
    {
        var options = configuration.Get<OpenApiClientOptions>();
        return services.AddOpenApiClient(options);
    }

    /// <summary>
    /// Регистрирует именованного клиента. Доступен как <see cref="NamedOpenApiClientHolder"/> (через коллекцию или по имени).
    /// </summary>
    public static IServiceCollection AddOpenApiClient(this IServiceCollection services, string name, OpenApiClientOptions options)
    {
        if (string.IsNullOrWhiteSpace(name)) throw new ArgumentNullException(nameof(name));
        if (options == null) throw new ArgumentNullException(nameof(options));
        options.Validate();

        var namedHolder = new NamedOpenApiClientHolder(name);
        services.AddSingleton(namedHolder);

        services.AddSingleton<IHostedService>(sp =>
        {
            var logger = sp.GetRequiredService<ILogger<OpenApiClientHostedInitializer<AlorOpenApiClientHolder>>>();
            return new OpenApiClientHostedInitializer<NamedOpenApiClientHolder>(options, namedHolder, logger, name);
        });

        if (services.All(d => d.ServiceType != typeof(IOpenApiClientProvider)))
            services.AddSingleton<IOpenApiClientProvider, OpenApiClientProvider>();

        return services;
    }

    /// <summary>
    /// Регистрирует несколько клиентов из секции конфига. Каждый доступен через <see cref="IOpenApiClientProvider"/> или коллекцию <see cref="NamedOpenApiClientHolder"/>.
    /// </summary>
    public static IServiceCollection AddOpenApiClientsFromConfiguration(
        this IServiceCollection services,
        IConfigurationSection clientsSection)
    {
        foreach (var client in clientsSection.GetChildren())
        {
            var options = client.Get<OpenApiClientOptions>() ?? throw new InvalidOperationException($"Failed to bind options for client '{client.Key}'.");
            services.AddOpenApiClient(client.Key, options);
        }
        if (services.All(d => d.ServiceType != typeof(IOpenApiClientProvider)))
            services.AddSingleton<IOpenApiClientProvider, OpenApiClientProvider>();
        return services;
    }
}
