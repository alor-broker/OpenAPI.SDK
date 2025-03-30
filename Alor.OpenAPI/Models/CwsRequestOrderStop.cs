using Alor.OpenAPI.Enums;
using SpanJson;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text;

namespace Alor.OpenAPI.Models
{
    [DataContract]
    internal class CwsRequestOrderStop : IEquatable<CwsRequestOrderStop>, IValidatableObject
    {
        public CwsRequestOrderStop() { }

        /// <include file='../XmlDocs/CoreModels.xml' path='Docs/Members[@name="wsCmdUpdateOrderStop"]/Member[@name="wsCmdUpdateOrderStop"]/*' />
        [JsonConstructor]
        public CwsRequestOrderStop(string? opcode = default, string? guid = default, string? orderId = default,
            Side side = default, Condition condition = default, decimal? triggerPrice = default, long? stopEndUnixTime = default,
            int? quantity = default, Instrument? instrument = default, Exchange? exchange = default,
            string? board = default, User? user = default, bool? checkDuplicates = default,
            int? protectingSeconds = default, bool? activate = true, bool? allowMargin = default)
        {
            Opcode = opcode;
            Guid = guid;
            OrderId = orderId;
            Side = side;
            Condition = condition;
            TriggerPrice = triggerPrice;
            StopEndUnixTime = stopEndUnixTime;
            Quantity = quantity;
            Instrument = instrument;
            Exchange = exchange;
            Board = board;
            User = user;
            CheckDuplicates = checkDuplicates;
            ProtectingSeconds = protectingSeconds;
            Activate = activate ?? true;
            AllowMargin = allowMargin;
        }

        /// <include file='../XmlDocs/CoreModels.xml' path='Docs/Members[@name="wsCmdUpdateOrderStop"]/Member[@name="opcode"]/*' />
        [DataMember(Name = "opcode", EmitDefaultValue = false)]
        public string? Opcode { get; init; }

        /// <include file='../XmlDocs/CoreModels.xml' path='Docs/Members[@name="wsCmdUpdateOrderStop"]/Member[@name="guid"]/*' />
        [DataMember(Name = "guid", EmitDefaultValue = false)]
        public string? Guid { get; init; }

        /// <include file='../XmlDocs/CoreModels.xml' path='Docs/Members[@name="wsCmdUpdateOrderStop"]/Member[@name="orderId"]/*' />
        [DataMember(Name = "orderId", EmitDefaultValue = false)]
        public string? OrderId { get; init; }

        /// <include file='../XmlDocs/CoreModels.xml' path='Docs/Members[@name="wsCmdUpdateOrderStop"]/Member[@name="side"]/*' />
        [DataMember(Name = "side", EmitDefaultValue = false)]
        public Side Side { get; init; }

        /// <include file='../XmlDocs/CoreModels.xml' path='Docs/Members[@name="wsCmdUpdateOrderStop"]/Member[@name="condition"]/*' />
        [DataMember(Name = "condition", EmitDefaultValue = false)]
        public Condition Condition { get; init; }

        /// <include file='../XmlDocs/CoreModels.xml' path='Docs/Members[@name="wsCmdUpdateOrderStop"]/Member[@name="triggerPrice"]/*' />
        [DataMember(Name = "triggerPrice", EmitDefaultValue = false)]
        public decimal? TriggerPrice { get; init; }

        /// <include file='../XmlDocs/CoreModels.xml' path='Docs/Members[@name="wsCmdUpdateOrderStop"]/Member[@name="stopEndUnixTime"]/*' />
        [DataMember(Name = "stopEndUnixTime", EmitDefaultValue = false)]
        public long? StopEndUnixTime { get; init; }

        /// <include file='../XmlDocs/CoreModels.xml' path='Docs/Members[@name="wsCmdUpdateOrderStop"]/Member[@name="quantity"]/*' />
        [DataMember(Name = "quantity", EmitDefaultValue = false)]
        public int? Quantity { get; init; }

        /// <include file='../XmlDocs/CoreModels.xml' path='Docs/Members[@name="wsCmdUpdateOrderStop"]/Member[@name="instrument"]/*' />
        [DataMember(Name = "instrument", EmitDefaultValue = false)]
        public Instrument? Instrument { get; init; }

        /// <include file='../XmlDocs/CoreModels.xml' path='Docs/Members[@name="wsCmdDeleteOrderStop"]/Member[@name="exchange"]/*' />
        [DataMember(Name = "exchange", EmitDefaultValue = false)]
        public Exchange? Exchange { get; init; }

        /// <include file='../XmlDocs/CoreModels.xml' path='Docs/Members[@name="wsCmdUpdateOrderStop"]/Member[@name="board"]/*' />
        [DataMember(Name = "board", EmitDefaultValue = false)]
        public string? Board { get; init; }

        /// <include file='../XmlDocs/CoreModels.xml' path='Docs/Members[@name="wsCmdUpdateOrderStop"]/Member[@name="user"]/*' />
        [DataMember(Name = "user", EmitDefaultValue = false)]
        public User? User { get; init; }

