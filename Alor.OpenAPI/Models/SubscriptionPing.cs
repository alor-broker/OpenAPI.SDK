using Alor.OpenAPI.Enums;
using SpanJson;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text;

namespace Alor.OpenAPI.Models
{
    [DataContract]
    internal sealed class SubscriptionPing : IEquatable<SubscriptionPing>, IValidatableObject
    {
        public SubscriptionPing() { }

        [JsonConstructor]
        public SubscriptionPing(bool? confirm = default, string? guid = default)
        {
            Confirm = confirm;
            Guid = guid;
        }

        [DataMember(Name = "opcode", EmitDefaultValue = false)]
        public string? Opcode { get; init; } = "ping";

        [DataMember(Name = "confirm", EmitDefaultValue = false)]
        public bool? Confirm { get; init; }

        [DataMember(Name = "guid", EmitDefaultValue = false)]
        public string? Guid { get; init; }

        [DataMember(Name = "token", EmitDefaultValue = false)]
        public string? Token { get; init; } = "JwtToken";

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class SubscriptionPing {").Append(Environment.NewLine);
            sb.Append("  Opcode: ").Append(Opcode).Append(Environment.NewLine);
            sb.Append("  Confirm: ").Append(Confirm).Append(Environment.NewLine);
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
            hash.Add(Confirm);
            hash.Add(Guid);
            hash.Add(Token);
            return hash.ToHashCode();
        }

        private static bool EqualsHelper(SubscriptionPing? first, SubscriptionPing? second) =>
            first?.Opcode == second?.Opcode &&
            first?.Confirm == second?.Confirm &&
            first?.Guid == second?.Guid &&
            first?.Token == second?.Token;

        public bool Equals(SubscriptionPing? other)
        {
            if (this == (object?)other)
                return true;

            if ((object?)other == null)
                return false;

            return GetType() == other.GetType() && EqualsHelper(this, other);
        }

        public override bool Equals(object? obj) => Equals(obj as SubscriptionPing);

        private static bool Equals(SubscriptionPing? first, SubscriptionPing? second) =>
            first?.Equals(second) ?? first == (object?)second;

        public static bool operator ==(SubscriptionPing? first, SubscriptionPing? second) => Equals(first, second);

        public static bool operator !=(SubscriptionPing? first, SubscriptionPing? second) => !Equals(first, second);

        IEnumerable<ValidationResult> IValidatableObject.Validate(ValidationContext validationContext)
        {
            yield break;
        }
    }
}
