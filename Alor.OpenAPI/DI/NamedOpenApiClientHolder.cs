namespace Alor.OpenAPI.DI;

public sealed class NamedOpenApiClientHolder(string name) : BaseOpenApiClientHolder
{
    public string Name { get; } = name;
}