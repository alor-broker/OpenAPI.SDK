using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text;
using SpanJson;

namespace Alor.OpenAPI.Models.Simple
{
    [DataContract]
    public sealed class FortsriskSimple : IEquatable<FortsriskSimple>, IValidatableObject
    {
        public FortsriskSimple() { }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseFortsRisk"]/Member[@name="responseFortsRisk"]/*' />
        public FortsriskSimple(decimal? balanceMoney = default, string? portfolio = default, decimal? moneyFree = default,
            decimal? moneyBlocked = default, decimal? fee = default, decimal? moneyOld = default,
            decimal? moneyAmount = default, decimal? moneyPledgeAmount = default, decimal? vmInterCl = default,
            decimal? vmCurrentPositions = default, decimal? varMargin = default, bool? isLimitsSet = default)
        {
            BalanceMoney = balanceMoney;
            Portfolio = portfolio;
            MoneyFree = moneyFree;
            MoneyBlocked = moneyBlocked;
            Fee = fee;
            MoneyOld = moneyOld;
            MoneyAmount = moneyAmount;
            MoneyPledgeAmount = moneyPledgeAmount;
            VmInterCl = vmInterCl;
            VmCurrentPositions = vmCurrentPositions;
            VarMargin = varMargin;
            IsLimitsSet = isLimitsSet;
        }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseFortsRisk"]/Member[@name="balanceMoney"]/*' />
        [DataMember(Name = "balanceMoney", EmitDefaultValue = false)]
        public decimal? BalanceMoney { get; private set; }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseFortsRisk"]/Member[@name="portfolio"]/*' />
        [DataMember(Name = "portfolio", EmitDefaultValue = false)]
        public string? Portfolio { get; private set; }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseFortsRisk"]/Member[@name="moneyFree"]/*' />
        [DataMember(Name = "moneyFree", EmitDefaultValue = false)]
        public decimal? MoneyFree { get; private set; }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseFortsRisk"]/Member[@name="moneyBlocked"]/*' />
        [DataMember(Name = "moneyBlocked", EmitDefaultValue = false)]
        public decimal? MoneyBlocked { get; private set; }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseFortsRisk"]/Member[@name="fee"]/*' />
        [DataMember(Name = "fee", EmitDefaultValue = false)]
        public decimal? Fee { get; private set; }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseFortsRisk"]/Member[@name="moneyOld"]/*' />
        [DataMember(Name = "moneyOld", EmitDefaultValue = false)]
        public decimal? MoneyOld { get; private set; }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseFortsRisk"]/Member[@name="moneyAmount"]/*' />
        [DataMember(Name = "moneyAmount", EmitDefaultValue = false)]
        public decimal? MoneyAmount { get; private set; }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseFortsRisk"]/Member[@name="moneyPledgeAmount"]/*' />
        [DataMember(Name = "moneyPledgeAmount", EmitDefaultValue = false)]
        public decimal? MoneyPledgeAmount { get; private set; }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseFortsRisk"]/Member[@name="vmInterCl"]/*' />
        [DataMember(Name = "vmInterCl", EmitDefaultValue = false)]
        public decimal? VmInterCl { get; private set; }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseFortsRisk"]/Member[@name="vmCurrentPositions"]/*' />
        [DataMember(Name = "vmCurrentPositions", EmitDefaultValue = false)]
        public decimal? VmCurrentPositions { get; private set; }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseFortsRisk"]/Member[@name="varMargin"]/*' />
        [DataMember(Name = "varMargin", EmitDefaultValue = false)]
        public decimal? VarMargin { get; private set; }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseFortsRisk"]/Member[@name="isLimitsSet"]/*' />
        [DataMember(Name = "isLimitsSet", EmitDefaultValue = false)]
        public bool? IsLimitsSet { get; private set; }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class FortsriskSimple {").Append(Environment.NewLine);
            sb.Append("  BalanceMoney: ").Append(BalanceMoney).Append(Environment.NewLine);
            sb.Append("  Portfolio: ").Append(Portfolio).Append(Environment.NewLine);
            sb.Append("  MoneyFree: ").Append(MoneyFree).Append(Environment.NewLine);
            sb.Append("  MoneyBlocked: ").Append(MoneyBlocked).Append(Environment.NewLine);
            sb.Append("  Fee: ").Append(Fee).Append(Environment.NewLine);
            sb.Append("  MoneyOld: ").Append(MoneyOld).Append(Environment.NewLine);
            sb.Append("  MoneyAmount: ").Append(MoneyAmount).Append(Environment.NewLine);
            sb.Append("  MoneyPledgeAmount: ").Append(MoneyPledgeAmount).Append(Environment.NewLine);
            sb.Append("  VmInterCl: ").Append(VmInterCl).Append(Environment.NewLine);
            sb.Append("  VmCurrentPositions: ").Append(VmCurrentPositions).Append(Environment.NewLine);
            sb.Append("  VarMargin: ").Append(VarMargin).Append(Environment.NewLine);
            sb.Append("  IsLimitsSet: ").Append(IsLimitsSet).Append(Environment.NewLine);
            sb.Append('}').Append(Environment.NewLine);
            return sb.ToString();
        }

