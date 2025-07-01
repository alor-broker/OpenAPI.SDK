using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text;
using Alor.OpenAPI.Enums;
using SpanJson;

namespace Alor.OpenAPI.Models.Slim
{
    [DataContract]
    public sealed class SecurityFromWsSlim : IEquatable<SecurityFromWsSlim>, IValidatableObject
    {
        public SecurityFromWsSlim() { }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseInstruments"]/Member[@name="responseInstruments"]/*' />
        public SecurityFromWsSlim(string? symbol = default, Exchange exchange = default,
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
        [DataMember(Name = "sym", EmitDefaultValue = false)]
        public string? Symbol { get; init; }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseInstruments"]/Member[@name="exchange"]/*' />
        [DataMember(Name = "ex", EmitDefaultValue = false)]
        public Exchange Exchange { get; init; }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseInstruments"]/Member[@name="priceMax"]/*' />
        [DataMember(Name = "pxmx", EmitDefaultValue = false)]
        public decimal? PriceMax { get; init; }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseInstruments"]/Member[@name="priceMin"]/*' />
        [DataMember(Name = "pxmn", EmitDefaultValue = false)]
        public decimal? PriceMin { get; init; }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseInstruments"]/Member[@name="board"]/*' />
        [DataMember(Name = "bd", EmitDefaultValue = false)]
        public string? Board { get; init; }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseInstruments"]/Member[@name="tradingStatus"]/*' />
        [DataMember(Name = "st", EmitDefaultValue = false)]
        public int? TradingStatus { get; init; }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseInstruments"]/Member[@name="tradingStatusInfo"]/*' />
        [DataMember(Name = "sti", EmitDefaultValue = false)]
        public string? TradingStatusInfo { get; init; }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseInstruments"]/Member[@name="marginBuy"]/*' />
        [DataMember(Name = "mgb", EmitDefaultValue = false)]
        public decimal? MarginBuy { get; init; }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseInstruments"]/Member[@name="marginSell"]/*' />
        [DataMember(Name = "mgs", EmitDefaultValue = false)]
        public decimal? MarginSell { get; init; }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseInstruments"]/Member[@name="marginSyntetic"]/*' />
        [DataMember(Name = "mgsnt", EmitDefaultValue = false)]
        public decimal? MarginSyntetic { get; init; }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseInstruments"]/Member[@name="theorPrice"]/*' />
        [DataMember(Name = "pxt", EmitDefaultValue = false)]
        public decimal? TheorPrice { get; init; }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseInstruments"]/Member[@name="theorPriceLimit"]/*' />
        [DataMember(Name = "pxtl", EmitDefaultValue = false)]
        public decimal? TheorPriceLimit { get; init; }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseInstruments"]/Member[@name="volatility"]/*' />
        [DataMember(Name = "vl", EmitDefaultValue = false)]
        public decimal? Volatility { get; init; }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class SecurityFromWsSlim {").Append(Environment.NewLine);
            sb.Append("  SymbolSimple: ").Append(Symbol).Append(Environment.NewLine);
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

        public override int GetHashCode()
        {
            var hash = new HashCode();
            hash.Add(Symbol);
            hash.Add(Exchange);
            hash.Add(PriceMax);
            hash.Add(PriceMin);
            hash.Add(Board);
            hash.Add(TradingStatus);
            hash.Add(TradingStatusInfo);
            hash.Add(MarginBuy);
            hash.Add(MarginSell);
            hash.Add(MarginSyntetic);
            hash.Add(TheorPrice);
            hash.Add(TheorPriceLimit);
            hash.Add(Volatility);
            return hash.ToHashCode();
        }

        private static bool EqualsHelper(SecurityFromWsSlim? first, SecurityFromWsSlim? second) =>
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

        public bool Equals(SecurityFromWsSlim? other)
        {
            if (this == (object?)other)
                return true;

            if ((object?)other == null)
                return false;

            return GetType() == other.GetType() && EqualsHelper(this, other);
        }

        public override bool Equals(object? obj) => Equals(obj as SecurityFromWsSlim);

        private static bool Equals(SecurityFromWsSlim? first, SecurityFromWsSlim? second) =>
            first?.Equals(second) ?? first == (object?)second;

        public static bool operator ==(SecurityFromWsSlim? first, SecurityFromWsSlim? second) => Equals(first, second);

        public static bool operator !=(SecurityFromWsSlim? first, SecurityFromWsSlim? second) => !Equals(first, second);

        IEnumerable<ValidationResult> IValidatableObject.Validate(ValidationContext validationContext)
        {
            yield break;
        }
    }
}
