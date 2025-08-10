using Alor.OpenAPI.Enums;
using SpanJson;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text;

namespace Alor.OpenAPI.Models.Simple
{
    [DataContract]
    public sealed class FuturesSimple : IEquatable<FuturesSimple>, IValidatableObject
    {
        public FuturesSimple() { }

        /// <include file='../../XmlDocs/CoreModels.xml'
        ///          path='Docs/Members[@name="responseFutures"]
        ///               /Member[@name="responseFutures"]
        ///               /param[
        ///                      @name="symbol" or @name="exchange" or @name="description" or @name="prevClosePrice"
        ///                      or @name="lastPrice" or @name="lastPriceTimestamp" or @name="highPrice" or @name="lowPrice"
        ///                      or @name="accruedInterest" or @name="volume" or @name="openInterest" or @name="ask" or @name="bid"
        ///                      or @name="askVol" or @name="bidVol" or @name="obMsTimestamp" or @name="openPrice" or @name="yield"
        ///                      or @name="lotsize" or @name="lotvalue" or @name="facevalue" or @name="type" or @name="totalBidVol"
        ///                      or @name="totalAskVol" or @name="change" or @name="changePercent" 
        ///                     ]'/>
        public FuturesSimple(string? symbol = null, Exchange? exchange = null, string? description = null,
            decimal? prevClosePrice = null, decimal? lastPrice = null, long? lastPriceTimestamp = null,
            decimal? highPrice = null, decimal? lowPrice = null, decimal? accruedInterest = null,
            decimal? volume = null, long? openInterest = null, decimal? ask = null, decimal? bid = null,
            decimal? askVol = null, decimal? bidVol = null, long? obMsTimestamp = null, decimal? openPrice = null,
            decimal? yield = null, decimal? lotsize = null, decimal? lotvalue = null, decimal? facevalue = null,
            string? type = null, decimal? totalBidVol = null, decimal? totalAskVol = null,
            decimal? change = null, decimal? changePercent = null)
        {
            Symbol = symbol;
            Exchange = exchange;
            Description = description;
            PrevClosePrice = prevClosePrice;
            LastPrice = lastPrice;
            LastPriceTimestamp = lastPriceTimestamp;
            HighPrice = highPrice;
            LowPrice = lowPrice;
            AccruedInterest = accruedInterest;
            Volume = volume;
            OpenInterest = openInterest;
            Ask = ask;
            Bid = bid;
            AskVol = askVol;
            BidVol = bidVol;
            ObMsTimestamp = obMsTimestamp;
            OpenPrice = openPrice;
            Yield = yield;
            Lotsize = lotsize;
            Lotvalue = lotvalue;
            Facevalue = facevalue;
            Type = type;
            TotalBidVol = totalBidVol;
            TotalAskVol = totalAskVol;
            Change = change;
            ChangePercent = changePercent;
        }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseFutures"]/Member[@name="symbol"]/*' />
        [DataMember(Name = "symbol", EmitDefaultValue = false)]
        public string? Symbol { get; init; }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseFutures"]/Member[@name="exchange"]/*' />
        [DataMember(Name = "exchange", EmitDefaultValue = false)]
        public Exchange? Exchange { get; init; }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseFutures"]/Member[@name="description"]/*' />
        [DataMember(Name = "description", EmitDefaultValue = false)]
        public string? Description { get; init; }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseFutures"]/Member[@name="prevClosePrice"]/*' />
        [DataMember(Name = "prev_close_price", EmitDefaultValue = false)]
        public decimal? PrevClosePrice { get; init; }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseFutures"]/Member[@name="lastPrice"]/*' />
        [DataMember(Name = "last_price", EmitDefaultValue = false)]
        public decimal? LastPrice { get; init; }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseFutures"]/Member[@name="lastPriceTimestamp"]/*' />
        [DataMember(Name = "last_price_timestamp", EmitDefaultValue = false)]
        public long? LastPriceTimestamp { get; init; }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseFutures"]/Member[@name="highPrice"]/*' />
        [DataMember(Name = "high_price", EmitDefaultValue = false)]
        public decimal? HighPrice { get; init; }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseFutures"]/Member[@name="lowPrice"]/*' />
        [DataMember(Name = "low_price", EmitDefaultValue = false)]
        public decimal? LowPrice { get; init; }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseFutures"]/Member[@name="accruedInterest"]/*' />
        [DataMember(Name = "accruedInt", EmitDefaultValue = false)]
        public decimal? AccruedInterest { get; init; }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseFutures"]/Member[@name="volume"]/*' />
        [DataMember(Name = "volume", EmitDefaultValue = false)]
        public decimal? Volume { get; init; }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseFutures"]/Member[@name="openInterest"]/*' />
        [DataMember(Name = "open_interest", EmitDefaultValue = false)]
        public long? OpenInterest { get; init; }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseFutures"]/Member[@name="ask"]/*' />
        [DataMember(Name = "ask", EmitDefaultValue = false)]
        public decimal? Ask { get; init; }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseFutures"]/Member[@name="bid"]/*' />
        [DataMember(Name = "bid", EmitDefaultValue = false)]
        public decimal? Bid { get; init; }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseFutures"]/Member[@name="askVol"]/*' />
        [DataMember(Name = "ask_vol", EmitDefaultValue = false)]
        public decimal? AskVol { get; init; }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseFutures"]/Member[@name="bidVol"]/*' />
        [DataMember(Name = "bid_vol", EmitDefaultValue = false)]
        public decimal? BidVol { get; init; }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseFutures"]/Member[@name="obMsTimestamp"]/*' />
        [DataMember(Name = "ob_ms_timestamp", EmitDefaultValue = false)]
        public long? ObMsTimestamp { get; init; }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseFutures"]/Member[@name="openPrice"]/*' />
        [DataMember(Name = "open_price", EmitDefaultValue = false)]
        public decimal? OpenPrice { get; init; }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseFutures"]/Member[@name="yield"]/*' />
        [DataMember(Name = "yield", EmitDefaultValue = false)]
        public decimal? Yield { get; init; }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseFutures"]/Member[@name="lotsize"]/*' />
        [DataMember(Name = "lotsize", EmitDefaultValue = false)]
        public decimal? Lotsize { get; init; }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseFutures"]/Member[@name="lotvalue"]/*' />
        [DataMember(Name = "lotvalue", EmitDefaultValue = false)]
        public decimal? Lotvalue { get; init; }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseFutures"]/Member[@name="facevalue"]/*' />
        [DataMember(Name = "facevalue", EmitDefaultValue = false)]
        public decimal? Facevalue { get; init; }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseFutures"]/Member[@name="type"]/*' />
        [DataMember(Name = "type", EmitDefaultValue = false)]
        public string? Type { get; init; }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseFutures"]/Member[@name="totalBidVol"]/*' />
        [DataMember(Name = "total_bid_vol", EmitDefaultValue = false)]
        public decimal? TotalBidVol { get; init; }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseFutures"]/Member[@name="totalAskVol"]/*' />
        [DataMember(Name = "total_ask_vol", EmitDefaultValue = false)]
        public decimal? TotalAskVol { get; init; }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseFutures"]/Member[@name="change"]/*' />
        [DataMember(Name = "change", EmitDefaultValue = false)]
        public decimal? Change { get; init; }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseFutures"]/Member[@name="changePercent"]/*' />
        [DataMember(Name = "change_percent", EmitDefaultValue = false)]
        public decimal? ChangePercent { get; init; }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class FuturesSimple {").Append(Environment.NewLine);
            sb.Append("  Symbol: ").Append(Symbol).Append(Environment.NewLine);
            sb.Append("  Exchange: ").Append(Exchange).Append(Environment.NewLine);
            sb.Append("  Description: ").Append(Description).Append(Environment.NewLine);
            sb.Append("  PrevClosePrice: ").Append(PrevClosePrice).Append(Environment.NewLine);
            sb.Append("  LastPrice: ").Append(LastPrice).Append(Environment.NewLine);
            sb.Append("  LastPriceTimestamp: ").Append(LastPriceTimestamp).Append(Environment.NewLine);
            sb.Append("  HighPrice: ").Append(HighPrice).Append(Environment.NewLine);
            sb.Append("  LowPrice: ").Append(LowPrice).Append(Environment.NewLine);
            sb.Append("  AccruedInterest: ").Append(AccruedInterest).Append(Environment.NewLine);
            sb.Append("  Volume: ").Append(Volume).Append(Environment.NewLine);
            sb.Append("  OpenInterest: ").Append(OpenInterest).Append(Environment.NewLine);
            sb.Append("  Ask: ").Append(Ask).Append(Environment.NewLine);
            sb.Append("  Bid: ").Append(Bid).Append(Environment.NewLine);
            sb.Append("  AskVol: ").Append(AskVol).Append(Environment.NewLine);
            sb.Append("  BidVol: ").Append(BidVol).Append(Environment.NewLine);
            sb.Append("  ObMsTimestamp: ").Append(ObMsTimestamp).Append(Environment.NewLine);
            sb.Append("  OpenPrice: ").Append(OpenPrice).Append(Environment.NewLine);
            sb.Append("  Yield: ").Append(Yield).Append(Environment.NewLine);
            sb.Append("  Lotsize: ").Append(Lotsize).Append(Environment.NewLine);
            sb.Append("  Lotvalue: ").Append(Lotvalue).Append(Environment.NewLine);
            sb.Append("  Facevalue: ").Append(Facevalue).Append(Environment.NewLine);
            sb.Append("  Type: ").Append(Type).Append(Environment.NewLine);
            sb.Append("  TotalBidVol: ").Append(TotalBidVol).Append(Environment.NewLine);
            sb.Append("  TotalAskVol: ").Append(TotalAskVol).Append(Environment.NewLine);
            sb.Append("  Change: ").Append(Change).Append(Environment.NewLine);
            sb.Append("  ChangePercent: ").Append(ChangePercent).Append(Environment.NewLine);
            sb.Append('}').Append(Environment.NewLine);
            return sb.ToString();
        }

