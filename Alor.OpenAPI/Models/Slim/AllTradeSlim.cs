using Alor.OpenAPI.Enums;
using SpanJson;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text;

namespace Alor.OpenAPI.Models.Slim
{
    [DataContract]
    public sealed class AllTradeSlim : IEquatable<AllTradeSlim>, IValidatableObject
    {
        public AllTradeSlim() { }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseAllTrade"]/Member[@name="responseAllTrade"]/*' />
        [JsonConstructor]
        public AllTradeSlim(long? id = default,
            string? symbol = default, string? board = default, int? qty = default,
            decimal? price = default, long? timestamp = default,
            Side side = default, long? oi = default, bool? existing = default)
        {
            Id = id;
            Symbol = symbol;
            Board = board;
            Qty = qty;
            Price = price;
            Timestamp = timestamp;
            Side = side;
            Oi = oi;
            Existing = existing;
        }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseAllTrade"]/Member[@name="id"]/*' />
        [DataMember(Name = "id", EmitDefaultValue = false)]
        public long? Id { get; init; }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseAllTrade"]/Member[@name="symbol"]/*' />
        [DataMember(Name = "sym", EmitDefaultValue = false)]
        public string? Symbol { get; init; }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseAllTrade"]/Member[@name="board"]/*' />
        [DataMember(Name = "bd", EmitDefaultValue = false)]
        public string? Board { get; init; }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseAllTrade"]/Member[@name="qty"]/*' />
        [DataMember(Name = "q", EmitDefaultValue = false)]
        public int? Qty { get; init; }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseAllTrade"]/Member[@name="price"]/*' />
        [DataMember(Name = "px", EmitDefaultValue = false)]
        public decimal? Price { get; init; }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseAllTrade"]/Member[@name="timestamp"]/*' />
        [DataMember(Name = "t", EmitDefaultValue = false)]
        public long? Timestamp { get; init; }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseAllTrade"]/Member[@name="side"]/*' />
        [DataMember(Name = "s", EmitDefaultValue = false)]
        public Side Side { get; init; }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseAllTrade"]/Member[@name="oi"]/*' />
        [DataMember(Name = "oi", EmitDefaultValue = false)]
        public long? Oi { get; init; }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseAllTrade"]/Member[@name="existing"]/*' />
        [DataMember(Name = "h", EmitDefaultValue = false)]
        public bool? Existing { get; init; }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class AllTradeSlim {").Append(Environment.NewLine);
            sb.Append("  Id: ").Append(Id).Append(Environment.NewLine);
            sb.Append("  Symbol: ").Append(Symbol).Append(Environment.NewLine);
            sb.Append("  Board: ").Append(Board).Append(Environment.NewLine);
            sb.Append("  Qty: ").Append(Qty).Append(Environment.NewLine);
            sb.Append("  Price: ").Append(Price).Append(Environment.NewLine);
            sb.Append("  Timestamp: ").Append(Timestamp).Append(Environment.NewLine);
            sb.Append("  Side: ").Append(Side).Append(Environment.NewLine);
            sb.Append("  Oi: ").Append(Oi).Append(Environment.NewLine);
            sb.Append("  Existing: ").Append(Existing).Append(Environment.NewLine);
            sb.Append('}').Append(Environment.NewLine);
            return sb.ToString();
        }

        public string ToJson() => Encoding.UTF8.GetString(JsonSerializer.Generic.Utf8.Serialize(this));

        public override int GetHashCode()
        {
            var hash = new HashCode();
            hash.Add(Id);
            hash.Add(Symbol);
            hash.Add(Board);
            hash.Add(Qty);
            hash.Add(Price);
            hash.Add(Timestamp);
            hash.Add(Side);
            hash.Add(Oi);
            hash.Add(Existing);
            return hash.ToHashCode();
        }

        private static bool EqualsHelper(AllTradeSlim? first, AllTradeSlim? second) =>
            first?.Id == second?.Id &&
            first?.Symbol == second?.Symbol &&
            first?.Board == second?.Board &&
            first?.Qty == second?.Qty &&
            first?.Price == second?.Price &&
            first?.Timestamp == second?.Timestamp &&
            first?.Side == second?.Side &&
            first?.Oi == second?.Oi &&
            first?.Existing == second?.Existing;


        public bool Equals(AllTradeSlim? other)
        {
            if (this == (object?)other)
                return true;

            if ((object?)other == null)
                return false;

            return GetType() == other.GetType() && EqualsHelper(this, other);
        }

        public override bool Equals(object? obj) => Equals(obj as AllTradeSlim);

        private static bool Equals(AllTradeSlim? first, AllTradeSlim? second) =>
            first?.Equals(second) ?? first == (object?)second;

        public static bool operator ==(AllTradeSlim? first, AllTradeSlim? second) => Equals(first, second);

        public static bool operator !=(AllTradeSlim? first, AllTradeSlim? second) => !Equals(first, second);

        IEnumerable<ValidationResult> IValidatableObject.Validate(ValidationContext validationContext)
        {
            yield break;
        }
    }
}