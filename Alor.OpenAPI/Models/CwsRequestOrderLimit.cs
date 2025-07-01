using Alor.OpenAPI.Enums;
using SpanJson;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text;

namespace Alor.OpenAPI.Models
{
    [DataContract]
    internal sealed class CwsRequestOrderLimit : IEquatable<CwsRequestOrderLimit>, IValidatableObject
    {
        public CwsRequestOrderLimit() { }

        /// <include file='../XmlDocs/CoreModels.xml' path='Docs/Members[@name="wsCmdUpdateOrderLimit"]/Member[@name="wsCmdUpdateOrderLimit"]/*' />
        public CwsRequestOrderLimit(string? opcode = default, string? guid = default, string? orderId = default,
            Side side = default, int? quantity = default, decimal? price = default, Instrument? instrument = default,
            Exchange? exchange = default, string? comment = default, string? board = default, User? user = default,
            TimeInForce timeInForce = default, int? icebergFixed = default, decimal? icebergVariance = default,
            bool? checkDuplicates = default, bool? allowMargin = default)
        {
            Opcode = opcode;
            Guid = guid;
            OrderId = orderId;
            Side = side;
            Quantity = quantity;
            Price = price;
            Instrument = instrument;
            Exchange = exchange;
            Comment = comment;
            Board = board;
            User = user;
            TimeInForce = timeInForce;
            IcebergFixed = icebergFixed;
            IcebergVariance = icebergVariance;
            CheckDuplicates = checkDuplicates;
            AllowMargin = allowMargin;
        }

        /// <include file='../XmlDocs/CoreModels.xml' path='Docs/Members[@name="wsCmdUpdateOrderLimit"]/Member[@name="opcode"]/*' />
        [DataMember(Name = "opcode", EmitDefaultValue = false)]
        public string? Opcode { get; init; }

        /// <include file='../XmlDocs/CoreModels.xml' path='Docs/Members[@name="wsCmdUpdateOrderLimit"]/Member[@name="guid"]/*' />
        [DataMember(Name = "guid", EmitDefaultValue = false)]
        public string? Guid { get; init; }

        /// <include file='../XmlDocs/CoreModels.xml' path='Docs/Members[@name="wsCmdUpdateOrderLimit"]/Member[@name="orderId"]/*' />
        [DataMember(Name = "orderId", EmitDefaultValue = false)]
        public string? OrderId { get; init; }

        /// <include file='../XmlDocs/CoreModels.xml' path='Docs/Members[@name="wsCmdUpdateOrderLimit"]/Member[@name="side"]/*' />
        [DataMember(Name = "side", EmitDefaultValue = false)]
        public Side Side { get; init; }

        /// <include file='../XmlDocs/CoreModels.xml' path='Docs/Members[@name="wsCmdUpdateOrderLimit"]/Member[@name="quantity"]/*' />
        [DataMember(Name = "quantity", EmitDefaultValue = false)]
        public int? Quantity { get; init; }

        /// <include file='../XmlDocs/CoreModels.xml' path='Docs/Members[@name="wsCmdUpdateOrderLimit"]/Member[@name="price"]/*' />
        [DataMember(Name = "price", EmitDefaultValue = false)]
        public decimal? Price { get; init; }

        /// <include file='../XmlDocs/CoreModels.xml' path='Docs/Members[@name="wsCmdUpdateOrderLimit"]/Member[@name="instrument"]/*' />
        [DataMember(Name = "instrument", EmitDefaultValue = false)]
        public Instrument? Instrument { get; init; }

        /// <include file='../XmlDocs/CoreModels.xml' path='Docs/Members[@name="wsCmdDeleteOrderLimit"]/Member[@name="exchange"]/*' />
        [DataMember(Name = "exchange", EmitDefaultValue = false)]
        public Exchange? Exchange { get; init; }

        /// <include file='../XmlDocs/CoreModels.xml' path='Docs/Members[@name="wsCmdUpdateOrderLimit"]/Member[@name="comment"]/*' />
        [DataMember(Name = "comment", EmitDefaultValue = false)]
        public string? Comment { get; init; }

        /// <include file='../XmlDocs/CoreModels.xml' path='Docs/Members[@name="wsCmdUpdateOrderLimit"]/Member[@name="board"]/*' />
        [DataMember(Name = "board", EmitDefaultValue = false)]
        public string? Board { get; init; }

        /// <include file='../XmlDocs/CoreModels.xml' path='Docs/Members[@name="wsCmdUpdateOrderLimit"]/Member[@name="user"]/*' />
        [DataMember(Name = "user", EmitDefaultValue = false)]
        public User? User { get; init; }

        /// <include file='../XmlDocs/CoreModels.xml' path='Docs/Members[@name="wsCmdUpdateOrderLimit"]/Member[@name="timeInForce"]/*' />
        [DataMember(Name = "timeInForce", EmitDefaultValue = false)]
        public TimeInForce TimeInForce { get; init; }

        /// <include file='../XmlDocs/CoreModels.xml' path='Docs/Members[@name="wsCmdUpdateOrderLimit"]/Member[@name="icebergFixed"]/*' />
        [DataMember(Name = "icebergFixed", EmitDefaultValue = false)]
        public int? IcebergFixed { get; init; }