        public string ToJson() => Encoding.UTF8.GetString(JsonSerializer.Generic.Utf8.Serialize(this));

        public override int GetHashCode() => Utilities.Utilities.GetHashCodeHelper(
            [
                BalanceMoney?.GetHashCode() ?? 0,
                Portfolio?.GetHashCode() ?? 0,
                MoneyFree?.GetHashCode() ?? 0,
                MoneyBlocked?.GetHashCode() ?? 0,
                Fee?.GetHashCode() ?? 0,
                MoneyOld?.GetHashCode() ?? 0,
                MoneyAmount?.GetHashCode() ?? 0,
                MoneyPledgeAmount?.GetHashCode() ?? 0,
                VmInterCl?.GetHashCode() ?? 0,
                VmCurrentPositions?.GetHashCode() ?? 0,
                VarMargin?.GetHashCode() ?? 0,
                IsLimitsSet?.GetHashCode() ?? 0,
            ]
        );

        private static bool EqualsHelper(FortsriskSimple? first, FortsriskSimple? second) =>
            first?.BalanceMoney == second?.BalanceMoney &&
            first?.Portfolio == second?.Portfolio &&
            first?.MoneyFree == second?.MoneyFree &&
            first?.MoneyBlocked == second?.MoneyBlocked &&
            first?.Fee == second?.Fee &&
            first?.MoneyOld == second?.MoneyOld &&
            first?.MoneyAmount == second?.MoneyAmount &&
            first?.MoneyPledgeAmount == second?.MoneyPledgeAmount &&
            first?.VmInterCl == second?.VmInterCl &&
            first?.VmCurrentPositions == second?.VmCurrentPositions &&
            first?.VarMargin == second?.VarMargin &&
            first?.IsLimitsSet == second?.IsLimitsSet;




        public bool Equals(FortsriskSimple? other)
        {
            if (this == (object?)other)
                return true;

            if ((object?)other == null)
                return false;

            if (GetType() != other.GetType())
                return false;

            return EqualsHelper(this, other);
        }

        public override bool Equals(object? obj) => Equals(obj as FortsriskSimple);

        private static bool Equals(FortsriskSimple? first, FortsriskSimple? second) =>
            first?.Equals(second) ?? first == (object?)second;

        public static bool operator ==(FortsriskSimple? first, FortsriskSimple? second) => Equals(first, second);

        public static bool operator !=(FortsriskSimple? first, FortsriskSimple? second) => !Equals(first, second);

        IEnumerable<ValidationResult> IValidatableObject.Validate(ValidationContext validationContext)
        {
            yield break;
        }
    }
}
