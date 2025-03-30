﻿using Alor.OpenAPI.Enums;
using SpanJson;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text;

namespace Alor.OpenAPI.Models
{
    [DataContract]
    internal sealed class SubscriptionSummary : IEquatable<SubscriptionSummary>, IValidatableObject
    {
        public SubscriptionSummary() { }

        /// <include file='../XmlDocs/CoreModels.xml' path='Docs/Members[@name="wsSubSummariesGetAndSubscribeV2"]/Member[@name="wsSubSummariesGetAndSubscribeV2"]/*' />
        [JsonConstructor]
        public SubscriptionSummary(string? portfolio = default, bool? skipHistory = default, 
            Exchange exchange = default, Format format = default, int? frequency = default,
            string? guid = default)
        {
            Portfolio = portfolio;
            SkipHistory = skipHistory;
            Exchange = exchange;
            Format = format;
            Frequency = frequency;
            Guid = guid;
        }

        /// <include file='../XmlDocs/CoreModels.xml' path='Docs/Members[@name="wsSubSummariesGetAndSubscribeV2"]/Member[@name="opcode"]/*' />
        [DataMember(Name = "opcode", EmitDefaultValue = false)]
        public string? Opcode { get; init; } = "SummariesGetAndSubscribeV2";

        /// <include file='../XmlDocs/CoreModels.xml' path='Docs/Members[@name="wsSubSummariesGetAndSubscribeV2"]/Member[@name="portfolio"]/*' />
        [DataMember(Name = "portfolio", EmitDefaultValue = false)]
        public string? Portfolio { get; init; }

        /// <include file='../XmlDocs/CoreModels.xml' path='Docs/Members[@name="wsSubSummariesGetAndSubscribeV2"]/Member[@name="skipHistory"]/*' />
        [DataMember(Name = "skipHistory", EmitDefaultValue = false)]
        public bool? SkipHistory { get; init; }

        /// <include file='../XmlDocs/CoreModels.xml' path='Docs/Members[@name="wsSubSummariesGetAndSubscribeV2"]/Member[@name="exchange"]/*' />
        [DataMember(Name = "exchange", EmitDefaultValue = false)]
        public Exchange Exchange { get; init; }

        /// <include file='../XmlDocs/CoreModels.xml' path='Docs/Members[@name="wsSubSummariesGetAndSubscribeV2"]/Member[@name="format"]/*' />
        [DataMember(Name = "format", EmitDefaultValue = false)]
        public Format Format { get; init; }

        /// <include file='../XmlDocs/CoreModels.xml' path='Docs/Members[@name="wsSubSummariesGetAndSubscribeV2"]/Member[@name="frequency"]/*' />
        [DataMember(Name = "frequency", EmitDefaultValue = false)]
        public int? Frequency { get; init; }

        /// <include file='../XmlDocs/CoreModels.xml' path='Docs/Members[@name="wsSubSummariesGetAndSubscribeV2"]/Member[@name="guid"]/*' />
        [DataMember(Name = "guid", EmitDefaultValue = false)]
        public string? Guid { get; init; }

        /// <include file='../XmlDocs/CoreModels.xml' path='Docs/Members[@name="wsSubSummariesGetAndSubscribeV2"]/Member[@name="token"]/*' />
        [DataMember(Name = "token", EmitDefaultValue = false)]
        public string? Token { get; init; } = "JwtToken";

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class SubscriptionSummary {").Append(Environment.NewLine);
            sb.Append("  Opcode: ").Append(Opcode).Append(Environment.NewLine);
            sb.Append("  Portfolio: ").Append(Portfolio).Append(Environment.NewLine);
            sb.Append("  SkipHistory: ").Append(SkipHistory).Append(Environment.NewLine);
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
            HashCode.Combine(Opcode, Portfolio, SkipHistory, Exchange, Format, Frequency, Guid, Token);

        private static bool EqualsHelper(SubscriptionSummary? first, SubscriptionSummary? second) =>
            first?.Opcode == second?.Opcode &&
            first?.Portfolio == second?.Portfolio &&
            first?.SkipHistory == second?.SkipHistory &&
            first?.Exchange == second?.Exchange &&
            first?.Format == second?.Format &&
            first?.Frequency == second?.Frequency &&
            first?.Guid == second?.Guid &&
            first?.Token == second?.Token;

        public bool Equals(SubscriptionSummary? other)
        {
            if (this == (object?)other)
                return true;

            if ((object?)other == null)
                return false;

            return GetType() == other.GetType() && EqualsHelper(this, other);
        }

        public override bool Equals(object? obj) => Equals(obj as SubscriptionSummary);

        private static bool Equals(SubscriptionSummary? first, SubscriptionSummary? second) =>
            first?.Equals(second) ?? first == (object?)second;

        public static bool operator ==(SubscriptionSummary? first, SubscriptionSummary? second) => Equals(first, second);

        public static bool operator !=(SubscriptionSummary? first, SubscriptionSummary? second) => !Equals(first, second);

        IEnumerable<ValidationResult> IValidatableObject.Validate(ValidationContext validationContext)
        {
            yield break;
        }
    }
}
