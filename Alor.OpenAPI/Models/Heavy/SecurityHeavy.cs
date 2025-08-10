using Alor.OpenAPI.Enums;
using SpanJson;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text;

namespace Alor.OpenAPI.Models.Heavy
{
	[DataContract]
	public sealed class SecurityHeavy : IEquatable<SecurityHeavy>, IValidatableObject
	{
		public SecurityHeavy() { }

        /// <include file='../../XmlDocs/CoreModels.xml'
        ///          path='Docs/Members[@name="responseSecurity"]
        ///               /Member[@name="responseSecurity"]
        ///               /param[
        ///                      @name="symbol" or @name="shortname" or @name="description" or @name="exchange" or @name="market"
        ///                      or @name="type" or @name="lotsize" or @name="facevalue" or @name="cfiCode" or @name="cancellation"
        ///                      or @name="minstep" or @name="roundToHeavy" or @name="rating" or @name="marginbuy" or @name="marginsell"
        ///						 or @name="marginrate" or @name="pricestep" or @name="priceMax" or @name="priceMin" or @name="theorPrice"
        ///						 or @name="theorPriceLimit" or @name="volatility" or @name="currency" or @name="isin" or @name="yield"
        ///						 or @name="board" or @name="primaryBoard" or @name="tradingStatus" or @name="tradingStatusInfo"
        ///						 or @name="complexProductCategory" or @name="priceMultiplier" or @name="priceShownUnits" or @name="strikePrice"
        ///						 or @name="endExpiration" or @name="fixedSpotDiscount" or @name="projectedSpotDiscount" or @name="underlyingSymbol"
        ///						 or @name="optionSide" or @name="initialMarginLowRiskLongHeavy" or @name="initialMarginLowRiskShortHeavy"
        ///						 or @name="initialMarginStandardRiskLongHeavy" or @name="initialMarginStandardRiskShortHeavy"
        ///						 or @name="initialMarginHighRiskLongHeavy" or @name="initialMarginHighRiskShortHeavy"
        ///						 or @name="initialMarginSpecialRiskLongHeavy" or @name="initialMarginSpecialRiskShortHeavy"
        ///                     ]'/>
        public SecurityHeavy(string? symbol = null, string? shortname = null,
		string? description = null, Exchange? exchange = null, Market? market = null,
			string? type = null, decimal? lotsize = null, decimal? facevalue = null,
			string? cfiCode = null, string? cancellation = null,
			decimal? minstep = null, int? roundToHeavy = null, decimal? rating = null,
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
			OptionSide? optionSide = null, decimal? initialMarginLowRiskLongHeavy = null,
			decimal? initialMarginLowRiskShortHeavy = null, decimal? initialMarginStandardRiskLongHeavy = null,
			decimal? initialMarginStandardRiskShortHeavy = null, decimal? initialMarginHighRiskLongHeavy = null,
			decimal? initialMarginHighRiskShortHeavy = null, decimal? initialMarginSpecialRiskLongHeavy = null,
			decimal? initialMarginSpecialRiskShortHeavy = null)
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
			RoundToHeavy = roundToHeavy;
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
			InitialMarginLowRiskLong = initialMarginLowRiskLongHeavy;
			InitialMarginLowRiskShort = initialMarginLowRiskShortHeavy;
			InitialMarginStandardRiskLong = initialMarginStandardRiskLongHeavy;
			InitialMarginStandardRiskShort = initialMarginStandardRiskShortHeavy;
			InitialMarginHighRiskLong = initialMarginHighRiskLongHeavy;
			InitialMarginHighRiskShort = initialMarginHighRiskShortHeavy;
			InitialMarginSpecialRiskLong = initialMarginSpecialRiskLongHeavy;
			InitialMarginSpecialRiskShort = initialMarginSpecialRiskShortHeavy;
		}

		/// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseSecurity"]/Member[@name="symbol"]/*' />
		[DataMember(Name = "symbol", EmitDefaultValue = false)]
		public string? Symbol { get; init; }

		/// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseSecurity"]/Member[@name="shortname"]/*' />
		[DataMember(Name = "shortName", EmitDefaultValue = false)]
		public string? Shortname { get; init; }

		/// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseSecurity"]/Member[@name="description"]/*' />
		[DataMember(Name = "description", EmitDefaultValue = false)]
		public string? Description { get; init; }

