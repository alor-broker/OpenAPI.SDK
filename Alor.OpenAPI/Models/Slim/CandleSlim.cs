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

        /// <include file='../../XmlDocs/CoreModels.xml'
        ///          path='Docs/Members[@name="responseHistoryObject"]
        ///               /Member[@name="responseHistoryObject"]
        ///               /param[@name="time" or @name="close" or @name="open" or @name="high" or @name="low" or @name="volume"]'/>
        public CandleSlim(long? time = null, decimal? close = null,
            decimal? open = null, decimal? high = null, decimal? low = null,
            long? volume = null)
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
        public long? Time { get; init; }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseHistoryObject"]/Member[@name="close"]/*' />
        [DataMember(Name = "c", EmitDefaultValue = false)]
        public decimal? Close { get; init; }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseHistoryObject"]/Member[@name="open"]/*' />
        [DataMember(Name = "o", EmitDefaultValue = false)]
        public decimal? Open { get; init; }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseHistoryObject"]/Member[@name="high"]/*' />
        [DataMember(Name = "h", EmitDefaultValue = false)]
        public decimal? High { get; init; }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseHistoryObject"]/Member[@name="low"]/*' />
        [DataMember(Name = "l", EmitDefaultValue = false)]
        public decimal? Low { get; init; }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseHistoryObject"]/Member[@name="volume"]/*' />
        [DataMember(Name = "v", EmitDefaultValue = false)]
        public long? Volume { get; init; }

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

        public override int GetHashCode() => HashCode.Combine(Time, Close, Open, High, Low, Volume);

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

            if (other is null)
                return false;

            return GetType() == other.GetType() && EqualsHelper(this, other);
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
