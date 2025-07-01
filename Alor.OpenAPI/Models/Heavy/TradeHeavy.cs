using Alor.OpenAPI.Enums;
using SpanJson;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.Serialization;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Xml.Linq;

namespace Alor.OpenAPI.Models.Heavy
{
    [DataContract]
    public class TradeHeavy : IEquatable<TradeHeavy>, IValidatableObject
    {
        public TradeHeavy() { }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseTradeV2"]/Member[@name="responseTradeV2"]/*' />
        public TradeHeavy(string? id = default, string? orderno = default,
            string? symbol = default, string? shortName = default, string? brokerSymbol = default,
            Exchange exchange = default, string? comment = default, DateTime? date = default, string? board = default,
            int? qtyUnits = default, int? qtyBatch = default, int? qty = default, decimal? price = default, string? currencyHeavy = default,
            decimal? accruedInt = default, Side side = default, bool? existing = default, decimal? commission = default,
            TradeRepoSpecificFieldsHeavy? repoSpecificFields = default, decimal? volume = default, DateTime? settleDateHeavy = default)
        {
            Id = id;
            Orderno = orderno;
            Symbol = symbol;
            ShortName = shortName;
            BrokerSymbol = brokerSymbol;
            Exchange = exchange;
            Comment = comment;
            Date = date;
            Board = board;
            QtyUnits = qtyUnits;
            QtyBatch = qtyBatch;
            Qty = qty;
            Price = price;
            Currency = currencyHeavy;
            AccruedInt = accruedInt;
            Side = side;
            Existing = existing;
            Commission = commission;
            RepoSpecificFields = repoSpecificFields;
            Volume = volume;
            SettleDate = settleDateHeavy;
        }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseTradeV2"]/Member[@name="id"]/*' />
        [DataMember(Name = "id", EmitDefaultValue = false)]
        public string? Id { get; init; }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseTradeV2"]/Member[@name="orderno"]/*' />
        [DataMember(Name = "orderno", EmitDefaultValue = false)]
        public string? Orderno { get; init; }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseTradeV2"]/Member[@name="symbol"]/*' />
        [DataMember(Name = "symbol", EmitDefaultValue = false)]
        public string? Symbol { get; init; }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseTradeV2"]/Member[@name="shortNameHeavy"]/*' />
        [DataMember(Name = "shortName", EmitDefaultValue = false)]
        public string? ShortName { get; init; }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseTradeV2"]/Member[@name="brokerSymbol"]/*' />
        [DataMember(Name = "brokerSymbol", EmitDefaultValue = false)]
        public string? BrokerSymbol { get; init; }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseTradeV2"]/Member[@name="exchange"]/*' />
        [DataMember(Name = "exchange", EmitDefaultValue = false)]
        public Exchange Exchange { get; init; }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseTradeV2"]/Member[@name="comment"]/*' />
        [DataMember(Name = "comment", EmitDefaultValue = false)]
        public string? Comment { get; init; }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseTradeV2"]/Member[@name="date"]/*' />
        [DataMember(Name = "date", EmitDefaultValue = false)]
        public DateTime? Date { get; init; }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseTradeV2"]/Member[@name="board"]/*' />
        [DataMember(Name = "board", EmitDefaultValue = false)]
        public string? Board { get; init; }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseTradeV2"]/Member[@name="qtyUnits"]/*' />
        [DataMember(Name = "qtyUnits", EmitDefaultValue = false)]
        public int? QtyUnits { get; init; }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseTradeV2"]/Member[@name="qtyBatch"]/*' />
        [DataMember(Name = "qtyBatch", EmitDefaultValue = false)]
        public int? QtyBatch { get; init; }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseTradeV2"]/Member[@name="qty"]/*' />
        [DataMember(Name = "qty", EmitDefaultValue = false)]
        public int? Qty { get; init; }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseTradeV2"]/Member[@name="price"]/*' />
        [DataMember(Name = "price", EmitDefaultValue = false)]
        public decimal? Price { get; init; }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseTradeV2"]/Member[@name="currencyHeavy"]/*' />
        [DataMember(Name = "currency", EmitDefaultValue = false)]
        public string? Currency { get; init; }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseTradeV2"]/Member[@name="accruedInt"]/*' />
        [DataMember(Name = "accruedInt", EmitDefaultValue = false)]
        public decimal? AccruedInt { get; init; }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseTradeV2"]/Member[@name="side"]/*' />
        [DataMember(Name = "side", EmitDefaultValue = false)]
        public Side Side { get; init; }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseTradeV2"]/Member[@name="existing"]/*' />
        [DataMember(Name = "existing", EmitDefaultValue = false)]
        public bool? Existing { get; init; }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseTradeV2"]/Member[@name="commission"]/*' />
        [DataMember(Name = "commission", EmitDefaultValue = false)]
        public decimal? Commission { get; init; }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseTradeV2"]/Member[@name="repoSpecificFields"]/*' />
        [DataMember(Name = "repoSpecificFields", EmitDefaultValue = false)]
        public TradeRepoSpecificFieldsHeavy? RepoSpecificFields { get; init; }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseTradeV2"]/Member[@name="volume"]/*' />
        [DataMember(Name = "volume", EmitDefaultValue = false)]
        public decimal? Volume { get; init; }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseTradeV2"]/Member[@name="settleDateHeavy"]/*' />
        [DataMember(Name = "settleDate", EmitDefaultValue = false)]
        public DateTime? SettleDate { get; init; }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class TradeHeavy {").Append(Environment.NewLine);
            sb.Append("  Id: ").Append(Id).Append(Environment.NewLine);
            sb.Append("  Orderno: ").Append(Orderno).Append(Environment.NewLine);
            sb.Append("  Symbol: ").Append(Symbol).Append(Environment.NewLine);
            sb.Append("  ShortName: ").Append(ShortName).Append(Environment.NewLine);
            sb.Append("  BrokerSymbol: ").Append(BrokerSymbol).Append(Environment.NewLine);
            sb.Append("  Exchange: ").Append(Exchange).Append(Environment.NewLine);
            sb.Append("  Comment: ").Append(Comment).Append(Environment.NewLine);
            sb.Append("  Date: ").Append(Date).Append(Environment.NewLine);
            sb.Append("  Board: ").Append(Board).Append(Environment.NewLine);
            sb.Append("  QtyUnits: ").Append(QtyUnits).Append(Environment.NewLine);
            sb.Append("  QtyBatch: ").Append(QtyBatch).Append(Environment.NewLine);
            sb.Append("  Qty: ").Append(Qty).Append(Environment.NewLine);
            sb.Append("  Price: ").Append(Price).Append(Environment.NewLine);
            sb.Append("  Currency: ").Append(Currency).Append(Environment.NewLine);
            sb.Append("  AccruedInt: ").Append(AccruedInt).Append(Environment.NewLine);
            sb.Append("  Side: ").Append(Side).Append(Environment.NewLine);
            sb.Append("  Existing: ").Append(Existing).Append(Environment.NewLine);
            sb.Append("  Commission: ").Append(Commission).Append(Environment.NewLine);
            sb.Append("  RepoSpecificFields: ").Append(RepoSpecificFields).Append(Environment.NewLine);
            sb.Append("  Volume: ").Append(Volume).Append(Environment.NewLine);
            sb.Append("  SettleDate: ").Append(SettleDate).Append(Environment.NewLine);
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
            hash.Add(ShortName);
            hash.Add(BrokerSymbol);
            hash.Add(Exchange);
            hash.Add(Comment);
            hash.Add(Date);
            hash.Add(Board);
            hash.Add(QtyUnits);
            hash.Add(QtyBatch);
            hash.Add(Qty);
            hash.Add(Price);
            hash.Add(Currency);
            hash.Add(AccruedInt);
            hash.Add(Side);
            hash.Add(Existing);
            hash.Add(Commission);
            hash.Add(RepoSpecificFields);
            hash.Add(Volume);
            hash.Add(SettleDate);
            return hash.ToHashCode();
        }

