namespace Alor.OpenAPI.Interfaces
{
    public interface IOpenApiClientProvider
    {
        IAlorOpenApiClient Get(string name);
    }
}
