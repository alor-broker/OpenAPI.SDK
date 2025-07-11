﻿using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text;
using SpanJson;

namespace Alor.OpenAPI.Models.Heavy
{
    [DataContract]
    public sealed class TradeRepoSpecificFieldsHeavy : IEquatable<TradeRepoSpecificFieldsHeavy>, IValidatableObject
    {
        public TradeRepoSpecificFieldsHeavy() { }

        public TradeRepoSpecificFieldsHeavy(decimal? repoRate = default, string? extRef = default, int? repoTerm = default,
            string? account = default, string? tradeTypeInfo = default, decimal? value = default,
            decimal? yield = default)
        {
            RepoRate = repoRate;
            ExtRef = extRef;
            RepoTerm = repoTerm;
            Account = account;
            TradeTypeInfo = tradeTypeInfo;
            Value = value;
            Yield = yield;
        }

        [DataMember(Name = "repoRate", EmitDefaultValue = false)]
        public decimal? RepoRate { get; init; }

        [DataMember(Name = "extRef", EmitDefaultValue = false)]
        public string? ExtRef { get; init; }

        [DataMember(Name = "repoTerm", EmitDefaultValue = false)]
        public int? RepoTerm { get; init; }

        [DataMember(Name = "account", EmitDefaultValue = false)]
        public string? Account { get; init; }

        [DataMember(Name = "tradeTypeInfo", EmitDefaultValue = false)]
        public string? TradeTypeInfo { get; init; }

        [DataMember(Name = "value", EmitDefaultValue = false)]
        public decimal? Value { get; init; }

        [DataMember(Name = "yield", EmitDefaultValue = false)]
        public decimal? Yield { get; init; }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class TradeRepoSpecificFieldsHeavy {").Append(Environment.NewLine);
            sb.Append("  RepoRate: ").Append(RepoRate).Append(Environment.NewLine);
            sb.Append("  ExtRef: ").Append(ExtRef).Append(Environment.NewLine);
            sb.Append("  RepoTerm: ").Append(RepoTerm).Append(Environment.NewLine);
            sb.Append("  Account: ").Append(Account).Append(Environment.NewLine);
            sb.Append("  TradeTypeInfo: ").Append(TradeTypeInfo).Append(Environment.NewLine);
            sb.Append("  Value: ").Append(Value).Append(Environment.NewLine);
            sb.Append("  Yield: ").Append(Yield).Append(Environment.NewLine);
            sb.Append('}').Append(Environment.NewLine);
            return sb.ToString();
        }

        public string ToJson() => Encoding.UTF8.GetString(JsonSerializer.Generic.Utf8.Serialize(this));

        public override int GetHashCode()
        {
            var hash = new HashCode();
            hash.Add(RepoRate);
            hash.Add(ExtRef);
            hash.Add(RepoTerm);
            hash.Add(Account);
            hash.Add(TradeTypeInfo);
            hash.Add(Value);
            hash.Add(Yield);
            return hash.ToHashCode();
        }

        private static bool EqualsHelper(TradeRepoSpecificFieldsHeavy? first, TradeRepoSpecificFieldsHeavy? second) =>
            first?.RepoRate == second?.RepoRate &&
            first?.ExtRef == second?.ExtRef &&
            first?.RepoTerm == second?.RepoTerm &&
            first?.Account == second?.Account &&
            first?.TradeTypeInfo == second?.TradeTypeInfo &&
            first?.Value == second?.Value &&
            first?.Yield == second?.Yield;


        public bool Equals(TradeRepoSpecificFieldsHeavy? other)
        {
            if (this == (object?)other)
                return true;

            if ((object?)other == null)
                return false;

            return GetType() == other.GetType() && EqualsHelper(this, other);
        }

        public override bool Equals(object? obj) => Equals(obj as TradeRepoSpecificFieldsHeavy);

        private static bool Equals(TradeRepoSpecificFieldsHeavy? first, TradeRepoSpecificFieldsHeavy? second) =>
            first?.Equals(second) ?? first == (object?)second;

        public static bool operator ==(TradeRepoSpecificFieldsHeavy? first, TradeRepoSpecificFieldsHeavy? second) => Equals(first, second);

        public static bool operator !=(TradeRepoSpecificFieldsHeavy? first, TradeRepoSpecificFieldsHeavy? second) => !Equals(first, second);

        IEnumerable<ValidationResult> IValidatableObject.Validate(ValidationContext validationContext)
        {
            yield break;
        }
    }
}
