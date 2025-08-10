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

        /// <include file='../../XmlDocs/CoreModels.xml'
        ///          path='Docs/Members[@name="responseSecurity"]
        ///               /Member[@name="responseSecurity"]
        ///               /param[
        ///                      @name="symbol" or @name="shortname" or @name="description" or @name="exchange" or @name="type"
        ///                      or @name="lotsize" or @name="facevalue" or @name="cfiCode" or @name="cancellation"
        ///                      or @name="minstep" or @name="rating" or @name="marginbuy" or @name="marginsell" or @name="marginrate"
        ///                      or @name="pricestep" or @name="priceMax" or @name="priceMin" or @name="theorPrice" or @name="theorPriceLimit"
        ///                      or @name="volatility" or @name="currency" or @name="isin" or @name="yield" or @name="board"
        ///                      or @name="primaryBoard" or @name="tradingStatus" or @name="tradingStatusInfo" or @name="complexProductCategory"
        ///                      or @name="priceMultiplier" or @name="priceShownUnits" or @name="strikePrice" or @name="endExpiration"
        ///                      or @name="fixedSpotDiscount" or @name="projectedSpotDiscount" or @name="underlyingSymbol"
        ///						 or @name="optionSide"
        ///                     ]'/>
        public SecuritySlim(string? symbol = null, string? shortname = null,
            string? description = null, Exchange? exchange = null, string? type = null,
            decimal? lotsize = null, decimal? facevalue = null,
            string? cfiCode = null, string? cancellation = null,
            decimal? minstep = null, decimal? rating = null,
            decimal? marginbuy = null, decimal? marginsell = null,
            decimal? marginrate = null, decimal? pricestep = null,
            decimal? priceMax = null, decimal? priceMin = null,
            decimal? theorPrice = null, decimal? theorPriceLimit = null,
            decimal? volatility = null, string? currency = null, string? isin = null,
            decimal? yield = null, string? board = null, string? primaryBoard = null,
            int? tradingStatus = null, string? tradingStatusInfo = null,
            string? complexProductCategory = null, decimal? priceMultiplier = null,
            decimal? priceShownUnits = null, decimal? strikePrice = null,
            DateTime? endExpiration = null, decimal? fixedSpotDiscount = null,
            decimal? projectedSpotDiscount = null, string? underlyingSymbol = null,
            OptionSide? optionSide = null)
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
        public string? Symbol { get; init; }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseSecurity"]/Member[@name="shortname"]/*' />
        [DataMember(Name = "n", EmitDefaultValue = false)]
        public string? Shortname { get; init; }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseSecurity"]/Member[@name="description"]/*' />
        [DataMember(Name = "desc", EmitDefaultValue = false)]
        public string? Description { get; init; }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseSecurity"]/Member[@name="exchange"]/*' />
        [DataMember(Name = "ex", EmitDefaultValue = false)]
        public Exchange? Exchange { get; init; }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseSecurity"]/Member[@name="type"]/*' />
        [DataMember(Name = "t", EmitDefaultValue = false)]
        public string? Type { get; init; }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseSecurity"]/Member[@name="lotsize"]/*' />
        [DataMember(Name = "lot", EmitDefaultValue = false)]
        public decimal? Lotsize { get; init; }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseSecurity"]/Member[@name="facevalue"]/*' />
        [DataMember(Name = "fv", EmitDefaultValue = false)]
        public decimal? Facevalue { get; init; }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseSecurity"]/Member[@name="cfiCode"]/*' />
        [DataMember(Name = "cfi", EmitDefaultValue = false)]
        public string? CfiCode { get; init; }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseSecurity"]/Member[@name="cancellation"]/*' />
        [DataMember(Name = "cncl", EmitDefaultValue = false)]
        public string? Cancellation { get; init; }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseSecurity"]/Member[@name="minstep"]/*' />
        [DataMember(Name = "stp", EmitDefaultValue = false)]
        public decimal? Minstep { get; init; }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseSecurity"]/Member[@name="rating"]/*' />
        [DataMember(Name = "rt", EmitDefaultValue = false)]
        public decimal? Rating { get; init; }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseSecurity"]/Member[@name="marginbuy"]/*' />
        [DataMember(Name = "mgb", EmitDefaultValue = false)]
        public decimal? Marginbuy { get; init; }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseSecurity"]/Member[@name="marginsell"]/*' />
        [DataMember(Name = "mgs", EmitDefaultValue = false)]
        public decimal? Marginsell { get; init; }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseSecurity"]/Member[@name="marginrate"]/*' />
        [DataMember(Name = "mgrt", EmitDefaultValue = false)]
        public decimal? Marginrate { get; init; }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseSecurity"]/Member[@name="pricestep"]/*' />
        [DataMember(Name = "stppx", EmitDefaultValue = false)]
        public decimal? Pricestep { get; init; }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseSecurity"]/Member[@name="priceMax"]/*' />
        [DataMember(Name = "pxmx", EmitDefaultValue = false)]
        public decimal? PriceMax { get; init; }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseSecurity"]/Member[@name="priceMin"]/*' />
        [DataMember(Name = "pxmn", EmitDefaultValue = false)]
        public decimal? PriceMin { get; init; }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseSecurity"]/Member[@name="theorPrice"]/*' />
        [DataMember(Name = "pxt", EmitDefaultValue = false)]
        public decimal? TheorPrice { get; init; }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseSecurity"]/Member[@name="theorPriceLimit"]/*' />
        [DataMember(Name = "pxtl", EmitDefaultValue = false)]
        public decimal? TheorPriceLimit { get; init; }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseSecurity"]/Member[@name="volatility"]/*' />
        [DataMember(Name = "vl", EmitDefaultValue = false)]
        public decimal? Volatility { get; init; }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseSecurity"]/Member[@name="currency"]/*' />
        [DataMember(Name = "cur", EmitDefaultValue = false)]
        public string? Currency { get; init; }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseSecurity"]/Member[@name="isin"]/*' />
        [DataMember(Name = "isin", EmitDefaultValue = false)]
        public string? Isin { get; init; }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseSecurity"]/Member[@name="yield"]/*' />
        [DataMember(Name = "yld", EmitDefaultValue = false)]
        public decimal? Yield { get; init; }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseSecurity"]/Member[@name="board"]/*' />
        [DataMember(Name = "bd", EmitDefaultValue = false)]
        public string? Board { get; init; }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseSecurity"]/Member[@name="primaryBoard"]/*' />
        [DataMember(Name = "pbd", EmitDefaultValue = false)]
        public string? PrimaryBoard { get; init; }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseSecurity"]/Member[@name="tradingStatus"]/*' />
        [DataMember(Name = "st", EmitDefaultValue = false)]
        public int? TradingStatus { get; init; }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseSecurity"]/Member[@name="tradingStatusInfo"]/*' />
        [DataMember(Name = "sti", EmitDefaultValue = false)]
        public string? TradingStatusInfo { get; init; }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseSecurity"]/Member[@name="complexProductCategory"]/*' />
        [DataMember(Name = "cpct", EmitDefaultValue = false)]
        public string? ComplexProductCategory { get; init; }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseSecurity"]/Member[@name="priceMultiplier"]/*' />
        [DataMember(Name = "pxmu", EmitDefaultValue = false)]
        public decimal? PriceMultiplier { get; init; }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseSecurity"]/Member[@name="priceShownUnits"]/*' />
        [DataMember(Name = "pxu", EmitDefaultValue = false)]
        public decimal? PriceShownUnits { get; init; }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseSecurity"]/Member[@name="strikePrice"]/*' />
        [DataMember(Name = "pxs", EmitDefaultValue = false)]
        public decimal? StrikePrice { get; init; }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseSecurity"]/Member[@name="endExpiration"]/*' />
        [DataMember(Name = "exp", EmitDefaultValue = false)]
        public DateTime? EndExpiration { get; init; }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseSecurity"]/Member[@name="fixedSpotDiscount"]/*' />
        [DataMember(Name = "fdis", EmitDefaultValue = false)]
        public decimal? FixedSpotDiscount { get; init; }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseSecurity"]/Member[@name="projectedSpotDiscount"]/*' />
        [DataMember(Name = "pdis", EmitDefaultValue = false)]
        public decimal? ProjectedSpotDiscount { get; init; }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseSecurity"]/Member[@name="underlyingSymbol"]/*' />
        [DataMember(Name = "usym", EmitDefaultValue = false)]
        public string? UnderlyingSymbol { get; init; }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseSecurity"]/Member[@name="optionSide"]/*' />
        [DataMember(Name = "osd", EmitDefaultValue = false)]
        public OptionSide? OptionSide { get; init; }

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

        public override int GetHashCode()
        {
            var hash = new HashCode();
            hash.Add(Symbol);
            hash.Add(Shortname);
            hash.Add(Description);
            hash.Add(Exchange);
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

            if (other is null)
                return false;

            return GetType() == other.GetType() && EqualsHelper(this, other);
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
