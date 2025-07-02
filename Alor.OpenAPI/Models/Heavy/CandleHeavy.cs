using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text;
using SpanJson;

namespace Alor.OpenAPI.Models.Heavy
{
    [DataContract]
    public sealed class CandleHeavy : IEquatable<CandleHeavy>, IValidatableObject
    {
        public CandleHeavy() { }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseHistoryObject"]/Member[@name="responseHistoryObject"]/*' />
        public CandleHeavy(long? time = default, decimal? close = default,
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
        [DataMember(Name = "time", EmitDefaultValue = false)]
        public long? Time { get; init; }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseHistoryObject"]/Member[@name="close"]/*' />
        [DataMember(Name = "close", EmitDefaultValue = false)]
        public decimal? Close { get; init; }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseHistoryObject"]/Member[@name="open"]/*' />
        [DataMember(Name = "open", EmitDefaultValue = false)]
        public decimal? Open { get; init; }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseHistoryObject"]/Member[@name="high"]/*' />
        [DataMember(Name = "high", EmitDefaultValue = false)]
        public decimal? High { get; init; }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseHistoryObject"]/Member[@name="low"]/*' />
        [DataMember(Name = "low", EmitDefaultValue = false)]
        public decimal? Low { get; init; }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseHistoryObject"]/Member[@name="volume"]/*' />
        [DataMember(Name = "volume", EmitDefaultValue = false)]
        public int? Volume { get; init; }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class CandleHeavy {").Append(Environment.NewLine);
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

        public override int GetHashCode() => HashCode.Combine(Time, Close, Open, High, Low, Volume);

        private static bool EqualsHelper(CandleHeavy? first, CandleHeavy? second) =>
            first?.Time == second?.Time &&
            first?.Close == second?.Close &&
            first?.Open == second?.Open &&
            first?.High == second?.High &&
            first?.Low == second?.Low &&
            first?.Volume == second?.Volume;

        public bool Equals(CandleHeavy? other)
        {
            if (this == (object?)other)
                return true;

            if ((object?)other == null)
                return false;

            return GetType() == other.GetType() && EqualsHelper(this, other);
        }

        public override bool Equals(object? obj) => Equals(obj as CandleHeavy);

        private static bool Equals(CandleHeavy? first, CandleHeavy? second) =>
            first?.Equals(second) ?? first == (object?)second;

        public static bool operator ==(CandleHeavy? first, CandleHeavy? second) => Equals(first, second);

        public static bool operator !=(CandleHeavy? first, CandleHeavy? second) => !Equals(first, second);

        IEnumerable<ValidationResult> IValidatableObject.Validate(ValidationContext validationContext)
        {
            yield break;
        }
    }
}
