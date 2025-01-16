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
    public sealed class WsAllTradeHeavy : IEquatable<WsAllTradeHeavy>, IValidatableObject, IWsElement<AllTradeHeavy>
    {
        public WsAllTradeHeavy() { }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="wsResponseSubAllTradesGetAndSubscribe"]/Member[@name="wsResponseSubAllTradesGetAndSubscribe"]/*' />
        public WsAllTradeHeavy(AllTradeHeavy? dataHeavy, string? guid)
        {
            Data = dataHeavy;
            Guid = guid;
        }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="wsResponseSubAllTradesGetAndSubscribe"]/Member[@name="dataHeavy"]/*' />
        [DataMember(Name = "data", EmitDefaultValue = false)]
        public AllTradeHeavy? Data { get; private set; }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="wsResponseSubAllTradesGetAndSubscribe"]/Member[@name="guid"]/*' />
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
            sb.Append("class WsAllTrade {").Append(Environment.NewLine);
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

        private static bool EqualsHelper(WsAllTradeHeavy? first, WsAllTradeHeavy? second) =>
            (bool)first?.Data?.Equals(second?.Data) &&
            first?.Guid == second?.Guid;

        public bool Equals(WsAllTradeHeavy? other)
        {
            if (this == (object?)other)
                return true;

            if ((object?)other == null)
                return false;

            if (GetType() != other.GetType())
                return false;

            return EqualsHelper(this, other);
        }

        public override bool Equals(object? obj) => Equals(obj as WsAllTradeHeavy);

        private static bool Equals(WsAllTradeHeavy? first, WsAllTradeHeavy? second) =>
            first?.Equals(second) ?? first == (object?)second;

        public static bool operator ==(WsAllTradeHeavy? first, WsAllTradeHeavy? second) => Equals(first, second);

        public static bool operator !=(WsAllTradeHeavy? first, WsAllTradeHeavy? second) => !Equals(first, second);

        IEnumerable<ValidationResult> IValidatableObject.Validate(ValidationContext validationContext)
        {
            yield break;
        }
    }
}
