using SpanJson;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text;

namespace Alor.OpenAPI.Models.Simple
{
    [DataContract]
    public sealed class AllTradesHistorySimple : IEquatable<AllTradesHistorySimple>, IValidatableObject
    {
        public AllTradesHistorySimple() { }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseAllTradesHistory"]/Member[@name="responseAllTradesHistory"]/*' />
        public AllTradesHistorySimple(int? total = default, List<AllTradeSimple>? list = default)
        {
            Total = total;
            List = list;
        }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseAllTradesHistory"]/Member[@name="total"]/*' />
        [DataMember(Name = "total", EmitDefaultValue = false)]
        public int? Total { get; init; }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseAllTradesHistory"]/Member[@name="list"]/*' />
        [DataMember(Name = "list", EmitDefaultValue = false)]
        public List<AllTradeSimple>? List { get; init; }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class AllTradesHistorySimple {").Append(Environment.NewLine);
            sb.Append("  Total: ").Append(Total).Append(Environment.NewLine);
            sb.Append("  List: ").Append(List == null ? "null" : string.Join(", ", List.Select(x => x.ToString()))).Append(Environment.NewLine);
            sb.Append('}').Append(Environment.NewLine);
            return sb.ToString();
        }

        public string ToJson() => Encoding.UTF8.GetString(JsonSerializer.Generic.Utf8.Serialize(this));

        public override int GetHashCode()
        {
            var hash = new HashCode();

            hash.Add(Total);
            if (List == null) return hash.ToHashCode();

            foreach (var item in List)
            {
                hash.Add(item.GetHashCode());
            }

            return hash.ToHashCode();
        }

        private static bool EqualsHelper(AllTradesHistorySimple? first, AllTradesHistorySimple? second)
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

        public bool Equals(AllTradesHistorySimple? other)
        {
            if (this == (object?)other)
                return true;

            if ((object?)other == null)
                return false;

            return GetType() == other.GetType() && EqualsHelper(this, other);
        }

        public override bool Equals(object? obj) => Equals(obj as AllTradesHistorySimple);

        private static bool Equals(AllTradesHistorySimple? first, AllTradesHistorySimple? second) =>
            first?.Equals(second) ?? first == (object?)second;

        public static bool operator ==(AllTradesHistorySimple? first, AllTradesHistorySimple? second) => Equals(first, second);

        public static bool operator !=(AllTradesHistorySimple? first, AllTradesHistorySimple? second) => !Equals(first, second);

        IEnumerable<ValidationResult> IValidatableObject.Validate(ValidationContext validationContext)
        {
            yield break;
        }
    }
}
