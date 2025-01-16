using Alor.OpenAPI.Interfaces;
using SpanJson;
using System.Collections.Concurrent;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json.Serialization;

namespace Alor.OpenAPI.Models.Slim
{
    [DataContract]
    public sealed class WsSecurityFromWsSlim : IEquatable<WsSecurityFromWsSlim>, IValidatableObject, IWsElement<SecurityFromWsSlim>
    {
        public WsSecurityFromWsSlim() { }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="wsResponseSubInstrumentsGetAndSubscribeV2"]/Member[@name="wsResponseSubInstrumentsGetAndSubscribeV2"]/*' />
        public WsSecurityFromWsSlim(SecurityFromWsSlim? dataSlim, string? guid)
        {
            Data = dataSlim;
            Guid = guid;
        }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="wsResponseSubInstrumentsGetAndSubscribeV2"]/Member[@name="dataSlim"]/*' />
        [DataMember(Name = "data", EmitDefaultValue = false)]
        public SecurityFromWsSlim? Data { get; private set; }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="wsResponseSubInstrumentsGetAndSubscribeV2"]/Member[@name="guid"]/*' />
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
            sb.Append("class WsSecurityFromWs {").Append(Environment.NewLine);
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

        private static bool EqualsHelper(WsSecurityFromWsSlim? first, WsSecurityFromWsSlim? second) =>
            (bool)first?.Data?.Equals(second?.Data) &&
            first?.Guid == second?.Guid;

        public bool Equals(WsSecurityFromWsSlim? other)
        {
            if (this == (object?)other)
                return true;

            if ((object?)other == null)
                return false;

            if (GetType() != other.GetType())
                return false;

            return EqualsHelper(this, other);
        }

        public override bool Equals(object? obj) => Equals(obj as WsSecurityFromWsSlim);

        private static bool Equals(WsSecurityFromWsSlim? first, WsSecurityFromWsSlim? second) =>
            first?.Equals(second) ?? first == (object?)second;

        public static bool operator ==(WsSecurityFromWsSlim? first, WsSecurityFromWsSlim? second) => Equals(first, second);

        public static bool operator !=(WsSecurityFromWsSlim? first, WsSecurityFromWsSlim? second) => !Equals(first, second);

        IEnumerable<ValidationResult> IValidatableObject.Validate(ValidationContext validationContext)
        {
            yield break;
        }
    }
}
