using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text;
using Alor.OpenAPI.Enums;
using SpanJson;

namespace Alor.OpenAPI.Models.Heavy
{
    [DataContract]
    public sealed class RiskHeavy : IEquatable<RiskHeavy>, IValidatableObject
    {
        public RiskHeavy() { }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseRisk"]/Member[@name="responseRisk"]/*' />
        public RiskHeavy(string? portfolio = default, Exchange exchange = default, decimal? portfolioEvaluation = default,
            decimal? portfolioLiquidationValue = default, decimal? initialMargin = default,
            decimal? minimalMargin = default, decimal? correctedMargin = default,
            decimal? riskCoverageRatioOne = default, decimal? riskCoverageRatioTwo = default,
            int? riskCategoryId = default, ClientType clientType = default,
            bool? hasForbiddenPositions = default, bool? hasNegativeQuantity = default)
        {
            Portfolio = portfolio;
            Exchange = exchange;
            PortfolioEvaluation = portfolioEvaluation;
            PortfolioLiquidationValue = portfolioLiquidationValue;
            InitialMargin = initialMargin;
            MinimalMargin = minimalMargin;
            CorrectedMargin = correctedMargin;
            RiskCoverageRatioOne = riskCoverageRatioOne;
            RiskCoverageRatioTwo = riskCoverageRatioTwo;
            RiskCategoryId = riskCategoryId;
            ClientType = clientType;
            HasForbiddenPositions = hasForbiddenPositions;
            HasNegativeQuantity = hasNegativeQuantity;
        }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseRisk"]/Member[@name="portfolio"]/*' />
        [DataMember(Name = "portfolio", EmitDefaultValue = false)]
        public string? Portfolio { get; set; }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseRisk"]/Member[@name="exchange"]/*' />
        [DataMember(Name = "exchange", EmitDefaultValue = false)]
        public Exchange Exchange { get; set; }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseRisk"]/Member[@name="portfolioEvaluation"]/*' />
        [DataMember(Name = "portfolioEvaluation", EmitDefaultValue = false)]
        public decimal? PortfolioEvaluation { get; set; }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseRisk"]/Member[@name="portfolioLiquidationValue"]/*' />
        [DataMember(Name = "portfolioLiquidationValue", EmitDefaultValue = false)]
        public decimal? PortfolioLiquidationValue { get; set; }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseRisk"]/Member[@name="initialMargin"]/*' />
        [DataMember(Name = "initialMargin", EmitDefaultValue = false)]
        public decimal? InitialMargin { get; set; }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseRisk"]/Member[@name="minimalMargin"]/*' />
        [DataMember(Name = "minimalMargin", EmitDefaultValue = false)]
        public decimal? MinimalMargin { get; set; }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseRisk"]/Member[@name="correctedMargin"]/*' />
        [DataMember(Name = "correctedMargin", EmitDefaultValue = false)]
        public decimal? CorrectedMargin { get; set; }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseRisk"]/Member[@name="riskCoverageRatioOne"]/*' />
        [DataMember(Name = "riskCoverageRatioOne", EmitDefaultValue = false)]
        public decimal? RiskCoverageRatioOne { get; set; }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseRisk"]/Member[@name="riskCoverageRatioTwo"]/*' />
        [DataMember(Name = "riskCoverageRatioTwo", EmitDefaultValue = false)]
        public decimal? RiskCoverageRatioTwo { get; set; }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseRisk"]/Member[@name="riskCategoryId"]/*' />
        [DataMember(Name = "riskCategoryId", EmitDefaultValue = false)]
        public int? RiskCategoryId { get; set; }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseRisk"]/Member[@name="clientType"]/*' />
        [DataMember(Name = "clientType", EmitDefaultValue = false)]
        public ClientType ClientType { get; set; }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseRisk"]/Member[@name="hasForbiddenPositions"]/*' />
        [DataMember(Name = "hasForbiddenPositions", EmitDefaultValue = false)]
        public bool? HasForbiddenPositions { get; set; }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseRisk"]/Member[@name="hasNegativeQuantity"]/*' />
        [DataMember(Name = "hasNegativeQuantity", EmitDefaultValue = false)]
        public bool? HasNegativeQuantity { get; set; }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class RiskHeavy {").Append(Environment.NewLine);
            sb.Append("  Portfolio: ").Append(Portfolio).Append(Environment.NewLine);
            sb.Append("  Exchange: ").Append(Exchange).Append(Environment.NewLine);
            sb.Append("  PortfolioEvaluation: ").Append(PortfolioEvaluation).Append(Environment.NewLine);
            sb.Append("  PortfolioLiquidationValue: ").Append(PortfolioLiquidationValue).Append(Environment.NewLine);
            sb.Append("  InitialMargin: ").Append(InitialMargin).Append(Environment.NewLine);
            sb.Append("  MinimalMargin: ").Append(MinimalMargin).Append(Environment.NewLine);
            sb.Append("  CorrectedMargin: ").Append(CorrectedMargin).Append(Environment.NewLine);
            sb.Append("  RiskCoverageRatioOne: ").Append(RiskCoverageRatioOne).Append(Environment.NewLine);
            sb.Append("  RiskCoverageRatioTwo: ").Append(RiskCoverageRatioTwo).Append(Environment.NewLine);
            sb.Append("  RiskCategoryId: ").Append(RiskCategoryId).Append(Environment.NewLine);
            sb.Append("  ClientType: ").Append(ClientType).Append(Environment.NewLine);
            sb.Append("  HasForbiddenPositions: ").Append(HasForbiddenPositions).Append(Environment.NewLine);
            sb.Append("  HasNegativeQuantity: ").Append(HasNegativeQuantity).Append(Environment.NewLine);
            sb.Append('}').Append(Environment.NewLine);
            return sb.ToString();
        }

