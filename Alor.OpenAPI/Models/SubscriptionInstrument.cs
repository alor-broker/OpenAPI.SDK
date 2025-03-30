using Alor.OpenAPI.Enums;
using SpanJson;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text;

namespace Alor.OpenAPI.Models
{
    [DataContract]
    internal sealed class SubscriptionInstrument : IEquatable<SubscriptionInstrument>, IValidatableObject
    {
        public SubscriptionInstrument() { }

        /// <include file='../XmlDocs/CoreModels.xml' path='Docs/Members[@name="wsSubInstrumentsGetAndSubscribeV2"]/Member[@name="wsSubInstrumentsGetAndSubscribeV2"]/*' />
        [JsonConstructor]
        public SubscriptionInstrument(string? code = default, string? instrumentGroup = default,
            Exchange exchange = default, Format format = default, int? frequency = default, string? guid = default)
        {
            Code = code;
            InstrumentGroup = instrumentGroup;
            Exchange = exchange;
            Format = format;
            Frequency = frequency;
            Guid = guid;
        }

        /// <include file='../XmlDocs/CoreModels.xml' path='Docs/Members[@name="wsSubInstrumentsGetAndSubscribeV2"]/Member[@name="opcode"]/*' />
        [DataMember(Name = "opcode", EmitDefaultValue = false)]
        public string? Opcode { get; init; } = "InstrumentsGetAndSubscribeV2";

        /// <include file='../XmlDocs/CoreModels.xml' path='Docs/Members[@name="wsSubInstrumentsGetAndSubscribeV2"]/Member[@name="code"]/*' />
        [DataMember(Name = "code", EmitDefaultValue = false)]
        public string? Code { get; init; }

        /// <include file='../XmlDocs/CoreModels.xml' path='Docs/Members[@name="wsSubInstrumentsGetAndSubscribeV2"]/Member[@name="instrumentGroup"]/*' />
        [DataMember(Name = "instrumentGroup", EmitDefaultValue = false)]
        public string? InstrumentGroup { get; init; }

        /// <include file='../XmlDocs/CoreModels.xml' path='Docs/Members[@name="wsSubInstrumentsGetAndSubscribeV2"]/Member[@name="exchange"]/*' />
        [DataMember(Name = "exchange", EmitDefaultValue = false)]
        public Exchange Exchange { get; init; }

        /// <include file='../XmlDocs/CoreModels.xml' path='Docs/Members[@name="wsSubInstrumentsGetAndSubscribeV2"]/Member[@name="format"]/*' />
        [DataMember(Name = "format", EmitDefaultValue = false)]
        public Format Format { get; init; }

        /// <include file='../XmlDocs/CoreModels.xml' path='Docs/Members[@name="wsSubInstrumentsGetAndSubscribeV2"]/Member[@name="frequency"]/*' />
        [DataMember(Name = "frequency", EmitDefaultValue = false)]
        public int? Frequency { get; init; }

        /// <include file='../XmlDocs/CoreModels.xml' path='Docs/Members[@name="wsSubInstrumentsGetAndSubscribeV2"]/Member[@name="guid"]/*' />
        [DataMember(Name = "guid", EmitDefaultValue = false)]
        public string? Guid { get; init; }

        /// <include file='../XmlDocs/CoreModels.xml' path='Docs/Members[@name="wsSubInstrumentsGetAndSubscribeV2"]/Member[@name="token"]/*' />
        [DataMember(Name = "token", EmitDefaultValue = false)]
        public string? Token { get; init; } = "JwtToken";
        
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class SubscriptionInstrument {").Append(Environment.NewLine);
            sb.Append("  Opcode: ").Append(Opcode).Append(Environment.NewLine);
            sb.Append("  Code: ").Append(Code).Append(Environment.NewLine);
            sb.Append("  InstrumentGroup: ").Append(InstrumentGroup).Append(Environment.NewLine);
            sb.Append("  Exchange: ").Append(Exchange).Append(Environment.NewLine);
            sb.Append("  Format: ").Append(Format).Append(Environment.NewLine);
            sb.Append("  Frequency: ").Append(Frequency).Append(Environment.NewLine);
            sb.Append("  Guid: ").Append(Guid).Append(Environment.NewLine);
            sb.Append("  Token: ").Append(Token).Append(Environment.NewLine);
            sb.Append('}').Append(Environment.NewLine);
            return sb.ToString();
        }

        public string ToJson() => Encoding.UTF8.GetString(JsonSerializer.Generic.Utf8.Serialize(this));

        public override int GetHashCode() =>
            HashCode.Combine(Opcode, Code, InstrumentGroup, Exchange, Format, Frequency, Guid, Token);

        private static bool EqualsHelper(SubscriptionInstrument? first, SubscriptionInstrument? second) =>
            first?.Opcode == second?.Opcode &&
            first?.Code == second?.Code &&
            first?.InstrumentGroup == second?.InstrumentGroup &&
            first?.Exchange == second?.Exchange &&
            first?.Format == second?.Format &&
            first?.Frequency == second?.Frequency &&
            first?.Guid == second?.Guid &&
            first?.Token == second?.Token;

        public bool Equals(SubscriptionInstrument? other)
        {
            if (this == (object?)other)
                return true;

            if ((object?)other == null)
                return false;

            return GetType() == other.GetType() && EqualsHelper(this, other);
        }

        public override bool Equals(object? obj) => Equals(obj as SubscriptionInstrument);

        private static bool Equals(SubscriptionInstrument? first, SubscriptionInstrument? second) =>
            first?.Equals(second) ?? first == (object?)second;

        public static bool operator ==(SubscriptionInstrument? first, SubscriptionInstrument? second) => Equals(first, second);

        public static bool operator !=(SubscriptionInstrument? first, SubscriptionInstrument? second) => !Equals(first, second);

        IEnumerable<ValidationResult> IValidatableObject.Validate(ValidationContext validationContext)
        {
            yield break;
        }
    }
}
