using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text;
using SpanJson;

namespace Alor.OpenAPI.Models
{
    [DataContract]
    public sealed class OrderActionLimitMarket : IEquatable<OrderActionLimitMarket>, IValidatableObject
    {
        public OrderActionLimitMarket() { }

        /// <include file='../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseOrderActionLimitMarketCommandAPI"]/Member[@name="responseOrderActionLimitMarketCommandAPI"]/*' />
        public OrderActionLimitMarket(string? message = default, string? orderNumber = default)
        {
            Message = message;
            OrderNumber = orderNumber;
        }

        /// <include file='../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseOrderActionLimitMarketCommandAPI"]/Member[@name="message"]/*' />
        [DataMember(Name = "message", EmitDefaultValue = false)]
        public string? Message { get; init; }

        /// <include file='../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseOrderActionLimitMarketCommandAPI"]/Member[@name="orderNumber"]/*' />
        [DataMember(Name = "orderNumber", EmitDefaultValue = false)]
        public string? OrderNumber { get; init; }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class OrderActionLimitMarket {").Append(Environment.NewLine);
            sb.Append("  Message: ").Append(Message).Append(Environment.NewLine);
            sb.Append("  OrderNumber: ").Append(OrderNumber).Append(Environment.NewLine);
            sb.Append('}').Append(Environment.NewLine);
            return sb.ToString();
        }

        public string ToJson() => Encoding.UTF8.GetString(JsonSerializer.Generic.Utf8.Serialize(this));

        public override int GetHashCode() => HashCode.Combine(Message, OrderNumber);

        private static bool EqualsHelper(OrderActionLimitMarket? first, OrderActionLimitMarket? second) =>
            first?.Message == second?.Message &&
            first?.OrderNumber == second?.OrderNumber;
        
        public bool Equals(OrderActionLimitMarket? other)
        {
            if (this == (object?)other)
                return true;

            if ((object?)other == null)
                return false;

            return GetType() == other.GetType() && EqualsHelper(this, other);
        }

        public override bool Equals(object? obj) => Equals(obj as OrderActionLimitMarket);

        private static bool Equals(OrderActionLimitMarket? first, OrderActionLimitMarket? second) =>
            first?.Equals(second) ?? first == (object?)second;

        public static bool operator ==(OrderActionLimitMarket? first, OrderActionLimitMarket? second) => Equals(first, second);

        public static bool operator !=(OrderActionLimitMarket? first, OrderActionLimitMarket? second) => !Equals(first, second);

        IEnumerable<ValidationResult> IValidatableObject.Validate(ValidationContext validationContext)
        {
            yield break;
        }
    }
}
