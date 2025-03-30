using Alor.OpenAPI.Enums;
using SpanJson;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text;

namespace Alor.OpenAPI.Models
{
    [DataContract]
    internal sealed class SubscriptionAllTrade : IEquatable<SubscriptionAllTrade>, IValidatableObject
    {
        public SubscriptionAllTrade() { }

        /// <include file='../XmlDocs/CoreModels.xml' path='Docs/Members[@name="wsSubAllTradesGetAndSubscribe"]/Member[@name="wsSubAllTradesGetAndSubscribe"]/*' />
        [JsonConstructor]
        public SubscriptionAllTrade(string? code = default, int? depth = default, bool? includeVirtualTrades = default,
            string? instrumentGroup = default, Exchange exchange = default, Format format = default,
            int? frequency = default, string? guid = default)
        {
            Code = code;
            Depth = depth;
            IncludeVirtualTrades = includeVirtualTrades;
            InstrumentGroup = instrumentGroup;
            Exchange = exchange;
            Format = format;
            Frequency = frequency;
            Guid = guid;
        }

        /// <include file='../XmlDocs/CoreModels.xml' path='Docs/Members[@name="wsSubAllTradesGetAndSubscribe"]/Member[@name="opcode"]/*' />
        [DataMember(Name = "opcode", EmitDefaultValue = false)]
        public string? Opcode { get; init; } = "AllTradesGetAndSubscribe";

        /// <include file='../XmlDocs/CoreModels.xml' path='Docs/Members[@name="wsSubAllTradesGetAndSubscribe"]/Member[@name="code"]/*' />
        [DataMember(Name = "code", EmitDefaultValue = false)]
        public string? Code { get; init; }

        /// <include file='../XmlDocs/CoreModels.xml' path='Docs/Members[@name="wsSubAllTradesGetAndSubscribe"]/Member[@name="depth"]/*' />
        [DataMember(Name = "depth", EmitDefaultValue = false)]
        public int? Depth { get; init; }

        /// <include file='../XmlDocs/CoreModels.xml' path='Docs/Members[@name="wsSubAllTradesGetAndSubscribe"]/Member[@name="includeVirtualTrades"]/*' />
        [DataMember(Name = "includeVirtualTrades", EmitDefaultValue = false)]
        public bool? IncludeVirtualTrades { get; init; }

        /// <include file='../XmlDocs/CoreModels.xml' path='Docs/Members[@name="wsSubAllTradesGetAndSubscribe"]/Member[@name="instrumentGroup"]/*' />
        [DataMember(Name = "instrumentGroup", EmitDefaultValue = false)]
        public string? InstrumentGroup { get; init; }

        /// <include file='../XmlDocs/CoreModels.xml' path='Docs/Members[@name="wsSubAllTradesGetAndSubscribe"]/Member[@name="exchange"]/*' />
        [DataMember(Name = "exchange", EmitDefaultValue = false)]
        public Exchange Exchange { get; init; }

        /// <include file='../XmlDocs/CoreModels.xml' path='Docs/Members[@name="wsSubAllTradesGetAndSubscribe"]/Member[@name="format"]/*' />
        [DataMember(Name = "format", EmitDefaultValue = false)]
        public Format Format { get; init; }

        /// <include file='../XmlDocs/CoreModels.xml' path='Docs/Members[@name="wsSubAllTradesGetAndSubscribe"]/Member[@name="frequency"]/*' />
        [DataMember(Name = "frequency", EmitDefaultValue = false)]
        public int? Frequency { get; init; }

        /// <include file='../XmlDocs/CoreModels.xml' path='Docs/Members[@name="wsSubAllTradesGetAndSubscribe"]/Member[@name="guid"]/*' />
        [DataMember(Name = "guid", EmitDefaultValue = false)]
        public string? Guid { get; init; }

        /// <include file='../XmlDocs/CoreModels.xml' path='Docs/Members[@name="wsSubAllTradesGetAndSubscribe"]/Member[@name="token"]/*' />
        [DataMember(Name = "token", EmitDefaultValue = false)]
        public string? Token { get; init; } = "JwtToken";

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class SubscriptionAllTrade {").Append(Environment.NewLine);
            sb.Append("  Opcode: ").Append(Opcode).Append(Environment.NewLine);
            sb.Append("  Code: ").Append(Code).Append(Environment.NewLine);
            sb.Append("  Depth: ").Append(Depth).Append(Environment.NewLine);
            sb.Append("  IncludeVirtualTrades: ").Append(IncludeVirtualTrades).Append(Environment.NewLine);
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

        public override int GetHashCode()
        {
            var hash = new HashCode();
            hash.Add(Opcode);
            hash.Add(Code);
            hash.Add(Depth);
            hash.Add(IncludeVirtualTrades);
            hash.Add(InstrumentGroup);
            hash.Add(Exchange);
            hash.Add(Format);
            hash.Add(Frequency);
            hash.Add(Guid);
            hash.Add(Token);
            return hash.ToHashCode();
        }

        private static bool EqualsHelper(SubscriptionAllTrade? first, SubscriptionAllTrade? second) =>
            first?.Opcode == second?.Opcode &&
            first?.Code == second?.Code &&
            first?.Depth == second?.Depth &&
            first?.IncludeVirtualTrades == second?.IncludeVirtualTrades &&
            first?.InstrumentGroup == second?.InstrumentGroup &&
            first?.Exchange == second?.Exchange &&
            first?.Format == second?.Format &&
            first?.Frequency == second?.Frequency &&
            first?.Guid == second?.Guid &&
            first?.Token == second?.Token;

        public bool Equals(SubscriptionAllTrade? other)
        {
            if (this == (object?)other)
                return true;

            if ((object?)other == null)
                return false;

            return GetType() == other.GetType() && EqualsHelper(this, other);
        }

        public override bool Equals(object? obj) => Equals(obj as SubscriptionAllTrade);

        private static bool Equals(SubscriptionAllTrade? first, SubscriptionAllTrade? second) =>
            first?.Equals(second) ?? first == (object?)second;

        public static bool operator ==(SubscriptionAllTrade? first, SubscriptionAllTrade? second) => Equals(first, second);

        public static bool operator !=(SubscriptionAllTrade? first, SubscriptionAllTrade? second) => !Equals(first, second);

        IEnumerable<ValidationResult> IValidatableObject.Validate(ValidationContext validationContext)
        {
            yield break;
        }
    }
}
