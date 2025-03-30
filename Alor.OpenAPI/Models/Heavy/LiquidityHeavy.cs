using SpanJson;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text;

namespace Alor.OpenAPI.Models.Heavy
{
    [DataContract]
    public sealed class LiquidityHeavy : IEquatable<LiquidityHeavy>, IValidatableObject
    {
        public LiquidityHeavy() { }

        [JsonConstructor]
        public LiquidityHeavy(decimal price, long volume)
        {
            Price = price;
            Volume = volume;
        }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseOrderBookBid"]/Member[@name="price"]/*' />
        [DataMember(Name = "price", EmitDefaultValue = false)]
        public decimal Price { get; init; }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseOrderBookBid"]/Member[@name="volume"]/*' />
        [DataMember(Name = "volume", EmitDefaultValue = false)]
        public long Volume { get; init; }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class LiquidityHeavy {").Append(Environment.NewLine);
            sb.Append("  Price: ").Append(Price).Append(Environment.NewLine);
            sb.Append("  Volume: ").Append(Volume).Append(Environment.NewLine);
            sb.Append('}').Append(Environment.NewLine);
            return sb.ToString();
        }

        public string ToJson() => Encoding.UTF8.GetString(JsonSerializer.Generic.Utf8.Serialize(this));

        public override int GetHashCode() => HashCode.Combine(Price, Volume);

        private static bool EqualsHelper(LiquidityHeavy? first, LiquidityHeavy? second) =>
            first?.Price == second?.Price &&
            first?.Volume == second?.Volume;

        public bool Equals(LiquidityHeavy? other)
        {
            if (this == (object?)other)
                return true;

            if ((object?)other == null)
                return false;

            return GetType() == other.GetType() && EqualsHelper(this, other);
        }

        public override bool Equals(object? obj) => Equals(obj as LiquidityHeavy);

        private static bool Equals(LiquidityHeavy? first, LiquidityHeavy? second) =>
            first?.Equals(second) ?? first == (object?)second;

        public static bool operator ==(LiquidityHeavy? first, LiquidityHeavy? second) => Equals(first, second);

        public static bool operator !=(LiquidityHeavy? first, LiquidityHeavy? second) => !Equals(first, second);

        IEnumerable<ValidationResult> IValidatableObject.Validate(ValidationContext validationContext)
        {
            yield break;
        }
    }
}
