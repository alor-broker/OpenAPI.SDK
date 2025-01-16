using Alor.OpenAPI.Enums;
using SpanJson;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text;

namespace Alor.OpenAPI.Models
{
    [DataContract]
    internal sealed class
        RequestOrdersActionsStopMarketTvWarp : IEquatable<RequestOrdersActionsStopMarketTvWarp>,
        IValidatableObject
    {
        public RequestOrdersActionsStopMarketTvWarp() { }

        /// <include file='../XmlDocs/CoreModels.xml' path='Docs/Members[@name="OrdersActionsStopMarketTVWarp"]/Member[@name="OrdersActionsStopMarketTVWarp"]/*' />
        public RequestOrdersActionsStopMarketTvWarp(Side side = default, Condition condition = default,
            decimal? triggerPrice = default, long? stopEndUnixTime = default,
            int? quantity = default, Instrument? instrument = default, User? user = default, int? protectingSeconds = null, bool? activate = true)
        {
            Side = side;
            Condition = condition;
            TriggerPrice = triggerPrice;
            StopEndUnixTime = stopEndUnixTime;
            Quantity = quantity;
            Instrument = instrument;
            User = user;
            ProtectingSeconds = protectingSeconds;
            Activate = activate ?? true;
        }

        /// <include file='../XmlDocs/CoreModels.xml' path='Docs/Members[@name="OrdersActionsStopMarketTVWarp"]/Member[@name="side"]/*' />
        [DataMember(Name = "side", EmitDefaultValue = false)]
        public Side Side { get; private set; }

        /// <include file='../XmlDocs/CoreModels.xml' path='Docs/Members[@name="OrdersActionsStopMarketTVWarp"]/Member[@name="condition"]/*' />
        [DataMember(Name = "condition", EmitDefaultValue = false)]
        public Condition Condition { get; private set; }

        /// <include file='../XmlDocs/CoreModels.xml' path='Docs/Members[@name="OrdersActionsStopMarketTVWarp"]/Member[@name="triggerPrice"]/*' />
        [DataMember(Name = "triggerPrice", EmitDefaultValue = false)]
        public decimal? TriggerPrice { get; private set; }

        /// <include file='../XmlDocs/CoreModels.xml' path='Docs/Members[@name="OrdersActionsStopMarketTVWarp"]/Member[@name="stopEndUnixTime"]/*' />
        [DataMember(Name = "stopEndUnixTime", EmitDefaultValue = false)]
        public long? StopEndUnixTime { get; private set; }

        /// <include file='../XmlDocs/CoreModels.xml' path='Docs/Members[@name="OrdersActionsStopMarketTVWarp"]/Member[@name="quantity"]/*' />
        [DataMember(Name = "quantity", EmitDefaultValue = false)]
        public int? Quantity { get; private set; }

        /// <include file='../XmlDocs/CoreModels.xml' path='Docs/Members[@name="OrdersActionsStopMarketTVWarp"]/Member[@name="instrument"]/*' />
        [DataMember(Name = "instrument", EmitDefaultValue = false)]
        public Instrument? Instrument { get; private set; }

        /// <include file='../XmlDocs/CoreModels.xml' path='Docs/Members[@name="OrdersActionsStopMarketTVWarp"]/Member[@name="user"]/*' />
        [DataMember(Name = "user", EmitDefaultValue = false)]
        public User? User { get; private set; }

        /// <include file='../XmlDocs/CoreModels.xml' path='Docs/Members[@name="OrdersActionsStopMarketTVWarp"]/Member[@name="protectingSeconds"]/*' />
        [DataMember(Name = "protectingSeconds", EmitDefaultValue = false)]
        public int? ProtectingSeconds { get; set; }

        /// <include file='../XmlDocs/CoreModels.xml' path='Docs/Members[@name="OrdersActionsStopMarketTVWarp"]/Member[@name="activate"]/*' />
        [DataMember(Name = "activate", EmitDefaultValue = false)]
        public bool? Activate { get; private set; }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class OrdersActionsStopMarketTvWarp {").Append(Environment.NewLine);
            sb.Append("  Side: ").Append(Side).Append(Environment.NewLine);
            sb.Append("  Condition: ").Append(Condition).Append(Environment.NewLine);
            sb.Append("  TriggerPrice: ").Append(TriggerPrice).Append(Environment.NewLine);
            sb.Append("  StopEndUnixTime: ").Append(StopEndUnixTime).Append(Environment.NewLine);
            sb.Append("  Quantity: ").Append(Quantity).Append(Environment.NewLine);
            sb.Append("  Instrument: ").Append(Instrument).Append(Environment.NewLine);
            sb.Append("  User: ").Append(User).Append(Environment.NewLine);
            sb.Append("  ProtectingSeconds: ").Append(ProtectingSeconds).Append(Environment.NewLine);
            sb.Append("  Activate: ").Append(Activate).Append(Environment.NewLine);
            sb.Append('}').Append(Environment.NewLine);
            return sb.ToString();
        }

        public string ToJson() => Encoding.UTF8.GetString(JsonSerializer.Generic.Utf8.Serialize(this));

        public override int GetHashCode() => Utilities.Utilities.GetHashCodeHelper(
            [
                Side.GetHashCode(),
                Condition.GetHashCode(),
                TriggerPrice?.GetHashCode() ?? 0,
                StopEndUnixTime?.GetHashCode() ?? 0,
                Quantity?.GetHashCode() ?? 0,
                Instrument?.GetHashCode() ?? 0,
                User?.GetHashCode() ?? 0,
                ProtectingSeconds?.GetHashCode() ?? 0,
                Activate?.GetHashCode() ?? 0,
            ]
        );

        private static bool EqualsHelper(RequestOrdersActionsStopMarketTvWarp? first,
            RequestOrdersActionsStopMarketTvWarp? second) =>
            first?.Side == second?.Side &&
            first?.Condition == second?.Condition &&
            first?.TriggerPrice == second?.TriggerPrice &&
            first?.StopEndUnixTime == second?.StopEndUnixTime &&
            first?.Quantity == second?.Quantity &&
            first?.Instrument == second?.Instrument &&
            first?.User == second?.User &&
            first?.ProtectingSeconds == second?.ProtectingSeconds &&
            first?.Activate == second?.Activate;

        public bool Equals(RequestOrdersActionsStopMarketTvWarp? other)
        {
            if (this == (object?)other)
                return true;

            if ((object?)other == null)
                return false;

            if (GetType() != other.GetType())
                return false;

            return EqualsHelper(this, other);
        }

        public override bool Equals(object? obj) => Equals(obj as RequestOrdersActionsStopMarketTvWarp);

        private static bool Equals(RequestOrdersActionsStopMarketTvWarp? first,
            RequestOrdersActionsStopMarketTvWarp? second) =>
            first?.Equals(second) ?? first == (object?)second;

        public static bool operator ==(RequestOrdersActionsStopMarketTvWarp? first,
            RequestOrdersActionsStopMarketTvWarp? second) => Equals(first, second);

        public static bool operator !=(RequestOrdersActionsStopMarketTvWarp? first,
            RequestOrdersActionsStopMarketTvWarp? second) => !Equals(first, second);

        IEnumerable<ValidationResult> IValidatableObject.Validate(ValidationContext validationContext)
        {
            yield break;
        }
    }
}
