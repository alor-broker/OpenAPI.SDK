﻿using Alor.OpenAPI.Enums;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text;

namespace Alor.OpenAPI.Models.Simple
{
    [DataContract]
    public class TradeSimple : IEquatable<TradeSimple>, IValidatableObject
    {
        public TradeSimple() { }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseTradeV2"]/Member[@name="responseTradeV2"]/*' />
        public TradeSimple(string? id = default, string? orderno = default,
            string? symbol = default, string? brokerSymbol = default,
            Exchange exchange = default, string? comment = default, DateTime? date = default, string? board = default,
            int? qtyUnits = default, int? qtyBatch = default, int? qty = default, decimal? price = default, decimal? accruedInt = default,
            Side side = default, bool? existing = default, decimal? commission = default,
            TradeRepoSpecificFieldsSimple? repoSpecificFields = default, decimal? volume = default)
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
            Qty = qty;
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
        [DataMember(Name = "orderno", EmitDefaultValue = false)]
        public string? Orderno { get; private set; }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseTradeV2"]/Member[@name="symbol"]/*' />
        [DataMember(Name = "symbol", EmitDefaultValue = false)]
        public string? Symbol { get; private set; }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseTradeV2"]/Member[@name="brokerSymbol"]/*' />
        [DataMember(Name = "brokerSymbol", EmitDefaultValue = false)]
        public string? BrokerSymbol { get; set; }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseTradeV2"]/Member[@name="exchange"]/*' />
        [DataMember(Name = "exchange", EmitDefaultValue = false)]
        public Exchange Exchange { get; private set; }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseTradeV2"]/Member[@name="comment"]/*' />
        [DataMember(Name = "comment", EmitDefaultValue = false)]
        public string? Comment { get; set; }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseTradeV2"]/Member[@name="date"]/*' />
        [DataMember(Name = "date", EmitDefaultValue = false)]
        public DateTime? Date { get; set; }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseTradeV2"]/Member[@name="board"]/*' />
        [DataMember(Name = "board", EmitDefaultValue = false)]
        public string? Board { get; set; }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseTradeV2"]/Member[@name="qtyUnits"]/*' />
        [DataMember(Name = "qtyUnits", EmitDefaultValue = false)]
        public int? QtyUnits { get; set; }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseTradeV2"]/Member[@name="qtyBatch"]/*' />
        [DataMember(Name = "qtyBatch", EmitDefaultValue = false)]
        public int? QtyBatch { get; set; }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseTradeV2"]/Member[@name="qty"]/*' />
        [DataMember(Name = "qty", EmitDefaultValue = false)]
        public int? Qty { get; set; }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseTradeV2"]/Member[@name="price"]/*' />
        [DataMember(Name = "price", EmitDefaultValue = false)]
        public decimal? Price { get; set; }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseTradeV2"]/Member[@name="accruedInt"]/*' />
        [DataMember(Name = "accruedInt", EmitDefaultValue = false)]
        public decimal? AccruedInt { get; set; }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseTradeV2"]/Member[@name="side"]/*' />
        [DataMember(Name = "side", EmitDefaultValue = false)]
        public Side Side { get; set; }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseTradeV2"]/Member[@name="existing"]/*' />
        [DataMember(Name = "existing", EmitDefaultValue = false)]
        public bool? Existing { get; set; }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseTradeV2"]/Member[@name="commission"]/*' />
        [DataMember(Name = "commission", EmitDefaultValue = false)]
        public decimal? Commission { get; set; }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseTradeV2"]/Member[@name="repoSpecificFields"]/*' />
        [DataMember(Name = "repoSpecificFields", EmitDefaultValue = false)]
        public TradeRepoSpecificFieldsSimple? RepoSpecificFields { get; set; }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseTradeV2"]/Member[@name="volume"]/*' />
        [DataMember(Name = "volume", EmitDefaultValue = false)]
        public decimal? Volume { get; set; }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class TradeSimple {").Append(Environment.NewLine);
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
            sb.Append("  Qty: ").Append(Qty).Append(Environment.NewLine);
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

        private static bool EqualsHelper(TradeSimple? first, TradeSimple? second) =>
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
            first?.Qty == second?.Qty &&
            first?.AccruedInt == second?.AccruedInt &&
            first?.Side == second?.Side &&
            first?.Existing == second?.Existing &&
            first?.Commission == second?.Commission &&
            first?.RepoSpecificFields == second?.RepoSpecificFields &&
            first?.Volume == second?.Volume;

        public bool Equals(TradeSimple? other)
        {
            if (this == (object?)other)
                return true;

            if ((object?)other == null)
                return false;

            if (GetType() != other.GetType())
                return false;

            return EqualsHelper(this, other);
        }

        public override bool Equals(object? obj) => Equals(obj as TradeSimple);

        private static bool Equals(TradeSimple? first, TradeSimple? second) =>
            first?.Equals(second) ?? first == (object?)second;

        public static bool operator ==(TradeSimple? first, TradeSimple? second) => Equals(first, second);

        public static bool operator !=(TradeSimple? first, TradeSimple? second) => !Equals(first, second);

        IEnumerable<ValidationResult> IValidatableObject.Validate(ValidationContext validationContext)
        {
            yield break;
        }
    }
}