using Alor.OpenAPI.Enums;
using SpanJson;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text;

namespace Alor.OpenAPI.Models
{
    [DataContract]
    internal sealed class RequestOrdersActionsLimitTv : IEquatable<RequestOrdersActionsLimitTv>, IValidatableObject
    {
        public RequestOrdersActionsLimitTv() { }

        /// <include file='../XmlDocs/CoreModels.xml' path='Docs/Members[@name="OrdersActionsLimitTV"]/Member[@name="OrdersActionsLimitTV"]/*' />
        [JsonConstructor]
        public RequestOrdersActionsLimitTv(Side side = default, int? quantity = default, decimal? price = default,
            Instrument? instrument = default, string? comment = default, User? user = default,
            TimeInForce timeInForce = default, int? icebergFixed = default, decimal? icebergVariance = default, bool? allowMargin = default)
        {
            Side = side;
            Quantity = quantity;
            Price = price;
            Instrument = instrument;
            Comment = comment;
            User = user;
            TimeInForce = timeInForce;
            IcebergFixed = icebergFixed;
            IcebergVariance = icebergVariance;
            AllowMargin = allowMargin;
        }

        /// <include file='../XmlDocs/CoreModels.xml' path='Docs/Members[@name="OrdersActionsLimitTV"]/Member[@name="side"]/*' />
        [DataMember(Name = "side", EmitDefaultValue = false)]
        public Side Side { get; init; }

        /// <include file='../XmlDocs/CoreModels.xml' path='Docs/Members[@name="OrdersActionsLimitTV"]/Member[@name="quantity"]/*' />
        [DataMember(Name = "quantity", EmitDefaultValue = false)]
        public int? Quantity { get; init; }

        /// <include file='../XmlDocs/CoreModels.xml' path='Docs/Members[@name="OrdersActionsLimitTV"]/Member[@name="price"]/*' />
        [DataMember(Name = "price", EmitDefaultValue = false)]
        public decimal? Price { get; init; }

        /// <include file='../XmlDocs/CoreModels.xml' path='Docs/Members[@name="OrdersActionsLimitTV"]/Member[@name="instrument"]/*' />
        [DataMember(Name = "instrument", EmitDefaultValue = false)]
        public Instrument? Instrument { get; init; }

        /// <include file='../XmlDocs/CoreModels.xml' path='Docs/Members[@name="OrdersActionsLimitTV"]/Member[@name="comment"]/*' />
        [DataMember(Name = "comment", EmitDefaultValue = false)]
        public string? Comment { get; init; }

        /// <include file='../XmlDocs/CoreModels.xml' path='Docs/Members[@name="OrdersActionsLimitTV"]/Member[@name="user"]/*' />
        [DataMember(Name = "user", EmitDefaultValue = false)]
        public User? User { get; init; }

        /// <include file='../XmlDocs/CoreModels.xml' path='Docs/Members[@name="OrdersActionsLimitTV"]/Member[@name="timeInForce"]/*' />
        [DataMember(Name = "timeInForce", EmitDefaultValue = false)]
        public TimeInForce TimeInForce { get; init; }

        /// <include file='../XmlDocs/CoreModels.xml' path='Docs/Members[@name="OrdersActionsLimitTV"]/Member[@name="icebergFixed"]/*' />
        [DataMember(Name = "icebergFixed", EmitDefaultValue = false)]
        public int? IcebergFixed { get; init; }

        /// <include file='../XmlDocs/CoreModels.xml' path='Docs/Members[@name="OrdersActionsLimitTV"]/Member[@name="icebergVariance"]/*' />
        [DataMember(Name = "icebergVariance", EmitDefaultValue = false)]
        public decimal? IcebergVariance { get; init; }

        /// <include file='../XmlDocs/CoreModels.xml' path='Docs/Members[@name="OrdersActionsLimitTV"]/Member[@name="allowMargin"]/*' />
        [DataMember(Name = "allowMargin", EmitDefaultValue = false)]
        public bool? AllowMargin { get; init; }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class OrdersActionsLimitTv {").Append(Environment.NewLine);
            sb.Append("  Side: ").Append(Side).Append(Environment.NewLine);
            sb.Append("  Quantity: ").Append(Quantity).Append(Environment.NewLine);
            sb.Append("  Price: ").Append(Price).Append(Environment.NewLine);
            sb.Append("  Instrument: ").Append(Instrument).Append(Environment.NewLine);
            sb.Append("  Comment: ").Append(Comment).Append(Environment.NewLine);
            sb.Append("  User: ").Append(User).Append(Environment.NewLine);
            sb.Append("  TimeInForce: ").Append(TimeInForce).Append(Environment.NewLine);
            sb.Append("  IcebergFixed: ").Append(IcebergFixed).Append(Environment.NewLine);
            sb.Append("  IcebergVariance: ").Append(IcebergVariance).Append(Environment.NewLine);
            sb.Append("  AllowMargin: ").Append(AllowMargin).Append(Environment.NewLine);
            sb.Append('}').Append(Environment.NewLine);
            return sb.ToString();
        }

        public string ToJson() => Encoding.UTF8.GetString(JsonSerializer.Generic.Utf8.Serialize(this));

        public override int GetHashCode()
        {
            var hash = new HashCode();
            hash.Add(Side);
            hash.Add(Quantity);
            hash.Add(Price);
            hash.Add(Instrument);
            hash.Add(Comment);
            hash.Add(User);
            hash.Add(TimeInForce);
            hash.Add(IcebergFixed);
            hash.Add(IcebergVariance);
            hash.Add(AllowMargin);
            return hash.ToHashCode();
        }

        private static bool EqualsHelper(RequestOrdersActionsLimitTv? first, RequestOrdersActionsLimitTv? second) =>
            first?.Side == second?.Side &&
            first?.Quantity == second?.Quantity &&
            first?.Price == second?.Price &&
            first?.Instrument == second?.Instrument &&
            first?.Comment == second?.Comment &&
            first?.User == second?.User &&
            first?.TimeInForce == second?.TimeInForce &&
            first?.IcebergFixed == second?.IcebergFixed &&
            first?.IcebergVariance == second?.IcebergVariance &&
            first?.AllowMargin == second?.AllowMargin;
        
        public bool Equals(RequestOrdersActionsLimitTv? other)
        {
            if (this == (object?)other)
                return true;

            if ((object?)other == null)
                return false;

            return GetType() == other.GetType() && EqualsHelper(this, other);
        }

        public override bool Equals(object? obj) => Equals(obj as RequestOrdersActionsLimitTv);

        private static bool Equals(RequestOrdersActionsLimitTv? first, RequestOrdersActionsLimitTv? second) =>
            first?.Equals(second) ?? first == (object?)second;

        public static bool operator ==(RequestOrdersActionsLimitTv? first, RequestOrdersActionsLimitTv? second) => Equals(first, second);

        public static bool operator !=(RequestOrdersActionsLimitTv? first, RequestOrdersActionsLimitTv? second) => !Equals(first, second);

        IEnumerable<ValidationResult> IValidatableObject.Validate(ValidationContext validationContext)
        {
            yield break;
        }
    }
}
