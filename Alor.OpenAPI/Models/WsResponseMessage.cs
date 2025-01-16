using System.Runtime.Serialization;
using System.Text;
using System.Text.Json.Serialization;
using SpanJson;

namespace Alor.OpenAPI.Models
{
    [DataContract]
    public class WsResponseMessage
    {
        [DataMember(Name = "socketName", EmitDefaultValue = false)]
        public string? SocketName { get; set; }

        /// <include file='../XmlDocs/CoreModels.xml' path='Docs/Members[@name="wsSubscription200"]/Member[@name="requestGuid"]/*' />
        [DataMember(Name = "requestGuid", EmitDefaultValue = false)]
        public string? RequestGuid { get; set; }

        /// <include file='../XmlDocs/CoreModels.xml' path='Docs/Members[@name="wsSubscription200"]/Member[@name="httpCode"]/*' />
        [DataMember(Name = "httpCode", EmitDefaultValue = false)]
        public int? HttpCode { get; set; }

        /// <include file='../XmlDocs/CoreModels.xml' path='Docs/Members[@name="wsSubscription200"]/Member[@name="message"]/*' />
        [DataMember(Name = "message", EmitDefaultValue = false)]
        public string? Message { get; set; }

        [IgnoreDataMember]
        [JsonIgnore]
        public Dictionary<string, Parameters>? Parameters { get; set; }

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
    }
}