using SpanJson;
using System.Runtime.Serialization;
using System.Text;

namespace Alor.OpenAPI.Models
{
    [DataContract]
    public class WsResponseCommandMessage
    {
        [DataMember(Name = "socketName", EmitDefaultValue = false)]
        public string? SocketName { get; set; }

        /// <include file='../XmlDocs/CoreModels.xml' path='Docs/Members[@name="wsCommands200Create"]/Member[@name="requestGuid"]/*' />
        [DataMember(Name = "requestGuid", EmitDefaultValue = false)]
        public string? RequestGuid { get; set; }

        /// <include file='../XmlDocs/CoreModels.xml' path='Docs/Members[@name="wsCommands200Create"]/Member[@name="httpCode"]/*' />
        [DataMember(Name = "httpCode", EmitDefaultValue = false)]
        public int? HttpCode { get; set; }

        /// <include file='../XmlDocs/CoreModels.xml' path='Docs/Members[@name="wsCommands200Create"]/Member[@name="message"]/*' />
        [DataMember(Name = "message", EmitDefaultValue = false)]
        public string? Message { get; set; }

        /// <include file='../XmlDocs/CoreModels.xml' path='Docs/Members[@name="wsCommands200Create"]/Member[@name="orderNumber"]/*' />
        [DataMember(Name = "orderNumber", EmitDefaultValue = false)]
        public string? OrderNumber { get; set; }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class WsResponseCommandMessage {").Append(Environment.NewLine);
            sb.Append("  SocketName: ").Append(SocketName).Append(Environment.NewLine);
            sb.Append("  RequestGuid: ").Append(RequestGuid).Append(Environment.NewLine);
            sb.Append("  HttpCode: ").Append(HttpCode).Append(Environment.NewLine);
            sb.Append("  Message: ").Append(Message).Append(Environment.NewLine);
            sb.Append("  OrderNumber: ").Append(OrderNumber).Append(Environment.NewLine);
            sb.Append('}').Append(Environment.NewLine);
            return sb.ToString();
        }

        public string ToJson() => Encoding.UTF8.GetString(JsonSerializer.Generic.Utf8.Serialize(this));
    }
}