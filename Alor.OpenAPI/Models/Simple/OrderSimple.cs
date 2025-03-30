using Alor.OpenAPI.Enums;
using SpanJson;
using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text;
using Type = Alor.OpenAPI.Enums.Type;

namespace Alor.OpenAPI.Models.Simple
{
    [DataContract]
    public sealed class OrderSimple : IEquatable<OrderSimple>, IValidatableObject
    {
        public OrderSimple() { }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseOrder"]/Member[@name="responseOrder"]/*' />
        [JsonConstructor]
        public OrderSimple(string? id = default, string? symbol = default, string? board = default,
            string? brokerSymbol = default,
            string? portfolio = default, Exchange exchange = default, string? comment = default,
            Type type = default, Side side = default, OrderStatus status = default,
            DateTime? transTime = default, DateTime? updateTime = default, DateTime? endTime = default,
            int? qtyUnits = default,
            int? qtyBatch = default, int? qty = default, decimal? filledQtyUnits = default,
            decimal? filledQtyBatch = default, decimal? filled = default,
            decimal? price = default, bool? existing = default,
            TimeInForce timeInForce = default, Iceberg? iceberg = default,
            decimal? volume = default)
        {
            Id = id;
            Symbol = symbol;
            Board = board;
            BrokerSymbol = brokerSymbol;
            Portfolio = portfolio;
            Exchange = exchange;
            Comment = comment;
            Type = type;
            Side = side;
            Status = status;
            TransTime = transTime;
            UpdateTime = updateTime;
            EndTime = endTime;
            QtyUnits = qtyUnits;
            QtyBatch = qtyBatch;
            Qty = qty;
            FilledQtyUnits = filledQtyUnits;
            FilledQtyBatch = filledQtyBatch;
            Filled = filled;
            Price = price;
            Existing = existing;
            TimeInForce = timeInForce;
            Iceberg = iceberg;
            Volume = volume;
        }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseOrder"]/Member[@name="id"]/*' />
        [DataMember(Name = "id", EmitDefaultValue = false)]
        public string? Id { get; init; }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseOrder"]/Member[@name="symbol"]/*' />
        [DataMember(Name = "symbol", EmitDefaultValue = false)]
        public string? Symbol { get; init; }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseOrder"]/Member[@name="board"]/*' />
        [DataMember(Name = "board", EmitDefaultValue = false)]
        public string? Board { get; init; }
        
        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseOrder"]/Member[@name="brokerSymbol"]/*' />
        [DataMember(Name = "brokerSymbol", EmitDefaultValue = false)]
        public string? BrokerSymbol { get; init; }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseOrder"]/Member[@name="portfolio"]/*' />
        [DataMember(Name = "portfolio", EmitDefaultValue = false)]
        public string? Portfolio { get; init; }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseOrder"]/Member[@name="exchange"]/*' />
        [DataMember(Name = "exchange", EmitDefaultValue = false)]
        public Exchange Exchange { get; init; }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseOrder"]/Member[@name="comment"]/*' />
        [DataMember(Name = "comment", EmitDefaultValue = false)]
        public string? Comment { get; init; }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseOrder"]/Member[@name="type"]/*' />
        [DataMember(Name = "type", EmitDefaultValue = false)]
        public Type Type { get; init; }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseOrder"]/Member[@name="side"]/*' />
        [DataMember(Name = "side", EmitDefaultValue = false)]
        public Side Side { get; init; }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseOrder"]/Member[@name="status"]/*' />
        [DataMember(Name = "status", EmitDefaultValue = false)]
        public OrderStatus Status { get; init; }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseOrder"]/Member[@name="transTime"]/*' />
        [DataMember(Name = "transTime", EmitDefaultValue = false)]
        public DateTime? TransTime { get; init; }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseOrder"]/Member[@name="updateTime"]/*' />
        [DataMember(Name = "updateTime", EmitDefaultValue = false)]
        public DateTime? UpdateTime { get; init; }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseOrder"]/Member[@name="endTime"]/*' />
        [DataMember(Name = "endTime", EmitDefaultValue = false)]
        public DateTime? EndTime { get; init; }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseOrder"]/Member[@name="qtyUnits"]/*' />
        [DataMember(Name = "qtyUnits", EmitDefaultValue = false)]
        public int? QtyUnits { get; init; }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseOrder"]/Member[@name="qtyBatch"]/*' />
        [DataMember(Name = "qtyBatch", EmitDefaultValue = false)]
        public int? QtyBatch { get; init; }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseOrder"]/Member[@name="qty"]/*' />
        [DataMember(Name = "qty", EmitDefaultValue = false)]
        public int? Qty { get; init; }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseOrder"]/Member[@name="filledQtyUnits"]/*' />
        [DataMember(Name = "filledQtyUnits", EmitDefaultValue = false)]
        public decimal? FilledQtyUnits { get; init; }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseOrder"]/Member[@name="filledQtyBatch"]/*' />
        [DataMember(Name = "filledQtyBatch", EmitDefaultValue = false)]
        public decimal? FilledQtyBatch { get; init; }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseOrder"]/Member[@name="filled"]/*' />
        [DataMember(Name = "filled", EmitDefaultValue = false)]
        public decimal? Filled { get; init; }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseOrder"]/Member[@name="price"]/*' />
        [DataMember(Name = "price", EmitDefaultValue = false)]
        public decimal? Price { get; init; }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseOrder"]/Member[@name="existing"]/*' />
        [DataMember(Name = "existing", EmitDefaultValue = false)]
        public bool? Existing { get; init; }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseOrder"]/Member[@name="timeInForce"]/*' />
        [DataMember(Name = "timeInForce", EmitDefaultValue = false)]
        public TimeInForce TimeInForce { get; init; }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseOrder"]/Member[@name="iceberg"]/*' />
        [DataMember(Name = "iceberg", EmitDefaultValue = false)]
        public Iceberg? Iceberg { get; init; }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseOrder"]/Member[@name="volume"]/*' />
        [DataMember(Name = "volume", EmitDefaultValue = false)]
        public decimal? Volume { get; init; }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class Order {").Append(Environment.NewLine);
            sb.Append("  Id: ").Append(Id).Append(Environment.NewLine);
            sb.Append("  Symbol: ").Append(Symbol).Append(Environment.NewLine);
            sb.Append("  Board: ").Append(Board).Append(Environment.NewLine);
            sb.Append("  BrokerSymbol: ").Append(BrokerSymbol).Append(Environment.NewLine);
            sb.Append("  Portfolio: ").Append(Portfolio).Append(Environment.NewLine);
            sb.Append("  Exchange: ").Append(Exchange).Append(Environment.NewLine);
            sb.Append("  Comment: ").Append(Comment).Append(Environment.NewLine);
            sb.Append("  Type: ").Append(Type).Append(Environment.NewLine);
            sb.Append("  Side: ").Append(Side).Append(Environment.NewLine);
            sb.Append("  Status: ").Append(Status).Append(Environment.NewLine);
            sb.Append("  TransTime: ").Append(TransTime).Append(Environment.NewLine);
            sb.Append("  UpdateTime: ").Append(UpdateTime).Append(Environment.NewLine);
            sb.Append("  EndTime: ").Append(EndTime).Append(Environment.NewLine);
            sb.Append("  QtyUnits: ").Append(QtyUnits).Append(Environment.NewLine);
            sb.Append("  QtyBatch: ").Append(QtyBatch).Append(Environment.NewLine);
            sb.Append("  Qty: ").Append(Qty).Append(Environment.NewLine);
            sb.Append("  FilledQtyUnits: ").Append(FilledQtyUnits).Append(Environment.NewLine);
            sb.Append("  FilledQtyBatch: ").Append(FilledQtyBatch).Append(Environment.NewLine);
            sb.Append("  Filled: ").Append(Filled).Append(Environment.NewLine);
            sb.Append("  Price: ").Append(Price).Append(Environment.NewLine);
            sb.Append("  Existing: ").Append(Existing).Append(Environment.NewLine);
            sb.Append("  TimeInForce: ").Append(TimeInForce).Append(Environment.NewLine);
            sb.Append("  Iceberg: ").Append(Iceberg).Append(Environment.NewLine);
            sb.Append("  Volume: ").Append(Volume).Append(Environment.NewLine);
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
            hash.Add(BrokerSymbol);
            hash.Add(Portfolio);
            hash.Add(Exchange);
            hash.Add(Comment);
            hash.Add(Type);
            hash.Add(Side);
            hash.Add(Status);
            hash.Add(TransTime);
            hash.Add(UpdateTime);
            hash.Add(EndTime);
            hash.Add(QtyUnits);
            hash.Add(QtyBatch);
            hash.Add(Qty);
            hash.Add(FilledQtyUnits);
            hash.Add(FilledQtyBatch);
            hash.Add(Filled);
            hash.Add(Price);
            hash.Add(Existing);
            hash.Add(TimeInForce);
            hash.Add(Iceberg);
            hash.Add(Volume);
            return hash.ToHashCode();
        }

