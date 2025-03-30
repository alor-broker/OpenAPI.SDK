using Alor.OpenAPI.Interfaces;
using SpanJson;
using System.Collections.Concurrent;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json.Serialization;

namespace Alor.OpenAPI.Models.Heavy
{
    [DataContract]
    public sealed class WsCandleHeavy : IEquatable<WsCandleHeavy>, IValidatableObject, IWsElement<CandleHeavy>
    {
        public WsCandleHeavy() { }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="wsResponseSubBarsGetAndSubscribe"]/Member[@name="wsResponseSubBarsGetAndSubscribe"]/*' />
        [SpanJson.JsonConstructor]
        public WsCandleHeavy(CandleHeavy? dataHeavy, string? guid)
        {
            Data = dataHeavy;
            Guid = guid;
        }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="wsResponseSubBarsGetAndSubscribe"]/Member[@name="dataHeavy"]/*' />
        [DataMember(Name = "data", EmitDefaultValue = false)]
        public CandleHeavy? Data { get; init; }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="wsResponseSubBarsGetAndSubscribe"]/Member[@name="guid"]/*' />
        [DataMember(Name = "guid", EmitDefaultValue = false)]
        public string? Guid { get; init; }

        [IgnoreDataMember]
        [JsonIgnore]
        DateTime? IWsElement.ReceivedDateTimeUtc { get; set; }

        [IgnoreDataMember]
        [JsonIgnore]
        ConcurrentDictionary<string, Parameters>? IWsElement.Parameters { get; set; }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class WsCandle {").Append(Environment.NewLine);
            sb.Append("  Data: ").Append(Data).Append(Environment.NewLine);
            sb.Append("  Guid: ").Append(Guid).Append(Environment.NewLine);
            sb.Append('}').Append(Environment.NewLine);
            return sb.ToString();
        }

        public string ToJson() => Encoding.UTF8.GetString(JsonSerializer.Generic.Utf8.Serialize(this));

        public override int GetHashCode() => HashCode.Combine(Data, Guid);

        private static bool EqualsHelper(WsCandleHeavy? first, WsCandleHeavy? second) =>
            Equals(first?.Data, second?.Data) &&
            first?.Guid == second?.Guid;

        public bool Equals(WsCandleHeavy? other)
        {
            if (this == (object?)other)
                return true;

            if ((object?)other == null)
                return false;

            return GetType() == other.GetType() && EqualsHelper(this, other);
        }

        public override bool Equals(object? obj) => Equals(obj as WsCandleHeavy);

        private static bool Equals(WsCandleHeavy? first, WsCandleHeavy? second) =>
            first?.Equals(second) ?? first == (object?)second;

        public static bool operator ==(WsCandleHeavy? first, WsCandleHeavy? second) => Equals(first, second);

        public static bool operator !=(WsCandleHeavy? first, WsCandleHeavy? second) => !Equals(first, second);

        IEnumerable<ValidationResult> IValidatableObject.Validate(ValidationContext validationContext)
        {
            yield break;
        }
    }
}
