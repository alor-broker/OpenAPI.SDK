using SpanJson;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text;

namespace Alor.OpenAPI.Models
{
    [DataContract]
    public sealed class CurrencyPair : IEquatable<CurrencyPair>, IValidatableObject
    {
        public CurrencyPair() { }

        /// <include file='../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseCurrencyPair"]/Member[@name="responseCurrencyPair"]/*' />
        public CurrencyPair(string? firstCode = null, string? secondCode = null, string? symbolTom = null)
        {
            FirstCode = firstCode;
            SecondCode = secondCode;
            SymbolTom = symbolTom;
        }

        /// <include file='../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseCurrencyPair"]/Member[@name="firstCode"]/*' />
        [DataMember(Name = "firstCode", EmitDefaultValue = false)]
        public string? FirstCode { get; init; }

        /// <include file='../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseCurrencyPair"]/Member[@name="secondCode"]/*' />
        [DataMember(Name = "secondCode", EmitDefaultValue = false)]
        public string? SecondCode { get; init; }

        /// <include file='../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseCurrencyPair"]/Member[@name="symbolTom"]/*' />
        [DataMember(Name = "symbolTom", EmitDefaultValue = false)]
        public string? SymbolTom { get; init; }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class CurrencyPair {").Append(Environment.NewLine);
            sb.Append("  FirstCode: ").Append(FirstCode).Append(Environment.NewLine);
            sb.Append("  SecondCode: ").Append(SecondCode).Append(Environment.NewLine);
            sb.Append("  SymbolTom: ").Append(SymbolTom).Append(Environment.NewLine);
            sb.Append('}').Append(Environment.NewLine);
            return sb.ToString();
        }

        public string ToJson() => Encoding.UTF8.GetString(JsonSerializer.Generic.Utf8.Serialize(this));

        public override int GetHashCode() => HashCode.Combine(FirstCode, SecondCode, SymbolTom);

        private static bool EqualsHelper(CurrencyPair? first, CurrencyPair? second) =>
            first?.FirstCode == second?.FirstCode &&
            first?.SecondCode == second?.SecondCode &&
            first?.SymbolTom == second?.SymbolTom;


        public bool Equals(CurrencyPair? other)
        {
            if (this == (object?)other)
                return true;

            if (other is null)
                return false;

            return GetType() == other.GetType() && EqualsHelper(this, other);
        }

        public override bool Equals(object? obj) => Equals(obj as CurrencyPair);

        private static bool Equals(CurrencyPair? first, CurrencyPair? second) =>
            first?.Equals(second) ?? first == (object?)second;

        public static bool operator ==(CurrencyPair? first, CurrencyPair? second) => Equals(first, second);

        public static bool operator !=(CurrencyPair? first, CurrencyPair? second) => !Equals(first, second);

        IEnumerable<ValidationResult> IValidatableObject.Validate(ValidationContext validationContext)
        {
            yield break;
        }
    }
}