        private static bool EqualsHelper(TradeHeavy? first, TradeHeavy? second) =>
            first?.Id == second?.Id &&
            first?.Orderno == second?.Orderno &&
            first?.Symbol == second?.Symbol &&
            first?.ShortName == second?.ShortName &&
            first?.BrokerSymbol == second?.BrokerSymbol &&
            first?.Exchange == second?.Exchange &&
            first?.Comment == second?.Comment &&
            first?.Date == second?.Date &&
            first?.Board == second?.Board &&
            first?.QtyUnits == second?.QtyUnits &&
            first?.QtyBatch == second?.QtyBatch &&
            first?.Qty == second?.Qty &&
            first?.Price == second?.Price &&
            first?.Currency == second?.Currency &&
            first?.AccruedInt == second?.AccruedInt &&
            first?.Side == second?.Side &&
            first?.Existing == second?.Existing &&
            first?.Commission == second?.Commission &&
            first?.RepoSpecificFields == second?.RepoSpecificFields &&
            first?.Volume == second?.Volume &&
            first?.SettleDate == second?.SettleDate;

        public bool Equals(TradeHeavy? other)
        {
            if (this == (object?)other)
                return true;

            if ((object?)other == null)
                return false;

            return GetType() == other.GetType() && EqualsHelper(this, other);
        }

        public override bool Equals(object? obj) => Equals(obj as TradeHeavy);

        private static bool Equals(TradeHeavy? first, TradeHeavy? second) =>
            first?.Equals(second) ?? first == (object?)second;

        public static bool operator ==(TradeHeavy? first, TradeHeavy? second) => Equals(first, second);

        public static bool operator !=(TradeHeavy? first, TradeHeavy? second) => !Equals(first, second);

        IEnumerable<ValidationResult> IValidatableObject.Validate(ValidationContext validationContext)
        {
            yield break;
        }
    }
}