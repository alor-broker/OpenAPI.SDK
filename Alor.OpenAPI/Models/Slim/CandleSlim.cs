using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text;
using SpanJson;

namespace Alor.OpenAPI.Models.Slim
{
    [DataContract]
    public sealed class CandleSlim : IEquatable<CandleSlim>, IValidatableObject
    {
        public CandleSlim() { }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseHistoryObject"]/Member[@name="responseHistoryObject"]/*' />
        public CandleSlim(long? time = default, decimal? close = default,
            decimal? open = default, decimal? high = default, decimal? low = default,
            int? volume = default)
        {
            Time = time;
            Close = close;
            Open = open;
            High = high;
            Low = low;
            Volume = volume;
        }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseHistoryObject"]/Member[@name="time"]/*' />
        [DataMember(Name = "t", EmitDefaultValue = false)]
        public long? Time { get; private set; }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseHistoryObject"]/Member[@name="close"]/*' />
        [DataMember(Name = "c", EmitDefaultValue = false)]
        public decimal? Close { get; private set; }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseHistoryObject"]/Member[@name="open"]/*' />
        [DataMember(Name = "o", EmitDefaultValue = false)]
        public decimal? Open { get; private set; }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseHistoryObject"]/Member[@name="high"]/*' />
        [DataMember(Name = "h", EmitDefaultValue = false)]
        public decimal? High { get; private set; }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseHistoryObject"]/Member[@name="low"]/*' />
        [DataMember(Name = "l", EmitDefaultValue = false)]
        public decimal? Low { get; private set; }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseHistoryObject"]/Member[@name="volume"]/*' />
        [DataMember(Name = "v", EmitDefaultValue = false)]
        public int? Volume { get; private set; }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class CandleSlim {").Append(Environment.NewLine);
            sb.Append("  Time: ").Append(Time).Append(Environment.NewLine);
            sb.Append("  Close: ").Append(Close).Append(Environment.NewLine);
            sb.Append("  Open: ").Append(Open).Append(Environment.NewLine);
            sb.Append("  High: ").Append(High).Append(Environment.NewLine);
            sb.Append("  Low: ").Append(Low).Append(Environment.NewLine);
            sb.Append("  Volume: ").Append(Volume).Append(Environment.NewLine);
            sb.Append('}').Append(Environment.NewLine);
            return sb.ToString();
        }

        public string ToJson() => Encoding.UTF8.GetString(JsonSerializer.Generic.Utf8.Serialize(this));

        public override int GetHashCode() => Utilities.Utilities.GetHashCodeHelper(
            [
                Time?.GetHashCode() ?? 0,
                Close?.GetHashCode() ?? 0,
                Open?.GetHashCode() ?? 0,
                High?.GetHashCode() ?? 0,
                Low?.GetHashCode() ?? 0,
                Volume?.GetHashCode() ?? 0,
            ]
        );

        private static bool EqualsHelper(CandleSlim? first, CandleSlim? second) =>
            first?.Time == second?.Time &&
            first?.Close == second?.Close &&
            first?.Open == second?.Open &&
            first?.High == second?.High &&
            first?.Low == second?.Low &&
            first?.Volume == second?.Volume;


        public bool Equals(CandleSlim? other)
        {
            if (this == (object?)other)
                return true;

            if ((object?)other == null)
                return false;

            if (GetType() != other.GetType())
                return false;

            return EqualsHelper(this, other);
        }

        public override bool Equals(object? obj) => Equals(obj as CandleSlim);

        private static bool Equals(CandleSlim? first, CandleSlim? second) =>
            first?.Equals(second) ?? first == (object?)second;

        public static bool operator ==(CandleSlim? first, CandleSlim? second) => Equals(first, second);

        public static bool operator !=(CandleSlim? first, CandleSlim? second) => !Equals(first, second);

        IEnumerable<ValidationResult> IValidatableObject.Validate(ValidationContext validationContext)
        {
            yield break;
        }
    }
}
