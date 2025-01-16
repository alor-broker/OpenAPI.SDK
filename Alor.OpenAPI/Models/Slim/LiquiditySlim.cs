using SpanJson;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text;

namespace Alor.OpenAPI.Models.Slim
{
    [DataContract]
    public sealed class LiquiditySlim : IEquatable<LiquiditySlim>, IValidatableObject
    {
        public LiquiditySlim() { }
        public LiquiditySlim(decimal price, int volume, decimal? yield)
        {
            Price = price;
            Volume = volume;
            Yield = yield;
        }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseOrderBookBid"]/Member[@name="price"]/*' />
        [DataMember(Name = "p", EmitDefaultValue = false)]
        public decimal Price { get; private set; }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseOrderBookBid"]/Member[@name="volume"]/*' />
        [DataMember(Name = "v", EmitDefaultValue = false)]
        public int Volume { get; private set; }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseOrderBookBid"]/Member[@name="ySlim"]/*' />
        [DataMember(Name = "v", EmitDefaultValue = false)]
        public decimal? Yield { get; private set; }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class LiquiditySlim {").Append(Environment.NewLine);
            sb.Append("  Price: ").Append(Price).Append(Environment.NewLine);
            sb.Append("  Volume: ").Append(Volume).Append(Environment.NewLine);
            sb.Append("  Yield: ").Append(Yield).Append(Environment.NewLine);
            sb.Append('}').Append(Environment.NewLine);
            return sb.ToString();
        }

        public string ToJson() => Encoding.UTF8.GetString(JsonSerializer.Generic.Utf8.Serialize(this));

        public override int GetHashCode() => Utilities.Utilities.GetHashCodeHelper(
            [
                Price.GetHashCode(),
                Volume.GetHashCode(),
                Yield?.GetHashCode() ?? 0,
            ]
        );

        private static bool EqualsHelper(LiquiditySlim? first, LiquiditySlim? second) =>
            first?.Price == second?.Price &&
            first?.Volume == second?.Volume &&
            first?.Yield == second?.Yield;

        public bool Equals(LiquiditySlim? other)
        {
            if (this == (object?)other)
                return true;

            if ((object?)other == null)
                return false;

            if (GetType() != other.GetType())
                return false;

            return EqualsHelper(this, other);
        }

        public override bool Equals(object? obj) => Equals(obj as LiquiditySlim);

        private static bool Equals(LiquiditySlim? first, LiquiditySlim? second) =>
            first?.Equals(second) ?? first == (object?)second;

        public static bool operator ==(LiquiditySlim? first, LiquiditySlim? second) => Equals(first, second);

        public static bool operator !=(LiquiditySlim? first, LiquiditySlim? second) => !Equals(first, second);

        IEnumerable<ValidationResult> IValidatableObject.Validate(ValidationContext validationContext)
        {
            yield break;
        }
    }
}
