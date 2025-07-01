using Alor.OpenAPI.Enums;
using SpanJson;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text;

namespace Alor.OpenAPI.Models
{
    [DataContract]
    public class RequestOrderGroupItem : IEquatable<RequestOrderGroupItem>, IValidatableObject
    {
        public RequestOrderGroupItem() { }

        /// <include file='../XmlDocs/CoreModels.xml' path='Docs/Members[@name="objectOrderGroupItem"]/Member[@name="objectOrderGroupItem"]/*' />
        public RequestOrderGroupItem(string? portfolio = default, Exchange exchange = default, string? orderId = default, OrderType type = default)
        {
            Portfolio = portfolio;
            Exchange = exchange;
            OrderId = orderId;
            Type = type;
        }

        /// <include file='../XmlDocs/CoreModels.xml' path='Docs/Members[@name="objectOrderGroupItem"]/Member[@name="portfolio"]/*' />
        [DataMember(Name = "portfolio", EmitDefaultValue = false)]
        public string? Portfolio { get; init; }

        /// <include file='../XmlDocs/CoreModels.xml' path='Docs/Members[@name="objectOrderGroupItem"]/Member[@name="exchange"]/*' />
        [DataMember(Name = "exchange", EmitDefaultValue = false)]
        public Exchange Exchange { get; init; }

        /// <include file='../XmlDocs/CoreModels.xml' path='Docs/Members[@name="objectOrderGroupItem"]/Member[@name="orderId"]/*' />
        [DataMember(Name = "orderId", EmitDefaultValue = false)]
        public string? OrderId { get; init; }

        /// <include file='../XmlDocs/CoreModels.xml' path='Docs/Members[@name="objectOrderGroupItem"]/Member[@name="type"]/*' />
        [DataMember(Name = "type", EmitDefaultValue = false)]
        public OrderType Type { get; init; }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class RequestOrderGroupItem {").Append(Environment.NewLine);
            sb.Append("  Portfolio: ").Append(Portfolio).Append(Environment.NewLine);
            sb.Append("  Exchange: ").Append(Exchange).Append(Environment.NewLine);
            sb.Append("  OrderId: ").Append(OrderId).Append(Environment.NewLine);
            sb.Append("  Type: ").Append(Type).Append(Environment.NewLine);
            sb.Append('}').Append(Environment.NewLine);
            return sb.ToString();
        }

        public string ToJson() => Encoding.UTF8.GetString(JsonSerializer.Generic.Utf8.Serialize(this));

        public override int GetHashCode() => HashCode.Combine(Portfolio, Exchange, OrderId, Type);

        private static bool EqualsHelper(RequestOrderGroupItem? first, RequestOrderGroupItem? second) =>
            first?.Portfolio == second?.Portfolio &&
            first?.Exchange == second?.Exchange &&
            first?.OrderId == second?.OrderId &&
            first?.Type == second?.Type;

        public bool Equals(RequestOrderGroupItem? other)
        {
            if (this == (object?)other)
                return true;

            if ((object?)other == null)
                return false;

            return GetType() == other.GetType() && EqualsHelper(this, other);
        }

        public override bool Equals(object? obj) => Equals(obj as RequestOrderGroupItem);

        private static bool Equals(RequestOrderGroupItem? first, RequestOrderGroupItem? second) =>
            first?.Equals(second) ?? first == (object?)second;

        public static bool operator ==(RequestOrderGroupItem? first, RequestOrderGroupItem? second) => Equals(first, second);

        public static bool operator !=(RequestOrderGroupItem? first, RequestOrderGroupItem? second) => !Equals(first, second);

        IEnumerable<ValidationResult> IValidatableObject.Validate(ValidationContext validationContext)
        {
            yield break;
        }
    }
}
