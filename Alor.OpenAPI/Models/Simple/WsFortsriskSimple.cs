using Alor.OpenAPI.Interfaces;
using SpanJson;
using System.Collections.Concurrent;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json.Serialization;

namespace Alor.OpenAPI.Models.Simple
{
    [DataContract]
    public sealed class WsFortsriskSimple : IEquatable<WsFortsriskSimple>, IValidatableObject, IWsElement<FortsriskSimple>
    {
        public WsFortsriskSimple() { }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="wsResponseSubSpectraRisksGetAndSubscribe"]/Member[@name="wsResponseSubSpectraRisksGetAndSubscribe"]/*' />
        public WsFortsriskSimple(FortsriskSimple? data, string? guid)
        {
            Data = data;
            Guid = guid;
        }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="wsResponseSubSpectraRisksGetAndSubscribe"]/Member[@name="data"]/*' />
        [DataMember(Name = "data", EmitDefaultValue = false)]
        public FortsriskSimple? Data { get; private set; }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="wsResponseSubSpectraRisksGetAndSubscribe"]/Member[@name="guid"]/*' />
        [DataMember(Name = "guid", EmitDefaultValue = false)]
        public string? Guid { get; private set; }

        [IgnoreDataMember]
        [JsonIgnore]
        DateTime? IWsElement.ReceivedDateTimeUtc { get; set; }

        [IgnoreDataMember]
        [JsonIgnore]
        ConcurrentDictionary<string, Parameters>? IWsElement.Parameters { get; set; }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class WsFortsrisk {").Append(Environment.NewLine);
            sb.Append("  Data: ").Append(Data).Append(Environment.NewLine);
            sb.Append("  Guid: ").Append(Guid).Append(Environment.NewLine);
            sb.Append('}').Append(Environment.NewLine);
            return sb.ToString();
        }

        public string ToJson() => Encoding.UTF8.GetString(JsonSerializer.Generic.Utf8.Serialize(this));

        public override int GetHashCode() => Utilities.Utilities.GetHashCodeHelper(
            [
                Data?.GetHashCode() ?? 0,
                Guid?.GetHashCode() ?? 0,
            ]
        );

        private static bool EqualsHelper(WsFortsriskSimple? first, WsFortsriskSimple? second) =>
            (bool)first?.Data?.Equals(second?.Data) &&
            first?.Guid == second?.Guid;

        public bool Equals(WsFortsriskSimple? other)
        {
            if (this == (object?)other)
                return true;

            if ((object?)other == null)
                return false;

            if (GetType() != other.GetType())
                return false;

            return EqualsHelper(this, other);
        }

        public override bool Equals(object? obj) => Equals(obj as WsFortsriskSimple);

        private static bool Equals(WsFortsriskSimple? first, WsFortsriskSimple? second) =>
            first?.Equals(second) ?? first == (object?)second;

        public static bool operator ==(WsFortsriskSimple? first, WsFortsriskSimple? second) => Equals(first, second);

        public static bool operator !=(WsFortsriskSimple? first, WsFortsriskSimple? second) => !Equals(first, second);

        IEnumerable<ValidationResult> IValidatableObject.Validate(ValidationContext validationContext)
        {
            yield break;
        }
    }
}
