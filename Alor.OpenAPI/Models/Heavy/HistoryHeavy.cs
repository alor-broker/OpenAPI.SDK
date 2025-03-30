using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text;
using SpanJson;

namespace Alor.OpenAPI.Models.Heavy
{
    [DataContract]
    public sealed class HistoryHeavy : IEquatable<HistoryHeavy>, IValidatableObject
    {
        public HistoryHeavy() { }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseHistory"]/Member[@name="responseHistory"]/*' />
        [JsonConstructor]
        public HistoryHeavy(List<CandleHeavy>? history = default, long? next = default,
            long? prev = default)
        {
            History = history;
            Next = next;
            Prev = prev;
        }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseHistory"]/Member[@name="history"]/*' />
        [DataMember(Name = "history", EmitDefaultValue = false)]
        public List<CandleHeavy>? History { get; init; }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseHistory"]/Member[@name="next"]/*' />
        [DataMember(Name = "next", EmitDefaultValue = false)]
        public long? Next { get; init; }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseHistory"]/Member[@name="prev"]/*' />
        [DataMember(Name = "prev", EmitDefaultValue = false)]
        public long? Prev { get; init; }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class HistoryHeavy {").Append(Environment.NewLine);
            sb.Append("  History: ").Append(History == null ? "null" : string.Join(", ", History.Select(x => x.ToString()))).Append(Environment.NewLine);
            sb.Append("  Next: ").Append(Next).Append(Environment.NewLine);
            sb.Append("  Prev: ").Append(Prev).Append(Environment.NewLine);
            sb.Append('}').Append(Environment.NewLine);
            return sb.ToString();
        }

        public string ToJson() => Encoding.UTF8.GetString(JsonSerializer.Generic.Utf8.Serialize(this));

        public override int GetHashCode() => HashCode.Combine(History, Next, Prev);

        private static bool EqualsHelper(HistoryHeavy? first, HistoryHeavy? second)
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

        public bool Equals(HistoryHeavy? other)
        {
            if (this == (object?)other)
                return true;

            if ((object?)other == null)
                return false;

            return GetType() == other.GetType() && EqualsHelper(this, other);
        }

        public override bool Equals(object? obj) => Equals(obj as HistoryHeavy);

        private static bool Equals(HistoryHeavy? first, HistoryHeavy? second) =>
            first?.Equals(second) ?? first == (object?)second;

        public static bool operator ==(HistoryHeavy? first, HistoryHeavy? second) => Equals(first, second);

        public static bool operator !=(HistoryHeavy? first, HistoryHeavy? second) => !Equals(first, second);

        IEnumerable<ValidationResult> IValidatableObject.Validate(ValidationContext validationContext)
        {
            yield break;
        }
    }
}
