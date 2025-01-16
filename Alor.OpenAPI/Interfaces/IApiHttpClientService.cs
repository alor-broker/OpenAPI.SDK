namespace Alor.OpenAPI.Interfaces
{
    internal interface IApiHttpClientService
    {
        void JwtUpdate(string? newToken);

        Task<T> ProcessRequest<T>(
            HttpMethod method,
            Uri uri,
            CancellationToken cancellationToken,
            bool needAuthorization = false,
            string? body = null,
            bool needXReqid = false);
    }
}
