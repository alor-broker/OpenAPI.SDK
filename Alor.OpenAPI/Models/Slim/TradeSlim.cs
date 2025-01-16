using Alor.OpenAPI.Enums;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text;

namespace Alor.OpenAPI.Models.Slim
{
    [DataContract]
    public class TradeSlim : IEquatable<TradeSlim>, IValidatableObject
    {
        public TradeSlim() { }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseTradeV2"]/Member[@name="responseTradeV2"]/*' />
        public TradeSlim(string? id = default, string? orderno = default,
            string? symbol = default, string? brokerSymbol = default,
            Exchange exchange = default, string? comment = default, DateTime? date = default, string? board = default,
            int? qtyUnits = default, int? qtyBatch = default, decimal? price = default, decimal? accruedInt = default,
            Side side = default, bool? existing = default, decimal? commission = default,
            TradeRepoSpecificFieldsSlim? repoSpecificFields = default, decimal? volume = default)
        {
            Id = id;
            Orderno = orderno;
            Symbol = symbol;
            BrokerSymbol = brokerSymbol;
            Exchange = exchange;
            Comment = comment;
            Date = date;
            Board = board;
            QtyUnits = qtyUnits;
            QtyBatch = qtyBatch;
            Price = price;
            AccruedInt = accruedInt;
            Side = side;
            Existing = existing;
            Commission = commission;
            RepoSpecificFields = repoSpecificFields;
            Volume = volume;
        }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseTradeV2"]/Member[@name="id"]/*' />
        [DataMember(Name = "id", EmitDefaultValue = false)]
        public string? Id { get; private set; }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseTradeV2"]/Member[@name="orderno"]/*' />
        [DataMember(Name = "eid", EmitDefaultValue = false)]
        public string? Orderno { get; private set; }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseTradeV2"]/Member[@name="symbol"]/*' />
        [DataMember(Name = "sym", EmitDefaultValue = false)]
        public string? Symbol { get; private set; }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseTradeV2"]/Member[@name="brokerSymbol"]/*' />
        [DataMember(Name = "tic", EmitDefaultValue = false)]
        public string? BrokerSymbol { get; set; }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseTradeV2"]/Member[@name="exchange"]/*' />
        [DataMember(Name = "ex", EmitDefaultValue = false)]
        public Exchange Exchange { get; private set; }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseTradeV2"]/Member[@name="comment"]/*' />
        [DataMember(Name = "cmt", EmitDefaultValue = false)]
        public string? Comment { get; set; }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseTradeV2"]/Member[@name="date"]/*' />
        [DataMember(Name = "d", EmitDefaultValue = false)]
        public DateTime? Date { get; set; }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseTradeV2"]/Member[@name="board"]/*' />
        [DataMember(Name = "b", EmitDefaultValue = false)]
        public string? Board { get; set; }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseTradeV2"]/Member[@name="qtyUnits"]/*' />
        [DataMember(Name = "q", EmitDefaultValue = false)]
        public int? QtyUnits { get; set; }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseTradeV2"]/Member[@name="qtyBatch"]/*' />
        [DataMember(Name = "qb", EmitDefaultValue = false)]
        public int? QtyBatch { get; set; }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseTradeV2"]/Member[@name="price"]/*' />
        [DataMember(Name = "px", EmitDefaultValue = false)]
        public decimal? Price { get; set; }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseTradeV2"]/Member[@name="accruedInt"]/*' />
        [DataMember(Name = "ai", EmitDefaultValue = false)]
        public decimal? AccruedInt { get; set; }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseTradeV2"]/Member[@name="side"]/*' />
        [DataMember(Name = "s", EmitDefaultValue = false)]
        public Side Side { get; set; }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseTradeV2"]/Member[@name="existing"]/*' />
        [DataMember(Name = "h", EmitDefaultValue = false)]
        public bool? Existing { get; set; }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseTradeV2"]/Member[@name="commission"]/*' />
        [DataMember(Name = "cms", EmitDefaultValue = false)]
        public decimal? Commission { get; set; }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseTradeV2"]/Member[@name="rSlim"]/*' />
        [DataMember(Name = "r", EmitDefaultValue = false)]
        public TradeRepoSpecificFieldsSlim? RepoSpecificFields { get; set; }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseTradeV2"]/Member[@name="volume"]/*' />
        [DataMember(Name = "v", EmitDefaultValue = false)]
        public decimal? Volume { get; set; }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class TradeSlim {").Append(Environment.NewLine);
            sb.Append("  Id: ").Append(Id).Append(Environment.NewLine);
            sb.Append("  Orderno: ").Append(Orderno).Append(Environment.NewLine);
            sb.Append("  SymbolSimple: ").Append(Symbol).Append(Environment.NewLine);
            sb.Append("  BrokerSymbol: ").Append(BrokerSymbol).Append(Environment.NewLine);
            sb.Append("  Exchange: ").Append(Exchange).Append(Environment.NewLine);
            sb.Append("  Comment: ").Append(Comment).Append(Environment.NewLine);
            sb.Append("  Date: ").Append(Date).Append(Environment.NewLine);
            sb.Append("  Board: ").Append(Board).Append(Environment.NewLine);
            sb.Append("  QtyUnits: ").Append(QtyUnits).Append(Environment.NewLine);
            sb.Append("  QtyBatch: ").Append(QtyBatch).Append(Environment.NewLine);
            sb.Append("  Price: ").Append(Price).Append(Environment.NewLine);
            sb.Append("  AccruedInt: ").Append(AccruedInt).Append(Environment.NewLine);
            sb.Append("  Side: ").Append(Side).Append(Environment.NewLine);
            sb.Append("  Existing: ").Append(Existing).Append(Environment.NewLine);
            sb.Append("  Commission: ").Append(Commission).Append(Environment.NewLine);
            sb.Append("  RepoSpecificFields: ").Append(RepoSpecificFields).Append(Environment.NewLine);
            sb.Append("  Volume: ").Append(Volume).Append(Environment.NewLine);
            sb.Append('}').Append(Environment.NewLine);
            return sb.ToString();
        }

