﻿using SpanJson;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text;

namespace Alor.OpenAPI.Models
{
    [DataContract]
    public class ResponseOrderGroupItem : IEquatable<ResponseOrderGroupItem>, IValidatableObject
    {
        public ResponseOrderGroupItem() { }

        /// <include file='../XmlDocs/CoreModels.xml' path='Docs/Members[@name="objectOrderGroupItems"]/Member[@name="objectOrderGroupItems"]/*' />
        public ResponseOrderGroupItem(string? orderId = default)
        {
            OrderId = orderId;
        }

        /// <include file='../XmlDocs/CoreModels.xml' path='Docs/Members[@name="objectOrderGroupItems"]/Member[@name="orderId"]/*' />
        [DataMember(Name = "orderId", EmitDefaultValue = false)]
        public string? OrderId { get; private set; }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class ResponseOrderGroupItem {").Append(Environment.NewLine);
            sb.Append("  OrderId: ").Append(OrderId).Append(Environment.NewLine);
            sb.Append('}').Append(Environment.NewLine);
            return sb.ToString();
        }

        public string ToJson() => Encoding.UTF8.GetString(JsonSerializer.Generic.Utf8.Serialize(this));

        public override int GetHashCode() => Utilities.Utilities.GetHashCodeHelper(
            [
                OrderId?.GetHashCode() ?? 0,
            ]
        );

        private static bool EqualsHelper(ResponseOrderGroupItem? first, ResponseOrderGroupItem? second) =>
            first?.OrderId == second?.OrderId;

        public bool Equals(ResponseOrderGroupItem? other)
        {
            if (this == (object?)other)
                return true;

            if ((object?)other == null)
                return false;

            if (GetType() != other.GetType())
                return false;

            return EqualsHelper(this, other);
        }

        public override bool Equals(object? obj) => Equals(obj as ResponseOrderGroupItem);

        private static bool Equals(ResponseOrderGroupItem? first, ResponseOrderGroupItem? second) =>
            first?.Equals(second) ?? first == (object?)second;

        public static bool operator ==(ResponseOrderGroupItem? first, ResponseOrderGroupItem? second) => Equals(first, second);

        public static bool operator !=(ResponseOrderGroupItem? first, ResponseOrderGroupItem? second) => !Equals(first, second);

        IEnumerable<ValidationResult> IValidatableObject.Validate(ValidationContext validationContext)
        {
            yield break;
        }
    }
}
