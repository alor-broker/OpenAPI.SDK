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
    public sealed class WsSymbolSlim : IEquatable<WsSymbolSlim>, IValidatableObject, IWsElement<SymbolSlim>
    {
        public WsSymbolSlim() { }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="wsResponseSubQuotesSubscribe"]/Member[@name="wsResponseSubQuotesSubscribe"]/*' />
        public WsSymbolSlim(SymbolSlim? dataSlim, string? guid)
        {
            Data = dataSlim;
            Guid = guid;
        }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="wsResponseSubQuotesSubscribe"]/Member[@name="dataSlim"]/*' />
        [DataMember(Name = "data", EmitDefaultValue = false)]
        public SymbolSlim? Data { get; init; }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="wsResponseSubQuotesSubscribe"]/Member[@name="guid"]/*' />
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
            sb.Append("class WsSymbol {").Append(Environment.NewLine);
            sb.Append("  Data: ").Append(Data).Append(Environment.NewLine);
            sb.Append("  Guid: ").Append(Guid).Append(Environment.NewLine);
            sb.Append('}').Append(Environment.NewLine);
            return sb.ToString();
        }

        public string ToJson() => Encoding.UTF8.GetString(JsonSerializer.Generic.Utf8.Serialize(this));

        public override int GetHashCode() => HashCode.Combine(Data, Guid);

        private static bool EqualsHelper(WsSymbolSlim? first, WsSymbolSlim? second) =>
            Equals(first?.Data, second?.Data) &&
            first?.Guid == second?.Guid;

        public bool Equals(WsSymbolSlim? other)
        {
            if (this == (object?)other)
                return true;

            if ((object?)other == null)
                return false;

            return GetType() == other.GetType() && EqualsHelper(this, other);
        }

        public override bool Equals(object? obj) => Equals(obj as WsSymbolSlim);

        private static bool Equals(WsSymbolSlim? first, WsSymbolSlim? second) =>
            first?.Equals(second) ?? first == (object?)second;

        public static bool operator ==(WsSymbolSlim? first, WsSymbolSlim? second) => Equals(first, second);

        public static bool operator !=(WsSymbolSlim? first, WsSymbolSlim? second) => !Equals(first, second);

        IEnumerable<ValidationResult> IValidatableObject.Validate(ValidationContext validationContext)
        {
            yield break;
        }
    }
}
