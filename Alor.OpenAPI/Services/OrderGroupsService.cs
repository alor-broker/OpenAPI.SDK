using Alor.OpenAPI.Enums;
using Alor.OpenAPI.Interfaces;
using Alor.OpenAPI.Models;
using SpanJson;
using System.Text;

namespace Alor.OpenAPI.Services
{
    internal class OrderGroupsService : IOrderGroupsService
    {
        private readonly IApiHttpClientService _apiHttpClient;
        private readonly Uri _baseUrl;
        private readonly CancellationTokenSource _cancellationTokenSource;


        internal OrderGroupsService(IApiHttpClientService apiHttpClient, Uri baseUrl,
            CancellationTokenSource cancellationTokenSource)
        {
            _apiHttpClient = apiHttpClient;
            _baseUrl = baseUrl;
            _cancellationTokenSource = cancellationTokenSource;
        }

        #region OrderGroups Headers
        public Task<ICollection<ResponseOrderGroupInfo>> CommandapiApiOrderGroupsGetAsync() =>
            CommandapiApiOrderGroupsGetAsync(_cancellationTokenSource.Token);

        public Task<BodyresponseOrderGroup> CommandapiApiOrderGroupsPostAsync(ICollection<RequestOrderGroupItem> orders, ExecutionPolicy executionPolicy) =>
            CommandapiApiOrderGroupsPostAsync(orders, executionPolicy, _cancellationTokenSource.Token);

        public Task<ResponseOrderGroupInfo> CommandapiApiOrderGroupsOrderGroupIdGetAsync(string orderGroupId) =>
            CommandapiApiOrderGroupsOrderGroupIdGetAsync(orderGroupId, _cancellationTokenSource.Token);

        public Task<string> CommandapiApiOrderGroupsOrderGroupIdPutAsync(string orderGroupId, ICollection<RequestOrderGroupItem> orders, ExecutionPolicy executionPolicy) =>
            CommandapiApiOrderGroupsOrderGroupIdPutAsync(orderGroupId, orders, executionPolicy, _cancellationTokenSource.Token);

        public Task<string> CommandapiApiOrderGroupsOrderGroupIdDeleteAsync(string orderGroupId) =>
            CommandapiApiOrderGroupsOrderGroupIdDeleteAsync(orderGroupId, _cancellationTokenSource.Token);
        #endregion

        #region OrderGroups Methods
        private Task<ICollection<ResponseOrderGroupInfo>> CommandapiApiOrderGroupsGetAsync(CancellationToken cancellationToken)
        {
            var uriBuilder = new UriBuilder(_baseUrl)
                             {
                                 Path = $"{_baseUrl.AbsolutePath.TrimEnd('/')}/commandapi/api/orderGroups",
                             };

            return _apiHttpClient.ProcessRequest<ICollection<ResponseOrderGroupInfo>>(HttpMethod.Get, uriBuilder.Uri, cancellationToken, needAuthorization: true);
        }

        private Task<BodyresponseOrderGroup> CommandapiApiOrderGroupsPostAsync(ICollection<RequestOrderGroupItem> orders, ExecutionPolicy executionPolicy, CancellationToken cancellationToken)
        {
            var bodyRequestCreateOrderGroup = new RequestCreateOrderGroup(orders, executionPolicy);
            var body = Encoding.UTF8.GetString(JsonSerializer.Generic.Utf8.Serialize(bodyRequestCreateOrderGroup));
            var uriBuilder = new UriBuilder(_baseUrl)
                             {
                                 Path = $"{_baseUrl.AbsolutePath.TrimEnd('/')}/commandapi/api/orderGroups",
                             };

            return _apiHttpClient.ProcessRequest<BodyresponseOrderGroup>(HttpMethod.Post, uriBuilder.Uri, cancellationToken, body: body, needAuthorization: true);
        }

        private Task<ResponseOrderGroupInfo> CommandapiApiOrderGroupsOrderGroupIdGetAsync(string? orderGroupId, CancellationToken cancellationToken)
        {
            if (string.IsNullOrEmpty(orderGroupId))
                throw new ArgumentNullException(nameof(orderGroupId));

            var uriBuilder = new UriBuilder(_baseUrl)
                             {
                                 Path = $"{_baseUrl.AbsolutePath.TrimEnd('/')}/commandapi/api/orderGroups/{Uri.EscapeDataString(orderGroupId)}",
                             };

            return _apiHttpClient.ProcessRequest<ResponseOrderGroupInfo>(HttpMethod.Get, uriBuilder.Uri, cancellationToken, needAuthorization: true);
        }

        private Task<string> CommandapiApiOrderGroupsOrderGroupIdPutAsync(string? orderGroupId, ICollection<RequestOrderGroupItem> orders, ExecutionPolicy executionPolicy, CancellationToken cancellationToken)
        {
            if (string.IsNullOrEmpty(orderGroupId))
                throw new ArgumentNullException(nameof(orderGroupId));

            var bodyRequestCreateOrderGroup = new RequestCreateOrderGroup(orders, executionPolicy);
            var body = Encoding.UTF8.GetString(JsonSerializer.Generic.Utf8.Serialize(bodyRequestCreateOrderGroup));

            var uriBuilder = new UriBuilder(_baseUrl)
                             {
                                 Path = $"{_baseUrl.AbsolutePath.TrimEnd('/')}/commandapi/api/orderGroups/{Uri.EscapeDataString(orderGroupId)}",
                             };

            return _apiHttpClient.ProcessRequest<string>(HttpMethod.Put, uriBuilder.Uri, cancellationToken, body: body, needAuthorization: true);
        }

        private Task<string> CommandapiApiOrderGroupsOrderGroupIdDeleteAsync(string? orderGroupId, CancellationToken cancellationToken)
        {
            if (string.IsNullOrEmpty(orderGroupId))
                throw new ArgumentNullException(nameof(orderGroupId));

            var uriBuilder = new UriBuilder(_baseUrl)
                             {
                                 Path = $"{_baseUrl.AbsolutePath.TrimEnd('/')}/commandapi/api/orderGroups/{Uri.EscapeDataString(orderGroupId)}",
                             };

            return _apiHttpClient.ProcessRequest<string>(HttpMethod.Delete, uriBuilder.Uri, cancellationToken, needAuthorization: true);
        }
        #endregion
    }
}
