﻿using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text;
using SpanJson;

namespace Alor.OpenAPI.Models.Slim
{
    [DataContract]
    public sealed class BuyingPowerByCurrencySlim : IEquatable<BuyingPowerByCurrencySlim>, IValidatableObject
    {
        public BuyingPowerByCurrencySlim() { }

        /// <include file='../../XmlDocs/CoreModels.xml'
        ///          path='Docs/Members[@name="objectBuyingPowerByCurrency"]
        ///               /Member[@name="objectBuyingPowerByCurrency"]
        ///               /param[@name="currency" or @name="buyingPower"]'/>
        public BuyingPowerByCurrencySlim(string? currency = null, decimal? buyingPower = null)
        {
            Currency = currency;
            BuyingPower = buyingPower;
        }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="objectBuyingPowerByCurrency"]/Member[@name="currency"]/*' />
        [DataMember(Name = "cr", EmitDefaultValue = false)]
        public string? Currency { get; init; }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="objectBuyingPowerByCurrency"]/Member[@name="buyingPower"]/*' />
        [DataMember(Name = "bp", EmitDefaultValue = false)]
        public decimal? BuyingPower { get; init; }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class BuyingPowerByCurrencySlim {").Append(Environment.NewLine);
            sb.Append("  Currency: ").Append(Currency).Append(Environment.NewLine);
            sb.Append("  BuyingPower: ").Append(BuyingPower).Append(Environment.NewLine);
            sb.Append('}').Append(Environment.NewLine);
            return sb.ToString();
        }

        public string ToJson() => Encoding.UTF8.GetString(JsonSerializer.Generic.Utf8.Serialize(this));

        public override int GetHashCode() => HashCode.Combine(Currency, BuyingPower);

        private static bool EqualsHelper(BuyingPowerByCurrencySlim? first, BuyingPowerByCurrencySlim? second) =>
            first?.Currency == second?.Currency &&
            first?.BuyingPower == second?.BuyingPower;

        public bool Equals(BuyingPowerByCurrencySlim? other)
        {
            if (this == (object?)other)
                return true;

            if (other is null)
                return false;

            return GetType() == other.GetType() && EqualsHelper(this, other);
        }

        public override bool Equals(object? obj) => Equals(obj as BuyingPowerByCurrencySlim);

        private static bool Equals(BuyingPowerByCurrencySlim? first, BuyingPowerByCurrencySlim? second) =>
            first?.Equals(second) ?? first == (object?)second;

        public static bool operator ==(BuyingPowerByCurrencySlim? first, BuyingPowerByCurrencySlim? second) => Equals(first, second);

        public static bool operator !=(BuyingPowerByCurrencySlim? first, BuyingPowerByCurrencySlim? second) => !Equals(first, second);

        IEnumerable<ValidationResult> IValidatableObject.Validate(ValidationContext validationContext)
        {
            yield break;
        }
    }
}
