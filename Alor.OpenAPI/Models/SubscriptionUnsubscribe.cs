using SpanJson;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text;

namespace Alor.OpenAPI.Models
{
    [DataContract]
    internal sealed class SubscriptionUnsubscribe : IEquatable<SubscriptionUnsubscribe>, IValidatableObject
    {
        public SubscriptionUnsubscribe() { }

        /// <include file='../XmlDocs/CoreModels.xml'
        ///          path='Docs/Members[@name="wsSubUnsubscribe"]
        ///               /Member[@name="wsSubUnsubscribe"]
        ///               /param[@name="guid"]'/>
        public SubscriptionUnsubscribe(string? guid = null)
        {
            Guid = guid;
        }

        /// <include file='../XmlDocs/CoreModels.xml' path='Docs/Members[@name="wsSubUnsubscribe"]/Member[@name="opcode"]/*' />
        [DataMember(Name = "opcode", EmitDefaultValue = false)]
        public string? Opcode { get; init; } = "unsubscribe";

        /// <include file='../XmlDocs/CoreModels.xml' path='Docs/Members[@name="wsSubUnsubscribe"]/Member[@name="guid"]/*' />
        [DataMember(Name = "guid", EmitDefaultValue = false)]
        public string? Guid { get; init; }

        /// <include file='../XmlDocs/CoreModels.xml' path='Docs/Members[@name="wsSubUnsubscribe"]/Member[@name="token"]/*' />
        [DataMember(Name = "token", EmitDefaultValue = false)]
        public string? Token { get; init; } = "JwtToken";


        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class SubscriptionUnsubscribe {").Append(Environment.NewLine);
            sb.Append("  Opcode: ").Append(Opcode).Append(Environment.NewLine);
            sb.Append("  Guid: ").Append(Guid).Append(Environment.NewLine);
            sb.Append("  Token: ").Append(Token).Append(Environment.NewLine);
            sb.Append('}').Append(Environment.NewLine);
            return sb.ToString();
        }

        public string ToJson() => Encoding.UTF8.GetString(JsonSerializer.Generic.Utf8.Serialize(this));

        public override int GetHashCode() => HashCode.Combine(Opcode, Guid, Token);

        private static bool EqualsHelper(SubscriptionUnsubscribe? first, SubscriptionUnsubscribe? second) =>
            first?.Opcode == second?.Opcode &&
            first?.Guid == second?.Guid &&
            first?.Token == second?.Token;

        public bool Equals(SubscriptionUnsubscribe? other)
        {
            if (this == (object?)other)
                return true;

            if (other is null)
                return false;

            return GetType() == other.GetType() && EqualsHelper(this, other);
        }

        public override bool Equals(object? obj) => Equals(obj as SubscriptionUnsubscribe);

        private static bool Equals(SubscriptionUnsubscribe? first, SubscriptionUnsubscribe? second) =>
            first?.Equals(second) ?? first == (object?)second;

        public static bool operator ==(SubscriptionUnsubscribe? first, SubscriptionUnsubscribe? second) => Equals(first, second);

        public static bool operator !=(SubscriptionUnsubscribe? first, SubscriptionUnsubscribe? second) => !Equals(first, second);

        IEnumerable<ValidationResult> IValidatableObject.Validate(ValidationContext validationContext)
        {
            yield break;
        }
    }
}
