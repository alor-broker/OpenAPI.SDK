using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text;

namespace Alor.OpenAPI.Models.Simple
{
    [DataContract]
    public sealed class OrderbookSimple : IEquatable<OrderbookSimple>, IValidatableObject
    {
        public OrderbookSimple() { }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseOrderBook"]/Member[@name="responseOrderBook"]/*' />
        public OrderbookSimple(ICollection<LiquiditySimple>? bids, ICollection<LiquiditySimple>? asks, long? msTimestamp, bool? existing)
        {
            Bids = bids;
            Asks = asks;
            MsTimestamp = msTimestamp;
            Existing = existing;
        }


        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseOrderBook"]/Member[@name="bids"]/*' />
        [DataMember(Name = "bids", EmitDefaultValue = false)]
        public ICollection<LiquiditySimple>? Bids { get; private set; }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseOrderBook"]/Member[@name="asks"]/*' />
        [DataMember(Name = "asks", EmitDefaultValue = false)]
        public ICollection<LiquiditySimple>? Asks { get; private set; }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseOrderBook"]/Member[@name="msTimestamp"]/*' />
        [DataMember(Name = "ms_timestamp", EmitDefaultValue = false)]
        public long? MsTimestamp { get; private set; }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseOrderBook"]/Member[@name="existing"]/*' />
        [DataMember(Name = "existing", EmitDefaultValue = false)]
        public bool? Existing { get; set; }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class OrderbookSimple {").Append(Environment.NewLine);
            sb.Append("  Bids: ").Append(Bids == null ? "null" : string.Join(", ", Bids.Select(x => x.ToString()))).Append(Environment.NewLine);
            sb.Append("  Asks: ").Append(Asks == null ? "null" : string.Join(", ", Asks.Select(x => x.ToString()))).Append(Environment.NewLine);
            sb.Append("  Ms_Timestamp: ").Append(MsTimestamp).Append(Environment.NewLine);
            sb.Append("  Existing: ").Append(Existing).Append(Environment.NewLine);
            sb.Append('}').Append(Environment.NewLine);
            return sb.ToString();
        }

        public string ToJson() => Encoding.UTF8.GetString(SpanJson.JsonSerializer.Generic.Utf8.Serialize(this));


        public override int GetHashCode() => Utilities.Utilities.GetHashCodeHelper(
            [
                Bids?.GetHashCode() ?? 0,
                Asks?.GetHashCode() ?? 0,
                MsTimestamp ?.GetHashCode() ?? 0,
            ]
        );

        private static bool EqualsHelper(OrderbookSimple? first, OrderbookSimple? second) =>
            first?.Bids != null && second?.Bids != null
                ? first.Bids.SequenceEqual(second.Bids)
                : first?.Bids == null && second?.Bids == null &&
                  first?.Asks != null && second?.Asks != null
                    ? first.Asks.SequenceEqual(second.Asks)
                    : first?.Asks == null && second?.Asks == null &&
                      first?.MsTimestamp == second?.MsTimestamp &&
                      first?.Existing == second?.Existing;

        public bool Equals(OrderbookSimple? other)
        {
            if (this == (object?)other)
                return true;

            if ((object?)other == null)
                return false;

            if (GetType() != other.GetType())
                return false;

            return EqualsHelper(this, other);
        }

        public override bool Equals(object? obj) => Equals(obj as OrderbookSimple);

        private static bool Equals(OrderbookSimple? first, OrderbookSimple? second) =>
            first?.Equals(second) ?? first == (object?)second;

        public static bool operator ==(OrderbookSimple? first, OrderbookSimple? second) => Equals(first, second);

        public static bool operator !=(OrderbookSimple? first, OrderbookSimple? second) => !Equals(first, second);

        IEnumerable<ValidationResult> IValidatableObject.Validate(ValidationContext validationContext)
        {
            yield break;
        }
    }
}
