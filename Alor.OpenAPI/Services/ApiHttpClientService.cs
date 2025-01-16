using Alor.OpenAPI.Core;
using Alor.OpenAPI.Interfaces;
using Alor.OpenAPI.Utilities;
using Serilog;
using SpanJson;
using System.Globalization;
using System.Net.Http.Headers;
using System.Text;

namespace Alor.OpenAPI.Services
{
    internal class ApiHttpClientService(HttpClient httpClient, ILogger logger, AlorOpenApiLogLevel logLevel) : IApiHttpClientService
    {
        private string? _jwtToken;

        public void JwtUpdate(string? newToken)
        {
            _jwtToken = newToken;
        }

        public async Task<T> ProcessRequest<T>(HttpMethod method, Uri uri, CancellationToken cancellationToken,
            bool needAuthorization = false, string? body = null, bool needXReqid = false)
        {
            using var request = new HttpRequestMessage();
            request.Method = method;
            request.Headers.Accept.Add(
                MediaTypeWithQualityHeaderValue.Parse("application/json"));
            if (method == HttpMethod.Post && !string.IsNullOrEmpty(body))
            {
                if (needXReqid)
                {
                    var xReqid = Guid.NewGuid();
                    request.Headers.TryAddWithoutValidation("X-REQID",
                        Utilities.Utilities.ConvertToString(xReqid, CultureInfo.InvariantCulture));
                }

                var content = new StringContent(body);
                request.Content = content;
                content.Headers.ContentType = MediaTypeHeaderValue.Parse("application/json");
            }

            if (needAuthorization)
            {
                if (string.IsNullOrEmpty(_jwtToken))
                    throw new ArgumentNullException(nameof(_jwtToken));
                PrepareRequest(request);
            }
            else
            {
                PrepareRequest(request);
                if (string.IsNullOrEmpty(_jwtToken))
                    logger.Information($"Запрос {method} {uri} выполнен без авторизации.");
            }

            request.RequestUri = uri;

            using var response = await httpClient
                .SendAsync(request, HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);

            if (logLevel == AlorOpenApiLogLevel.Verbose)
            {
                logger.Verbose($"Request: {request}");
                logger.Verbose($"Response: {response}");
            }

            var headers =
                response.Headers.ToDictionary(h => h.Key, h => h.Value);
            if (response.Content is { Headers: not null })
            {
                foreach (var item in response.Content.Headers)
                    headers[item.Key] = item.Value;
            }

            //var res = await response.Content.ReadAsStringAsync(cancellationToken).ConfigureAwait(false);
            if (response.IsSuccessStatusCode)
            {
                var objectResponse =
                    await ReadObjectResponseAsync<T>(
                        response, headers, cancellationToken).ConfigureAwait(false);
                if (objectResponse.Object == null)
                {
                    throw new ApiException(logger, "Response was null which was not expected.",
                        (int)response.StatusCode,
                        objectResponse.Text, headers, null);
                }

                return objectResponse.Object;
            }

            var responseData = await response.Content.ReadAsStringAsync(cancellationToken).ConfigureAwait(false);
            throw new ApiException(logger,
                "The HTTP status code of the response was not expected (" + (int?)response?.StatusCode + ").",
                Convert.ToInt32(response?.StatusCode),
                responseData, headers, null);
        }

        private void PrepareRequest(HttpRequestMessage request)
        {
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", _jwtToken);
        }

        private readonly struct ObjectResponseResult<T>(T responseObject, string responseText)
        {
            public T Object { get; } = responseObject;

            public string Text { get; } = responseText;
        }

        private bool ReadResponseAsString { get; set; }

        private async Task<ObjectResponseResult<T?>> ReadObjectResponseAsync<T>(
            HttpResponseMessage? response, IReadOnlyDictionary<string, IEnumerable<string>>
                headers, CancellationToken cancellationToken)
        {
            if (response?.Content == null)
            {
                return new ObjectResponseResult<T?>(default, string.Empty);
            }

            if (ReadResponseAsString)
            {
                var responseText = await response.Content.ReadAsByteArrayAsync(cancellationToken).ConfigureAwait(false);
                try
                {
                    var typedBody = JsonSerializer.Generic.Utf8.Deserialize<T>(responseText);
                    var contentText = Encoding.UTF8.GetString(responseText);
                    logger.Verbose($"ResponseContent: {contentText}");
                    return new ObjectResponseResult<T?>(typedBody, contentText);
                }
                catch (Exception exception)
                {
                    var message = "Could not deserialize the response body string as " + typeof(T).FullName + ".";
                    throw new ApiException(logger, message, (int)response.StatusCode, Encoding.UTF8.GetString(responseText), headers,
                        exception);
                }
            }

            Memory<byte> responseMemory = null;

            try
            {
                responseMemory =
                    (await response.Content.ReadAsByteArrayAsync(cancellationToken).ConfigureAwait(false))
                    .AsMemory();
                var typedBody = JsonSerializer.Generic.Utf8.Deserialize<T>(responseMemory.Span);
                if (logLevel == AlorOpenApiLogLevel.Verbose)
                    logger.Verbose($"ResponseContent: {Encoding.UTF8.GetString(JsonSerializer.Generic.Utf8.Serialize(typedBody))}");
                return new ObjectResponseResult<T?>(typedBody, string.Empty);
            }
            catch (Exception exception)
            {
                var message = "Could not deserialize the response body stream as " + typeof(T).FullName + ".";
                throw new ApiException(logger, message, (int)response.StatusCode, Encoding.UTF8.GetString(responseMemory.Span), headers, exception);
            }
        }
    }
}
