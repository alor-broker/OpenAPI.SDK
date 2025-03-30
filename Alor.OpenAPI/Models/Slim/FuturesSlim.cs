using Alor.OpenAPI.Enums;
using SpanJson;
using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text;

namespace Alor.OpenAPI.Models.Slim
{
    [DataContract]
    public sealed class FuturesSlim : IEquatable<FuturesSlim>, IValidatableObject
    {
        public FuturesSlim() { }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseFutures"]/Member[@name="responseFutures"]/*' />
        [JsonConstructor]
        public FuturesSlim(string? symbol = default, Exchange exchange = default, string? description = default,
            decimal? lastPrice = default, long? lastPriceTimestamp = default,
            decimal? highPrice = default, decimal? lowPrice = default, decimal? accruedInterest = default,
            decimal? volume = default,
            long? openInterest = default, decimal? ask = default, decimal? bid = default, decimal? askVol = default,
            decimal? bidVol = default, long? obMsTimestamp = default, decimal? openPrice = default,
            decimal? yield = default,
            decimal? lotsize = default, decimal? lotvalue = default, decimal? facevalue = default,
            string? type = default,
            decimal? totalBidVol = default, decimal? totalAskVol = default)
        {
            Symbol = symbol;
            Exchange = exchange;
            Description = description;
            LastPrice = lastPrice;
            LastPriceTimestamp = lastPriceTimestamp;
            ObMsTimestamp = obMsTimestamp;
            HighPrice = highPrice;
            LowPrice = lowPrice;
            AccruedInterest = accruedInterest;
            Volume = volume;
            OpenInterest = openInterest;
            Ask = ask;
            Bid = bid;
            AskVol = askVol;
            BidVol = bidVol;
            OpenPrice = openPrice;
            Yield = yield;
            Lotsize = lotsize;
            Lotvalue = lotvalue;
            Facevalue = facevalue;
            Type = type;
            TotalBidVol = totalBidVol;
            TotalAskVol = totalAskVol;
        }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseFutures"]/Member[@name="symbol"]/*' />
        [DataMember(Name = "sym", EmitDefaultValue = false)]
        public string? Symbol { get; init; }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseFutures"]/Member[@name="exchange"]/*' />
        [DataMember(Name = "ex", EmitDefaultValue = false)]
        public Exchange Exchange { get; init; }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseFutures"]/Member[@name="description"]/*' />
        [DataMember(Name = "desc", EmitDefaultValue = false)]
        public string? Description { get; init; }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseFutures"]/Member[@name="lastPrice"]/*' />
        [DataMember(Name = "c", EmitDefaultValue = false)]
        public decimal? LastPrice { get; init; }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseFutures"]/Member[@name="lastPriceTimestamp"]/*' />
        [DataMember(Name = "tst", EmitDefaultValue = false)]
        public long? LastPriceTimestamp { get; init; }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseFutures"]/Member[@name="highPrice"]/*' />
        [DataMember(Name = "h", EmitDefaultValue = false)]
        public decimal? HighPrice { get; init; }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseFutures"]/Member[@name="lowPrice"]/*' />
        [DataMember(Name = "l", EmitDefaultValue = false)]
        public decimal? LowPrice { get; init; }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseFutures"]/Member[@name="accruedInterest"]/*' />
        [DataMember(Name = "acci", EmitDefaultValue = false)]
        public decimal? AccruedInterest { get; init; }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseFutures"]/Member[@name="volume"]/*' />
        [DataMember(Name = "v", EmitDefaultValue = false)]
        public decimal? Volume { get; init; }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseFutures"]/Member[@name="openInterest"]/*' />
        [DataMember(Name = "oi", EmitDefaultValue = false)]
        public long? OpenInterest { get; init; }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseFutures"]/Member[@name="ask"]/*' />
        [DataMember(Name = "a", EmitDefaultValue = false)]
        public decimal? Ask { get; init; }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseFutures"]/Member[@name="bid"]/*' />
        [DataMember(Name = "b", EmitDefaultValue = false)]
        public decimal? Bid { get; init; }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseFutures"]/Member[@name="askVol"]/*' />
        [DataMember(Name = "av", EmitDefaultValue = false)]
        public decimal? AskVol { get; init; }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseFutures"]/Member[@name="bidVol"]/*' />
        [DataMember(Name = "bv", EmitDefaultValue = false)]
        public decimal? BidVol { get; init; }
        
        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseFutures"]/Member[@name="obMsTimestamp"]/*' />
        [DataMember(Name = "tso", EmitDefaultValue = false)]
        public long? ObMsTimestamp { get; init; }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseFutures"]/Member[@name="openPrice"]/*' />
        [DataMember(Name = "o", EmitDefaultValue = false)]
        public decimal? OpenPrice { get; init; }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseFutures"]/Member[@name="yield"]/*' />
        [DataMember(Name = "y", EmitDefaultValue = false)]
        public decimal? Yield { get; init; }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseFutures"]/Member[@name="lotsize"]/*' />
        [DataMember(Name = "lot", EmitDefaultValue = false)]
        public decimal? Lotsize { get; init; }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseFutures"]/Member[@name="lotvalue"]/*' />
        [DataMember(Name = "lotv", EmitDefaultValue = false)]
        public decimal? Lotvalue { get; init; }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseFutures"]/Member[@name="facevalue"]/*' />
        [DataMember(Name = "fv", EmitDefaultValue = false)]
        public decimal? Facevalue { get; init; }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseFutures"]/Member[@name="type"]/*' />
        [DataMember(Name = "t", EmitDefaultValue = false)]
        public string? Type { get; init; }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseFutures"]/Member[@name="totalBidVol"]/*' />
        [DataMember(Name = "tbv", EmitDefaultValue = false)]
        public decimal? TotalBidVol { get; init; }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseFutures"]/Member[@name="totalAskVol"]/*' />
        [DataMember(Name = "tav", EmitDefaultValue = false)]
        public decimal? TotalAskVol { get; init; }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class FuturesSlim {").Append(Environment.NewLine);
            sb.Append("  Symbol: ").Append(Symbol).Append(Environment.NewLine);
            sb.Append("  Exchange: ").Append(Exchange).Append(Environment.NewLine);
            sb.Append("  Description: ").Append(Description).Append(Environment.NewLine);
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
            return hash.ToHashCode();
        }

        private static bool EqualsHelper(FuturesSlim? first, FuturesSlim? second) =>
            first?.Symbol == second?.Symbol &&
            first?.Exchange == second?.Exchange &&
            first?.Description == second?.Description &&
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
            first?.TotalAskVol == second?.TotalAskVol;

        public bool Equals(FuturesSlim? other)
        {
            if (this == (object?)other)
                return true;

            if ((object?)other == null)
                return false;

            return GetType() == other.GetType() && EqualsHelper(this, other);
        }

        public override bool Equals(object? obj) => Equals(obj as FuturesSlim);

        private static bool Equals(FuturesSlim? first, FuturesSlim? second) =>
            first?.Equals(second) ?? first == (object?)second;

        public static bool operator ==(FuturesSlim? first, FuturesSlim? second) => Equals(first, second);

        public static bool operator !=(FuturesSlim? first, FuturesSlim? second) => !Equals(first, second);

        IEnumerable<ValidationResult> IValidatableObject.Validate(ValidationContext validationContext)
        {
            yield break;
        }
    }
}
