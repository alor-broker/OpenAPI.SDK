using Alor.OpenAPI.Core;
using Alor.OpenAPI.Interfaces;
using Alor.OpenAPI.Models;

namespace Alor.OpenAPI.Extensions
{
    public static class Extractor
    {
        public static Parameters? Extract(this IWsElement element)
        {
            Parameters? result = null;
            if (element.Guid != null)
            {
                _ = element.Parameters?.TryGetValue(element.Guid, out result);
            }

            return result;
        }

        public static Parameters? Extract(this string? guid, AlorOpenApiClient api)
        {
            Parameters? result = null;
            if (!string.IsNullOrEmpty(guid))
            {
                _ = api.Parameters.TryGetValue(guid, out result);
            }

            return result;
        }

        public static DateTime GetMessageReceivedDateTimeUtc(this IWsElement element) => element.ReceivedDateTimeUtc!.Value;

    }
}
