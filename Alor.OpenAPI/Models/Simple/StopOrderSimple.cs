using Alor.OpenAPI.Enums;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text;

namespace Alor.OpenAPI.Models.Simple
{
    [DataContract]
    public sealed class StopOrderSimple : IEquatable<StopOrderSimple>, IValidatableObject
    {
        public StopOrderSimple() { }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseStopOrderWarp"]/Member[@name="responseStopOrderWarp"]/*' />
        public StopOrderSimple(int? id = default, long? exchangeOrderId = default,
            string? symbol = default, string? brokerSymbol = default, string? portfolio = default,
            Exchange exchange = default, string? board = default, OrderTypeStopLimit type = default,
            Side side = default, Condition condition = default,
            OrderStatus status = default, DateTime? transTime = default, DateTime? updateTime = default,
            DateTime? endTime = default, string? error = default, decimal? qtyUnits = default,
            int? qtyBatch = default, int? qty = default, decimal? filledQtyUnits = default,
            decimal? filledQtyBatch = default, decimal? price = default,
            decimal? avgPrice = default, decimal? stopPrice = default,
            bool? existing = default, TimeInForce timeInForce = default, Iceberg? iceberg = default,
            decimal? volume = default, int? protectingSeconds = default)
        {
            Id = id;
            ExchangeOrderId = exchangeOrderId;
            Symbol = symbol;
            BrokerSymbol = brokerSymbol;
            Portfolio = portfolio;
            Exchange = exchange;
            Board = board;
            Type = type;
            Side = side;
            Condition = condition;
            Status = status;
            TransTime = transTime;
            UpdateTime = updateTime;
            EndTime = endTime;
            Error = error;
            QtyUnits = qtyUnits;
            QtyBatch = qtyBatch;
            Qty = qty;
            FilledQtyUnits = filledQtyUnits;
            FilledQtyBatch = filledQtyBatch;
            Price = price;
            AvgPrice = avgPrice;
            StopPrice = stopPrice;
            Existing = existing;
            TimeInForce = timeInForce;
            Iceberg = iceberg;
            Volume = volume;
            ProtectingSeconds = protectingSeconds;
        }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseStopOrderWarp"]/Member[@name="id"]/*' />
        [DataMember(Name = "id", EmitDefaultValue = false)]
        public int? Id { get; set; }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseStopOrderWarp"]/Member[@name="exchangeOrderId"]/*' />
        [DataMember(Name = "exchangeOrderId", EmitDefaultValue = false)]
        public long? ExchangeOrderId { get; set; }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseStopOrderWarp"]/Member[@name="symbol"]/*' />
        [DataMember(Name = "symbol", EmitDefaultValue = false)]
        public string? Symbol { get; set; }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseStopOrderWarp"]/Member[@name="brokerSymbol"]/*' />
        [DataMember(Name = "brokerSymbol", EmitDefaultValue = false)]
        public string? BrokerSymbol { get; set; }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseStopOrderWarp"]/Member[@name="portfolio"]/*' />
        [DataMember(Name = "portfolio", EmitDefaultValue = false)]
        public string? Portfolio { get; set; }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseStopOrderWarp"]/Member[@name="exchange"]/*' />
        [DataMember(Name = "exchange", EmitDefaultValue = false)]
        public Exchange Exchange { get; set; }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseStopOrderWarp"]/Member[@name="board"]/*' />
        [DataMember(Name = "board", EmitDefaultValue = false)]
        public string? Board { get; set; }
        
        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseStopOrderWarp"]/Member[@name="type"]/*' />
        [DataMember(Name = "type", EmitDefaultValue = false)]
        public OrderTypeStopLimit Type { get; set; }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseStopOrderWarp"]/Member[@name="side"]/*' />
        [DataMember(Name = "side", EmitDefaultValue = false)]
        public Side Side { get; set; }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseStopOrderWarp"]/Member[@name="condition"]/*' />
        [DataMember(Name = "condition", EmitDefaultValue = false)]
        public Condition Condition { get; set; }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseStopOrderWarp"]/Member[@name="status"]/*' />
        [DataMember(Name = "status", EmitDefaultValue = false)]
        public OrderStatus Status { get; set; }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseStopOrderWarp"]/Member[@name="transTime"]/*' />
        [DataMember(Name = "transTime", EmitDefaultValue = false)]
        public DateTime? TransTime { get; set; }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseStopOrderWarp"]/Member[@name="updateTime"]/*' />
        [DataMember(Name = "updateTime", EmitDefaultValue = false)]
        public DateTime? UpdateTime { get; set; }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseStopOrderWarp"]/Member[@name="endTime"]/*' />
        [DataMember(Name = "endTime", EmitDefaultValue = false)]
        public DateTime? EndTime { get; set; }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseStopOrderWarp"]/Member[@name="error"]/*' />
        [DataMember(Name = "error", EmitDefaultValue = false)]
        public string? Error { get; set; }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseStopOrderWarp"]/Member[@name="qtyUnits"]/*' />
        [DataMember(Name = "qtyUnits", EmitDefaultValue = false)]
        public decimal? QtyUnits { get; set; }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseStopOrderWarp"]/Member[@name="qtyBatch"]/*' />
        [DataMember(Name = "qtyBatch", EmitDefaultValue = false)]
        public int? QtyBatch { get; set; }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseStopOrderWarp"]/Member[@name="qty"]/*' />
        [DataMember(Name = "qty", EmitDefaultValue = false)]
        public int? Qty { get; set; }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseStopOrderWarp"]/Member[@name="filledQtyUnits"]/*' />
        [DataMember(Name = "filledQtyUnits", EmitDefaultValue = false)]
        public decimal? FilledQtyUnits { get; set; }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseStopOrderWarp"]/Member[@name="filledQtyBatch"]/*' />
        [DataMember(Name = "filledQtyBatch", EmitDefaultValue = false)]
        public decimal? FilledQtyBatch { get; set; }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseStopOrderWarp"]/Member[@name="price"]/*' />
        [DataMember(Name = "price", EmitDefaultValue = false)]
        public decimal? Price { get; set; }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseStopOrderWarp"]/Member[@name="avgPrice"]/*' />
        [DataMember(Name = "avg_price", EmitDefaultValue = false)]
        public decimal? AvgPrice { get; set; }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseStopOrderWarp"]/Member[@name="stopPrice"]/*' />
        [DataMember(Name = "stopPrice", EmitDefaultValue = false)]
        public decimal? StopPrice { get; set; }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseStopOrderWarp"]/Member[@name="existing"]/*' />
        [DataMember(Name = "existing", EmitDefaultValue = false)]
        public bool? Existing { get; set; }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseStopOrderWarp"]/Member[@name="timeInForce"]/*' />
        [DataMember(Name = "timeInForce", EmitDefaultValue = false)]
        public TimeInForce TimeInForce { get; set; }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseStopOrderWarp"]/Member[@name="iceberg"]/*' />
        [DataMember(Name = "iceberg", EmitDefaultValue = false)]
        public Iceberg? Iceberg { get; set; }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseStopOrderWarp"]/Member[@name="volume"]/*' />
        [DataMember(Name = "volume", EmitDefaultValue = false)]
        public decimal? Volume { get; set; }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseStopOrderWarp"]/Member[@name="protectingSeconds"]/*' />
        [DataMember(Name = "protectingSeconds", EmitDefaultValue = false)]
        public int? ProtectingSeconds { get; set; }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class StopOrderSimple {").Append(Environment.NewLine);
            sb.Append("  Id: ").Append(Id).Append(Environment.NewLine);
            sb.Append("  ExchangeOrderId: ").Append(ExchangeOrderId).Append(Environment.NewLine);
            sb.Append("  Symbol: ").Append(Symbol).Append(Environment.NewLine);
            sb.Append("  BrokerSymbol: ").Append(BrokerSymbol).Append(Environment.NewLine);
            sb.Append("  Portfolio: ").Append(Portfolio).Append(Environment.NewLine);
            sb.Append("  Exchange: ").Append(Exchange).Append(Environment.NewLine);
            sb.Append("  Board: ").Append(Board).Append(Environment.NewLine);
            sb.Append("  Type: ").Append(Type).Append(Environment.NewLine);
            sb.Append("  Side: ").Append(Side).Append(Environment.NewLine);
            sb.Append("  Condition: ").Append(Condition).Append(Environment.NewLine);
            sb.Append("  Status: ").Append(Status).Append(Environment.NewLine);
            sb.Append("  TransTime: ").Append(TransTime).Append(Environment.NewLine);
            sb.Append("  UpdateTime: ").Append(UpdateTime).Append(Environment.NewLine);
            sb.Append("  EndTime: ").Append(EndTime).Append(Environment.NewLine);
            sb.Append("  Error: ").Append(Error).Append(Environment.NewLine);
            sb.Append("  QtyUnits: ").Append(QtyUnits).Append(Environment.NewLine);
            sb.Append("  QtyBatch: ").Append(QtyBatch).Append(Environment.NewLine);
            sb.Append("  Qty: ").Append(Qty).Append(Environment.NewLine);
            sb.Append("  FilledQtyUnits: ").Append(FilledQtyUnits).Append(Environment.NewLine);
            sb.Append("  FilledQtyBatch: ").Append(FilledQtyBatch).Append(Environment.NewLine);
            sb.Append("  Price: ").Append(Price).Append(Environment.NewLine);
            sb.Append("  AvgPrice: ").Append(AvgPrice).Append(Environment.NewLine);
            sb.Append("  StopPrice: ").Append(StopPrice).Append(Environment.NewLine);
            sb.Append("  Existing: ").Append(Existing).Append(Environment.NewLine);
            sb.Append("  TimeInForce: ").Append(TimeInForce).Append(Environment.NewLine);
            sb.Append("  Iceberg: ").Append(Iceberg).Append(Environment.NewLine);
            sb.Append("  Volume: ").Append(Volume).Append(Environment.NewLine);
            sb.Append("  ProtectingSeconds: ").Append(ProtectingSeconds).Append(Environment.NewLine);
            sb.Append('}').Append(Environment.NewLine);
            return sb.ToString();
        }

