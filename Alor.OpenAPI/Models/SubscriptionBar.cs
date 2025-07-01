using Alor.OpenAPI.Enums;
using SpanJson;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text;

namespace Alor.OpenAPI.Models
{
    [DataContract]
    internal sealed class SubscriptionBar : IEquatable<SubscriptionBar>, IValidatableObject
    {
        public SubscriptionBar() { }

        /// <include file='../XmlDocs/CoreModels.xml' path='Docs/Members[@name="wsSubBarsGetAndSubscribe"]/Member[@name="wsSubBarsGetAndSubscribe"]/*' />
        public SubscriptionBar(string? code = default, string? tf = default,
            long? from = default, string? instrumentGroup = default, bool? skipHistory = default,
            bool? splitAdjust = default, CandleSliceMode? sliceMode = default, Exchange exchange = default,
            Format format = default, int? frequency = default, string? guid = default)
        {
            Code = code;
            Tf = tf;
            From = from;
            InstrumentGroup = instrumentGroup;
            SkipHistory = skipHistory;
            SplitAdjust = splitAdjust;
            SliceMode = sliceMode;
            Exchange = exchange;
            Format = format;
            Frequency = frequency;
            Guid = guid;
        }

        /// <include file='../XmlDocs/CoreModels.xml' path='Docs/Members[@name="wsSubBarsGetAndSubscribe"]/Member[@name="opcode"]/*' />
        [DataMember(Name = "opcode", EmitDefaultValue = false)]
        public string? Opcode { get; init; } = "BarsGetAndSubscribe";

        /// <include file='../XmlDocs/CoreModels.xml' path='Docs/Members[@name="wsSubBarsGetAndSubscribe"]/Member[@name="code"]/*' />
        [DataMember(Name = "code", EmitDefaultValue = false)]
        public string? Code { get; init; }

        /// <include file='../XmlDocs/CoreModels.xml' path='Docs/Members[@name="wsSubBarsGetAndSubscribe"]/Member[@name="tf"]/*' />
        [DataMember(Name = "tf", EmitDefaultValue = false)]
        public string? Tf { get; init; }

        /// <include file='../XmlDocs/CoreModels.xml' path='Docs/Members[@name="wsSubBarsGetAndSubscribe"]/Member[@name="from"]/*' />
        [DataMember(Name = "from", EmitDefaultValue = false)]
        public long? From { get; init; }

        /// <include file='../XmlDocs/CoreModels.xml' path='Docs/Members[@name="wsSubBarsGetAndSubscribe"]/Member[@name="instrumentGroup"]/*' />
        [DataMember(Name = "instrumentGroup", EmitDefaultValue = false)]
        public string? InstrumentGroup { get; init; }

        /// <include file='../XmlDocs/CoreModels.xml' path='Docs/Members[@name="wsSubBarsGetAndSubscribe"]/Member[@name="skipHistory"]/*' />
        [DataMember(Name = "skipHistory", EmitDefaultValue = false)]
        public bool? SkipHistory { get; init; }

        /// <include file='../XmlDocs/CoreModels.xml' path='Docs/Members[@name="wsSubBarsGetAndSubscribe"]/Member[@name="splitAdjust"]/*' />
        [DataMember(Name = "splitAdjust", EmitDefaultValue = false)]
        public bool? SplitAdjust { get; init; }

        /// <include file='../XmlDocs/CoreModels.xml' path='Docs/Members[@name="wsSubBarsGetAndSubscribe"]/Member[@name="sliceMode"]/*' />
        [DataMember(Name = "sliceMode", EmitDefaultValue = false)]
        public CandleSliceMode? SliceMode { get; init; }
        
        /// <include file='../XmlDocs/CoreModels.xml' path='Docs/Members[@name="wsSubBarsGetAndSubscribe"]/Member[@name="exchange"]/*' />
        [DataMember(Name = "exchange", EmitDefaultValue = false)]
        public Exchange Exchange { get; init; }

        /// <include file='../XmlDocs/CoreModels.xml' path='Docs/Members[@name="wsSubBarsGetAndSubscribe"]/Member[@name="format"]/*' />
        [DataMember(Name = "format", EmitDefaultValue = false)]
        public Format Format { get; init; }

        /// <include file='../XmlDocs/CoreModels.xml' path='Docs/Members[@name="wsSubBarsGetAndSubscribe"]/Member[@name="frequency"]/*' />
        [DataMember(Name = "frequency", EmitDefaultValue = false)]
        public int? Frequency { get; init; }

        /// <include file='../XmlDocs/CoreModels.xml' path='Docs/Members[@name="wsSubBarsGetAndSubscribe"]/Member[@name="guid"]/*' />
        [DataMember(Name = "guid", EmitDefaultValue = false)]
        public string? Guid { get; init; }

        /// <include file='../XmlDocs/CoreModels.xml' path='Docs/Members[@name="wsSubBarsGetAndSubscribe"]/Member[@name="token"]/*' />
        [DataMember(Name = "token", EmitDefaultValue = false)]
        public string? Token { get; init; } = "JwtToken";

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class SubscriptionBar {").Append(Environment.NewLine);
            sb.Append("  Opcode: ").Append(Opcode).Append(Environment.NewLine);
            sb.Append("  Code: ").Append(Code).Append(Environment.NewLine);
            sb.Append("  Tf: ").Append(Tf).Append(Environment.NewLine);
            sb.Append("  From: ").Append(From).Append(Environment.NewLine);
            sb.Append("  InstrumentGroup: ").Append(InstrumentGroup).Append(Environment.NewLine);
            sb.Append("  SkipHistory: ").Append(SkipHistory).Append(Environment.NewLine);
            sb.Append("  SliceMode: ").Append(SliceMode).Append(Environment.NewLine);
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
            hash.Add(Tf);
            hash.Add(From);
            hash.Add(InstrumentGroup);
            hash.Add(SkipHistory);
            hash.Add(SplitAdjust);
            hash.Add(SliceMode);
            hash.Add(Exchange);
            hash.Add(Format);
            hash.Add(Frequency);
            hash.Add(Guid);
            hash.Add(Token);
            return hash.ToHashCode();
        }

        private static bool EqualsHelper(SubscriptionBar? first, SubscriptionBar? second) =>
            first?.Opcode == second?.Opcode &&
            first?.Code == second?.Code &&
            first?.Tf == second?.Tf &&
            first?.From == second?.From &&
            first?.InstrumentGroup == second?.InstrumentGroup &&
            first?.SkipHistory == second?.SkipHistory &&
            first?.SliceMode == second?.SliceMode &&
            first?.Exchange == second?.Exchange &&
            first?.Format == second?.Format &&
            first?.Frequency == second?.Frequency &&
            first?.Guid == second?.Guid &&
            first?.Token == second?.Token;

        public bool Equals(SubscriptionBar? other)
        {
            if (this == (object?)other)
                return true;

            if ((object?)other == null)
                return false;

            return GetType() == other.GetType() && EqualsHelper(this, other);
        }

        public override bool Equals(object? obj) => Equals(obj as SubscriptionBar);

        private static bool Equals(SubscriptionBar? first, SubscriptionBar? second) =>
            first?.Equals(second) ?? first == (object?)second;

        public static bool operator ==(SubscriptionBar? first, SubscriptionBar? second) => Equals(first, second);

        public static bool operator !=(SubscriptionBar? first, SubscriptionBar? second) => !Equals(first, second);

        IEnumerable<ValidationResult> IValidatableObject.Validate(ValidationContext validationContext)
        {
            yield break;
        }
    }
}
