using SpanJson;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text;

namespace Alor.OpenAPI.Models
{
    [DataContract]
    internal sealed class CwsRequestAuthorize : IEquatable<CwsRequestAuthorize>, IValidatableObject
    {
        public CwsRequestAuthorize() { }

        /// <include file='../XmlDocs/CoreModels.xml' path='Docs/Members[@name="wsCmdAuthorize"]/Member[@name="wsCmdAuthorize"]/*' />
        public CwsRequestAuthorize(string? guid = default)
        {
            Guid = guid;
        }

        /// <include file='../XmlDocs/CoreModels.xml' path='Docs/Members[@name="wsCmdAuthorize"]/Member[@name="opcode"]/*' />
        [DataMember(Name = "opcode", EmitDefaultValue = false)]
        public string? Opcode { get; private set; } = "authorize";

        /// <include file='../XmlDocs/CoreModels.xml' path='Docs/Members[@name="wsCmdAuthorize"]/Member[@name="guid"]/*' />
        [DataMember(Name = "guid", EmitDefaultValue = false)]
        public string? Guid { get; private set; }

        /// <include file='../XmlDocs/CoreModels.xml' path='Docs/Members[@name="wsCmdAuthorize"]/Member[@name="token"]/*' />
        [DataMember(Name = "token", EmitDefaultValue = false)]
        public string? Token { get; private set; } = "JwtToken";

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class CwsRequestAuthorize {").Append(Environment.NewLine);
            sb.Append("  Opcode: ").Append(Opcode).Append(Environment.NewLine);
            sb.Append("  Guid: ").Append(Guid).Append(Environment.NewLine);
            sb.Append("  Token: ").Append(Token).Append(Environment.NewLine);
            sb.Append('}').Append(Environment.NewLine);
            return sb.ToString();
        }

        public string ToJson() => Encoding.UTF8.GetString(JsonSerializer.Generic.Utf8.Serialize(this));

        public override int GetHashCode() => Utilities.Utilities.GetHashCodeHelper(
            [
                Guid?.GetHashCode() ?? 0,
            ]
        );

        private static bool EqualsHelper(CwsRequestAuthorize? first, CwsRequestAuthorize? second) =>
            first?.Opcode == second?.Opcode &&
            first?.Guid == second?.Guid &&
            first?.Token == second?.Token;

        public bool Equals(CwsRequestAuthorize? other)
        {
            if (this == (object?)other)
                return true;

            if ((object?)other == null)
                return false;

            if (GetType() != other.GetType())
                return false;

            return EqualsHelper(this, other);
        }

        public override bool Equals(object? obj) => Equals(obj as CwsRequestAuthorize);

        private static bool Equals(CwsRequestAuthorize? first, CwsRequestAuthorize? second) =>
            first?.Equals(second) ?? first == (object?)second;

        public static bool operator ==(CwsRequestAuthorize? first, CwsRequestAuthorize? second) => Equals(first, second);

        public static bool operator !=(CwsRequestAuthorize? first, CwsRequestAuthorize? second) => !Equals(first, second);

        IEnumerable<ValidationResult> IValidatableObject.Validate(ValidationContext validationContext)
        {
            yield break;
        }
    }
}