        public string ToJson() => Encoding.UTF8.GetString(JsonSerializer.Generic.Utf8.Serialize(this));

        public override int GetHashCode() => Utilities.Utilities.GetHashCodeHelper(
            [
                Portfolio?.GetHashCode() ?? 0,
                Exchange.GetHashCode(),
            ]
        );

        private static bool EqualsHelper(RiskHeavy? first, RiskHeavy? second) =>
            first?.Portfolio == second?.Portfolio &&
            first?.Exchange == second?.Exchange &&
            first?.PortfolioEvaluation == second?.PortfolioEvaluation &&
            first?.PortfolioLiquidationValue == second?.PortfolioLiquidationValue &&
            first?.InitialMargin == second?.InitialMargin &&
            first?.MinimalMargin == second?.MinimalMargin &&
            first?.CorrectedMargin == second?.CorrectedMargin &&
            first?.RiskCoverageRatioOne == second?.RiskCoverageRatioOne &&
            first?.RiskCoverageRatioTwo == second?.RiskCoverageRatioTwo &&
            first?.RiskCategoryId == second?.RiskCategoryId &&
            first?.ClientType == second?.ClientType &&
            first?.HasForbiddenPositions == second?.HasForbiddenPositions &&
            first?.HasNegativeQuantity == second?.HasNegativeQuantity;





        public bool Equals(RiskHeavy? other)
        {
            if (this == (object?)other)
                return true;

            if ((object?)other == null)
                return false;

            if (GetType() != other.GetType())
                return false;

            return EqualsHelper(this, other);
        }

        public override bool Equals(object? obj) => Equals(obj as RiskHeavy);

        private static bool Equals(RiskHeavy? first, RiskHeavy? second) =>
            first?.Equals(second) ?? first == (object?)second;

        public static bool operator ==(RiskHeavy? first, RiskHeavy? second) => Equals(first, second);

        public static bool operator !=(RiskHeavy? first, RiskHeavy? second) => !Equals(first, second);

        IEnumerable<ValidationResult> IValidatableObject.Validate(ValidationContext validationContext)
        {
            yield break;
        }
    }
}
