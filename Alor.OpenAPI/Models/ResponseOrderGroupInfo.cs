using Alor.OpenAPI.Enums;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text;
using SpanJson;

namespace Alor.OpenAPI.Models
{
    [DataContract]
    public class ResponseOrderGroupInfo : IEquatable<ResponseOrderGroupInfo>, IValidatableObject
    {
        public ResponseOrderGroupInfo() { }

        /// <include file='../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseOrderGroupInfo"]/Member[@name="responseOrderGroupInfo"]/*' />
        [JsonConstructor]
        public ResponseOrderGroupInfo(Guid? id = default, string? login = default,
            List<ResponseOrderGroupItem>? orders = default, ExecutionPolicy executionPolicy = default,
            OrderGroupStatus status = default, DateTime? createdAt = default, DateTime? closedAt = default)
        {
            Id = id;
            Login = login;
            Orders = orders;
            ExecutionPolicy = executionPolicy;
            Status = status;
            CreatedAt = createdAt;
            ClosedAt = closedAt;
        }

        /// <include file='../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseOrderGroupInfo"]/Member[@name="id"]/*' />
        [DataMember(Name = "id", EmitDefaultValue = false)]
        public Guid? Id { get; init; }

        /// <include file='../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseOrderGroupInfo"]/Member[@name="login"]/*' />
        [DataMember(Name = "login", EmitDefaultValue = false)]
        public string? Login { get; init; }

        /// <include file='../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseOrderGroupInfo"]/Member[@name="orders"]/*' />
        [DataMember(Name = "orders", EmitDefaultValue = false)]
        public List<ResponseOrderGroupItem>? Orders { get; init; }

        /// <include file='../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseOrderGroupInfo"]/Member[@name="executionPolicy"]/*' />
        [DataMember(Name = "executionPolicy", EmitDefaultValue = false)]
        public ExecutionPolicy ExecutionPolicy { get; init; }

        /// <include file='../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseOrderGroupInfo"]/Member[@name="status"]/*' />
        [DataMember(Name = "status", EmitDefaultValue = false)]
        public OrderGroupStatus Status { get; init; }

        /// <include file='../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseOrderGroupInfo"]/Member[@name="createdAt"]/*' />
        [DataMember(Name = "createdAt", EmitDefaultValue = false)]
        public DateTime? CreatedAt { get; init; }

        /// <include file='../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseOrderGroupInfo"]/Member[@name="closedAt"]/*' />
        [DataMember(Name = "closedAt", EmitDefaultValue = false)]
        public DateTime? ClosedAt { get; init; }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class ResponseOrderGroupInfo {").Append(Environment.NewLine);
            sb.Append("  Id: ").Append(Id).Append(Environment.NewLine);
            sb.Append("  Login: ").Append(Login).Append(Environment.NewLine);
            sb.Append("  Orders: ").Append(Orders == null ? "null" : string.Join(", ", Orders.Select(x => x.ToString()))).Append(Environment.NewLine);
            sb.Append("  ExecutionPolicy: ").Append(ExecutionPolicy).Append(Environment.NewLine);
            sb.Append("  Status: ").Append(Status).Append(Environment.NewLine);
            sb.Append("  CreatedAt: ").Append(CreatedAt).Append(Environment.NewLine);
            sb.Append("  ClosedAt: ").Append(ClosedAt).Append(Environment.NewLine);
            sb.Append('}').Append(Environment.NewLine);
            return sb.ToString();
        }

        public string ToJson() => Encoding.UTF8.GetString(SpanJson.JsonSerializer.Generic.Utf8.Serialize(this));

        public override int GetHashCode()
        {
            var hash = new HashCode();
            hash.Add(Id);
            hash.Add(Login);

            if (Orders == null) return hash.ToHashCode();
            foreach (var item in Orders)
            {
                hash.Add(item.GetHashCode());
            }

            hash.Add(ExecutionPolicy);
            hash.Add(Status);
            hash.Add(CreatedAt);
            hash.Add(ClosedAt);
            return hash.ToHashCode();
        }


        private static bool EqualsHelper(ResponseOrderGroupInfo? first,
            ResponseOrderGroupInfo? second) =>
            first?.Id == second?.Id &&
            first?.Login == second?.Login &&
            first?.Orders != null && second?.Orders != null
                ? first.Orders.SequenceEqual(second.Orders)
                : first?.Orders == null && second?.Orders == null &&
                  first?.ExecutionPolicy == second?.ExecutionPolicy &&
                  first?.Status == second?.Status &&
                  first?.CreatedAt == second?.CreatedAt &&
                  first?.ClosedAt == second?.ClosedAt;

        public bool Equals(ResponseOrderGroupInfo? other)
        {
            if (this == (object?)other)
                return true;

            if ((object?)other == null)
                return false;

            return GetType() == other.GetType() && EqualsHelper(this, other);
        }

        public override bool Equals(object? obj) => Equals(obj as ResponseOrderGroupInfo);

        private static bool Equals(ResponseOrderGroupInfo? first, ResponseOrderGroupInfo? second) =>
            first?.Equals(second) ?? first == (object?)second;

        public static bool operator ==(ResponseOrderGroupInfo? first, ResponseOrderGroupInfo? second) => Equals(first, second);

        public static bool operator !=(ResponseOrderGroupInfo? first, ResponseOrderGroupInfo? second) => !Equals(first, second);

        IEnumerable<ValidationResult> IValidatableObject.Validate(ValidationContext validationContext)
        {
            yield break;
        }
    }
}