        public string ToJson() => Encoding.UTF8.GetString(SpanJson.JsonSerializer.Generic.Utf8.Serialize(this));

        public override int GetHashCode() => Utilities.Utilities.GetHashCodeHelper(
            [
                Id?.GetHashCode() ?? 0,
                Orderno?.GetHashCode() ?? 0,
                Symbol?.GetHashCode() ?? 0,
                Exchange.GetHashCode(),
            ]
        );

        private static bool EqualsHelper(TradeSlim? first, TradeSlim? second) =>
            first?.Id == second?.Id &&
            first?.Orderno == second?.Orderno &&
            first?.Symbol == second?.Symbol &&
            first?.BrokerSymbol == second?.BrokerSymbol &&
            first?.Exchange == second?.Exchange &&
            first?.Comment == second?.Comment &&
            first?.Date == second?.Date &&
            first?.Board == second?.Board &&
            first?.QtyUnits == second?.QtyUnits &&
            first?.QtyBatch == second?.QtyBatch &&
            first?.Price == second?.Price &&
            first?.AccruedInt == second?.AccruedInt &&
            first?.Side == second?.Side &&
            first?.Existing == second?.Existing &&
            first?.Commission == second?.Commission &&
            first?.RepoSpecificFields == second?.RepoSpecificFields &&
            first?.Volume == second?.Volume;

        public bool Equals(TradeSlim? other)
        {
            if (this == (object?)other)
                return true;

            if ((object?)other == null)
                return false;

            if (GetType() != other.GetType())
                return false;

            return EqualsHelper(this, other);
        }

        public override bool Equals(object? obj) => Equals(obj as TradeSlim);

        private static bool Equals(TradeSlim? first, TradeSlim? second) =>
            first?.Equals(second) ?? first == (object?)second;

        public static bool operator ==(TradeSlim? first, TradeSlim? second) => Equals(first, second);

        public static bool operator !=(TradeSlim? first, TradeSlim? second) => !Equals(first, second);

        IEnumerable<ValidationResult> IValidatableObject.Validate(ValidationContext validationContext)
        {
            yield break;
        }
    }
}