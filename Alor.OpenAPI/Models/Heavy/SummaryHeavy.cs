using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text;
using SpanJson;

namespace Alor.OpenAPI.Models.Heavy
{
    [DataContract]
    public sealed class SummaryHeavy : IEquatable<SummaryHeavy>, IValidatableObject
    {
        public SummaryHeavy() { }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseSummary"]/Member[@name="responseSummary"]/*' />
        public SummaryHeavy(decimal? buyingPowerAtMorning = default, decimal? buyingPower = default,
            decimal? profit = default, decimal? profitRate = default,
            decimal? portfolioEvaluation = default, decimal? portfolioLiquidationValue = default,
            decimal? initialMargin = default, decimal? riskBeforeForcePositionClosing = default,
            decimal? commission = default, ICollection<BuyingPowerByCurrencyHeavy>? buyingPowerByCurrency = default)
        {
            BuyingPowerAtMorning = buyingPowerAtMorning;
            BuyingPower = buyingPower;
            Profit = profit;
            ProfitRate = profitRate;
            PortfolioEvaluation = portfolioEvaluation;
            PortfolioLiquidationValue = portfolioLiquidationValue;
            InitialMargin = initialMargin;
            RiskBeforeForcePositionClosing = riskBeforeForcePositionClosing;
            Commission = commission;
            BuyingPowerByCurrency = buyingPowerByCurrency;
        }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseSummary"]/Member[@name="buyingPowerAtMorning"]/*' />
        [DataMember(Name = "buyingPowerAtMorning", EmitDefaultValue = false)]
        public decimal? BuyingPowerAtMorning { get; init; }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseSummary"]/Member[@name="buyingPowerAtMorning"]/*' />
        [DataMember(Name = "buyingPower", EmitDefaultValue = false)]
        public decimal? BuyingPower { get; init; }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseSummary"]/Member[@name="profit"]/*' />
        [DataMember(Name = "profit", EmitDefaultValue = false)]
        public decimal? Profit { get; init; }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseSummary"]/Member[@name="profitRate"]/*' />
        [DataMember(Name = "profitRate", EmitDefaultValue = false)]
        public decimal? ProfitRate { get; init; }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseSummary"]/Member[@name="portfolioEvaluation"]/*' />
        [DataMember(Name = "portfolioEvaluation", EmitDefaultValue = false)]
        public decimal? PortfolioEvaluation { get; init; }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseSummary"]/Member[@name="portfolioLiquidationValue"]/*' />
        [DataMember(Name = "portfolioLiquidationValue", EmitDefaultValue = false)]
        public decimal? PortfolioLiquidationValue { get; init; }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseSummary"]/Member[@name="initialMargin"]/*' />
        [DataMember(Name = "initialMargin", EmitDefaultValue = false)]
        public decimal? InitialMargin { get; init; }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseSummary"]/Member[@name="riskBeforeForcePositionClosing"]/*' />
        [DataMember(Name = "riskBeforeForcePositionClosing", EmitDefaultValue = false)]
        public decimal? RiskBeforeForcePositionClosing { get; init; }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseSummary"]/Member[@name="commission"]/*' />
        [DataMember(Name = "commission", EmitDefaultValue = false)]
        public decimal? Commission { get; init; }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseSummary"]/Member[@name="buyingPowerByCurrency"]/*' />
        [DataMember(Name = "buyingPowerByCurrency", EmitDefaultValue = false)]
        public ICollection<BuyingPowerByCurrencyHeavy>? BuyingPowerByCurrency { get; init; }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class SummaryHeavy {").Append(Environment.NewLine);
            sb.Append("  BuyingPowerAtMorning: ").Append(BuyingPowerAtMorning).Append(Environment.NewLine);
            sb.Append("  BuyingPower: ").Append(BuyingPower).Append(Environment.NewLine);
            sb.Append("  Profit: ").Append(Profit).Append(Environment.NewLine);
            sb.Append("  ProfitRate: ").Append(ProfitRate).Append(Environment.NewLine);
            sb.Append("  PortfolioEvaluation: ").Append(PortfolioEvaluation).Append(Environment.NewLine);
            sb.Append("  PortfolioLiquidationValue: ").Append(PortfolioLiquidationValue).Append(Environment.NewLine);
            sb.Append("  InitialMargin: ").Append(InitialMargin).Append(Environment.NewLine);
            sb.Append("  RiskBeforeForcePositionClosing: ").Append(RiskBeforeForcePositionClosing).Append(Environment.NewLine);
            sb.Append("  Commission: ").Append(Commission).Append(Environment.NewLine);
            sb.Append("  BuyingPowerByCurrencyHeavy: ").Append(BuyingPowerByCurrency == null ? "null" : string.Join(", ", BuyingPowerByCurrency.Select(x => x.ToString()))).Append(Environment.NewLine);
            sb.Append('}').Append(Environment.NewLine);
            return sb.ToString();
        }

        public string ToJson() => Encoding.UTF8.GetString(JsonSerializer.Generic.Utf8.Serialize(this));

        public override int GetHashCode()
        {
            var hash = new HashCode();
            hash.Add(BuyingPowerAtMorning);
            hash.Add(BuyingPower);
            hash.Add(Profit);
            hash.Add(ProfitRate);
            hash.Add(PortfolioEvaluation);
            hash.Add(PortfolioLiquidationValue);
            hash.Add(InitialMargin);
            hash.Add(RiskBeforeForcePositionClosing);
            hash.Add(Commission);

            if (BuyingPowerByCurrency == null) return hash.ToHashCode();
            foreach (var item in BuyingPowerByCurrency)
            {
                hash.Add(item.GetHashCode());
            }

            return hash.ToHashCode();
        }

        private static bool EqualsHelper(SummaryHeavy? first, SummaryHeavy? second) =>
            first?.BuyingPowerAtMorning == second?.BuyingPowerAtMorning &&
            first?.BuyingPower == second?.BuyingPower &&
            first?.Profit == second?.Profit &&
            first?.ProfitRate == second?.ProfitRate &&
            first?.PortfolioEvaluation == second?.PortfolioEvaluation &&
            first?.PortfolioLiquidationValue == second?.PortfolioLiquidationValue &&
            first?.InitialMargin == second?.InitialMargin &&
            first?.RiskBeforeForcePositionClosing == second?.RiskBeforeForcePositionClosing &&
            first?.Commission == second?.Commission &&
            first?.BuyingPowerByCurrency != null && second?.BuyingPowerByCurrency != null
                ? first.BuyingPowerByCurrency.SequenceEqual(second.BuyingPowerByCurrency)
                : first?.BuyingPowerByCurrency == null && second?.BuyingPowerByCurrency == null;

        public bool Equals(SummaryHeavy? other)
        {
            if (this == (object?)other)
                return true;

            if ((object?)other == null)
                return false;

            return GetType() == other.GetType() && EqualsHelper(this, other);
        }

        public override bool Equals(object? obj) => Equals(obj as SummaryHeavy);

        private static bool Equals(SummaryHeavy? first, SummaryHeavy? second) =>
            first?.Equals(second) ?? first == (object?)second;

        public static bool operator ==(SummaryHeavy? first, SummaryHeavy? second) => Equals(first, second);

        public static bool operator !=(SummaryHeavy? first, SummaryHeavy? second) => !Equals(first, second);

        IEnumerable<ValidationResult> IValidatableObject.Validate(ValidationContext validationContext)
        {
            yield break;
        }
    }
}
