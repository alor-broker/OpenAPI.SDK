using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text;
using SpanJson;

namespace Alor.OpenAPI.Models.Simple
{
    [DataContract]
    public sealed class CandleSimple : IEquatable<CandleSimple>, IValidatableObject
    {
        public CandleSimple() { }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseHistoryObject"]/Member[@name="responseHistoryObject"]/*' />
        public CandleSimple(long? time = default, decimal? close = default,
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
        public long? Time { get; private set; }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseHistoryObject"]/Member[@name="close"]/*' />
        [DataMember(Name = "close", EmitDefaultValue = false)]
        public decimal? Close { get; private set; }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseHistoryObject"]/Member[@name="open"]/*' />
        [DataMember(Name = "open", EmitDefaultValue = false)]
        public decimal? Open { get; private set; }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseHistoryObject"]/Member[@name="high"]/*' />
        [DataMember(Name = "high", EmitDefaultValue = false)]
        public decimal? High { get; private set; }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseHistoryObject"]/Member[@name="low"]/*' />
        [DataMember(Name = "low", EmitDefaultValue = false)]
        public decimal? Low { get; private set; }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseHistoryObject"]/Member[@name="volume"]/*' />
        [DataMember(Name = "volume", EmitDefaultValue = false)]
        public int? Volume { get; private set; }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class CandleSimple {").Append(Environment.NewLine);
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

        private static bool EqualsHelper(CandleSimple? first, CandleSimple? second) =>
            first?.Time == second?.Time &&
            first?.Close == second?.Close &&
            first?.Open == second?.Open &&
            first?.High == second?.High &&
            first?.Low == second?.Low &&
            first?.Volume == second?.Volume;


        public bool Equals(CandleSimple? other)
        {
            if (this == (object?)other)
                return true;

            if ((object?)other == null)
                return false;

            if (GetType() != other.GetType())
                return false;

            return EqualsHelper(this, other);
        }

        public override bool Equals(object? obj) => Equals(obj as CandleSimple);

        private static bool Equals(CandleSimple? first, CandleSimple? second) =>
            first?.Equals(second) ?? first == (object?)second;

        public static bool operator ==(CandleSimple? first, CandleSimple? second) => Equals(first, second);

        public static bool operator !=(CandleSimple? first, CandleSimple? second) => !Equals(first, second);

        IEnumerable<ValidationResult> IValidatableObject.Validate(ValidationContext validationContext)
        {
            yield break;
        }
    }
}