        public string ToJson() => Encoding.UTF8.GetString(SpanJson.JsonSerializer.Generic.Utf8.Serialize(this));

        public override int GetHashCode() => Utilities.Utilities.GetHashCodeHelper(
            [
                Id?.GetHashCode() ?? 0,
                Symbol?.GetHashCode() ?? 0,
                Exchange.GetHashCode(),
                Board?.GetHashCode() ?? 0,
            ]
        );

        private static bool EqualsHelper(StopOrderSimple? first, StopOrderSimple? second) =>
            first?.Id == second?.Id &&
            first?.ExchangeOrderId == second?.ExchangeOrderId &&
            first?.Symbol == second?.Symbol &&
            first?.BrokerSymbol == second?.BrokerSymbol &&
            first?.Portfolio == second?.Portfolio &&
            first?.Exchange == second?.Exchange &&
            first?.Board == second?.Board &&
            first?.Type == second?.Type &&
            first?.Side == second?.Side &&
            first?.Condition == second?.Condition &&
            first?.Status == second?.Status &&
            first?.TransTime == second?.TransTime &&
            first?.UpdateTime == second?.UpdateTime &&
            first?.EndTime == second?.EndTime &&
            first?.Error == second?.Error &&
            first?.QtyUnits == second?.QtyUnits &&
            first?.QtyBatch == second?.QtyBatch &&
            first?.Qty == second?.Qty &&
            first?.FilledQtyUnits == second?.FilledQtyUnits &&
            first?.FilledQtyBatch == second?.FilledQtyBatch &&
            first?.Price == second?.Price &&
            first?.AvgPrice == second?.AvgPrice &&
            first?.StopPrice == second?.StopPrice &&
            first?.Existing == second?.Existing &&
            first?.TimeInForce == second?.TimeInForce &&
            first?.Iceberg == second?.Iceberg &&
            first?.Volume == second?.Volume &&
            first?.ProtectingSeconds == second?.ProtectingSeconds;

        public bool Equals(StopOrderSimple? other)
        {
            if (this == (object?)other)
                return true;

            if ((object?)other == null)
                return false;

            if (GetType() != other.GetType())
                return false;

            return EqualsHelper(this, other);
        }

        public override bool Equals(object? obj) => Equals(obj as StopOrderSimple);

        private static bool Equals(StopOrderSimple? first, StopOrderSimple? second) =>
            first?.Equals(second) ?? first == (object?)second;

        public static bool operator ==(StopOrderSimple? first, StopOrderSimple? second) => Equals(first, second);

        public static bool operator !=(StopOrderSimple? first, StopOrderSimple? second) => !Equals(first, second);

        IEnumerable<ValidationResult> IValidatableObject.Validate(ValidationContext validationContext)
        {
            yield break;
        }
    }
}
