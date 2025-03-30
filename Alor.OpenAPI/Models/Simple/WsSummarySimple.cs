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
    public sealed class WsSummarySimple : IEquatable<WsSummarySimple>, IValidatableObject, IWsElement<SummarySimple>
    {
        public WsSummarySimple() { }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="wsResponseSubSummariesGetAndSubscribeV2"]/Member[@name="wsResponseSubSummariesGetAndSubscribeV2"]/*' />
        [SpanJson.JsonConstructor]
        public WsSummarySimple(SummarySimple? data, string? guid)
        {
            Data = data;
            Guid = guid;
        }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="wsResponseSubSummariesGetAndSubscribeV2"]/Member[@name="data"]/*' />
        [DataMember(Name = "data", EmitDefaultValue = false)]
        public SummarySimple? Data { get; init; }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="wsResponseSubSummariesGetAndSubscribeV2"]/Member[@name="guid"]/*' />
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
            sb.Append("class WsSummary {").Append(Environment.NewLine);
            sb.Append("  Data: ").Append(Data).Append(Environment.NewLine);
            sb.Append("  Guid: ").Append(Guid).Append(Environment.NewLine);
            sb.Append('}').Append(Environment.NewLine);
            return sb.ToString();
        }

        public string ToJson() => Encoding.UTF8.GetString(JsonSerializer.Generic.Utf8.Serialize(this));

        public override int GetHashCode() => HashCode.Combine(Data, Guid);

        private static bool EqualsHelper(WsSummarySimple? first, WsSummarySimple? second) =>
            Equals(first?.Data, second?.Data) &&
            first?.Guid == second?.Guid;

        public bool Equals(WsSummarySimple? other)
        {
            if (this == (object?)other)
                return true;

            if ((object?)other == null)
                return false;

            return GetType() == other.GetType() && EqualsHelper(this, other);
        }

        public override bool Equals(object? obj) => Equals(obj as WsSummarySimple);

        private static bool Equals(WsSummarySimple? first, WsSummarySimple? second) =>
            first?.Equals(second) ?? first == (object?)second;

        public static bool operator ==(WsSummarySimple? first, WsSummarySimple? second) => Equals(first, second);

        public static bool operator !=(WsSummarySimple? first, WsSummarySimple? second) => !Equals(first, second);

        IEnumerable<ValidationResult> IValidatableObject.Validate(ValidationContext validationContext)
        {
            yield break;
        }
    }
}
