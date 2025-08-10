﻿using Alor.OpenAPI.Enums;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text;
using SpanJson;

namespace Alor.OpenAPI.Models
{
    [DataContract]
    internal sealed class RequestCreateOrderGroup : IEquatable<RequestCreateOrderGroup>, IValidatableObject
    {
        public RequestCreateOrderGroup() { }

        /// <include file='../XmlDocs/CoreModels.xml' path='Docs/Members[@name="OrderGroupCreate"]/Member[@name="OrderGroupCreate"]/*' />
        public RequestCreateOrderGroup(ICollection<RequestOrderGroupItem>? orders = null, ExecutionPolicy? executionPolicy = null)
        {
            // to ensure "orders" is required (not null)
            Orders = orders ?? throw new InvalidDataException(
                "orders is a required property for RequestCreateOrderGroup and cannot be null");

            // to ensure "executionPolicy" is required (not null)
            ExecutionPolicy = executionPolicy ?? throw new InvalidDataException(
                    "executionPolicy is a required property for RequestCreateOrderGroup and cannot be null");
        }

        /// <include file='../XmlDocs/CoreModels.xml' path='Docs/Members[@name="OrderGroupCreate"]/Member[@name="orders"]/*' />
        [DataMember(Name = "orders", EmitDefaultValue = false)]
        public ICollection<RequestOrderGroupItem>? Orders { get; init; }

        /// <include file='../XmlDocs/CoreModels.xml' path='Docs/Members[@name="OrderGroupCreate"]/Member[@name="executionPolicy"]/*' />
        [DataMember(Name = "executionPolicy", EmitDefaultValue = false)]
        public ExecutionPolicy? ExecutionPolicy { get; init; }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class RequestCreateOrderGroup {").Append(Environment.NewLine);
            sb.Append("  Orders: ").Append(Orders == null ? "null" : string.Join(", ", Orders.Select(x => x.ToString()))).Append(Environment.NewLine);
            sb.Append("  ExecutionPolicy: ").Append(ExecutionPolicy).Append(Environment.NewLine);
            sb.Append('}').Append(Environment.NewLine);
            return sb.ToString();
        }

        public string ToJson() => Encoding.UTF8.GetString(JsonSerializer.Generic.Utf8.Serialize(this));

        public override int GetHashCode()
        {
            var hash = new HashCode();

            if (Orders == null) return hash.ToHashCode();
            foreach (var item in Orders)
            {
                hash.Add(item.GetHashCode());
            }

            hash.Add(ExecutionPolicy);
            return hash.ToHashCode();
        }

        private static bool EqualsHelper(RequestCreateOrderGroup? first, RequestCreateOrderGroup? second) =>
            first?.Orders != null && second?.Orders != null
                ? first.Orders.SequenceEqual(second.Orders)
                : first?.Orders == null && second?.Orders == null &&
                  first?.ExecutionPolicy == second?.ExecutionPolicy;

        public bool Equals(RequestCreateOrderGroup? other)
        {
            if (this == (object?)other)
                return true;

            if (other is null)
                return false;

            return GetType() == other.GetType() && EqualsHelper(this, other);
        }

        public override bool Equals(object? obj) => Equals(obj as RequestCreateOrderGroup);

        private static bool Equals(RequestCreateOrderGroup? first, RequestCreateOrderGroup? second) =>
            first?.Equals(second) ?? first == (object?)second;

        public static bool operator ==(RequestCreateOrderGroup? first, RequestCreateOrderGroup? second) => Equals(first, second);

        public static bool operator !=(RequestCreateOrderGroup? first, RequestCreateOrderGroup? second) => !Equals(first, second);

        IEnumerable<ValidationResult> IValidatableObject.Validate(ValidationContext validationContext)
        {
            yield break;
        }
    }
}
