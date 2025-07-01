using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text;
using SpanJson;

namespace Alor.OpenAPI.Models.Simple
{
    [DataContract]
    public sealed class HistorySimple : IEquatable<HistorySimple>, IValidatableObject
    {
        public HistorySimple() { }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseHistory"]/Member[@name="responseHistory"]/*' />
        public HistorySimple(List<CandleSimple>? history = default, long? next = default,
            long? prev = default)
        {
            History = history;
            Next = next;
            Prev = prev;
        }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseHistory"]/Member[@name="history"]/*' />
        [DataMember(Name = "history", EmitDefaultValue = false)]
        public List<CandleSimple>? History { get; init; }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseHistory"]/Member[@name="next"]/*' />
        [DataMember(Name = "next", EmitDefaultValue = false)]
        public long? Next { get; init; }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseHistory"]/Member[@name="prev"]/*' />
        [DataMember(Name = "prev", EmitDefaultValue = false)]
        public long? Prev { get; init; }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class HistorySimple {").Append(Environment.NewLine);
            sb.Append("  History: ").Append(History == null ? "null" : string.Join(", ", History.Select(x => x.ToString()))).Append(Environment.NewLine);
            sb.Append("  Next: ").Append(Next).Append(Environment.NewLine);
            sb.Append("  Prev: ").Append(Prev).Append(Environment.NewLine);
            sb.Append('}').Append(Environment.NewLine);
            return sb.ToString();
        }

        public string ToJson() => Encoding.UTF8.GetString(JsonSerializer.Generic.Utf8.Serialize(this));

        public override int GetHashCode()
        {
            var hash = new HashCode();
            hash.Add(Next);
            hash.Add(Prev);

            if (History == null) return hash.ToHashCode();

            foreach (var item in History)
            {
                hash.Add(item.GetHashCode());
            }

            return hash.ToHashCode();
        }

        private static bool EqualsHelper(HistorySimple? first, HistorySimple? second)
        {
            if (ReferenceEquals(first, second))
            {
                return true;
            }

            if (first is null || second is null)
            {
                return false;
            }

            return first.Next == second.Next &&
                   first.Prev == second.Prev &&
                   first.History != null &&
                   second.History != null &&
                   first.History.SequenceEqual(second.History);
        }

        public bool Equals(HistorySimple? other)
        {
            if (this == (object?)other)
                return true;

            if ((object?)other == null)
                return false;

            return GetType() == other.GetType() && EqualsHelper(this, other);
        }

        public override bool Equals(object? obj) => Equals(obj as HistorySimple);

        private static bool Equals(HistorySimple? first, HistorySimple? second) =>
            first?.Equals(second) ?? first == (object?)second;

        public static bool operator ==(HistorySimple? first, HistorySimple? second) => Equals(first, second);

        public static bool operator !=(HistorySimple? first, HistorySimple? second) => !Equals(first, second);

        IEnumerable<ValidationResult> IValidatableObject.Validate(ValidationContext validationContext)
        {
            yield break;
        }
    }
}
