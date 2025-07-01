using Alor.OpenAPI.Enums;
using SpanJson;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text;

namespace Alor.OpenAPI.Models
{
    [DataContract]
    internal sealed class RequestOrdersActionsStopLimitTvWarp : IEquatable<RequestOrdersActionsStopLimitTvWarp>,
        IValidatableObject
    {
        public RequestOrdersActionsStopLimitTvWarp() { }

        /// <include file='../XmlDocs/CoreModels.xml' path='Docs/Members[@name="OrdersActionsStopLimitTVWarp"]/Member[@name="OrdersActionsStopLimitTVWarp"]/*' />
        public RequestOrdersActionsStopLimitTvWarp(Side side = default, Condition condition = default,
            decimal? triggerPrice = default, long? stopEndUnixTime = default, decimal? price = default,
            int? quantity = default, Instrument? instrument = default,
            User? user = default, TimeInForce timeInForce = default,
            int? icebergFixed = default, decimal? icebergVariance = default,
            int? protectingSeconds = default, bool? activate = true, bool? allowMargin = default)
        {
            Side = side;
            Condition = condition;
            TriggerPrice = triggerPrice;
            StopEndUnixTime = stopEndUnixTime;
            Price = price;
            Quantity = quantity;
            Instrument = instrument;
            User = user;
            TimeInForce = timeInForce;
            IcebergFixed = icebergFixed;
            IcebergVariance = icebergVariance;
            ProtectingSeconds = protectingSeconds;
            Activate = activate ?? true;
            AllowMargin = allowMargin;
        }

        /// <include file='../XmlDocs/CoreModels.xml' path='Docs/Members[@name="OrdersActionsStopLimitTVWarp"]/Member[@name="side"]/*' />
        [DataMember(Name = "side", EmitDefaultValue = false)]
        public Side Side { get; init; }

        /// <include file='../XmlDocs/CoreModels.xml' path='Docs/Members[@name="OrdersActionsStopLimitTVWarp"]/Member[@name="condition"]/*' />
        [DataMember(Name = "condition", EmitDefaultValue = false)]
        public Condition Condition { get; init; }

        /// <include file='../XmlDocs/CoreModels.xml' path='Docs/Members[@name="OrdersActionsStopLimitTVWarp"]/Member[@name="triggerPrice"]/*' />
        [DataMember(Name = "triggerPrice", EmitDefaultValue = false)]
        public decimal? TriggerPrice { get; init; }

        /// <include file='../XmlDocs/CoreModels.xml' path='Docs/Members[@name="OrdersActionsStopLimitTVWarp"]/Member[@name="stopEndUnixTime"]/*' />
        [DataMember(Name = "stopEndUnixTime", EmitDefaultValue = false)]
        public long? StopEndUnixTime { get; init; }

        /// <include file='../XmlDocs/CoreModels.xml' path='Docs/Members[@name="OrdersActionsStopLimitTVWarp"]/Member[@name="price"]/*' />
        [DataMember(Name = "price", EmitDefaultValue = false)]
        public decimal? Price { get; init; }

        /// <include file='../XmlDocs/CoreModels.xml' path='Docs/Members[@name="OrdersActionsStopLimitTVWarp"]/Member[@name="quantity"]/*' />
        [DataMember(Name = "quantity", EmitDefaultValue = false)]
        public int? Quantity { get; init; }

        /// <include file='../XmlDocs/CoreModels.xml' path='Docs/Members[@name="OrdersActionsStopLimitTVWarp"]/Member[@name="instrument"]/*' />
        [DataMember(Name = "instrument", EmitDefaultValue = false)]
        public Instrument? Instrument { get; init; }

        /// <include file='../XmlDocs/CoreModels.xml' path='Docs/Members[@name="OrdersActionsStopLimitTVWarp"]/Member[@name="user"]/*' />
        [DataMember(Name = "user", EmitDefaultValue = false)]
        public User? User { get; init; }

        /// <include file='../XmlDocs/CoreModels.xml' path='Docs/Members[@name="OrdersActionsStopLimitTVWarp"]/Member[@name="timeInForce"]/*' />
        [DataMember(Name = "timeInForce", EmitDefaultValue = false)]
        public TimeInForce TimeInForce { get; init; }

        /// <include file='../XmlDocs/CoreModels.xml' path='Docs/Members[@name="OrdersActionsStopLimitTVWarp"]/Member[@name="icebergFixed"]/*' />
        [DataMember(Name = "icebergFixed", EmitDefaultValue = false)]
        public int? IcebergFixed { get; init; }

        /// <include file='../XmlDocs/CoreModels.xml' path='Docs/Members[@name="OrdersActionsStopLimitTVWarp"]/Member[@name="icebergVariance"]/*' />
        [DataMember(Name = "icebergVariance", EmitDefaultValue = false)]
        public decimal? IcebergVariance { get; init; }

        /// <include file='../XmlDocs/CoreModels.xml' path='Docs/Members[@name="OrdersActionsStopLimitTVWarp"]/Member[@name="protectingSeconds"]/*' />
        [DataMember(Name = "protectingSeconds", EmitDefaultValue = false)]
        public int? ProtectingSeconds { get; init; }

        /// <include file='../XmlDocs/CoreModels.xml' path='Docs/Members[@name="OrdersActionsStopLimitTVWarp"]/Member[@name="activate"]/*' />
        [DataMember(Name = "activate", EmitDefaultValue = false)]
        public bool? Activate { get; init; }

        /// <include file='../XmlDocs/CoreModels.xml' path='Docs/Members[@name="OrdersActionsStopLimitTVWarp"]/Member[@name="allowMargin"]/*' />
        [DataMember(Name = "allowMargin", EmitDefaultValue = false)]
        public bool? AllowMargin { get; init; }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class OrdersActionsStopLimitTvWarp {").Append(Environment.NewLine);
            sb.Append("  Side: ").Append(Side).Append(Environment.NewLine);
            sb.Append("  Condition: ").Append(Condition).Append(Environment.NewLine);
            sb.Append("  TriggerPrice: ").Append(TriggerPrice).Append(Environment.NewLine);
            sb.Append("  StopEndUnixTime: ").Append(StopEndUnixTime).Append(Environment.NewLine);
            sb.Append("  Price: ").Append(Price).Append(Environment.NewLine);
            sb.Append("  Quantity: ").Append(Quantity).Append(Environment.NewLine);
            sb.Append("  Instrument: ").Append(Instrument).Append(Environment.NewLine);
            sb.Append("  User: ").Append(User).Append(Environment.NewLine);
            sb.Append("  TimeInForce: ").Append(TimeInForce).Append(Environment.NewLine);
            sb.Append("  IcebergFixed: ").Append(IcebergFixed).Append(Environment.NewLine);
            sb.Append("  IcebergVariance: ").Append(IcebergVariance).Append(Environment.NewLine);
            sb.Append("  ProtectingSeconds: ").Append(ProtectingSeconds).Append(Environment.NewLine);
            sb.Append("  Activate: ").Append(Activate).Append(Environment.NewLine);
            sb.Append("  AllowMargin: ").Append(AllowMargin).Append(Environment.NewLine);
            sb.Append('}').Append(Environment.NewLine);
            return sb.ToString();
        }

        public string ToJson() => Encoding.UTF8.GetString(JsonSerializer.Generic.Utf8.Serialize(this));

        public override int GetHashCode()
        {
            var hash = new HashCode();
            hash.Add(Side);
            hash.Add(Condition);
            hash.Add(TriggerPrice);
            hash.Add(StopEndUnixTime);
            hash.Add(Price);
            hash.Add(Quantity);
            hash.Add(Instrument);
            hash.Add(User);
            hash.Add(TimeInForce);
            hash.Add(IcebergFixed);
            hash.Add(IcebergVariance);
            hash.Add(ProtectingSeconds);
            hash.Add(Activate);
            hash.Add(AllowMargin);
            return hash.ToHashCode();
        }

        private static bool EqualsHelper(RequestOrdersActionsStopLimitTvWarp? first,
            RequestOrdersActionsStopLimitTvWarp? second) =>
            first?.Side == second?.Side &&
            first?.Condition == second?.Condition &&
            first?.TriggerPrice == second?.TriggerPrice &&
            first?.StopEndUnixTime == second?.StopEndUnixTime &&
            first?.Price == second?.Price &&
            first?.Quantity == second?.Quantity &&
            first?.Instrument == second?.Instrument &&
            first?.User == second?.User &&
            first?.TimeInForce == second?.TimeInForce &&
            first?.IcebergFixed == second?.IcebergFixed &&
            first?.IcebergVariance == second?.IcebergVariance &&
            first?.ProtectingSeconds == second?.ProtectingSeconds &&
            first?.Activate == second?.Activate &&
            first?.AllowMargin == second?.AllowMargin;

        public bool Equals(RequestOrdersActionsStopLimitTvWarp? other)
        {
            if (this == (object?)other)
                return true;

            if ((object?)other == null)
                return false;

            return GetType() == other.GetType() && EqualsHelper(this, other);
        }

        public override bool Equals(object? obj) => Equals(obj as RequestOrdersActionsStopLimitTvWarp);

        private static bool Equals(RequestOrdersActionsStopLimitTvWarp? first,
            RequestOrdersActionsStopLimitTvWarp? second) =>
            first?.Equals(second) ?? first == (object?)second;

        public static bool operator ==(RequestOrdersActionsStopLimitTvWarp? first,
            RequestOrdersActionsStopLimitTvWarp? second) => Equals(first, second);

        public static bool operator !=(RequestOrdersActionsStopLimitTvWarp? first,
            RequestOrdersActionsStopLimitTvWarp? second) => !Equals(first, second);

        IEnumerable<ValidationResult> IValidatableObject.Validate(ValidationContext validationContext)
        {
            yield break;
        }
    }
}
