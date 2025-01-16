using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text;
using SpanJson;

namespace Alor.OpenAPI.Models
{
    [DataContract]
    public sealed class Iceberg : IEquatable<Iceberg>, IValidatableObject
    {
        public Iceberg() { }

        /// <include file='../XmlDocs/CoreModels.xml' path='Docs/Members[@name="objectIcebergFields"]/Member[@name="objectIcebergFields"]/*' />
        public Iceberg(int? creationFixedQuantity = default, int? creationVarianceQuantity = default,
            int? visibleQuantity = default, int? visibleQuantityBatch = default,
            int? visibleFilledQuantity = default, int? visibleFilledQuantityBatch = default)
        {
            CreationFixedQuantity = creationFixedQuantity;
            CreationVarianceQuantity = creationVarianceQuantity;
            VisibleQuantity = visibleQuantity;
            VisibleQuantityBatch = visibleQuantityBatch;
            VisibleFilledQuantity = visibleFilledQuantity;
            VisibleFilledQuantityBatch = visibleFilledQuantityBatch;
        }

        /// <include file='../XmlDocs/CoreModels.xml' path='Docs/Members[@name="objectIcebergFields"]/Member[@name="creationFixedQuantity"]/*' />
        [DataMember(Name = "creationFixedQuantity", EmitDefaultValue = false)]
        public int? CreationFixedQuantity { get; private set; }

        /// <include file='../XmlDocs/CoreModels.xml' path='Docs/Members[@name="objectIcebergFields"]/Member[@name="creationVarianceQuantity"]/*' />
        [DataMember(Name = "creationVarianceQuantity", EmitDefaultValue = false)]
        public int? CreationVarianceQuantity { get; private set; }

        /// <include file='../XmlDocs/CoreModels.xml' path='Docs/Members[@name="objectIcebergFields"]/Member[@name="visibleQuantity"]/*' />
        [DataMember(Name = "visibleQuantity", EmitDefaultValue = false)]
        public int? VisibleQuantity { get; private set; }

        /// <include file='../XmlDocs/CoreModels.xml' path='Docs/Members[@name="objectIcebergFields"]/Member[@name="visibleQuantityBatch"]/*' />
        [DataMember(Name = "visibleQuantityBatch", EmitDefaultValue = false)]
        public int? VisibleQuantityBatch { get; private set; }

        /// <include file='../XmlDocs/CoreModels.xml' path='Docs/Members[@name="objectIcebergFields"]/Member[@name="visibleFilledQuantity"]/*' />
        [DataMember(Name = "visibleFilledQuantity", EmitDefaultValue = false)]
        public int? VisibleFilledQuantity { get; private set; }

        /// <include file='../XmlDocs/CoreModels.xml' path='Docs/Members[@name="objectIcebergFields"]/Member[@name="visibleFilledQuantityBatch"]/*' />
        [DataMember(Name = "visibleFilledQuantityBatch", EmitDefaultValue = false)]
        public int? VisibleFilledQuantityBatch { get; private set; }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class IcebergObject {").Append(Environment.NewLine);
            sb.Append("  CreationFixedQuantity: ").Append(CreationFixedQuantity).Append(Environment.NewLine);
            sb.Append("  CreationVarianceQuantity: ").Append(CreationVarianceQuantity).Append(Environment.NewLine);
            sb.Append("  VisibleQuantity: ").Append(VisibleQuantity).Append(Environment.NewLine);
            sb.Append("  VisibleQuantityBatch: ").Append(VisibleQuantityBatch).Append(Environment.NewLine);
            sb.Append("  VisibleFilledQuantity: ").Append(VisibleFilledQuantity).Append(Environment.NewLine);
            sb.Append("  VisibleFilledQuantityBatch: ").Append(VisibleFilledQuantityBatch).Append(Environment.NewLine);
            sb.Append('}').Append(Environment.NewLine);
            return sb.ToString();
        }

        public string ToJson() => Encoding.UTF8.GetString(JsonSerializer.Generic.Utf8.Serialize(this));

        public override int GetHashCode() => Utilities.Utilities.GetHashCodeHelper(
            [
                CreationFixedQuantity?.GetHashCode() ?? 0,
                CreationVarianceQuantity?.GetHashCode() ?? 0,
                VisibleQuantity?.GetHashCode() ?? 0,
                VisibleQuantityBatch?.GetHashCode() ?? 0,
                VisibleFilledQuantity?.GetHashCode() ?? 0,
                VisibleFilledQuantityBatch?.GetHashCode() ?? 0,
            ]
        );

        private static bool EqualsHelper(Iceberg? first, Iceberg? second) =>
            first?.CreationFixedQuantity == second?.CreationFixedQuantity &&
            first?.CreationVarianceQuantity == second?.CreationVarianceQuantity &&
            first?.VisibleQuantity == second?.VisibleQuantity &&
            first?.VisibleQuantityBatch == second?.VisibleQuantityBatch &&
            first?.VisibleFilledQuantity == second?.VisibleFilledQuantity &&
            first?.VisibleFilledQuantityBatch == second?.VisibleFilledQuantityBatch;

        public bool Equals(Iceberg? other)
        {
            if (this == (object?)other)
                return true;

            if ((object?)other == null)
                return false;

            if (GetType() != other.GetType())
                return false;

            return EqualsHelper(this, other);
        }

        public override bool Equals(object? obj) => Equals(obj as Iceberg);

        private static bool Equals(Iceberg? first, Iceberg? second) =>
            first?.Equals(second) ?? first == (object?)second;

        public static bool operator ==(Iceberg? first, Iceberg? second) => Equals(first, second);

        public static bool operator !=(Iceberg? first, Iceberg? second) => !Equals(first, second);

        IEnumerable<ValidationResult> IValidatableObject.Validate(ValidationContext validationContext)
        {
            yield break;
        }
    }
}
