using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text;
using SpanJson;

namespace Alor.OpenAPI.Models.Heavy
{
    [DataContract]
    public sealed class OrderbookHeavy : IEquatable<OrderbookHeavy>, IValidatableObject
    {
        public OrderbookHeavy() { }

        /// <include file='../../XmlDocs/CoreModels.xml'
        ///          path='Docs/Members[@name="responseOrderBook"]
        ///               /Member[@name="responseOrderBook"]
        ///               /param[@name="bids" or @name="asks" or @name="msTimestamp" or @name="existing"]'/>
        public OrderbookHeavy(ICollection<LiquidityHeavy>? bids, ICollection<LiquidityHeavy>? asks, long? msTimestamp, bool? existing)
        {
            Bids = bids;
            Asks = asks;
            MsTimestamp = msTimestamp;
            Existing = existing;
        }
        
        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseOrderBook"]/Member[@name="bids"]/*' />
        [DataMember(Name = "bids", EmitDefaultValue = false)]
        public ICollection<LiquidityHeavy>? Bids { get; init; }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseOrderBook"]/Member[@name="asks"]/*' />
        [DataMember(Name = "asks", EmitDefaultValue = false)]
        public ICollection<LiquidityHeavy>? Asks { get; init; }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseOrderBook"]/Member[@name="msTimestamp"]/*' />
        [DataMember(Name = "msTimestamp", EmitDefaultValue = false)]
        public long? MsTimestamp { get; init; }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseOrderBook"]/Member[@name="existing"]/*' />
        [DataMember(Name = "existing", EmitDefaultValue = false)]
        public bool? Existing { get; init; }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class OrderbookHeavy {").Append(Environment.NewLine);
            sb.Append("  Bids: ").Append(Bids == null ? "null" : string.Join(", ", Bids.Select(x => x.ToString()))).Append(Environment.NewLine);
            sb.Append("  Asks: ").Append(Asks == null ? "null" : string.Join(", ", Asks.Select(x => x.ToString()))).Append(Environment.NewLine);
            sb.Append("  Ms_Timestamp: ").Append(MsTimestamp).Append(Environment.NewLine);
            sb.Append("  Existing: ").Append(Existing).Append(Environment.NewLine);
            sb.Append('}').Append(Environment.NewLine);
            return sb.ToString();
        }

        public string ToJson() => Encoding.UTF8.GetString(JsonSerializer.Generic.Utf8.Serialize(this));

        public override int GetHashCode()
        {
            var hash = new HashCode();

            if (Asks != null)
                foreach (var ask in Asks)
                {
                    hash.Add(ask.GetHashCode());
                }

            if (Bids != null)
                foreach (var bid in Bids)
                {
                    hash.Add(bid.GetHashCode());
                }

            hash.Add(MsTimestamp);
            hash.Add(Existing);
            return hash.ToHashCode();
        }

        private static bool EqualsHelper(OrderbookHeavy? first, OrderbookHeavy? second) =>
            first?.Bids != null && second?.Bids != null
                ? first.Bids.SequenceEqual(second.Bids)
                : first?.Bids == null && second?.Bids == null &&
                  first?.Asks != null && second?.Asks != null
                    ? first.Asks.SequenceEqual(second.Asks)
                    : first?.Asks == null && second?.Asks == null &&
                      first?.MsTimestamp == second?.MsTimestamp &&
                      first?.Existing == second?.Existing;

        public bool Equals(OrderbookHeavy? other)
        {
            if (this == (object?)other)
                return true;

            if (other is null)
                return false;

            return GetType() == other.GetType() && EqualsHelper(this, other);
        }

        public override bool Equals(object? obj) => Equals(obj as OrderbookHeavy);

        private static bool Equals(OrderbookHeavy? first, OrderbookHeavy? second) =>
            first?.Equals(second) ?? first == (object?)second;

        public static bool operator ==(OrderbookHeavy? first, OrderbookHeavy? second) => Equals(first, second);

        public static bool operator !=(OrderbookHeavy? first, OrderbookHeavy? second) => !Equals(first, second);

        IEnumerable<ValidationResult> IValidatableObject.Validate(ValidationContext validationContext)
        {
            yield break;
        }
    }
}
