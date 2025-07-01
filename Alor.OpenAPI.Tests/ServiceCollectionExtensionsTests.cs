using Alor.OpenAPI.DI;
using Alor.OpenAPI.Extensions;
using Alor.OpenAPI.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Alor.OpenAPI.Tests;

public class ServiceCollectionExtensionsTests
{
    [Fact]
    public void Registers_Single_Client()
    {
        var services = new ServiceCollection();
        var options = new OpenApiClientOptions { RefreshToken = "token", Contour = "Prod" };

        services.AddOpenApiClient(options);

        var provider = services.BuildServiceProvider();
        var client = provider.GetRequiredService<IAlorOpenApiClient>();
        Assert.NotNull(client);
    }

    [Fact]
    public void Registers_Multiple_Named_Clients_And_Provider()
    {
        var services = new ServiceCollection();
        services.AddOpenApiClient("A", new OpenApiClientOptions { RefreshToken = "a", Contour = "Dev" });
        services.AddOpenApiClient("B", new OpenApiClientOptions { RefreshToken = "b", Contour = "Prod" });

        var provider = services.BuildServiceProvider();

        var named = provider.GetServices<NamedOpenApiClientHolder>();
        Assert.Equal(2, named.Count());

        var all = provider.GetServices<IAlorOpenApiClient>();
        Assert.Empty(all);

        var registry = provider.GetService<IOpenApiClientProvider>();
        Assert.NotNull(registry);
        var a = registry.Get("A");
        var b = registry.Get("B");
        Assert.NotNull(a);
        Assert.NotNull(b);
    }

}