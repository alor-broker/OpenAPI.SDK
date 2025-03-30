using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text;
using SpanJson;

namespace Alor.OpenAPI.Models.Simple
{
    [DataContract]
    public sealed class BuyingPowerByCurrencySimple : IEquatable<BuyingPowerByCurrencySimple>, IValidatableObject
    {
        public BuyingPowerByCurrencySimple() { }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="objectBuyingPowerByCurrency"]/Member[@name="objectBuyingPowerByCurrency"]/*' />
        [JsonConstructor]
        public BuyingPowerByCurrencySimple(string? currency = default, decimal? buyingPower = default)
        {
            Currency = currency;
            BuyingPower = buyingPower;
        }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="objectBuyingPowerByCurrency"]/Member[@name="currency"]/*' />
        [DataMember(Name = "currency", EmitDefaultValue = false)]
        public string? Currency { get; init; }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="objectBuyingPowerByCurrency"]/Member[@name="buyingPower"]/*' />
        [DataMember(Name = "buyingPower", EmitDefaultValue = false)]
        public decimal? BuyingPower { get; init; }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class BuyingPowerByCurrencySimple {").Append(Environment.NewLine);
            sb.Append("  Currency: ").Append(Currency).Append(Environment.NewLine);
            sb.Append("  BuyingPower: ").Append(BuyingPower).Append(Environment.NewLine);
            sb.Append('}').Append(Environment.NewLine);
            return sb.ToString();
        }

        public string ToJson() => Encoding.UTF8.GetString(JsonSerializer.Generic.Utf8.Serialize(this));

        public override int GetHashCode() => HashCode.Combine(Currency, BuyingPower);

        private static bool EqualsHelper(BuyingPowerByCurrencySimple? first, BuyingPowerByCurrencySimple? second) =>
            first?.Currency == second?.Currency &&
            first?.BuyingPower == second?.BuyingPower;

        public bool Equals(BuyingPowerByCurrencySimple? other)
        {
            if (this == (object?)other)
                return true;

            if ((object?)other == null)
                return false;

            return GetType() == other.GetType() && EqualsHelper(this, other);
        }

        public override bool Equals(object? obj) => Equals(obj as BuyingPowerByCurrencySimple);

        private static bool Equals(BuyingPowerByCurrencySimple? first, BuyingPowerByCurrencySimple? second) =>
            first?.Equals(second) ?? first == (object?)second;

        public static bool operator ==(BuyingPowerByCurrencySimple? first, BuyingPowerByCurrencySimple? second) => Equals(first, second);

        public static bool operator !=(BuyingPowerByCurrencySimple? first, BuyingPowerByCurrencySimple? second) => !Equals(first, second);

        IEnumerable<ValidationResult> IValidatableObject.Validate(ValidationContext validationContext)
        {
            yield break;
        }
    }
}
