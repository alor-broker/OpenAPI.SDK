using SpanJson;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text;

namespace Alor.OpenAPI.Models
{
    [DataContract]
    public sealed class User : IEquatable<User>, IValidatableObject
    {
        public User() { }

        /// <include file='../XmlDocs/CoreModels.xml' path='Docs/Members[@name="objectUserPortfolioOnly"]/Member[@name="objectUserPortfolioOnly"]/*' />
        public User(string? portfolio = default)
        {
            Portfolio = portfolio;
        }

        /// <include file='../XmlDocs/CoreModels.xml' path='Docs/Members[@name="objectUserPortfolioOnly"]/Member[@name="portfolio"]/*' />
        [DataMember(Name = "portfolio", EmitDefaultValue = false)]
        public string? Portfolio { get; init; }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class User {").Append(Environment.NewLine);
            sb.Append("  Portfolio: ").Append(Portfolio).Append(Environment.NewLine);
            sb.Append('}').Append(Environment.NewLine);
            return sb.ToString();
        }

        public string ToJson() => Encoding.UTF8.GetString(JsonSerializer.Generic.Utf8.Serialize(this));

        public override int GetHashCode() => HashCode.Combine(Portfolio);

        private static bool EqualsHelper(User? first, User? second) =>
            first?.Portfolio == second?.Portfolio;


        public bool Equals(User? other)
        {
            if (this == (object?)other)
                return true;

            if ((object?)other == null)
                return false;

            return GetType() == other.GetType() && EqualsHelper(this, other);
        }

        public override bool Equals(object? obj) => Equals(obj as User);

        private static bool Equals(User? first, User? second) =>
            first?.Equals(second) ?? first == (object?)second;

        public static bool operator ==(User? first, User? second) => Equals(first, second);

        public static bool operator !=(User? first, User? second) => !Equals(first, second);

        IEnumerable<ValidationResult> IValidatableObject.Validate(ValidationContext validationContext)
        {
            yield break;
        }
    }
}