        public string ToJson() => Encoding.UTF8.GetString(JsonSerializer.Generic.Utf8.Serialize(this));

        public override int GetHashCode()
        {
            var hash = new HashCode();
            hash.Add(Symbol);
            hash.Add(Exchange);
            hash.Add(Description);
            hash.Add(PrevClosePrice);
            hash.Add(LastPrice);
            hash.Add(LastPriceTimestamp);
            hash.Add(HighPrice);
            hash.Add(LowPrice);
            hash.Add(AccruedInterest);
            hash.Add(Volume);
            hash.Add(OpenInterest);
            hash.Add(Ask);
            hash.Add(Bid);
            hash.Add(AskVol);
            hash.Add(BidVol);
            hash.Add(ObMsTimestamp);
            hash.Add(OpenPrice);
            hash.Add(Yield);
            hash.Add(Lotsize);
            hash.Add(Lotvalue);
            hash.Add(Facevalue);
            hash.Add(Type);
            hash.Add(TotalBidVol);
            hash.Add(TotalAskVol);
            hash.Add(Change);
            hash.Add(ChangePercent);
            return hash.ToHashCode();
        }

        private static bool EqualsHelper(FuturesSimple? first, FuturesSimple? second) =>
            first?.Symbol == second?.Symbol &&
            first?.Exchange == second?.Exchange &&
            first?.Description == second?.Description &&
            first?.PrevClosePrice == second?.PrevClosePrice &&
            first?.LastPrice == second?.LastPrice &&
            first?.LastPriceTimestamp == second?.LastPriceTimestamp &&
            first?.HighPrice == second?.HighPrice &&
            first?.LowPrice == second?.LowPrice &&
            first?.AccruedInterest == second?.AccruedInterest &&
            first?.Volume == second?.Volume &&
            first?.OpenInterest == second?.OpenInterest &&
            first?.Ask == second?.Ask &&
            first?.Bid == second?.Bid &&
            first?.AskVol == second?.AskVol &&
            first?.BidVol == second?.BidVol &&
            first?.ObMsTimestamp == second?.ObMsTimestamp &&
            first?.OpenPrice == second?.OpenPrice &&
            first?.Yield == second?.Yield &&
            first?.Lotsize == second?.Lotsize &&
            first?.Lotvalue == second?.Lotvalue &&
            first?.Facevalue == second?.Facevalue &&
            first?.Type == second?.Type &&
            first?.TotalBidVol == second?.TotalBidVol &&
            first?.TotalAskVol == second?.TotalAskVol &&
            first?.Change == second?.Change &&
            first?.ChangePercent == second?.ChangePercent;
        
        public bool Equals(FuturesSimple? other)
        {
            if (this == (object?)other)
                return true;

            if (other is null)
                return false;

            return GetType() == other.GetType() && EqualsHelper(this, other);
        }

        public override bool Equals(object? obj) => Equals(obj as FuturesSimple);

        private static bool Equals(FuturesSimple? first, FuturesSimple? second) =>
            first?.Equals(second) ?? first == (object?)second;

        public static bool operator ==(FuturesSimple? first, FuturesSimple? second) => Equals(first, second);

        public static bool operator !=(FuturesSimple? first, FuturesSimple? second) => !Equals(first, second);

        IEnumerable<ValidationResult> IValidatableObject.Validate(ValidationContext validationContext)
        {
            yield break;
        }
    }
}
