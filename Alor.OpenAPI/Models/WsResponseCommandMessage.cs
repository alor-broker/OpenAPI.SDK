using SpanJson;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text;

namespace Alor.OpenAPI.Models
{
    [DataContract]
    public record WsResponseCommandMessage: IEquatable<WsResponseCommandMessage>, IValidatableObject
    {
        public WsResponseCommandMessage() { }

        /// <include file='../XmlDocs/CoreModels.xml' path='Docs/Members[@name="wsCommands200Create"]/Member[@name="wsCommands200Create"]/*' />
        /// <param name="socketName">Название сокета (для логов)</param>
        public WsResponseCommandMessage(string? socketName = null, string? requestGuid = null, int? httpCode = null,
            string? message = null, string? orderNumber = null)
        {
            SocketName = socketName;
            RequestGuid = requestGuid;
            HttpCode = httpCode;
            Message = message;
            OrderNumber = orderNumber;
        }

        /// <summary>Название сокета (для логов)</summary>
        [DataMember(Name = "socketName", EmitDefaultValue = false)]
        public string? SocketName { get; init; }

        /// <include file='../XmlDocs/CoreModels.xml' path='Docs/Members[@name="wsCommands200Create"]/Member[@name="requestGuid"]/*' />
        [DataMember(Name = "requestGuid", EmitDefaultValue = false)]
        public string? RequestGuid { get; init; }

        /// <include file='../XmlDocs/CoreModels.xml' path='Docs/Members[@name="wsCommands200Create"]/Member[@name="httpCode"]/*' />
        [DataMember(Name = "httpCode", EmitDefaultValue = false)]
        public int? HttpCode { get; init; }

        /// <include file='../XmlDocs/CoreModels.xml' path='Docs/Members[@name="wsCommands200Create"]/Member[@name="message"]/*' />
        [DataMember(Name = "message", EmitDefaultValue = false)]
        public string? Message { get; init; }

        /// <include file='../XmlDocs/CoreModels.xml' path='Docs/Members[@name="wsCommands200Create"]/Member[@name="orderNumber"]/*' />
        [DataMember(Name = "orderNumber", EmitDefaultValue = false)]
        public string? OrderNumber { get; init; }

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

        IEnumerable<ValidationResult> IValidatableObject.Validate(ValidationContext validationContext)
        {
            yield break;
        }
    }
}