using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text;
using SpanJson;

namespace Alor.OpenAPI.Models.Slim
{
    [DataContract]
    public sealed class FortsriskSlim : IEquatable<FortsriskSlim>, IValidatableObject
    {
        public FortsriskSlim() { }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseFortsRisk"]/Member[@name="responseFortsRisk"]/*' />
        public FortsriskSlim(string? portfolio = default, decimal? moneyFree = default,
            decimal? moneyBlocked = default, decimal? fee = default, decimal? moneyOld = default,
            decimal? moneyAmount = default, decimal? moneyPledgeAmount = default, decimal? vmInterCl = default,
            decimal? vmCurrentPositions = default, bool? isLimitsSet = default)
        {
            Portfolio = portfolio;
            MoneyFree = moneyFree;
            MoneyBlocked = moneyBlocked;
            Fee = fee;
            MoneyOld = moneyOld;
            MoneyAmount = moneyAmount;
            MoneyPledgeAmount = moneyPledgeAmount;
            VmInterCl = vmInterCl;
            VmCurrentPositions = vmCurrentPositions;
            IsLimitsSet = isLimitsSet;
        }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseFortsRisk"]/Member[@name="portfolio"]/*' />
        [DataMember(Name = "p", EmitDefaultValue = false)]
        public string? Portfolio { get; private set; }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseFortsRisk"]/Member[@name="moneyFree"]/*' />
        [DataMember(Name = "f", EmitDefaultValue = false)]
        public decimal? MoneyFree { get; private set; }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseFortsRisk"]/Member[@name="moneyBlocked"]/*' />
        [DataMember(Name = "b", EmitDefaultValue = false)]
        public decimal? MoneyBlocked { get; private set; }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseFortsRisk"]/Member[@name="fee"]/*' />
        [DataMember(Name = "fee", EmitDefaultValue = false)]
        public decimal? Fee { get; private set; }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseFortsRisk"]/Member[@name="moneyOld"]/*' />
        [DataMember(Name = "o", EmitDefaultValue = false)]
        public decimal? MoneyOld { get; private set; }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseFortsRisk"]/Member[@name="moneyAmount"]/*' />
        [DataMember(Name = "a", EmitDefaultValue = false)]
        public decimal? MoneyAmount { get; private set; }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseFortsRisk"]/Member[@name="moneyPledgeAmount"]/*' />
        [DataMember(Name = "pa", EmitDefaultValue = false)]
        public decimal? MoneyPledgeAmount { get; private set; }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseFortsRisk"]/Member[@name="vmInterCl"]/*' />
        [DataMember(Name = "mgc", EmitDefaultValue = false)]
        public decimal? VmInterCl { get; private set; }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseFortsRisk"]/Member[@name="vmCurrentPositions"]/*' />
        [DataMember(Name = "mgp", EmitDefaultValue = false)]
        public decimal? VmCurrentPositions { get; private set; }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseFortsRisk"]/Member[@name="isLimitsSet"]/*' />
        [DataMember(Name = "lim", EmitDefaultValue = false)]
        public bool? IsLimitsSet { get; private set; }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class FortsriskSlim {").Append(Environment.NewLine);
            sb.Append("  Portfolio: ").Append(Portfolio).Append(Environment.NewLine);
            sb.Append("  MoneyFree: ").Append(MoneyFree).Append(Environment.NewLine);
            sb.Append("  MoneyBlocked: ").Append(MoneyBlocked).Append(Environment.NewLine);
            sb.Append("  Fee: ").Append(Fee).Append(Environment.NewLine);
            sb.Append("  MoneyOld: ").Append(MoneyOld).Append(Environment.NewLine);
            sb.Append("  MoneyAmount: ").Append(MoneyAmount).Append(Environment.NewLine);
            sb.Append("  MoneyPledgeAmount: ").Append(MoneyPledgeAmount).Append(Environment.NewLine);
            sb.Append("  VmInterCl: ").Append(VmInterCl).Append(Environment.NewLine);
            sb.Append("  VmCurrentPositions: ").Append(VmCurrentPositions).Append(Environment.NewLine);
            sb.Append("  IsLimitsSet: ").Append(IsLimitsSet).Append(Environment.NewLine);
            sb.Append('}').Append(Environment.NewLine);
            return sb.ToString();
        }

        public string ToJson() => Encoding.UTF8.GetString(JsonSerializer.Generic.Utf8.Serialize(this));

        public override int GetHashCode() => Utilities.Utilities.GetHashCodeHelper(
            [
                Portfolio?.GetHashCode() ?? 0,
                MoneyFree?.GetHashCode() ?? 0,
                MoneyBlocked?.GetHashCode() ?? 0,
                Fee?.GetHashCode() ?? 0,
                MoneyOld?.GetHashCode() ?? 0,
                MoneyAmount?.GetHashCode() ?? 0,
                MoneyPledgeAmount?.GetHashCode() ?? 0,
                VmInterCl?.GetHashCode() ?? 0,
                VmCurrentPositions?.GetHashCode() ?? 0,
                IsLimitsSet?.GetHashCode() ?? 0,
            ]
        );

        private static bool EqualsHelper(FortsriskSlim? first, FortsriskSlim? second) =>
            first?.Portfolio == second?.Portfolio &&
            first?.MoneyFree == second?.MoneyFree &&
            first?.MoneyBlocked == second?.MoneyBlocked &&
            first?.Fee == second?.Fee &&
            first?.MoneyOld == second?.MoneyOld &&
            first?.MoneyAmount == second?.MoneyAmount &&
            first?.MoneyPledgeAmount == second?.MoneyPledgeAmount &&
            first?.VmInterCl == second?.VmInterCl &&
            first?.VmCurrentPositions == second?.VmCurrentPositions &&
            first?.IsLimitsSet == second?.IsLimitsSet;

        public bool Equals(FortsriskSlim? other)
        {
            if (this == (object?)other)
                return true;

            if ((object?)other == null)
                return false;

            if (GetType() != other.GetType())
                return false;

            return EqualsHelper(this, other);
        }

        public override bool Equals(object? obj) => Equals(obj as FortsriskSlim);

        private static bool Equals(FortsriskSlim? first, FortsriskSlim? second) =>
            first?.Equals(second) ?? first == (object?)second;

        public static bool operator ==(FortsriskSlim? first, FortsriskSlim? second) => Equals(first, second);

        public static bool operator !=(FortsriskSlim? first, FortsriskSlim? second) => !Equals(first, second);

        IEnumerable<ValidationResult> IValidatableObject.Validate(ValidationContext validationContext)
        {
            yield break;
        }
    }
}
