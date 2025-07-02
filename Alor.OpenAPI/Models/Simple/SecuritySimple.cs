using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text;
using Alor.OpenAPI.Enums;
using SpanJson;

namespace Alor.OpenAPI.Models.Simple
{
    [DataContract]
    public sealed class SecuritySimple : IEquatable<SecuritySimple>, IValidatableObject
    {
        public SecuritySimple() { }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseSecurity"]/Member[@name="responseSecurity"]/*' />
        public SecuritySimple(string? symbol = default, string? shortname = default,
            string? description = default, Exchange exchange = default, Market market = default,
            string? type = default, decimal? lotsize = default, decimal? facevalue = default,
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
            Market = market;
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
        [DataMember(Name = "symbol", EmitDefaultValue = false)]
        public string? Symbol { get; init; }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseSecurity"]/Member[@name="shortname"]/*' />
        [DataMember(Name = "shortname", EmitDefaultValue = false)]
        public string? Shortname { get; init; }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseSecurity"]/Member[@name="description"]/*' />
        [DataMember(Name = "description", EmitDefaultValue = false)]
        public string? Description { get; init; }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseSecurity"]/Member[@name="exchange"]/*' />
        [DataMember(Name = "exchange", EmitDefaultValue = false)]
        public Exchange Exchange { get; init; }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseSecurity"]/Member[@name="market"]/*' />
        [DataMember(Name = "market", EmitDefaultValue = false)]
        public Market Market { get;  init; }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseSecurity"]/Member[@name="type"]/*' />
        [DataMember(Name = "type", EmitDefaultValue = false)]
        public string? Type { get; init; }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseSecurity"]/Member[@name="lotsize"]/*' />
        [DataMember(Name = "lotsize", EmitDefaultValue = false)]
        public decimal? Lotsize { get; init; }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseSecurity"]/Member[@name="facevalue"]/*' />
        [DataMember(Name = "facevalue", EmitDefaultValue = false)]
        public decimal? Facevalue { get; init; }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseSecurity"]/Member[@name="cfiCode"]/*' />
        [DataMember(Name = "cfiCode", EmitDefaultValue = false)]
        public string? CfiCode { get; init; }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseSecurity"]/Member[@name="cancellation"]/*' />
        [DataMember(Name = "cancellation", EmitDefaultValue = false)]
        public string? Cancellation { get; init; }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseSecurity"]/Member[@name="minstep"]/*' />
        [DataMember(Name = "minstep", EmitDefaultValue = false)]
        public decimal? Minstep { get; init; }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseSecurity"]/Member[@name="rating"]/*' />
        [DataMember(Name = "rating", EmitDefaultValue = false)]
        public decimal? Rating { get; init; }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseSecurity"]/Member[@name="marginbuy"]/*' />
        [DataMember(Name = "marginbuy", EmitDefaultValue = false)]
        public decimal? Marginbuy { get; init; }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseSecurity"]/Member[@name="marginsell"]/*' />
        [DataMember(Name = "marginsell", EmitDefaultValue = false)]
        public decimal? Marginsell { get; init; }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseSecurity"]/Member[@name="marginrate"]/*' />
        [DataMember(Name = "marginrate", EmitDefaultValue = false)]
        public decimal? Marginrate { get; init; }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseSecurity"]/Member[@name="pricestep"]/*' />
        [DataMember(Name = "pricestep", EmitDefaultValue = false)]
        public decimal? Pricestep { get; init; }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseSecurity"]/Member[@name="priceMax"]/*' />
        [DataMember(Name = "priceMax", EmitDefaultValue = false)]
        public decimal? PriceMax { get; init; }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseSecurity"]/Member[@name="priceMin"]/*' />
        [DataMember(Name = "priceMin", EmitDefaultValue = false)]
        public decimal? PriceMin { get; init; }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseSecurity"]/Member[@name="theorPrice"]/*' />
        [DataMember(Name = "theorPrice", EmitDefaultValue = false)]
        public decimal? TheorPrice { get; init; }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseSecurity"]/Member[@name="theorPriceLimit"]/*' />
        [DataMember(Name = "theorPriceLimit", EmitDefaultValue = false)]
        public decimal? TheorPriceLimit { get; init; }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseSecurity"]/Member[@name="volatility"]/*' />
        [DataMember(Name = "volatility", EmitDefaultValue = false)]
        public decimal? Volatility { get; init; }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseSecurity"]/Member[@name="currency"]/*' />
        [DataMember(Name = "currency", EmitDefaultValue = false)]
        public string? Currency { get; init; }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseSecurity"]/Member[@name="isin"]/*' />
        [DataMember(Name = "ISIN", EmitDefaultValue = false)]
        public string? Isin { get; init; }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseSecurity"]/Member[@name="yield"]/*' />
        [DataMember(Name = "yield", EmitDefaultValue = false)]
        public decimal? Yield { get; init; }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseSecurity"]/Member[@name="board"]/*' />
        [DataMember(Name = "board", EmitDefaultValue = false)]
        public string? Board { get; init; }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseSecurity"]/Member[@name="primaryBoard"]/*' />
        [DataMember(Name = "primary_board", EmitDefaultValue = false)]
        public string? PrimaryBoard { get; init; }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseSecurity"]/Member[@name="tradingStatus"]/*' />
        [DataMember(Name = "tradingStatus", EmitDefaultValue = false)]
        public int? TradingStatus { get; init; }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseSecurity"]/Member[@name="tradingStatusInfo"]/*' />
        [DataMember(Name = "tradingStatusInfo", EmitDefaultValue = false)]
        public string? TradingStatusInfo { get; init; }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseSecurity"]/Member[@name="complexProductCategory"]/*' />
        [DataMember(Name = "complexProductCategory", EmitDefaultValue = false)]
        public string? ComplexProductCategory { get; init; }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseSecurity"]/Member[@name="priceMultiplier"]/*' />
        [DataMember(Name = "priceMultiplier", EmitDefaultValue = false)]
        public decimal? PriceMultiplier { get; init; }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseSecurity"]/Member[@name="priceShownUnits"]/*' />
        [DataMember(Name = "priceShownUnits", EmitDefaultValue = false)]
        public decimal? PriceShownUnits { get; init; }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseSecurity"]/Member[@name="strikePrice"]/*' />
        [DataMember(Name = "strikePrice", EmitDefaultValue = false)]
        public decimal? StrikePrice { get; init; }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseSecurity"]/Member[@name="endExpiration"]/*' />
        [DataMember(Name = "endExpiration", EmitDefaultValue = false)]
        public DateTime? EndExpiration { get; init; }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseSecurity"]/Member[@name="fixedSpotDiscount"]/*' />
        [DataMember(Name = "fixedSpotDiscount", EmitDefaultValue = false)]
        public decimal? FixedSpotDiscount { get; init; }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseSecurity"]/Member[@name="projectedSpotDiscount"]/*' />
        [DataMember(Name = "projectedSpotDiscount", EmitDefaultValue = false)]
        public decimal? ProjectedSpotDiscount { get; init; }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseSecurity"]/Member[@name="underlyingSymbol"]/*' />
        [DataMember(Name = "underlyingSymbol", EmitDefaultValue = false)]
        public string? UnderlyingSymbol { get; init; }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseSecurity"]/Member[@name="optionSide"]/*' />
        [DataMember(Name = "optionSide", EmitDefaultValue = false)]
        public OptionSide? OptionSide { get; init; }
        
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class SecuritySimple {").Append(Environment.NewLine);
            sb.Append("  SymbolSimple: ").Append(Symbol).Append(Environment.NewLine);
            sb.Append("  Shortname: ").Append(Shortname).Append(Environment.NewLine);
            sb.Append("  Description: ").Append(Description).Append(Environment.NewLine);
            sb.Append("  Exchange: ").Append(Exchange).Append(Environment.NewLine);
            sb.Append("  Market: ").Append(Market).Append(Environment.NewLine);
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

        public override int GetHashCode()
        {
            var hash = new HashCode();
            hash.Add(Symbol);
            hash.Add(Shortname);
            hash.Add(Description);
            hash.Add(Exchange);
            hash.Add(Market);
            hash.Add(Type);
            hash.Add(Lotsize);
            hash.Add(Facevalue);
            hash.Add(CfiCode);
            hash.Add(Cancellation);
            hash.Add(Minstep);
            hash.Add(Rating);
            hash.Add(Marginbuy);
            hash.Add(Marginsell);
            hash.Add(Marginrate);
            hash.Add(Pricestep);
            hash.Add(PriceMax);
            hash.Add(PriceMin);
            hash.Add(TheorPrice);
            hash.Add(TheorPriceLimit);
            hash.Add(Volatility);
            hash.Add(Currency);
            hash.Add(Isin);
            hash.Add(Yield);
            hash.Add(Board);
            hash.Add(PrimaryBoard);
            hash.Add(TradingStatus);
            hash.Add(TradingStatusInfo);
            hash.Add(ComplexProductCategory);
            hash.Add(PriceMultiplier);
            hash.Add(PriceShownUnits);
            hash.Add(StrikePrice);
            hash.Add(EndExpiration);
            hash.Add(FixedSpotDiscount);
            hash.Add(ProjectedSpotDiscount);
            hash.Add(UnderlyingSymbol);
            hash.Add(OptionSide);
            return hash.ToHashCode();
        }

        private static bool EqualsHelper(SecuritySimple? first, SecuritySimple? second) =>
            first?.Symbol == second?.Symbol &&
            first?.Shortname == second?.Shortname &&
            first?.Description == second?.Description &&
            first?.Exchange == second?.Exchange &&
            first?.Market == second?.Market &&
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

        public bool Equals(SecuritySimple? other)
        {
            if (this == (object?)other)
                return true;

            if ((object?)other == null)
                return false;

            return GetType() == other.GetType() && EqualsHelper(this, other);
        }

        public override bool Equals(object? obj) => Equals(obj as SecuritySimple);

        private static bool Equals(SecuritySimple? first, SecuritySimple? second) =>
            first?.Equals(second) ?? first == (object?)second;

        public static bool operator ==(SecuritySimple? first, SecuritySimple? second) => Equals(first, second);

        public static bool operator !=(SecuritySimple? first, SecuritySimple? second) => !Equals(first, second);

        IEnumerable<ValidationResult> IValidatableObject.Validate(ValidationContext validationContext)
        {
            yield break;
        }
    }
}
