namespace Alor.OpenAPI.Interfaces
{
    internal interface ITokenService : IDisposable
    {
        Task RefreshTokenAndSetRefreshTimer();
        Action<string?>? JwtUpdated { get; set; }
    }
}