		/// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseSecurity"]/Member[@name="exchange"]/*' />
		[DataMember(Name = "exchange", EmitDefaultValue = false)]
		public Exchange? Exchange { get; init; }

		/// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseSecurity"]/Member[@name="market"]/*' />
		[DataMember(Name = "market", EmitDefaultValue = false)]
		public Market? Market { get; init; }

		/// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseSecurity"]/Member[@name="type"]/*' />
		[DataMember(Name = "type", EmitDefaultValue = false)]
		public string? Type { get; init; }

		/// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseSecurity"]/Member[@name="lotsize"]/*' />
		[DataMember(Name = "lotSize", EmitDefaultValue = false)]
		public decimal? Lotsize { get; init; }

		/// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseSecurity"]/Member[@name="facevalue"]/*' />
		[DataMember(Name = "faceValue", EmitDefaultValue = false)]
		public decimal? Facevalue { get; init; }

		/// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseSecurity"]/Member[@name="cfiCode"]/*' />
		[DataMember(Name = "cfiCode", EmitDefaultValue = false)]
		public string? CfiCode { get; init; }

		/// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseSecurity"]/Member[@name="cancellation"]/*' />
		[DataMember(Name = "cancellation", EmitDefaultValue = false)]
		public string? Cancellation { get; init; }

		/// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseSecurity"]/Member[@name="minstep"]/*' />
		[DataMember(Name = "minStep", EmitDefaultValue = false)]
		public decimal? Minstep { get; init; }

		/// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseSecurity"]/Member[@name="roundToHeavy"]/*' />
		[DataMember(Name = "roundTo", EmitDefaultValue = false)]
		public int? RoundToHeavy { get; init; }

		/// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseSecurity"]/Member[@name="rating"]/*' />
		[DataMember(Name = "rating", EmitDefaultValue = false)]
		public decimal? Rating { get; init; }

		/// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseSecurity"]/Member[@name="marginbuy"]/*' />
		[DataMember(Name = "marginBuy", EmitDefaultValue = false)]
		public decimal? Marginbuy { get; init; }

		/// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseSecurity"]/Member[@name="marginsell"]/*' />
		[DataMember(Name = "marginSell", EmitDefaultValue = false)]
		public decimal? Marginsell { get; init; }

		/// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseSecurity"]/Member[@name="marginrate"]/*' />
		[DataMember(Name = "marginRate", EmitDefaultValue = false)]
		public decimal? Marginrate { get; init; }

		/// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseSecurity"]/Member[@name="pricestep"]/*' />
		[DataMember(Name = "priceStep", EmitDefaultValue = false)]
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
		[DataMember(Name = "primaryBoard", EmitDefaultValue = false)]
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

		/// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseSecurity"]/Member[@name="initialMarginLowRiskLongHeavy"]/*' />
		[DataMember(Name = "initialMarginLowRiskLong", EmitDefaultValue = false)]
		public decimal? InitialMarginLowRiskLong { get; init; }

		/// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseSecurity"]/Member[@name="initialMarginLowRiskShortHeavy"]/*' />
		[DataMember(Name = "initialMarginLowRiskShort", EmitDefaultValue = false)]
		public decimal? InitialMarginLowRiskShort { get; init; }

		/// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseSecurity"]/Member[@name="initialMarginStandardRiskLongHeavy"]/*' />
		[DataMember(Name = "initialMarginStandardRiskLong", EmitDefaultValue = false)]
		public decimal? InitialMarginStandardRiskLong { get; init; }

		/// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseSecurity"]/Member[@name="initialMarginStandardRiskShortHeavy"]/*' />
		[DataMember(Name = "initialMarginStandardRiskShort", EmitDefaultValue = false)]
		public decimal? InitialMarginStandardRiskShort { get; init; }

		/// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseSecurity"]/Member[@name="initialMarginHighRiskLongHeavy"]/*' />
		[DataMember(Name = "initialMarginHighRiskLong", EmitDefaultValue = false)]
		public decimal? InitialMarginHighRiskLong { get; init; }

		/// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseSecurity"]/Member[@name="initialMarginHighRiskShortHeavy"]/*' />
		[DataMember(Name = "initialMarginHighRiskShort", EmitDefaultValue = false)]
		public decimal? InitialMarginHighRiskShort { get; init; }

