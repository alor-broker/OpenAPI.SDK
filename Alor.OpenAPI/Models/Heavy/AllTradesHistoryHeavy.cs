using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text;
using SpanJson;

namespace Alor.OpenAPI.Models.Heavy
{
    [DataContract]
    public sealed class AllTradesHistoryHeavy : IEquatable<AllTradesHistoryHeavy>, IValidatableObject
    {
        public AllTradesHistoryHeavy() { }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseAllTradesHistory"]/Member[@name="responseAllTradesHistory"]/*' />
        [JsonConstructor]
        public AllTradesHistoryHeavy(int? total = default, List<AllTradeHeavy>? listHeavy = default)
        {
            Total = total;
            List = listHeavy;
        }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseAllTradesHistory"]/Member[@name="total"]/*' />
        [DataMember(Name = "total", EmitDefaultValue = false)]
        public int? Total { get; init; }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseAllTradesHistory"]/Member[@name="listHeavy"]/*' />
        [DataMember(Name = "list", EmitDefaultValue = false)]
        public List<AllTradeHeavy>? List { get; init; }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class AllTradesHistoryHeavy {").Append(Environment.NewLine);
            sb.Append("  Total: ").Append(Total).Append(Environment.NewLine);
            sb.Append("  List: ").Append(List == null ? "null" : string.Join(", ", List.Select(x => x.ToString()))).Append(Environment.NewLine);
            sb.Append('}').Append(Environment.NewLine);
            return sb.ToString();
        }

        public string ToJson() => Encoding.UTF8.GetString(JsonSerializer.Generic.Utf8.Serialize(this));

        public override int GetHashCode() => HashCode.Combine(Total, List);

        private static bool EqualsHelper(AllTradesHistoryHeavy? first, AllTradesHistoryHeavy? second)
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

        public bool Equals(AllTradesHistoryHeavy? other)
        {
            if (this == (object?)other)
                return true;

            if ((object?)other == null)
                return false;

            return GetType() == other.GetType() && EqualsHelper(this, other);
        }

        public override bool Equals(object? obj) => Equals(obj as AllTradesHistoryHeavy);

        private static bool Equals(AllTradesHistoryHeavy? first, AllTradesHistoryHeavy? second) =>
            first?.Equals(second) ?? first == (object?)second;

        public static bool operator ==(AllTradesHistoryHeavy? first, AllTradesHistoryHeavy? second) => Equals(first, second);

        public static bool operator !=(AllTradesHistoryHeavy? first, AllTradesHistoryHeavy? second) => !Equals(first, second);

        IEnumerable<ValidationResult> IValidatableObject.Validate(ValidationContext validationContext)
        {
            yield break;
        }
    }
}
