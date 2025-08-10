﻿using Alor.OpenAPI.Enums;
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
    public sealed class WsPositionHeavy : IEquatable<WsPositionHeavy>, IValidatableObject, IWsElement<PositionHeavy>
    {
        public WsPositionHeavy() { }

        /// <include file='../../XmlDocs/CoreModels.xml'
        ///          path='Docs/Members[@name="wsResponseSubPositionsGetAndSubscribe"]
        ///               /Member[@name="wsResponseSubPositionsGetAndSubscribe"]
        ///               /param[@name="dataHeavy" or @name="guid"]'/>
        public WsPositionHeavy(PositionHeavy? dataHeavy, string? guid)
        {
            Data = dataHeavy;
            Guid = guid;
        }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="wsResponseSubPositionsGetAndSubscribe"]/Member[@name="dataHeavy"]/*' />
        [DataMember(Name = "data", EmitDefaultValue = false)]
        public PositionHeavy? Data { get; init; }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="wsResponseSubPositionsGetAndSubscribe"]/Member[@name="guid"]/*' />
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
            sb.Append("class WsPosition {").Append(Environment.NewLine);
            sb.Append("  Data: ").Append(Data).Append(Environment.NewLine);
            sb.Append("  Guid: ").Append(Guid).Append(Environment.NewLine);
            sb.Append('}').Append(Environment.NewLine);
            return sb.ToString();
        }

        public string ToJson() => Encoding.UTF8.GetString(JsonSerializer.Generic.Utf8.Serialize(this));

        public override int GetHashCode() => HashCode.Combine(Data, Guid);

        private static bool EqualsHelper(WsPositionHeavy? first, WsPositionHeavy? second) =>
            Equals(first?.Data, second?.Data) &&
            first?.Guid == second?.Guid;

        public bool Equals(WsPositionHeavy? other)
        {
            if (this == (object?)other)
                return true;

            if (other is null)
                return false;

            return GetType() == other.GetType() && EqualsHelper(this, other);
        }

        public override bool Equals(object? obj) => Equals(obj as WsPositionHeavy);

        private static bool Equals(WsPositionHeavy? first, WsPositionHeavy? second) =>
            first?.Equals(second) ?? first == (object?)second;

        public static bool operator ==(WsPositionHeavy? first, WsPositionHeavy? second) => Equals(first, second);

        public static bool operator !=(WsPositionHeavy? first, WsPositionHeavy? second) => !Equals(first, second);

        IEnumerable<ValidationResult> IValidatableObject.Validate(ValidationContext validationContext)
        {
            yield break;
        }
    }
}
