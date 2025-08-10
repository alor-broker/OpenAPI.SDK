using Alor.OpenAPI.Enums;
using SpanJson;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text;

namespace Alor.OpenAPI.Models.Simple
{
    [DataContract]
    public sealed class AllTradeSimple : IEquatable<AllTradeSimple>, IValidatableObject
    {
        public AllTradeSimple() { }

        /// <include file='../../XmlDocs/CoreModels.xml'
        ///          path='Docs/Members[@name="responseAllTrade"]
        ///               /Member[@name="responseAllTrade"]
        ///               /param[
        ///                      @name="id" or @name="orderno" or @name="symbol" or @name="board" or @name="qty" or @name="price"
        ///                      or @name="time" or @name="timestamp" or @name="side" or @name="oi" or @name="existing"
        ///                     ]'/>
        public AllTradeSimple(long? id = null, long? orderno = null,
            string? symbol = null, string? board = null, int? qty = null,
            decimal? price = null, DateTime? time = null, long? timestamp = null,
            Side? side = null, long? oi = null, bool? existing = null)
        {
            Id = id;
            Orderno = orderno;
            Symbol = symbol;
            Board = board;
            Qty = qty;
            Price = price;
            Time = time;
            Timestamp = timestamp;
            Side = side;
            Oi = oi;
            Existing = existing;
        }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseAllTrade"]/Member[@name="id"]/*' />
        [DataMember(Name = "id", EmitDefaultValue = false)]
        public long? Id { get; init; }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseAllTrade"]/Member[@name="symbol"]/*' />
        [DataMember(Name = "orderno", EmitDefaultValue = false)]
        public long? Orderno { get; init; }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseAllTrade"]/Member[@name="board"]/*' />
        [DataMember(Name = "symbol", EmitDefaultValue = false)]
        public string? Symbol { get; init; }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseAllTrade"]/Member[@name="board"]/*' />
        [DataMember(Name = "board", EmitDefaultValue = false)]
        public string? Board { get; init; }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseAllTrade"]/Member[@name="qty"]/*' />
        [DataMember(Name = "qty", EmitDefaultValue = false)]
        public int? Qty { get; init; }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseAllTrade"]/Member[@name="price"]/*' />
        [DataMember(Name = "price", EmitDefaultValue = false)]
        public decimal? Price { get; init; }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseAllTrade"]/Member[@name="time"]/*' />
        [DataMember(Name = "time", EmitDefaultValue = false)]
        public DateTime? Time { get; init; }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseAllTrade"]/Member[@name="timestamp"]/*' />
        [DataMember(Name = "timestamp", EmitDefaultValue = false)]
        public long? Timestamp { get; init; }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseAllTrade"]/Member[@name="side"]/*' />
        [DataMember(Name = "side", EmitDefaultValue = false)]
        public Side? Side { get; init; }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseAllTrade"]/Member[@name="oi"]/*' />
        [DataMember(Name = "oi", EmitDefaultValue = false)]
        public long? Oi { get; init; }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseAllTrade"]/Member[@name="existing"]/*' />
        [DataMember(Name = "existing", EmitDefaultValue = false)]
        public bool? Existing { get; init; }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class AllTradeSimple {").Append(Environment.NewLine);
            sb.Append("  Id: ").Append(Id).Append(Environment.NewLine);
            sb.Append("  Orderno: ").Append(Orderno).Append(Environment.NewLine);
            sb.Append("  Symbol: ").Append(Symbol).Append(Environment.NewLine);
            sb.Append("  Board: ").Append(Board).Append(Environment.NewLine);
            sb.Append("  Qty: ").Append(Qty).Append(Environment.NewLine);
            sb.Append("  Price: ").Append(Price).Append(Environment.NewLine);
            sb.Append("  Time: ").Append(Time).Append(Environment.NewLine);
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
            hash.Add(Orderno);
            hash.Add(Symbol);
            hash.Add(Board);
            hash.Add(Qty);
            hash.Add(Price);
            hash.Add(Time);
            hash.Add(Timestamp);
            hash.Add(Side);
            hash.Add(Oi);
            hash.Add(Existing);
            return hash.ToHashCode();
        }

        private static bool EqualsHelper(AllTradeSimple? first, AllTradeSimple? second) =>
            first?.Id == second?.Id &&
            first?.Orderno == second?.Orderno &&
            first?.Symbol == second?.Symbol &&
            first?.Board == second?.Board &&
            first?.Qty == second?.Qty &&
            first?.Price == second?.Price &&
            first?.Time == second?.Time &&
            first?.Timestamp == second?.Timestamp &&
            first?.Side == second?.Side &&
            first?.Oi == second?.Oi &&
            first?.Existing == second?.Existing;
        
        public bool Equals(AllTradeSimple? other)
        {
            if (this == (object?)other)
                return true;

            if (other is null)
                return false;

            return GetType() == other.GetType() && EqualsHelper(this, other);
        }

        public override bool Equals(object? obj) => Equals(obj as AllTradeSimple);

        private static bool Equals(AllTradeSimple? first, AllTradeSimple? second) =>
            first?.Equals(second) ?? first == (object?)second;

        public static bool operator ==(AllTradeSimple? first, AllTradeSimple? second) => Equals(first, second);

        public static bool operator !=(AllTradeSimple? first, AllTradeSimple? second) => !Equals(first, second);

        IEnumerable<ValidationResult> IValidatableObject.Validate(ValidationContext validationContext)
        {
            yield break;
        }
    }
}