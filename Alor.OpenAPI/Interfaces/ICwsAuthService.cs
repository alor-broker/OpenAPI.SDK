namespace Alor.OpenAPI.Interfaces
{
    internal interface ICwsAuthService : IDisposable
    {
        Task CwsAuthorizeAndSetRefreshTimer();
    }
}
