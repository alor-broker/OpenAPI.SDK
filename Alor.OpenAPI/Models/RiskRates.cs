﻿using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text;
using SpanJson;

namespace Alor.OpenAPI.Models
{
    [DataContract]
    public sealed class RiskRates : IEquatable<RiskRates>, IValidatableObject
    {
        public RiskRates() { }

        /// <include file='../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseRiskRates"]/Member[@name="responseRiskRates"]/*' />
        public RiskRates(int? total = null, List<RiskRate>? list = null)
        {
            Total = total;
            List = list;
        }

        /// <include file='../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseRiskRates"]/Member[@name="total"]/*' />
        [DataMember(Name = "total", EmitDefaultValue = false)]
        public int? Total { get; init; }

        /// <include file='../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseRiskRates"]/Member[@name="list"]/*' />
        [DataMember(Name = "list", EmitDefaultValue = false)]
        public List<RiskRate>? List { get; init; }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class RiskRates {").Append(Environment.NewLine);
            sb.Append("  Total: ").Append(Total).Append(Environment.NewLine);
            sb.Append("  List: ").Append(List == null ? "null" : string.Join(", ", List.Select(x => x.ToString()))).Append(Environment.NewLine);
            sb.Append('}').Append(Environment.NewLine);
            return sb.ToString();
        }

        public string ToJson() => Encoding.UTF8.GetString(JsonSerializer.Generic.Utf8.Serialize(this));

        public override int GetHashCode()
        {
            var hash = new HashCode();
            hash.Add(Total);

            if (List == null) return hash.ToHashCode();
            foreach (var item in List)
            {
                hash.Add(item.GetHashCode());
            }

            return hash.ToHashCode();
        }

        private static bool EqualsHelper(RiskRates? first, RiskRates? second)
        {
            if (ReferenceEquals(first, second))
            {
                return true;
            }

            if (first is null || second is null)
            {
                return false;
            }

            return first.Total == second.Total &&
                   first.List != null &&
                   second.List != null &&
                   first.List.SequenceEqual(second.List);
        }

        public bool Equals(RiskRates? other)
        {
            if (this == (object?)other)
                return true;

            if (other is null)
                return false;

            return GetType() == other.GetType() && EqualsHelper(this, other);
        }

        public override bool Equals(object? obj) => Equals(obj as RiskRates);

        private static bool Equals(RiskRates? first, RiskRates? second) =>
            first?.Equals(second) ?? first == (object?)second;

        public static bool operator ==(RiskRates? first, RiskRates? second) => Equals(first, second);

        public static bool operator !=(RiskRates? first, RiskRates? second) => !Equals(first, second);

        IEnumerable<ValidationResult> IValidatableObject.Validate(ValidationContext validationContext)
        {
            yield break;
        }
    }
}
