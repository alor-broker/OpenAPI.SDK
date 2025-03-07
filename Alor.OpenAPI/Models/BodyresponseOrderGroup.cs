﻿using SpanJson;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text;

namespace Alor.OpenAPI.Models
{
    [DataContract]
    public sealed class BodyresponseOrderGroup : IEquatable<BodyresponseOrderGroup>, IValidatableObject
    {
        public BodyresponseOrderGroup() { }

        /// <include file='../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseOrderGroupCreationSuccess"]/Member[@name="responseOrderGroupCreationSuccess"]/*' />
        public BodyresponseOrderGroup(string? message = default, Guid? groupId = default)
        {
            Message = message;
            GroupId = groupId;
        }

        /// <include file='../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseOrderGroupCreationSuccess"]/Member[@name="message"]/*' />
        [DataMember(Name = "message", EmitDefaultValue = false)]
        public string? Message { get; set; }

        /// <include file='../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseOrderGroupCreationSuccess"]/Member[@name="groupId"]/*' />
        [DataMember(Name = "groupId", EmitDefaultValue = false)]
        public Guid? GroupId { get; set; }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class BodyresponseOrderGroup {").Append(Environment.NewLine);
            sb.Append("  Message: ").Append(Message).Append(Environment.NewLine);
            sb.Append("  GroupId: ").Append(GroupId).Append(Environment.NewLine);
            sb.Append('}').Append(Environment.NewLine);
            return sb.ToString();
        }

        public string ToJson() => Encoding.UTF8.GetString(JsonSerializer.Generic.Utf8.Serialize(this));

        public override int GetHashCode() => Utilities.Utilities.GetHashCodeHelper(
            [
                Message?.GetHashCode() ?? 0,
                GroupId?.GetHashCode() ?? 0,
            ]
        );

        private static bool EqualsHelper(BodyresponseOrderGroup? first, BodyresponseOrderGroup? second) =>
            first?.Message == second?.Message &&
            first?.GroupId == second?.GroupId;

        public bool Equals(BodyresponseOrderGroup? other)
        {
            if (this == (object?)other)
                return true;

            if ((object?)other == null)
                return false;

            if (GetType() != other.GetType())
                return false;

            return EqualsHelper(this, other);
        }

        public override bool Equals(object? obj) => Equals(obj as BodyresponseOrderGroup);

        private static bool Equals(BodyresponseOrderGroup? first, BodyresponseOrderGroup? second) =>
            first?.Equals(second) ?? first == (object?)second;

        public static bool operator ==(BodyresponseOrderGroup? first, BodyresponseOrderGroup? second) => Equals(first, second);

        public static bool operator !=(BodyresponseOrderGroup? first, BodyresponseOrderGroup? second) => !Equals(first, second);

        IEnumerable<ValidationResult> IValidatableObject.Validate(ValidationContext validationContext)
        {
            yield break;
        }
    }
}