        private static bool EqualsHelper(OrderSimple? first, OrderSimple? second) =>
            first?.Id == second?.Id &&
            first?.Symbol == second?.Symbol &&
            first?.Board == second?.Board &&
            first?.BrokerSymbol == second?.BrokerSymbol &&
            first?.Portfolio == second?.Portfolio &&
            first?.Exchange == second?.Exchange &&
            first?.Comment == second?.Comment &&
            first?.Type == second?.Type &&
            first?.Side == second?.Side &&
            first?.Status == second?.Status &&
            first?.TransTime == second?.TransTime &&
            first?.UpdateTime == second?.UpdateTime &&
            first?.EndTime == second?.EndTime &&
            first?.QtyUnits == second?.QtyUnits &&
            first?.QtyBatch == second?.QtyBatch &&
            first?.Qty == second?.Qty &&
            first?.FilledQtyUnits == second?.FilledQtyUnits &&
            first?.FilledQtyBatch == second?.FilledQtyBatch &&
            first?.Filled == second?.Filled &&
            first?.Price == second?.Price &&
            first?.Existing == second?.Existing &&
            first?.TimeInForce == second?.TimeInForce &&
            first?.Iceberg == second?.Iceberg &&
            first?.Volume == second?.Volume;
        
        public bool Equals(OrderSimple? other)
        {
            if (this == (object?)other)
                return true;

            if ((object?)other == null)
                return false;

            return GetType() == other.GetType() && EqualsHelper(this, other);
        }

        public override bool Equals(object? obj) => Equals(obj as OrderSimple);

        private static bool Equals(OrderSimple? first, OrderSimple? second) =>
            first?.Equals(second) ?? first == (object?)second;

        public static bool operator ==(OrderSimple? first, OrderSimple? second) => Equals(first, second);

        public static bool operator !=(OrderSimple? first, OrderSimple? second) => !Equals(first, second);

        IEnumerable<ValidationResult> IValidatableObject.Validate(ValidationContext validationContext)
        {
            yield break;
        }
    }
}
