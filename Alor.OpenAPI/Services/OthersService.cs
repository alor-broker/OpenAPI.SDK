using Alor.OpenAPI.Interfaces;

namespace Alor.OpenAPI.Services
{
    internal class OthersService : IOthersService
    {
        private readonly IApiHttpClientService _apiHttpClient;
        private readonly Uri _baseUrl;
        private readonly CancellationTokenSource _cancellationTokenSource;


        internal OthersService(IApiHttpClientService apiHttpClient, Uri baseUrl,
            CancellationTokenSource cancellationTokenSource)
        {
            _apiHttpClient = apiHttpClient;
            _baseUrl = baseUrl;
            _cancellationTokenSource = cancellationTokenSource;
        }

        public Task<long> MdV2TimeGetAsync() =>
            MdV2TimeGetAsync(_cancellationTokenSource.Token);

        private Task<long> MdV2TimeGetAsync(CancellationToken cancellationToken)
        {
            var uriBuilder = new UriBuilder(_baseUrl)
                             {
                                 Path = $"{_baseUrl.AbsolutePath.TrimEnd('/')}/md/v2/time",
                             };

            return _apiHttpClient.ProcessRequest<long>(HttpMethod.Get, uriBuilder.Uri, cancellationToken);
        }
    }
}
