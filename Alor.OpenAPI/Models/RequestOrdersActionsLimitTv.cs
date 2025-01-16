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
        public RequestOrdersActionsLimitTv(Side side = default, int? quantity = default, decimal? price = default,
            Instrument? instrument = default, string? comment = default, User? user = default,
            TimeInForce timeInForce = default, int? icebergFixed = default, decimal? icebergVariance = default)
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
        }

        /// <include file='../XmlDocs/CoreModels.xml' path='Docs/Members[@name="OrdersActionsLimitTV"]/Member[@name="side"]/*' />
        [DataMember(Name = "side", EmitDefaultValue = false)]
        public Side Side { get; set; }

        /// <include file='../XmlDocs/CoreModels.xml' path='Docs/Members[@name="OrdersActionsLimitTV"]/Member[@name="quantity"]/*' />
        [DataMember(Name = "quantity", EmitDefaultValue = false)]
        public int? Quantity { get; set; }

        /// <include file='../XmlDocs/CoreModels.xml' path='Docs/Members[@name="OrdersActionsLimitTV"]/Member[@name="price"]/*' />
        [DataMember(Name = "price", EmitDefaultValue = false)]
        public decimal? Price { get; set; }

        /// <include file='../XmlDocs/CoreModels.xml' path='Docs/Members[@name="OrdersActionsLimitTV"]/Member[@name="instrument"]/*' />
        [DataMember(Name = "instrument", EmitDefaultValue = false)]
        public Instrument? Instrument { get; set; }

        /// <include file='../XmlDocs/CoreModels.xml' path='Docs/Members[@name="OrdersActionsLimitTV"]/Member[@name="comment"]/*' />
        [DataMember(Name = "comment", EmitDefaultValue = false)]
        public string? Comment { get; set; }

        /// <include file='../XmlDocs/CoreModels.xml' path='Docs/Members[@name="OrdersActionsLimitTV"]/Member[@name="user"]/*' />
        [DataMember(Name = "user", EmitDefaultValue = false)]
        public User? User { get; set; }

        /// <include file='../XmlDocs/CoreModels.xml' path='Docs/Members[@name="OrdersActionsLimitTV"]/Member[@name="timeInForce"]/*' />
        [DataMember(Name = "timeInForce", EmitDefaultValue = false)]
        public TimeInForce TimeInForce { get; set; }

        /// <include file='../XmlDocs/CoreModels.xml' path='Docs/Members[@name="OrdersActionsLimitTV"]/Member[@name="icebergFixed"]/*' />
        [DataMember(Name = "icebergFixed", EmitDefaultValue = false)]
        public int? IcebergFixed { get; set; }

        /// <include file='../XmlDocs/CoreModels.xml' path='Docs/Members[@name="OrdersActionsLimitTV"]/Member[@name="icebergVariance"]/*' />
        [DataMember(Name = "icebergVariance", EmitDefaultValue = false)]
        public decimal? IcebergVariance { get; set; }

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
            sb.Append('}').Append(Environment.NewLine);
            return sb.ToString();
        }

        public string ToJson() => Encoding.UTF8.GetString(JsonSerializer.Generic.Utf8.Serialize(this));

        public override int GetHashCode() => Utilities.Utilities.GetHashCodeHelper(
            [
                Side.GetHashCode(),
                Quantity?.GetHashCode() ?? 0,
                Price?.GetHashCode() ?? 0,
                Instrument?.GetHashCode() ?? 0,
                Comment?.GetHashCode() ?? 0,
                User?.GetHashCode() ?? 0,
                TimeInForce.GetHashCode(),
                IcebergFixed?.GetHashCode() ?? 0,
                IcebergVariance?.GetHashCode() ?? 0,
            ]
        );

        private static bool EqualsHelper(RequestOrdersActionsLimitTv? first, RequestOrdersActionsLimitTv? second) =>
            first?.Side == second?.Side &&
            first?.Quantity == second?.Quantity &&
            first?.Price == second?.Price &&
            first?.Instrument == second?.Instrument &&
            first?.Comment == second?.Comment &&
            first?.User == second?.User &&
            first?.TimeInForce == second?.TimeInForce &&
            first?.IcebergFixed == second?.IcebergFixed &&
            first?.IcebergVariance == second?.IcebergVariance;

        public bool Equals(RequestOrdersActionsLimitTv? other)
        {
            if (this == (object?)other)
                return true;

            if ((object?)other == null)
                return false;

            if (GetType() != other.GetType())
                return false;

            return EqualsHelper(this, other);
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
