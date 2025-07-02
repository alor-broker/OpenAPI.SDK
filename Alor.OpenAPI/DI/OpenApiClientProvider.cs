using Alor.OpenAPI.Interfaces;

namespace Alor.OpenAPI.DI;

public sealed class OpenApiClientProvider(IEnumerable<NamedOpenApiClientHolder> namedClients) : IOpenApiClientProvider
{
    private readonly IEnumerable<NamedOpenApiClientHolder> _namedClients = namedClients ?? throw new ArgumentNullException(nameof(namedClients));

    public IAlorOpenApiClient Get(string name) =>
        _namedClients.FirstOrDefault(c => c.Name == name)
        ?? throw new KeyNotFoundException($"No OpenApiClient registered with name '{name}'");
}