﻿using Alor.OpenAPI.Enums;
using SpanJson;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text;

namespace Alor.OpenAPI.Models
{
    [DataContract]
    public class ResponseEstimateOrder : IEquatable<ResponseEstimateOrder>, IValidatableObject
    {
        public ResponseEstimateOrder() { }
        
        /// <include file='../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseEstimateOrder"]/Member[@name="responseEstimateOrder"]/*' />
        public ResponseEstimateOrder(string? portfolio = default, string? ticker = default, Exchange exchange = default,
            decimal? quantityToSell = default, decimal? quantityToBuy = default,
            decimal? notMarginQuantityToSell = default, decimal? notMarginQuantityToBuy = default,
            decimal? orderEvaluation = default, decimal? commission = default, decimal? buyPrice = default, bool? isUnitedPortfolio = default)
        {
            Portfolio = portfolio;
            Ticker = ticker;
            Exchange = exchange;
            QuantityToSell = quantityToSell;
            QuantityToBuy = quantityToBuy;
            NotMarginQuantityToSell = notMarginQuantityToSell;
            NotMarginQuantityToBuy = notMarginQuantityToBuy;
            OrderEvaluation = orderEvaluation;
            Commission = commission;
            BuyPrice = buyPrice;
            IsUnitedPortfolio = isUnitedPortfolio;
        }

        /// <include file='../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseEstimateOrder"]/Member[@name="portfolio"]/*' />
        [DataMember(Name = "portfolio", EmitDefaultValue = false)]
        public string? Portfolio { get; private set; }

        /// <include file='../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseEstimateOrder"]/Member[@name="ticker"]/*' />
        [DataMember(Name = "ticker", EmitDefaultValue = false)]
        public string? Ticker { get; private set; }

        /// <include file='../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseEstimateOrder"]/Member[@name="exchange"]/*' />
        [DataMember(Name = "exchange", EmitDefaultValue = false)]
        public Exchange Exchange { get; private set; }

        /// <include file='../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseEstimateOrder"]/Member[@name="quantityToSell"]/*' />
        [DataMember(Name = "quantityToSell", EmitDefaultValue = false)]
        public decimal? QuantityToSell { get; private set; }

        /// <include file='../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseEstimateOrder"]/Member[@name="quantityToBuy"]/*' />
        [DataMember(Name = "quantityToBuy", EmitDefaultValue = false)]
        public decimal? QuantityToBuy { get; private set; }

        /// <include file='../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseEstimateOrder"]/Member[@name="notMarginQuantityToSell"]/*' />
        [DataMember(Name = "notMarginQuantityToSell", EmitDefaultValue = false)]
        public decimal? NotMarginQuantityToSell { get; private set; }

        /// <include file='../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseEstimateOrder"]/Member[@name="notMarginQuantityToBuy"]/*' />
        [DataMember(Name = "notMarginQuantityToBuy", EmitDefaultValue = false)]
        public decimal? NotMarginQuantityToBuy { get; private set; }

        /// <include file='../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseEstimateOrder"]/Member[@name="orderEvaluation"]/*' />
        [DataMember(Name = "orderEvaluation", EmitDefaultValue = false)]
        public decimal? OrderEvaluation { get; private set; }

        /// <include file='../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseEstimateOrder"]/Member[@name="commission"]/*' />
        [DataMember(Name = "commission", EmitDefaultValue = false)]
        public decimal? Commission { get; private set; }

        /// <include file='../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseEstimateOrder"]/Member[@name="buyPrice"]/*' />
        [DataMember(Name = "buyPrice", EmitDefaultValue = false)]
        public decimal? BuyPrice { get; private set; }

