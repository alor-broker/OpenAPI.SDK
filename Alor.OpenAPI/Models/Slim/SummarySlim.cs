using SpanJson;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text;

namespace Alor.OpenAPI.Models.Slim
{
    [DataContract]
    public sealed class SummarySlim : IEquatable<SummarySlim>, IValidatableObject
    {
        public SummarySlim() { }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseSummary"]/Member[@name="responseSummary"]/*' />
        public SummarySlim(decimal? buyingPowerAtMorning = default, decimal? buyingPower = default,
            decimal? profit = default, decimal? profitRate = default,
            decimal? portfolioEvaluation = default, decimal? portfolioLiquidationValue = default,
            decimal? initialMargin = default, decimal? riskBeforeForcePositionClosing = default,
            decimal? commission = default, ICollection<BuyingPowerByCurrencySlim>? buyingPowerByCurrency = default)
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
        [DataMember(Name = "bpm", EmitDefaultValue = false)]
        public decimal? BuyingPowerAtMorning { get; init; }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseSummary"]/Member[@name="buyingPowerAtMorning"]/*' />
        [DataMember(Name = "bp", EmitDefaultValue = false)]
        public decimal? BuyingPower { get; init; }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseSummary"]/Member[@name="profit"]/*' />
        [DataMember(Name = "p", EmitDefaultValue = false)]
        public decimal? Profit { get; init; }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseSummary"]/Member[@name="profitRate"]/*' />
        [DataMember(Name = "pr", EmitDefaultValue = false)]
        public decimal? ProfitRate { get; init; }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseSummary"]/Member[@name="portfolioEvaluation"]/*' />
        [DataMember(Name = "pe", EmitDefaultValue = false)]
        public decimal? PortfolioEvaluation { get; init; }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseSummary"]/Member[@name="portfolioLiquidationValue"]/*' />
        [DataMember(Name = "plv", EmitDefaultValue = false)]
        public decimal? PortfolioLiquidationValue { get; init; }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseSummary"]/Member[@name="initialMargin"]/*' />
        [DataMember(Name = "im", EmitDefaultValue = false)]
        public decimal? InitialMargin { get; init; }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseSummary"]/Member[@name="riskBeforeForcePositionClosing"]/*' />
        [DataMember(Name = "r", EmitDefaultValue = false)]
        public decimal? RiskBeforeForcePositionClosing { get; init; }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseSummary"]/Member[@name="commission"]/*' />
        [DataMember(Name = "cms", EmitDefaultValue = false)]
        public decimal? Commission { get; init; }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseSummary"]/Member[@name="bpv2Slim"]/*' />
        [DataMember(Name = "bpv2", EmitDefaultValue = false)]
        public ICollection<BuyingPowerByCurrencySlim>? BuyingPowerByCurrency { get; init; }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class SummarySlim {").Append(Environment.NewLine);
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

        private static bool EqualsHelper(SummarySlim? first, SummarySlim? second) =>
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


        public bool Equals(SummarySlim? other)
        {
            if (this == (object?)other)
                return true;

            if ((object?)other == null)
                return false;

            if (GetType() != other.GetType())
                return false;

            return EqualsHelper(this, other);
        }

        public override bool Equals(object? obj) => Equals(obj as SummarySlim);

        private static bool Equals(SummarySlim? first, SummarySlim? second) =>
            first?.Equals(second) ?? first == (object?)second;

        public static bool operator ==(SummarySlim? first, SummarySlim? second) => Equals(first, second);

        public static bool operator !=(SummarySlim? first, SummarySlim? second) => !Equals(first, second);

        IEnumerable<ValidationResult> IValidatableObject.Validate(ValidationContext validationContext)
        {
            yield break;
        }
    }
}
