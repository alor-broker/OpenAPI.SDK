using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text;
using Alor.OpenAPI.Enums;
using SpanJson;

namespace Alor.OpenAPI.Models.Slim
{
    [DataContract]
    public sealed class SecuritySlim : IEquatable<SecuritySlim>, IValidatableObject
    {
        public SecuritySlim() { }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseSecurity"]/Member[@name="responseSecurity"]/*' />
        public SecuritySlim(string? symbol = default, string? shortname = default,
            string? description = default, Exchange exchange = default, string? type = default,
            decimal? lotsize = default, decimal? facevalue = default,
            string? cfiCode = default, string? cancellation = default,
            decimal? minstep = default, decimal? rating = default,
            decimal? marginbuy = default, decimal? marginsell = default,
            decimal? marginrate = default, decimal? pricestep = default,
            decimal? priceMax = default, decimal? priceMin = default,
            decimal? theorPrice = default, decimal? theorPriceLimit = default,
            decimal? volatility = default, string? currency = default, string? isin = default,
            decimal? yield = default, string? board = default, string? primaryBoard = default,
            int? tradingStatus = default, string? tradingStatusInfo = default,
            string? complexProductCategory = default, decimal? priceMultiplier = default,
            decimal? priceShownUnits = default, decimal? strikePrice = default,
            DateTime? endExpiration = default, decimal? fixedSpotDiscount = default,
            decimal? projectedSpotDiscount = default, string? underlyingSymbol = default,
            OptionSide? optionSide = default)
        {
            Symbol = symbol;
            Shortname = shortname;
            Description = description;
            Exchange = exchange;
            Type = type;
            Lotsize = lotsize;
            Facevalue = facevalue;
            CfiCode = cfiCode;
            Cancellation = cancellation;
            Minstep = minstep;
            Rating = rating;
            Marginbuy = marginbuy;
            Marginsell = marginsell;
            Marginrate = marginrate;
            Pricestep = pricestep;
            PriceMax = priceMax;
            PriceMin = priceMin;
            TheorPrice = theorPrice;
            TheorPriceLimit = theorPriceLimit;
            Volatility = volatility;
            Currency = currency;
            Isin = isin;
            Yield = yield;
            Board = board;
            PrimaryBoard = primaryBoard;
            TradingStatus = tradingStatus;
            TradingStatusInfo = tradingStatusInfo;
            ComplexProductCategory = complexProductCategory;
            PriceMultiplier = priceMultiplier;
            PriceShownUnits = priceShownUnits;
            StrikePrice = strikePrice;
            EndExpiration = endExpiration;
            FixedSpotDiscount = fixedSpotDiscount;
            ProjectedSpotDiscount = projectedSpotDiscount;
            UnderlyingSymbol = underlyingSymbol;
            OptionSide = optionSide;
        }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseSecurity"]/Member[@name="symbol"]/*' />
        [DataMember(Name = "sym", EmitDefaultValue = false)]
        public string? Symbol { get; private set; }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseSecurity"]/Member[@name="shortname"]/*' />
        [DataMember(Name = "n", EmitDefaultValue = false)]
        public string? Shortname { get; set; }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseSecurity"]/Member[@name="description"]/*' />
        [DataMember(Name = "desc", EmitDefaultValue = false)]
        public string? Description { get; set; }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseSecurity"]/Member[@name="exchange"]/*' />
        [DataMember(Name = "ex", EmitDefaultValue = false)]
        public Exchange Exchange { get; private set; }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseSecurity"]/Member[@name="type"]/*' />
        [DataMember(Name = "t", EmitDefaultValue = false)]
        public string? Type { get; set; }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseSecurity"]/Member[@name="lotsize"]/*' />
        [DataMember(Name = "lot", EmitDefaultValue = false)]
        public decimal? Lotsize { get; set; }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseSecurity"]/Member[@name="facevalue"]/*' />
        [DataMember(Name = "fv", EmitDefaultValue = false)]
        public decimal? Facevalue { get; set; }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseSecurity"]/Member[@name="cfiCode"]/*' />
        [DataMember(Name = "cfi", EmitDefaultValue = false)]
        public string? CfiCode { get; set; }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseSecurity"]/Member[@name="cancellation"]/*' />
        [DataMember(Name = "cncl", EmitDefaultValue = false)]
        public string? Cancellation { get; set; }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseSecurity"]/Member[@name="minstep"]/*' />
        [DataMember(Name = "stp", EmitDefaultValue = false)]
        public decimal? Minstep { get; set; }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseSecurity"]/Member[@name="rating"]/*' />
        [DataMember(Name = "rt", EmitDefaultValue = false)]
        public decimal? Rating { get; set; }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseSecurity"]/Member[@name="marginbuy"]/*' />
        [DataMember(Name = "mgb", EmitDefaultValue = false)]
        public decimal? Marginbuy { get; set; }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseSecurity"]/Member[@name="marginsell"]/*' />
        [DataMember(Name = "mgs", EmitDefaultValue = false)]
        public decimal? Marginsell { get; set; }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseSecurity"]/Member[@name="marginrate"]/*' />
        [DataMember(Name = "mgrt", EmitDefaultValue = false)]
        public decimal? Marginrate { get; set; }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseSecurity"]/Member[@name="pricestep"]/*' />
        [DataMember(Name = "stppx", EmitDefaultValue = false)]
        public decimal? Pricestep { get; set; }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseSecurity"]/Member[@name="priceMax"]/*' />
        [DataMember(Name = "pxmx", EmitDefaultValue = false)]
        public decimal? PriceMax { get; set; }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseSecurity"]/Member[@name="priceMin"]/*' />
        [DataMember(Name = "pxmn", EmitDefaultValue = false)]
        public decimal? PriceMin { get; set; }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseSecurity"]/Member[@name="theorPrice"]/*' />
        [DataMember(Name = "pxt", EmitDefaultValue = false)]
        public decimal? TheorPrice { get; set; }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseSecurity"]/Member[@name="theorPriceLimit"]/*' />
        [DataMember(Name = "pxtl", EmitDefaultValue = false)]
        public decimal? TheorPriceLimit { get; set; }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseSecurity"]/Member[@name="volatility"]/*' />
        [DataMember(Name = "vl", EmitDefaultValue = false)]
        public decimal? Volatility { get; set; }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseSecurity"]/Member[@name="currency"]/*' />
        [DataMember(Name = "cur", EmitDefaultValue = false)]
        public string? Currency { get; set; }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseSecurity"]/Member[@name="isin"]/*' />
        [DataMember(Name = "isin", EmitDefaultValue = false)]
        public string? Isin { get; set; }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseSecurity"]/Member[@name="yield"]/*' />
        [DataMember(Name = "yld", EmitDefaultValue = false)]
        public decimal? Yield { get; set; }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseSecurity"]/Member[@name="board"]/*' />
        [DataMember(Name = "bd", EmitDefaultValue = false)]
        public string? Board { get; private set; }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseSecurity"]/Member[@name="primaryBoard"]/*' />
        [DataMember(Name = "pbd", EmitDefaultValue = false)]
        public string? PrimaryBoard { get; set; }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseSecurity"]/Member[@name="tradingStatus"]/*' />
        [DataMember(Name = "st", EmitDefaultValue = false)]
        public int? TradingStatus { get; set; }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseSecurity"]/Member[@name="tradingStatusInfo"]/*' />
        [DataMember(Name = "sti", EmitDefaultValue = false)]
        public string? TradingStatusInfo { get; set; }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseSecurity"]/Member[@name="complexProductCategory"]/*' />
        [DataMember(Name = "cpct", EmitDefaultValue = false)]
        public string? ComplexProductCategory { get; set; }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseSecurity"]/Member[@name="priceMultiplier"]/*' />
        [DataMember(Name = "pxmu", EmitDefaultValue = false)]
        public decimal? PriceMultiplier { get; set; }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseSecurity"]/Member[@name="priceShownUnits"]/*' />
        [DataMember(Name = "pxu", EmitDefaultValue = false)]
        public decimal? PriceShownUnits { get; set; }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseSecurity"]/Member[@name="strikePrice"]/*' />
        [DataMember(Name = "pxs", EmitDefaultValue = false)]
        public decimal? StrikePrice { get; set; }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseSecurity"]/Member[@name="endExpiration"]/*' />
        [DataMember(Name = "exp", EmitDefaultValue = false)]
        public DateTime? EndExpiration { get; set; }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseSecurity"]/Member[@name="fixedSpotDiscount"]/*' />
        [DataMember(Name = "fdis", EmitDefaultValue = false)]
        public decimal? FixedSpotDiscount { get; set; }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseSecurity"]/Member[@name="projectedSpotDiscount"]/*' />
        [DataMember(Name = "pdis", EmitDefaultValue = false)]
        public decimal? ProjectedSpotDiscount { get; set; }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseSecurity"]/Member[@name="underlyingSymbol"]/*' />
        [DataMember(Name = "usym", EmitDefaultValue = false)]
        public string? UnderlyingSymbol { get; set; }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseSecurity"]/Member[@name="optionSide"]/*' />
        [DataMember(Name = "osd", EmitDefaultValue = false)]
        public OptionSide? OptionSide { get; set; }


        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class SecuritySlim {").Append(Environment.NewLine);
            sb.Append("  SymbolSimple: ").Append(Symbol).Append(Environment.NewLine);
            sb.Append("  Shortname: ").Append(Shortname).Append(Environment.NewLine);
            sb.Append("  Description: ").Append(Description).Append(Environment.NewLine);
            sb.Append("  Exchange: ").Append(Exchange).Append(Environment.NewLine);
            sb.Append("  Type: ").Append(Type).Append(Environment.NewLine);
            sb.Append("  Lotsize: ").Append(Lotsize).Append(Environment.NewLine);
            sb.Append("  Facevalue: ").Append(Facevalue).Append(Environment.NewLine);
            sb.Append("  CfiCode: ").Append(CfiCode).Append(Environment.NewLine);
            sb.Append("  Cancellation: ").Append(Cancellation).Append(Environment.NewLine);
            sb.Append("  Minstep: ").Append(Minstep).Append(Environment.NewLine);
            sb.Append("  Rating: ").Append(Rating).Append(Environment.NewLine);
            sb.Append("  Marginbuy: ").Append(Marginbuy).Append(Environment.NewLine);
            sb.Append("  Marginsell: ").Append(Marginsell).Append(Environment.NewLine);
            sb.Append("  Marginrate: ").Append(Marginrate).Append(Environment.NewLine);
            sb.Append("  Pricestep: ").Append(Pricestep).Append(Environment.NewLine);
            sb.Append("  PriceMax: ").Append(PriceMax).Append(Environment.NewLine);
            sb.Append("  PriceMin: ").Append(PriceMin).Append(Environment.NewLine);
            sb.Append("  TheorPrice: ").Append(TheorPrice).Append(Environment.NewLine);
            sb.Append("  TheorPriceLimit: ").Append(TheorPriceLimit).Append(Environment.NewLine);
            sb.Append("  Volatility: ").Append(Volatility).Append(Environment.NewLine);
            sb.Append("  Currency: ").Append(Currency).Append(Environment.NewLine);
            sb.Append("  ISIN: ").Append(Isin).Append(Environment.NewLine);
            sb.Append("  Yield: ").Append(Yield).Append(Environment.NewLine);
            sb.Append("  Board: ").Append(Board).Append(Environment.NewLine);
            sb.Append("  PrimaryBoard: ").Append(PrimaryBoard).Append(Environment.NewLine);
            sb.Append("  TradingStatus: ").Append(TradingStatus).Append(Environment.NewLine);
            sb.Append("  TradingStatusInfo: ").Append(TradingStatusInfo).Append(Environment.NewLine);
            sb.Append("  ComplexProductCategory: ").Append(ComplexProductCategory).Append(Environment.NewLine);
            sb.Append("  PriceMultiplier: ").Append(PriceMultiplier).Append(Environment.NewLine);
            sb.Append("  PriceShownUnits: ").Append(PriceShownUnits).Append(Environment.NewLine);
            sb.Append("  StrikePrice: ").Append(StrikePrice).Append(Environment.NewLine);
            sb.Append("  EndExpiration: ").Append(EndExpiration).Append(Environment.NewLine);
            sb.Append("  FixedSpotDiscount: ").Append(FixedSpotDiscount).Append(Environment.NewLine);
            sb.Append("  ProjectedSpotDiscount: ").Append(ProjectedSpotDiscount).Append(Environment.NewLine);
            sb.Append("  UnderlyingSymbol: ").Append(UnderlyingSymbol).Append(Environment.NewLine);
            sb.Append("  OptionSide: ").Append(OptionSide).Append(Environment.NewLine);
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

        private static bool EqualsHelper(SecuritySlim? first, SecuritySlim? second) =>
            first?.Symbol == second?.Symbol &&
            first?.Shortname == second?.Shortname &&
            first?.Description == second?.Description &&
            first?.Exchange == second?.Exchange &&
            first?.Type == second?.Type &&
            first?.Lotsize == second?.Lotsize &&
            first?.Facevalue == second?.Facevalue &&
            first?.CfiCode == second?.CfiCode &&
            first?.Cancellation == second?.Cancellation &&
            first?.Minstep == second?.Minstep &&
            first?.Rating == second?.Rating &&
            first?.Marginbuy == second?.Marginbuy &&
            first?.Marginsell == second?.Marginsell &&
            first?.Marginrate == second?.Marginrate &&
            first?.Pricestep == second?.Pricestep &&
            first?.PriceMax == second?.PriceMax &&
            first?.PriceMin == second?.PriceMin &&
            first?.TheorPrice == second?.TheorPrice &&
            first?.TheorPriceLimit == second?.TheorPriceLimit &&
            first?.Volatility == second?.Volatility &&
            first?.Currency == second?.Currency &&
            first?.Isin == second?.Isin &&
            first?.Yield == second?.Yield &&
            first?.Board == second?.Board &&
            first?.PrimaryBoard == second?.PrimaryBoard &&
            first?.TradingStatus == second?.TradingStatus &&
            first?.TradingStatusInfo == second?.TradingStatusInfo &&
            first?.ComplexProductCategory == second?.ComplexProductCategory &&
            first?.PriceMultiplier == second?.PriceMultiplier &&
            first?.PriceShownUnits == second?.PriceShownUnits &&
            first?.StrikePrice == second?.StrikePrice &&
            first?.EndExpiration == second?.EndExpiration &&
            first?.FixedSpotDiscount == second?.FixedSpotDiscount &&
            first?.ProjectedSpotDiscount == second?.ProjectedSpotDiscount &&
            first?.UnderlyingSymbol == second?.UnderlyingSymbol &&
            first?.OptionSide == second?.OptionSide;

        public bool Equals(SecuritySlim? other)
        {
            if (this == (object?)other)
                return true;

            if ((object?)other == null)
                return false;

            if (GetType() != other.GetType())
                return false;

            return EqualsHelper(this, other);
        }

        public override bool Equals(object? obj) => Equals(obj as SecuritySlim);

        private static bool Equals(SecuritySlim? first, SecuritySlim? second) =>
            first?.Equals(second) ?? first == (object?)second;

        public static bool operator ==(SecuritySlim? first, SecuritySlim? second) => Equals(first, second);

        public static bool operator !=(SecuritySlim? first, SecuritySlim? second) => !Equals(first, second);

        IEnumerable<ValidationResult> IValidatableObject.Validate(ValidationContext validationContext)
        {
            yield break;
        }
    }
}
