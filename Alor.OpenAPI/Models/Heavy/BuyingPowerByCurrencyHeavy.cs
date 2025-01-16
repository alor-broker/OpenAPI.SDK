using SpanJson;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text;

namespace Alor.OpenAPI.Models.Heavy
{
    [DataContract]
    public sealed class BuyingPowerByCurrencyHeavy : IEquatable<BuyingPowerByCurrencyHeavy>, IValidatableObject
    {
        public BuyingPowerByCurrencyHeavy() { }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="objectBuyingPowerByCurrency"]/Member[@name="objectBuyingPowerByCurrency"]/*' />
        public BuyingPowerByCurrencyHeavy(string? currency = default, decimal? buyingPower = default)
        {
            Currency = currency;
            BuyingPower = buyingPower;
        }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="objectBuyingPowerByCurrency"]/Member[@name="currency"]/*' />
        [DataMember(Name = "currency", EmitDefaultValue = false)]
        public string? Currency { get; private set; }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="objectBuyingPowerByCurrency"]/Member[@name="buyingPower"]/*' />
        [DataMember(Name = "buyingPower", EmitDefaultValue = false)]
        public decimal? BuyingPower { get; private set; }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class BuyingPowerByCurrencyHeavy {").Append(Environment.NewLine);
            sb.Append("  Currency: ").Append(Currency).Append(Environment.NewLine);
            sb.Append("  BuyingPower: ").Append(BuyingPower).Append(Environment.NewLine);
            sb.Append('}').Append(Environment.NewLine);
            return sb.ToString();
        }

        public string ToJson() => Encoding.UTF8.GetString(JsonSerializer.Generic.Utf8.Serialize(this));

        public override int GetHashCode() => Utilities.Utilities.GetHashCodeHelper(
            [
                Currency?.GetHashCode() ?? 0,
                BuyingPower?.GetHashCode() ?? 0,
            ]
        );

        private static bool EqualsHelper(BuyingPowerByCurrencyHeavy? first, BuyingPowerByCurrencyHeavy? second) =>
            first?.Currency == second?.Currency &&
            first?.BuyingPower == second?.BuyingPower;


        public bool Equals(BuyingPowerByCurrencyHeavy? other)
        {
            if (this == (object?)other)
                return true;

            if ((object?)other == null)
                return false;

            if (GetType() != other.GetType())
                return false;

            return EqualsHelper(this, other);
        }

        public override bool Equals(object? obj) => Equals(obj as BuyingPowerByCurrencyHeavy);

        private static bool Equals(BuyingPowerByCurrencyHeavy? first, BuyingPowerByCurrencyHeavy? second) =>
            first?.Equals(second) ?? first == (object?)second;

        public static bool operator ==(BuyingPowerByCurrencyHeavy? first, BuyingPowerByCurrencyHeavy? second) => Equals(first, second);

        public static bool operator !=(BuyingPowerByCurrencyHeavy? first, BuyingPowerByCurrencyHeavy? second) => !Equals(first, second);

        IEnumerable<ValidationResult> IValidatableObject.Validate(ValidationContext validationContext)
        {
            yield break;
        }
    }
}