        /// <include file='../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseEstimateOrder"]/Member[@name="isUnitedPortfolio"]/*' />
        [DataMember(Name = "isUnitedPortfolio", EmitDefaultValue = false)]
        public bool? IsUnitedPortfolio { get; private set; }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class ResponseEstimateOrder {").Append(Environment.NewLine);
            sb.Append("  Portfolio: ").Append(Portfolio).Append(Environment.NewLine);
            sb.Append("  Ticker: ").Append(Ticker).Append(Environment.NewLine);
            sb.Append("  Exchange: ").Append(Exchange).Append(Environment.NewLine);
            sb.Append("  QuantityToSell: ").Append(QuantityToSell).Append(Environment.NewLine);
            sb.Append("  QuantityToBuy: ").Append(QuantityToBuy).Append(Environment.NewLine);
            sb.Append("  NotMarginQuantityToSell: ").Append(NotMarginQuantityToSell).Append(Environment.NewLine);
            sb.Append("  NotMarginQuantityToBuy: ").Append(NotMarginQuantityToBuy).Append(Environment.NewLine);
            sb.Append("  OrderEvaluation: ").Append(OrderEvaluation).Append(Environment.NewLine);
            sb.Append("  Commission: ").Append(Commission).Append(Environment.NewLine);
            sb.Append("  BuyPrice: ").Append(BuyPrice).Append(Environment.NewLine);
            sb.Append("  IsUnitedPortfolio: ").Append(IsUnitedPortfolio).Append(Environment.NewLine);
            sb.Append('}').Append(Environment.NewLine);
            return sb.ToString();
        }

        public string ToJson() => Encoding.UTF8.GetString(JsonSerializer.Generic.Utf8.Serialize(this));

        public override int GetHashCode() => Utilities.Utilities.GetHashCodeHelper(
            [
                Portfolio?.GetHashCode() ?? 0,
                Ticker?.GetHashCode() ?? 0,
                Exchange.GetHashCode(),
                QuantityToSell?.GetHashCode() ?? 0,
                QuantityToBuy?.GetHashCode() ?? 0,
                NotMarginQuantityToSell?.GetHashCode() ?? 0,
                NotMarginQuantityToBuy?.GetHashCode() ?? 0,
                OrderEvaluation?.GetHashCode() ?? 0,
                Commission?.GetHashCode() ?? 0,
                BuyPrice?.GetHashCode() ?? 0,
                IsUnitedPortfolio?.GetHashCode() ?? 0,
            ]
        );

        private static bool EqualsHelper(ResponseEstimateOrder? first, ResponseEstimateOrder? second) =>
            first?.Portfolio == second?.Portfolio &&
            first?.Ticker == second?.Ticker &&
            first?.Exchange == second?.Exchange &&
            first?.QuantityToSell == second?.QuantityToSell &&
            first?.QuantityToBuy == second?.QuantityToBuy &&
            first?.NotMarginQuantityToSell == second?.NotMarginQuantityToSell &&
            first?.NotMarginQuantityToBuy == second?.NotMarginQuantityToBuy &&
            first?.OrderEvaluation == second?.OrderEvaluation &&
            first?.Commission == second?.Commission &&
            first?.BuyPrice == second?.BuyPrice &&
            first?.IsUnitedPortfolio == second?.IsUnitedPortfolio;


        public bool Equals(ResponseEstimateOrder? other)
        {
            if (this == (object?)other)
                return true;

            if ((object?)other == null)
                return false;

            if (GetType() != other.GetType())
                return false;

            return EqualsHelper(this, other);
        }

        public override bool Equals(object? obj) => Equals(obj as ResponseEstimateOrder);

        private static bool Equals(ResponseEstimateOrder? first, ResponseEstimateOrder? second) =>
            first?.Equals(second) ?? first == (object?)second;

        public static bool operator ==(ResponseEstimateOrder? first, ResponseEstimateOrder? second) => Equals(first, second);

        public static bool operator !=(ResponseEstimateOrder? first, ResponseEstimateOrder? second) => !Equals(first, second);

        IEnumerable<ValidationResult> IValidatableObject.Validate(ValidationContext validationContext)
        {
            yield break;
        }
    }
}