        /// <include file='../XmlDocs/CoreModels.xml' path='Docs/Members[@name="wsCmdUpdateOrderLimit"]/Member[@name="icebergVariance"]/*' />
        [DataMember(Name = "icebergVariance", EmitDefaultValue = false)]
        public decimal? IcebergVariance { get; init; }

        /// <include file='../XmlDocs/CoreModels.xml' path='Docs/Members[@name="wsCmdUpdateOrderLimit"]/Member[@name="checkDuplicates"]/*' />
        [DataMember(Name = "checkDuplicates", EmitDefaultValue = false)]
        public bool? CheckDuplicates { get; init; }

        /// <include file='../XmlDocs/CoreModels.xml' path='Docs/Members[@name="wsCmdUpdateOrderLimit"]/Member[@name="allowMargin"]/*' />
        [DataMember(Name = "allowMargin", EmitDefaultValue = false)]
        public bool? AllowMargin { get; init; }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class CwsRequestOrderLimit {").Append(Environment.NewLine);
            sb.Append("  Opcode: ").Append(Opcode).Append(Environment.NewLine);
            sb.Append("  Guid: ").Append(Guid).Append(Environment.NewLine);
            sb.Append("  OrderId: ").Append(OrderId).Append(Environment.NewLine);
            sb.Append("  Side: ").Append(Side).Append(Environment.NewLine);
            sb.Append("  Quantity: ").Append(Quantity).Append(Environment.NewLine);
            sb.Append("  Price: ").Append(Price).Append(Environment.NewLine);
            sb.Append("  Instrument: ").Append(Instrument).Append(Environment.NewLine);
            sb.Append("  Exchange: ").Append(Exchange).Append(Environment.NewLine);
            sb.Append("  Comment: ").Append(Comment).Append(Environment.NewLine);
            sb.Append("  Board: ").Append(Board).Append(Environment.NewLine);
            sb.Append("  User: ").Append(User).Append(Environment.NewLine);
            sb.Append("  TimeInForce: ").Append(TimeInForce).Append(Environment.NewLine);
            sb.Append("  IcebergFixed: ").Append(IcebergFixed).Append(Environment.NewLine);
            sb.Append("  IcebergVariance: ").Append(IcebergVariance).Append(Environment.NewLine);
            sb.Append("  CheckDuplicates: ").Append(CheckDuplicates).Append(Environment.NewLine);
            sb.Append("  AllowMargin: ").Append(AllowMargin).Append(Environment.NewLine);
            sb.Append('}').Append(Environment.NewLine);
            return sb.ToString();
        }

        public string ToJson() => Encoding.UTF8.GetString(JsonSerializer.Generic.Utf8.Serialize(this));

        public override int GetHashCode()
        {
            var hash = new HashCode();
            hash.Add(Opcode);
            hash.Add(Guid);
            hash.Add(OrderId);
            hash.Add(Side);
            hash.Add(Quantity);
            hash.Add(Price);
            hash.Add(Instrument);
            hash.Add(Exchange);
            hash.Add(Comment);
            hash.Add(Board);
            hash.Add(User);
            hash.Add(TimeInForce);
            hash.Add(IcebergFixed);
            hash.Add(IcebergVariance);
            hash.Add(CheckDuplicates);
            hash.Add(AllowMargin);
            return hash.ToHashCode();
        }

        private static bool EqualsHelper(CwsRequestOrderLimit? first, CwsRequestOrderLimit? second) =>
            first?.Opcode == second?.Opcode &&
            first?.Guid == second?.Guid &&
            first?.OrderId == second?.OrderId &&
            first?.Side == second?.Side &&
            first?.Quantity == second?.Quantity &&
            first?.Price == second?.Price &&
            first?.Instrument == second?.Instrument &&
            first?.Exchange == second?.Exchange &&
            first?.Comment == second?.Comment &&
            first?.Board == second?.Board &&
            first?.User == second?.User &&
            first?.TimeInForce == second?.TimeInForce &&
            first?.IcebergFixed == second?.IcebergFixed &&
            first?.IcebergVariance == second?.IcebergVariance &&
            first?.CheckDuplicates == second?.CheckDuplicates &&
            first?.AllowMargin == second?.AllowMargin;

        public bool Equals(CwsRequestOrderLimit? other)
        {
            if (this == (object?)other)
                return true;

            if ((object?)other == null)
                return false;

            return GetType() == other.GetType() && EqualsHelper(this, other);
        }

        public override bool Equals(object? obj) => Equals(obj as CwsRequestOrderLimit);

        private static bool Equals(CwsRequestOrderLimit? first, CwsRequestOrderLimit? second) =>
            first?.Equals(second) ?? first == (object?)second;

        public static bool operator ==(CwsRequestOrderLimit? first, CwsRequestOrderLimit? second) => Equals(first, second);

        public static bool operator !=(CwsRequestOrderLimit? first, CwsRequestOrderLimit? second) => !Equals(first, second);

        IEnumerable<ValidationResult> IValidatableObject.Validate(ValidationContext validationContext)
        {
            yield break;
        }
    }
}
