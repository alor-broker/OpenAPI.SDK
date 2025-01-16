using Serilog;

namespace Alor.OpenAPI.Core
{
    public class ApiException : Exception
    {
        /// <include file='../XmlDocs/ApiException.xml' path='Docs/Members[@name="ApiException"]/Member[@name="ApiException"]/*' />
        public ApiException(ILogger logger, string message, int statusCode, string? response,
            IReadOnlyDictionary<string, IEnumerable<string>>
                headers, Exception? innerException) : base(message + Environment.NewLine + "Status: " + statusCode + Environment.NewLine + "Response: " +
                                                           (response == null
                                                               ? "(null)"
                                                               : response[
                                                                   ..(response.Length >= 512
                                                                       ? 512
                                                                       : response.Length)]) + Environment.NewLine, innerException)
        {
            StatusCode = statusCode;
            Response = response;
            Headers = headers;
            logger.Error("Exception: {@ApiException}", this);
        }

        /// <include file='../XmlDocs/ApiException.xml' path='Docs/Members[@name="ApiException"]/Member[@name="StatusCode"]/*' />
        public int StatusCode { get; private set; }

        /// <include file='../XmlDocs/ApiException.xml' path='Docs/Members[@name="ApiException"]/Member[@name="Response"]/*' />
        public string? Response { get; }

        /// <include file='../XmlDocs/ApiException.xml' path='Docs/Members[@name="ApiException"]/Member[@name="Headers"]/*' />
        public IReadOnlyDictionary<string, IEnumerable<string>> Headers { get; private set; }

        /// <include file='../XmlDocs/ApiException.xml' path='Docs/Members[@name="ApiException"]/Member[@name="ToString"]/*' />
        public override string ToString()
        {
            return
                $"HTTP Response: {Environment.NewLine}{Environment.NewLine}{Response}{Environment.NewLine}{Environment.NewLine}{base.ToString()}";
        }
    }
}
