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

        /// <include file='../../XmlDocs/CoreModels.xml'
        ///          path='Docs/Members[@name="responseRisk"]
        ///               /Member[@name="responseRisk"]
        ///               /param[
        ///                      @name="portfolio" or @name="exchange" or @name="portfolioEvaluation" or @name="portfolioLiquidationValue" 
        ///                      or @name="initialMargin" or @name="minimalMargin" or @name="correctedMargin" or @name="riskCoverageRatioOne"
        ///                      or @name="riskCoverageRatioTwo" or @name="riskCategoryId" or @name="clientType" or @name="hasForbiddenPositions"
        ///                      or @name="hasNegativeQuantity" or @name="riskStatus" or @name="calculationTime"
        ///                     ]'/>
        public RiskHeavy(string? portfolio = null, Exchange? exchange = null, decimal? portfolioEvaluation = null,
            decimal? portfolioLiquidationValue = null, decimal? initialMargin = null, decimal? minimalMargin = null,
            decimal? correctedMargin = null, decimal? riskCoverageRatioOne = null, decimal? riskCoverageRatioTwo = null,
            int? riskCategoryId = null, ClientType? clientType = null, bool? hasForbiddenPositions = null,
            bool? hasNegativeQuantity = null, RiskStatus? riskStatus = null, DateTime? calculationTime = null)
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
            RiskStatus = riskStatus;
            CalculationTime = calculationTime;
        }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseRisk"]/Member[@name="portfolio"]/*' />
        [DataMember(Name = "portfolio", EmitDefaultValue = false)]
        public string? Portfolio { get; init; }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseRisk"]/Member[@name="exchange"]/*' />
        [DataMember(Name = "exchange", EmitDefaultValue = false)]
        public Exchange? Exchange { get; init; }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseRisk"]/Member[@name="portfolioEvaluation"]/*' />
        [DataMember(Name = "portfolioEvaluation", EmitDefaultValue = false)]
        public decimal? PortfolioEvaluation { get; init; }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseRisk"]/Member[@name="portfolioLiquidationValue"]/*' />
        [DataMember(Name = "portfolioLiquidationValue", EmitDefaultValue = false)]
        public decimal? PortfolioLiquidationValue { get; init; }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseRisk"]/Member[@name="initialMargin"]/*' />
        [DataMember(Name = "initialMargin", EmitDefaultValue = false)]
        public decimal? InitialMargin { get; init; }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseRisk"]/Member[@name="minimalMargin"]/*' />
        [DataMember(Name = "minimalMargin", EmitDefaultValue = false)]
        public decimal? MinimalMargin { get; init; }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseRisk"]/Member[@name="correctedMargin"]/*' />
        [DataMember(Name = "correctedMargin", EmitDefaultValue = false)]
        public decimal? CorrectedMargin { get; init; }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseRisk"]/Member[@name="riskCoverageRatioOne"]/*' />
        [DataMember(Name = "riskCoverageRatioOne", EmitDefaultValue = false)]
        public decimal? RiskCoverageRatioOne { get; init; }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseRisk"]/Member[@name="riskCoverageRatioTwo"]/*' />
        [DataMember(Name = "riskCoverageRatioTwo", EmitDefaultValue = false)]
        public decimal? RiskCoverageRatioTwo { get; init; }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseRisk"]/Member[@name="riskCategoryId"]/*' />
        [DataMember(Name = "riskCategoryId", EmitDefaultValue = false)]
        public int? RiskCategoryId { get; init; }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseRisk"]/Member[@name="clientType"]/*' />
        [DataMember(Name = "clientType", EmitDefaultValue = false)]
        public ClientType? ClientType { get; init; }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseRisk"]/Member[@name="hasForbiddenPositions"]/*' />
        [DataMember(Name = "hasForbiddenPositions", EmitDefaultValue = false)]
        public bool? HasForbiddenPositions { get; init; }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseRisk"]/Member[@name="hasNegativeQuantity"]/*' />
        [DataMember(Name = "hasNegativeQuantity", EmitDefaultValue = false)]
        public bool? HasNegativeQuantity { get; init; }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseRisk"]/Member[@name="riskStatus"]/*' />
        [DataMember(Name = "riskStatus", EmitDefaultValue = false)]
        public RiskStatus? RiskStatus { get; init; }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseRisk"]/Member[@name="calculationTime"]/*' />
        [DataMember(Name = "calculationTime", EmitDefaultValue = false)]
        public DateTime? CalculationTime { get; init; }

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
            sb.Append("  RiskStatus: ").Append(RiskStatus).Append(Environment.NewLine);
            sb.Append("  CalculationTime: ").Append(CalculationTime).Append(Environment.NewLine);
            sb.Append('}').Append(Environment.NewLine);
            return sb.ToString();
        }

        public string ToJson() => Encoding.UTF8.GetString(JsonSerializer.Generic.Utf8.Serialize(this));

        public override int GetHashCode()
        {
            var hash = new HashCode();
            hash.Add(Portfolio);
            hash.Add(Exchange);
            hash.Add(PortfolioEvaluation);
            hash.Add(PortfolioLiquidationValue);
            hash.Add(InitialMargin);
            hash.Add(MinimalMargin);
            hash.Add(CorrectedMargin);
            hash.Add(RiskCoverageRatioOne);
            hash.Add(RiskCoverageRatioTwo);
            hash.Add(RiskCategoryId);
            hash.Add(ClientType);
            hash.Add(HasForbiddenPositions);
            hash.Add(HasNegativeQuantity);
            hash.Add(RiskStatus);
            hash.Add(CalculationTime);
            return hash.ToHashCode();
        }

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
            first?.HasNegativeQuantity == second?.HasNegativeQuantity &&
            first?.RiskStatus == second?.RiskStatus &&
            first?.CalculationTime == second?.CalculationTime;
        
        public bool Equals(RiskHeavy? other)
        {
            if (this == (object?)other)
                return true;

            if (other is null)
                return false;

            return GetType() == other.GetType() && EqualsHelper(this, other);
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
