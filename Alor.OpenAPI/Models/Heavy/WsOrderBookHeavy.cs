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
    public sealed class WsOrderBookHeavy : IEquatable<WsOrderBookHeavy>, IValidatableObject, IWsElement<OrderbookHeavy>
    {
        public WsOrderBookHeavy() { }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="wsResponseSubOrderBookGetAndSubscribe"]/Member[@name="wsResponseSubOrderBookGetAndSubscribe"]/*' />
        [SpanJson.JsonConstructor]
        public WsOrderBookHeavy(OrderbookHeavy? dataHeavy, string? guid)
        {
            Data = dataHeavy;
            Guid = guid;
        }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="wsResponseSubOrderBookGetAndSubscribe"]/Member[@name="dataHeavy"]/*' />
        [DataMember(Name = "data", EmitDefaultValue = false)]
        public OrderbookHeavy? Data { get; private set; }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="wsResponseSubOrderBookGetAndSubscribe"]/Member[@name="guid"]/*' />
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
            sb.Append("class WsOrderBook {").Append(Environment.NewLine);
            sb.Append("  Data: ").Append(Data).Append(Environment.NewLine);
            sb.Append("  Guid: ").Append(Guid).Append(Environment.NewLine);
            sb.Append('}').Append(Environment.NewLine);
            return sb.ToString();
        }

        public string ToJson() => Encoding.UTF8.GetString(JsonSerializer.Generic.Utf8.Serialize(this));

        public override int GetHashCode() => HashCode.Combine(Data, Guid);

        private static bool EqualsHelper(WsOrderBookHeavy? first, WsOrderBookHeavy? second) =>
            Equals(first?.Data, second?.Data) &&
            first?.Guid == second?.Guid;

        public bool Equals(WsOrderBookHeavy? other)
        {
            if (this == (object?)other)
                return true;

            if ((object?)other == null)
                return false;

            return GetType() == other.GetType() && EqualsHelper(this, other);
        }

        public override bool Equals(object? obj) => Equals(obj as WsOrderBookHeavy);

        private static bool Equals(WsOrderBookHeavy? first, WsOrderBookHeavy? second) =>
            first?.Equals(second) ?? first == (object?)second;

        public static bool operator ==(WsOrderBookHeavy? first, WsOrderBookHeavy? second) => Equals(first, second);

        public static bool operator !=(WsOrderBookHeavy? first, WsOrderBookHeavy? second) => !Equals(first, second);

        IEnumerable<ValidationResult> IValidatableObject.Validate(ValidationContext validationContext)
        {
            yield break;
        }
    }
}
