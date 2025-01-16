using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text;
using SpanJson;

namespace Alor.OpenAPI.Models.Slim
{
    [DataContract]
    public sealed class TradeRepoSpecificFieldsSlim : IEquatable<TradeRepoSpecificFieldsSlim>, IValidatableObject
    {
        public TradeRepoSpecificFieldsSlim() { }

        public TradeRepoSpecificFieldsSlim(decimal? repoRate = default, string? extRef = default, int? repoTerm = default,
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

        [DataMember(Name = "r", EmitDefaultValue = false)]
        public decimal? RepoRate { get; private set; }

        [DataMember(Name = "exr", EmitDefaultValue = false)]
        public string? ExtRef { get; private set; }

        [DataMember(Name = "tm", EmitDefaultValue = false)]
        public int? RepoTerm { get; private set; }

        [DataMember(Name = "a", EmitDefaultValue = false)]
        public string? Account { get; private set; }

        [DataMember(Name = "t", EmitDefaultValue = false)]
        public string? TradeTypeInfo { get; private set; }

        [DataMember(Name = "v", EmitDefaultValue = false)]
        public decimal? Value { get; private set; }

        [DataMember(Name = "y", EmitDefaultValue = false)]
        public decimal? Yield { get; private set; }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class TradeRepoSpecificFieldsSlim {").Append(Environment.NewLine);
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

        public override int GetHashCode() => Utilities.Utilities.GetHashCodeHelper(
            [
                RepoRate?.GetHashCode() ?? 0,
                ExtRef?.GetHashCode() ?? 0,
                RepoTerm?.GetHashCode() ?? 0,
                Account?.GetHashCode() ?? 0,
                TradeTypeInfo?.GetHashCode() ?? 0,
                Value?.GetHashCode() ?? 0,
                Yield?.GetHashCode() ?? 0,
            ]
        );

        private static bool EqualsHelper(TradeRepoSpecificFieldsSlim? first, TradeRepoSpecificFieldsSlim? second) =>
            first?.RepoRate == second?.RepoRate &&
            first?.ExtRef == second?.ExtRef &&
            first?.RepoTerm == second?.RepoTerm &&
            first?.Account == second?.Account &&
            first?.TradeTypeInfo == second?.TradeTypeInfo &&
            first?.Value == second?.Value &&
            first?.Yield == second?.Yield;


        public bool Equals(TradeRepoSpecificFieldsSlim? other)
        {
            if (this == (object?)other)
                return true;

            if ((object?)other == null)
                return false;

            if (GetType() != other.GetType())
                return false;

            return EqualsHelper(this, other);
        }

        public override bool Equals(object? obj) => Equals(obj as TradeRepoSpecificFieldsSlim);

        private static bool Equals(TradeRepoSpecificFieldsSlim? first, TradeRepoSpecificFieldsSlim? second) =>
            first?.Equals(second) ?? first == (object?)second;

        public static bool operator ==(TradeRepoSpecificFieldsSlim? first, TradeRepoSpecificFieldsSlim? second) => Equals(first, second);

        public static bool operator !=(TradeRepoSpecificFieldsSlim? first, TradeRepoSpecificFieldsSlim? second) => !Equals(first, second);

        IEnumerable<ValidationResult> IValidatableObject.Validate(ValidationContext validationContext)
        {
            yield break;
        }
    }
}
