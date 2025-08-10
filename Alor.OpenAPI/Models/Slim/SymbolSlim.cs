﻿using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text;
using Alor.OpenAPI.Enums;
using SpanJson;

namespace Alor.OpenAPI.Models.Slim
{
    [DataContract]
    public sealed class SymbolSlim : IEquatable<SymbolSlim>, IValidatableObject
    {
        public SymbolSlim() { }

        /// <include file='../../XmlDocs/CoreModels.xml'
        ///          path='Docs/Members[@name="responseSymbol"]
        ///               /Member[@name="responseSymbol"]
        ///               /param[
        ///                      @name="symbol" or @name="exchange" or @name="description" or @name="ask" or @name="bid"
        ///                      or @name="askVol" or @name="bidVol" or @name="obMsTimestamp" or @name="lastPrice"
        ///                      or @name="lastPriceTimestamp" or @name="highPrice" or @name="lowPrice" or @name="accruedInterest"
        ///                      or @name="volume" or @name="openInterest" or @name="openPrice" or @name="yield" or @name="lotsize" 
        ///                      or @name="lotvalue" or @name="facevalue" or @name="type" or @name="totalAskVol" or @name="totalBidVol" 
        ///                     ]'/>
        public SymbolSlim(string? symbol = null, Exchange? exchange = null, string? description = null,
            decimal? ask = null, decimal? bid = null, int? askVol = null, int? bidVol = null,
            long? obMsTimestamp = null, decimal? lastPrice = null, long? lastPriceTimestamp = null,
            decimal? highPrice = null, decimal? lowPrice = null, decimal? accruedInterest = null,
            decimal? volume = null, long? openInterest = null, decimal? openPrice = null, decimal? yield = null,
            decimal? lotsize = null, decimal? lotvalue = null, decimal? facevalue = null, string? type = null,
            int? totalAskVol = null, int? totalBidVol = null)
        {
            Symbol = symbol;
            Exchange = exchange;
            Description = description;
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
        }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseSymbol"]/Member[@name="symbol"]/*' />
        [DataMember(Name = "sym", EmitDefaultValue = false)]
        public string? Symbol { get; init; }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseSymbol"]/Member[@name="exchange"]/*' />
        [DataMember(Name = "ex", EmitDefaultValue = false)]
        public Exchange? Exchange { get; init; }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseSymbol"]/Member[@name="description"]/*' />
        [DataMember(Name = "desc", EmitDefaultValue = false)]
        public string? Description { get; init; }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseSymbol"]/Member[@name="ask"]/*' />
        [DataMember(Name = "ask", EmitDefaultValue = false)]
        public decimal? Ask { get; init; }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseSymbol"]/Member[@name="bid"]/*' />
        [DataMember(Name = "bid", EmitDefaultValue = false)]
        public decimal? Bid { get; init; }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseSymbol"]/Member[@name="askVol"]/*' />
        [DataMember(Name = "av", EmitDefaultValue = false)]
        public int? AskVol { get; init; }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseSymbol"]/Member[@name="bidVol"]/*' />
        [DataMember(Name = "bv", EmitDefaultValue = false)]
        public int? BidVol { get; init; }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseSymbol"]/Member[@name="obMsTimestamp"]/*' />
        [DataMember(Name = "tso", EmitDefaultValue = false)]
        public long? ObMsTimestamp { get; init; }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseSymbol"]/Member[@name="prevClosePrice"]/*' />
        [DataMember(Name = "c", EmitDefaultValue = false)]
        public decimal? LastPrice { get; init; }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseSymbol"]/Member[@name="lastPriceTimestamp"]/*' />
        [DataMember(Name = "tst", EmitDefaultValue = false)]
        public long? LastPriceTimestamp { get; init; }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseSymbol"]/Member[@name="highPrice"]/*' />
        [DataMember(Name = "h", EmitDefaultValue = false)]
        public decimal? HighPrice { get; init; }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseSymbol"]/Member[@name="lowPrice"]/*' />
        [DataMember(Name = "le", EmitDefaultValue = false)]
        public decimal? LowPrice { get; init; }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseSymbol"]/Member[@name="accruedInt"]/*' />
        [DataMember(Name = "acci", EmitDefaultValue = false)]
        public decimal? AccruedInterest { get; init; }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseSymbol"]/Member[@name="volume"]/*' />
        [DataMember(Name = "v", EmitDefaultValue = false)]
        public decimal? Volume { get; init; }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseSymbol"]/Member[@name="openInterest"]/*' />
        [DataMember(Name = "oi", EmitDefaultValue = false)]
        public long? OpenInterest { get; init; }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseSymbol"]/Member[@name="openPrice"]/*' />
        [DataMember(Name = "o", EmitDefaultValue = false)]
        public decimal? OpenPrice { get; init; }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseSymbol"]/Member[@name="yield"]/*' />
        [DataMember(Name = "y", EmitDefaultValue = false)]
        public decimal? Yield { get; init; }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseSymbol"]/Member[@name="lotsize"]/*' />
        [DataMember(Name = "lot", EmitDefaultValue = false)]
        public decimal? Lotsize { get; init; }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseSymbol"]/Member[@name="lotvalue"]/*' />
        [DataMember(Name = "lotv", EmitDefaultValue = false)]
        public decimal? Lotvalue { get; init; }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseSymbol"]/Member[@name="facevalue"]/*' />
        [DataMember(Name = "fv", EmitDefaultValue = false)]
        public decimal? Facevalue { get; init; }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseSymbol"]/Member[@name="type"]/*' />
        [DataMember(Name = "t", EmitDefaultValue = false)]
        public string? Type { get; init; }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseSymbol"]/Member[@name="totalBidVol"]/*' />
        [DataMember(Name = "tbv", EmitDefaultValue = false)]
        public int? TotalBidVol { get; init; }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseSymbol"]/Member[@name="totalAskVol"]/*' />
        [DataMember(Name = "tav", EmitDefaultValue = false)]
        public int? TotalAskVol { get; init; }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class SymbolSlim {").Append(Environment.NewLine);
            sb.Append("class SymbolSimple {").Append(Environment.NewLine);
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

        private static bool EqualsHelper(SymbolSlim? first, SymbolSlim? second) =>
            first?.Symbol == second?.Symbol &&
            first?.Exchange == second?.Exchange &&
            first?.Description == second?.Description &&
            first?.Ask == second?.Ask &&
            first?.Bid == second?.Bid &&
            first?.AskVol == second?.AskVol &&
            first?.BidVol == second?.BidVol &&
            first?.ObMsTimestamp == second?.ObMsTimestamp &&
            first?.LastPrice == second?.LastPrice &&
            first?.LastPriceTimestamp == second?.LastPriceTimestamp &&
            first?.HighPrice == second?.HighPrice &&
            first?.LowPrice == second?.LowPrice &&
            first?.AccruedInterest == second?.AccruedInterest &&
            first?.Volume == second?.Volume &&
            first?.OpenInterest == second?.OpenInterest &&
            first?.OpenPrice == second?.OpenPrice &&
            first?.Yield == second?.Yield &&
            first?.Lotsize == second?.Lotsize &&
            first?.Lotvalue == second?.Lotvalue &&
            first?.Facevalue == second?.Facevalue &&
            first?.Type == second?.Type &&
            first?.TotalAskVol == second?.TotalAskVol &&
            first?.TotalBidVol == second?.TotalBidVol;


        public bool Equals(SymbolSlim? other)
        {
            if (this == (object?)other)
                return true;

            if (other is null)
                return false;

            return GetType() == other.GetType() && EqualsHelper(this, other);
        }

        public override bool Equals(object? obj) => Equals(obj as SymbolSlim);

        private static bool Equals(SymbolSlim? first, SymbolSlim? second) =>
            first?.Equals(second) ?? first == (object?)second;

        public static bool operator ==(SymbolSlim? first, SymbolSlim? second) => Equals(first, second);

        public static bool operator !=(SymbolSlim? first, SymbolSlim? second) => !Equals(first, second);

        IEnumerable<ValidationResult> IValidatableObject.Validate(ValidationContext validationContext)
        {
            yield break;
        }
    }
}
