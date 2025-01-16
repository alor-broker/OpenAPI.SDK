using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text;
using SpanJson;

namespace Alor.OpenAPI.Models
{
    [DataContract]
    public sealed class RiskRates : IEquatable<RiskRates>, IValidatableObject
    {
        public RiskRates() { }
        /// <include file='../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseRiskRates"]/Member[@name="responseRiskRates"]/*' />
        public RiskRates(int? total = default, List<RiskRate>? list = default)
        {
            Total = total;
            List = list;
        }

        /// <include file='../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseRiskRates"]/Member[@name="total"]/*' />
        [DataMember(Name = "total", EmitDefaultValue = false)]
        public int? Total { get; private set; }

        /// <include file='../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseRiskRates"]/Member[@name="list"]/*' />
        [DataMember(Name = "list", EmitDefaultValue = false)]
        public List<RiskRate>? List { get; private set; }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class RiskRates {").Append(Environment.NewLine);
            sb.Append("  Total: ").Append(Total).Append(Environment.NewLine);
            sb.Append("  List: ").Append(List == null ? "null" : string.Join(", ", List.Select(x => x.ToString()))).Append(Environment.NewLine);
            sb.Append('}').Append(Environment.NewLine);
            return sb.ToString();
        }

        public string ToJson() => Encoding.UTF8.GetString(JsonSerializer.Generic.Utf8.Serialize(this));

        public override int GetHashCode() => Utilities.Utilities.GetHashCodeHelper(
            [
                Total?.GetHashCode() ?? 0,
                List?.GetHashCode() ?? 0,
            ]
        );

        private static bool EqualsHelper(RiskRates? first, RiskRates? second)
        {
            if (ReferenceEquals(first, second))
            {
                return true;
            }

            if (first is null || second is null)
            {
                return false;
            }

            return first.Total == second.Total &&
                   first.List != null &&
                   second.List != null &&
                   first.List.SequenceEqual(second.List);
        }

        public bool Equals(RiskRates? other)
        {
            if (this == (object?)other)
                return true;

            if ((object?)other == null)
                return false;

            if (GetType() != other.GetType())
                return false;

            return EqualsHelper(this, other);
        }

        public override bool Equals(object? obj) => Equals(obj as RiskRates);

        private static bool Equals(RiskRates? first, RiskRates? second) =>
            first?.Equals(second) ?? first == (object?)second;

        public static bool operator ==(RiskRates? first, RiskRates? second) => Equals(first, second);

        public static bool operator !=(RiskRates? first, RiskRates? second) => !Equals(first, second);

        IEnumerable<ValidationResult> IValidatableObject.Validate(ValidationContext validationContext)
        {
            yield break;
        }
    }
}
