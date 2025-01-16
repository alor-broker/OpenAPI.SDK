using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text;
using Alor.OpenAPI.Enums;
using SpanJson;

namespace Alor.OpenAPI.Models.Heavy
{
    [DataContract]
    public sealed class SecurityFromWsHeavy : IEquatable<SecurityFromWsHeavy>, IValidatableObject
    {
        public SecurityFromWsHeavy() { }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseInstruments"]/Member[@name="responseInstruments"]/*' />
        public SecurityFromWsHeavy(string? symbol = default, Exchange exchange = default,
            string? board = default, decimal? priceMax = default, decimal? priceMin = default,
            int? tradingStatus = default, string? tradingStatusInfo = default,
            decimal? marginBuy = default, decimal? marginSell = default, decimal? marginSyntetic = default,
            decimal? theorPrice = default, decimal? theorPriceLimit = default, decimal? volatility = default)
        {
            Symbol = symbol;
            Exchange = exchange;
            PriceMax = priceMax;
            PriceMin = priceMin;
            Board = board;
            TradingStatus = tradingStatus;
            TradingStatusInfo = tradingStatusInfo;
            MarginBuy = marginBuy;
            MarginSell = marginSell;
            MarginSyntetic = marginSyntetic;
            TheorPrice = theorPrice;
            TheorPriceLimit = theorPriceLimit;
            Volatility = volatility;
        }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseInstruments"]/Member[@name="symbol"]/*' />
        [DataMember(Name = "symbol", EmitDefaultValue = false)]
        public string? Symbol { get; private set; }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseInstruments"]/Member[@name="exchange"]/*' />
        [DataMember(Name = "exchange", EmitDefaultValue = false)]
        public Exchange Exchange { get; private set; }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseInstruments"]/Member[@name="priceMax"]/*' />
        [DataMember(Name = "priceMax", EmitDefaultValue = false)]
        public decimal? PriceMax { get; set; }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseInstruments"]/Member[@name="priceMin"]/*' />
        [DataMember(Name = "priceMin", EmitDefaultValue = false)]
        public decimal? PriceMin { get; set; }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseInstruments"]/Member[@name="board"]/*' />
        [DataMember(Name = "board", EmitDefaultValue = false)]
        public string? Board { get; private set; }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseInstruments"]/Member[@name="tradingStatus"]/*' />
        [DataMember(Name = "tradingStatus", EmitDefaultValue = false)]
        public int? TradingStatus { get; set; }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseInstruments"]/Member[@name="tradingStatusInfo"]/*' />
        [DataMember(Name = "tradingStatusInfo", EmitDefaultValue = false)]
        public string? TradingStatusInfo { get; set; }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseInstruments"]/Member[@name="marginBuy"]/*' />
        [DataMember(Name = "marginBuy", EmitDefaultValue = false)]
        public decimal? MarginBuy { get; set; }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseInstruments"]/Member[@name="marginSell"]/*' />
        [DataMember(Name = "marginSell", EmitDefaultValue = false)]
        public decimal? MarginSell { get; set; }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseInstruments"]/Member[@name="marginSyntetic"]/*' />
        [DataMember(Name = "marginSyntetic", EmitDefaultValue = false)]
        public decimal? MarginSyntetic { get; set; }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseInstruments"]/Member[@name="theorPrice"]/*' />
        [DataMember(Name = "theorPrice", EmitDefaultValue = false)]
        public decimal? TheorPrice { get; set; }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseInstruments"]/Member[@name="theorPriceLimit"]/*' />
        [DataMember(Name = "theorPriceLimit", EmitDefaultValue = false)]
        public decimal? TheorPriceLimit { get; set; }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseInstruments"]/Member[@name="volatility"]/*' />
        [DataMember(Name = "volatility", EmitDefaultValue = false)]
        public decimal? Volatility { get; set; }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class SecurityFromWsHeavy {").Append(Environment.NewLine);
            sb.Append("  SymbolHeavy: ").Append(Symbol).Append(Environment.NewLine);
            sb.Append("  Exchange: ").Append(Exchange).Append(Environment.NewLine);
            sb.Append("  PriceMax: ").Append(PriceMax).Append(Environment.NewLine);
            sb.Append("  PriceMin: ").Append(PriceMin).Append(Environment.NewLine);
            sb.Append("  Board: ").Append(Board).Append(Environment.NewLine);
            sb.Append("  TradingStatus: ").Append(TradingStatus).Append(Environment.NewLine);
            sb.Append("  TradingStatusInfo: ").Append(TradingStatusInfo).Append(Environment.NewLine);
            sb.Append("  MarginBuy: ").Append(MarginBuy).Append(Environment.NewLine);
            sb.Append("  MarginSell: ").Append(MarginSell).Append(Environment.NewLine);
            sb.Append("  MarginSyntetic: ").Append(MarginSyntetic).Append(Environment.NewLine);
            sb.Append("  TheorPrice: ").Append(TheorPrice).Append(Environment.NewLine);
            sb.Append("  TheorPriceLimit: ").Append(TheorPriceLimit).Append(Environment.NewLine);
            sb.Append("  Volatility: ").Append(Volatility).Append(Environment.NewLine);
            sb.Append('}').Append(Environment.NewLine);
            return sb.ToString();
        }

        public string ToJson() => Encoding.UTF8.GetString(JsonSerializer.Generic.Utf8.Serialize(this));

        public override int GetHashCode() => Utilities.Utilities.GetHashCodeHelper(
            [
                Symbol?.GetHashCode() ?? 0,
                Exchange.GetHashCode(),
                Board?.GetHashCode() ?? 0,
            ]
        );

        private static bool EqualsHelper(SecurityFromWsHeavy? first, SecurityFromWsHeavy? second) =>
            first?.Symbol == second?.Symbol &&
            first?.Exchange == second?.Exchange &&
            first?.PriceMax == second?.PriceMax &&
            first?.PriceMin == second?.PriceMin &&
            first?.Board == second?.Board &&
            first?.TradingStatus == second?.TradingStatus &&
            first?.TradingStatusInfo == second?.TradingStatusInfo &&
            first?.MarginBuy == second?.MarginBuy &&
            first?.MarginSell == second?.MarginSell &&
            first?.MarginSyntetic == second?.MarginSyntetic &&
            first?.TheorPrice == second?.TheorPrice &&
            first?.TheorPriceLimit == second?.TheorPriceLimit &&
            first?.Volatility == second?.Volatility;

        public bool Equals(SecurityFromWsHeavy? other)
        {
            if (this == (object?)other)
                return true;

            if ((object?)other == null)
                return false;

            if (GetType() != other.GetType())
                return false;

            return EqualsHelper(this, other);
        }

        public override bool Equals(object? obj) => Equals(obj as SecurityFromWsHeavy);

        private static bool Equals(SecurityFromWsHeavy? first, SecurityFromWsHeavy? second) =>
            first?.Equals(second) ?? first == (object?)second;

        public static bool operator ==(SecurityFromWsHeavy? first, SecurityFromWsHeavy? second) => Equals(first, second);

        public static bool operator !=(SecurityFromWsHeavy? first, SecurityFromWsHeavy? second) => !Equals(first, second);

        IEnumerable<ValidationResult> IValidatableObject.Validate(ValidationContext validationContext)
        {
            yield break;
        }
    }
}
