﻿using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Alor.OpenAPI.Enums;
using SpanJson;

namespace Alor.OpenAPI.Models.Heavy
{
    [DataContract]
    public sealed class SymbolHeavy : IEquatable<SymbolHeavy>, IValidatableObject
    {
        public SymbolHeavy() { }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseSymbol"]/Member[@name="responseSymbol"]/*' />
        public SymbolHeavy(string? symbol = default, Exchange exchange = default,
            string? description = default, string? currencyHeavy = default, decimal? ask = default, decimal? bid = default,
            int? askVol = default, int? bidVol = default, long? obMsTimestamp = default,
            decimal? prevClosePrice = default, decimal? lastPrice = default,
            long? lastPriceTimestamp = default, decimal? change = default,
            decimal? changePercent = default, decimal? highPrice = default,
            decimal? lowPrice = default, decimal? accruedInterest = default,
            decimal? volume = default,
            long? openInterest = default, decimal? openPrice = default,
            decimal? yield = default, decimal? lotsize = default, decimal? lotvalue = default,
            decimal? facevalue = default, string? type = default,
            int? totalAskVol = default, int? totalBidVol = default)
        {
            Symbol = symbol;
            Exchange = exchange;
            Description = description;
            Currency = currencyHeavy;
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

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseSymbol"]/Member[@name="symbol"]/*' />
        [DataMember(Name = "symbol", EmitDefaultValue = false)]
        public string? Symbol { get; init; }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseSymbol"]/Member[@name="exchange"]/*' />
        [DataMember(Name = "exchange", EmitDefaultValue = false)]
        public Exchange Exchange { get; init; }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseSymbol"]/Member[@name="description"]/*' />
        [DataMember(Name = "description", EmitDefaultValue = false)]
        public string? Description { get; init; }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseSymbol"]/Member[@name="currencyHeavy"]/*' />
        [DataMember(Name = "currency", EmitDefaultValue = false)]
        public string? Currency { get; init; }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseSymbol"]/Member[@name="ask"]/*' />
        [DataMember(Name = "ask", EmitDefaultValue = false)]
        public decimal? Ask { get; init; }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseSymbol"]/Member[@name="bid"]/*' />
        [DataMember(Name = "bid", EmitDefaultValue = false)]
        public decimal? Bid { get; init; }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseSymbol"]/Member[@name="askVol"]/*' />
        [DataMember(Name = "askVol", EmitDefaultValue = false)]
        public int? AskVol { get; init; }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseSymbol"]/Member[@name="bidVol"]/*' />
        [DataMember(Name = "bidVol", EmitDefaultValue = false)]
        public int? BidVol { get; init; }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseSymbol"]/Member[@name="obMsTimestamp"]/*' />
        [DataMember(Name = "obMsTimestamp", EmitDefaultValue = false)]
        public long? ObMsTimestamp { get; init; }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseSymbol"]/Member[@name="prevClosePrice"]/*' />
        [DataMember(Name = "prevClosePrice", EmitDefaultValue = false)]
        public decimal? PrevClosePrice { get; init; }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseSymbol"]/Member[@name="lastPrice"]/*' />
        [DataMember(Name = "lastPrice", EmitDefaultValue = false)]
        public decimal? LastPrice { get; init; }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseSymbol"]/Member[@name="lastPriceTimestamp"]/*' />
        [DataMember(Name = "lastPriceTimestamp", EmitDefaultValue = false)]
        public long? LastPriceTimestamp { get; init; }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseSymbol"]/Member[@name="change"]/*' />
        [DataMember(Name = "change", EmitDefaultValue = false)]
        public decimal? Change { get; init; }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseSymbol"]/Member[@name="changePercent"]/*' />
        [DataMember(Name = "change_percent", EmitDefaultValue = false)]
        public decimal? ChangePercent { get; init; }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseSymbol"]/Member[@name="highPrice"]/*' />
        [DataMember(Name = "highPrice", EmitDefaultValue = false)]
        public decimal? HighPrice { get; init; }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseSymbol"]/Member[@name="lowPrice"]/*' />
        [DataMember(Name = "lowPrice", EmitDefaultValue = false)]
        public decimal? LowPrice { get; init; }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseSymbol"]/Member[@name="accruedInt"]/*' />
        [DataMember(Name = "accruedIntetest", EmitDefaultValue = false)]
        public decimal? AccruedInterest { get; init; }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseSymbol"]/Member[@name="volume"]/*' />
        [DataMember(Name = "volume", EmitDefaultValue = false)]
        public decimal? Volume { get; init; }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseSymbol"]/Member[@name="openInterest"]/*' />
        [DataMember(Name = "openInterest", EmitDefaultValue = false)]
        public long? OpenInterest { get; init; }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseSymbol"]/Member[@name="openPrice"]/*' />
        [DataMember(Name = "openPrice", EmitDefaultValue = false)]
        public decimal? OpenPrice { get; init; }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseSymbol"]/Member[@name="yield"]/*' />
        [DataMember(Name = "yield", EmitDefaultValue = false)]
        public decimal? Yield { get; init; }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseSymbol"]/Member[@name="lotsize"]/*' />
        [DataMember(Name = "lotSize", EmitDefaultValue = false)]
        public decimal? Lotsize { get; init; }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseSymbol"]/Member[@name="lotvalue"]/*' />
        [DataMember(Name = "lotValue", EmitDefaultValue = false)]
        public decimal? Lotvalue { get; init; }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseSymbol"]/Member[@name="facevalue"]/*' />
        [DataMember(Name = "faceValue", EmitDefaultValue = false)]
        public decimal? Facevalue { get; init; }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseSymbol"]/Member[@name="type"]/*' />
        [DataMember(Name = "type", EmitDefaultValue = false)]
        public string? Type { get; init; }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseSymbol"]/Member[@name="totalBidVol"]/*' />
        [DataMember(Name = "totalBidVol", EmitDefaultValue = false)]
        public int? TotalBidVol { get; init; }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseSymbol"]/Member[@name="totalAskVol"]/*' />
        [DataMember(Name = "totalAskVol", EmitDefaultValue = false)]
        public int? TotalAskVol { get; init; }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class SymbolHeavy {").Append(Environment.NewLine);
            sb.Append("  Symbol: ").Append(Symbol).Append(Environment.NewLine);
            sb.Append("  Exchange: ").Append(Exchange).Append(Environment.NewLine);
            sb.Append("  Description: ").Append(Description).Append(Environment.NewLine);
            sb.Append("  Currency: ").Append(Currency).Append(Environment.NewLine);
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
            hash.Add(Currency);
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

        private static bool EqualsHelper(SymbolHeavy? first, SymbolHeavy? second) =>
            first?.Symbol == second?.Symbol &&
            first?.Exchange == second?.Exchange &&
            first?.Description == second?.Description &&
            first?.Currency == second?.Currency &&
            first?.Ask == second?.Ask &&
            first?.Bid == second?.Bid &&
            first?.AskVol == second?.AskVol &&
            first?.BidVol == second?.BidVol &&
            first?.ObMsTimestamp == second?.ObMsTimestamp &&
            first?.PrevClosePrice == second?.PrevClosePrice &&
            first?.LastPrice == second?.LastPrice &&
            first?.LastPriceTimestamp == second?.LastPriceTimestamp &&
            first?.Change == second?.Change &&
            first?.ChangePercent == second?.ChangePercent &&
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


        public bool Equals(SymbolHeavy? other)
        {
            if (this == (object?)other)
                return true;

            if ((object?)other == null)
                return false;

            return GetType() == other.GetType() && EqualsHelper(this, other);
        }

        public override bool Equals(object? obj) => Equals(obj as SymbolHeavy);

        private static bool Equals(SymbolHeavy? first, SymbolHeavy? second) =>
            first?.Equals(second) ?? first == (object?)second;

        public static bool operator ==(SymbolHeavy? first, SymbolHeavy? second) => Equals(first, second);

        public static bool operator !=(SymbolHeavy? first, SymbolHeavy? second) => !Equals(first, second);

        IEnumerable<ValidationResult> IValidatableObject.Validate(ValidationContext validationContext)
        {
            yield break;
        }
    }
}
