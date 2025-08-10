using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json.Serialization;
using SpanJson;

namespace Alor.OpenAPI.Models
{
    [DataContract]
    public record WsResponseMessage: IEquatable<WsResponseMessage>, IValidatableObject
    {
        public WsResponseMessage() { }
        public WsResponseMessage(string? socketName = null, string? requestGuid = null, int? httpCode = null,
            string? message = null)
        {
            SocketName = socketName;
            RequestGuid = requestGuid;
            HttpCode = httpCode;
            Message = message;
        }

        [DataMember(Name = "socketName", EmitDefaultValue = false)]
        public string? SocketName { get; init; }

        /// <include file='../XmlDocs/CoreModels.xml' path='Docs/Members[@name="wsSubscription200"]/Member[@name="requestGuid"]/*' />
        [DataMember(Name = "requestGuid", EmitDefaultValue = false)]
        public string? RequestGuid { get; init; }

        /// <include file='../XmlDocs/CoreModels.xml' path='Docs/Members[@name="wsSubscription200"]/Member[@name="httpCode"]/*' />
        [DataMember(Name = "httpCode", EmitDefaultValue = false)]
        public int? HttpCode { get; init; }

        /// <include file='../XmlDocs/CoreModels.xml' path='Docs/Members[@name="wsSubscription200"]/Member[@name="message"]/*' />
        [DataMember(Name = "message", EmitDefaultValue = false)]
        public string? Message { get; init; }

        [IgnoreDataMember]
        [JsonIgnore]
        public Dictionary<string, Parameters>? Parameters { get; init; }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class WsResponseMessage {").Append(Environment.NewLine);
            sb.Append("  SocketName: ").Append(SocketName).Append(Environment.NewLine);
            sb.Append("  RequestGuid: ").Append(RequestGuid).Append(Environment.NewLine);
            sb.Append("  HttpCode: ").Append(HttpCode).Append(Environment.NewLine);
            sb.Append("  Message: ").Append(Message).Append(Environment.NewLine);
            sb.Append('}').Append(Environment.NewLine);
            return sb.ToString();
        }

        public string ToJson() => Encoding.UTF8.GetString(JsonSerializer.Generic.Utf8.Serialize(this));

        IEnumerable<ValidationResult> IValidatableObject.Validate(ValidationContext validationContext)
        {
            yield break;
        }
    }
}