		/// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseSecurity"]/Member[@name="initialMarginSpecialRiskLongHeavy"]/*' />
		[DataMember(Name = "initialMarginSpecialRiskLong", EmitDefaultValue = false)]
		public decimal? InitialMarginSpecialRiskLong { get; init; }

		/// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseSecurity"]/Member[@name="initialMarginSpecialRiskShortHeavy"]/*' />
		[DataMember(Name = "initialMarginSpecialRiskShort", EmitDefaultValue = false)]
		public decimal? InitialMarginSpecialRiskShort { get; init; }

		public override string ToString()
		{
			var sb = new StringBuilder();
			sb.Append("class SecurityHeavy {").Append(Environment.NewLine);
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
			sb.Append("  RoundToHeavy: ").Append(RoundToHeavy).Append(Environment.NewLine);
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
			sb.Append("  InitialMarginLowRiskLong: ").Append(InitialMarginLowRiskLong).Append(Environment.NewLine);
			sb.Append("  InitialMarginLowRiskShort: ").Append(InitialMarginLowRiskShort).Append(Environment.NewLine);
			sb.Append("  InitialMarginStandardRiskLong: ").Append(InitialMarginStandardRiskLong).Append(Environment.NewLine);
			sb.Append("  InitialMarginStandardRiskShort: ").Append(InitialMarginStandardRiskShort).Append(Environment.NewLine);
			sb.Append("  InitialMarginHighRiskLong: ").Append(InitialMarginHighRiskLong).Append(Environment.NewLine);
			sb.Append("  InitialMarginHighRiskShort: ").Append(InitialMarginHighRiskShort).Append(Environment.NewLine);
			sb.Append("  InitialMarginSpecialRiskLong: ").Append(InitialMarginSpecialRiskLong).Append(Environment.NewLine);
			sb.Append("  InitialMarginSpecialRiskShort: ").Append(InitialMarginSpecialRiskShort).Append(Environment.NewLine);
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
			hash.Add(RoundToHeavy);
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
			hash.Add(InitialMarginLowRiskLong);
			hash.Add(InitialMarginLowRiskShort);
			hash.Add(InitialMarginStandardRiskLong);
			hash.Add(InitialMarginStandardRiskShort);
			hash.Add(InitialMarginHighRiskLong);
			hash.Add(InitialMarginHighRiskShort);
			hash.Add(InitialMarginSpecialRiskLong);
			hash.Add(InitialMarginSpecialRiskShort);
			return hash.ToHashCode();
		}

		private static bool EqualsHelper(SecurityHeavy? first, SecurityHeavy? second) =>
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
			first?.Minstep == second?.RoundToHeavy &&
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
			first?.OptionSide == second?.OptionSide &&
			first?.InitialMarginLowRiskLong == second?.InitialMarginLowRiskLong &&
			first?.InitialMarginLowRiskShort == second?.InitialMarginLowRiskShort &&
			first?.InitialMarginStandardRiskLong == second?.InitialMarginStandardRiskLong &&
			first?.InitialMarginStandardRiskShort == second?.InitialMarginStandardRiskShort &&
			first?.InitialMarginHighRiskLong == second?.InitialMarginStandardRiskLong &&
			first?.InitialMarginHighRiskShort == second?.InitialMarginHighRiskShort &&
			first?.InitialMarginSpecialRiskLong == second?.InitialMarginSpecialRiskLong &&
			first?.InitialMarginSpecialRiskShort == second?.InitialMarginSpecialRiskShort;

		public bool Equals(SecurityHeavy? other)
		{
			if (this == (object?)other)
				return true;

			if (other is null)
				return false;

			return GetType() == other.GetType() && EqualsHelper(this, other);
		}

		public override bool Equals(object? obj) => Equals(obj as SecurityHeavy);

		private static bool Equals(SecurityHeavy? first, SecurityHeavy? second) =>
			first?.Equals(second) ?? first == (object?)second;

		public static bool operator ==(SecurityHeavy? first, SecurityHeavy? second) => Equals(first, second);

		public static bool operator !=(SecurityHeavy? first, SecurityHeavy? second) => !Equals(first, second);

		IEnumerable<ValidationResult> IValidatableObject.Validate(ValidationContext validationContext)
		{
			yield break;
		}
	}
}