        /// <include file='../XmlDocs/CoreModels.xml' path='Docs/Members[@name="wsCmdUpdateOrderStop"]/Member[@name="checkDuplicates"]/*' />
        [DataMember(Name = "checkDuplicates", EmitDefaultValue = false)]
        public bool? CheckDuplicates { get; init; }

        /// <include file='../XmlDocs/CoreModels.xml' path='Docs/Members[@name="wsCmdUpdateOrderStop"]/Member[@name="protectingSeconds"]/*' />
        [DataMember(Name = "protectingSeconds", EmitDefaultValue = false)]
        public int? ProtectingSeconds { get; init; }

        /// <include file='../XmlDocs/CoreModels.xml' path='Docs/Members[@name="wsCmdUpdateOrderStop"]/Member[@name="activate"]/*' />
        [DataMember(Name = "activate", EmitDefaultValue = false)]
        public bool? Activate { get; init; }

        /// <include file='../XmlDocs/CoreModels.xml' path='Docs/Members[@name="wsCmdUpdateOrderStop"]/Member[@name="allowMargin"]/*' />
        [DataMember(Name = "allowMargin", EmitDefaultValue = false)]
        public bool? AllowMargin { get; init; }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class CwsRequestOrderStop {").Append(Environment.NewLine);
            sb.Append("  Opcode: ").Append(Opcode).Append(Environment.NewLine);
            sb.Append("  Guid: ").Append(Guid).Append(Environment.NewLine);
            sb.Append("  OrderId: ").Append(OrderId).Append(Environment.NewLine);
            sb.Append("  Side: ").Append(Side).Append(Environment.NewLine);
            sb.Append("  Condition: ").Append(Condition).Append(Environment.NewLine);
            sb.Append("  TriggerPrice: ").Append(TriggerPrice).Append(Environment.NewLine);
            sb.Append("  StopEndUnixTime: ").Append(StopEndUnixTime).Append(Environment.NewLine);
            sb.Append("  Quantity: ").Append(Quantity).Append(Environment.NewLine);
            sb.Append("  Instrument: ").Append(Instrument).Append(Environment.NewLine);
            sb.Append("  Exchange: ").Append(Exchange).Append(Environment.NewLine);
            sb.Append("  Board: ").Append(Board).Append(Environment.NewLine);
            sb.Append("  User: ").Append(User).Append(Environment.NewLine);
            sb.Append("  CheckDuplicates: ").Append(CheckDuplicates).Append(Environment.NewLine);
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
            hash.Add(Opcode);
            hash.Add(Guid);
            hash.Add(OrderId);
            hash.Add(Side);
            hash.Add(Condition);
            hash.Add(TriggerPrice);
            hash.Add(StopEndUnixTime);
            hash.Add(Quantity);
            hash.Add(Instrument);
            hash.Add(Exchange);
            hash.Add(Board);
            hash.Add(User);
            hash.Add(CheckDuplicates);
            hash.Add(ProtectingSeconds);
            hash.Add(Activate);
            hash.Add(AllowMargin);
            return hash.ToHashCode();
        }

        private static bool EqualsHelper(CwsRequestOrderStop? first, CwsRequestOrderStop? second) =>
            first?.Opcode == second?.Opcode &&
            first?.Guid == second?.Guid &&
            first?.OrderId == second?.OrderId &&
            first?.Side == second?.Side &&
            first?.Condition == second?.Condition &&
            first?.TriggerPrice == second?.TriggerPrice &&
            first?.StopEndUnixTime == second?.StopEndUnixTime &&
            first?.Quantity == second?.Quantity &&
            first?.Instrument == second?.Instrument &&
            first?.Exchange == second?.Exchange &&
            first?.Board == second?.Board &&
            first?.User == second?.User &&
            first?.CheckDuplicates == second?.CheckDuplicates &&
            first?.ProtectingSeconds == second?.ProtectingSeconds &&
            first?.Activate == second?.Activate &&
            first?.AllowMargin == second?.AllowMargin;

        public bool Equals(CwsRequestOrderStop? other)
        {
            if (this == (object?)other)
                return true;

            if ((object?)other == null)
                return false;

            return GetType() == other.GetType() && EqualsHelper(this, other);
        }

        public override bool Equals(object? obj) => Equals(obj as CwsRequestOrderStop);

        private static bool Equals(CwsRequestOrderStop? first, CwsRequestOrderStop? second) =>
            first?.Equals(second) ?? first == (object?)second;

        public static bool operator ==(CwsRequestOrderStop? first, CwsRequestOrderStop? second) =>
            Equals(first, second);

        public static bool operator !=(CwsRequestOrderStop? first, CwsRequestOrderStop? second) =>
            !Equals(first, second);

        IEnumerable<ValidationResult> IValidatableObject.Validate(ValidationContext validationContext)
        {
            yield break;
        }
    }
}
