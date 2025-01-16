using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text;
using Alor.OpenAPI.Enums;
using SpanJson;

namespace Alor.OpenAPI.Models.Simple
{
    [DataContract]
    public sealed class SymbolSimple : IEquatable<SymbolSimple>, IValidatableObject
    {
        public SymbolSimple() { }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseSymbol"]/Member[@name="responseSymbol"]/*' />
        public SymbolSimple(string? symbol = default, Exchange exchange = default,
            string? description = default, decimal? ask = default, decimal? bid = default,
            int? askVol = default, int? bidVol = default, long? obMsTimestamp = default,
            decimal? prevClosePrice = default, decimal? lastPrice = default,
            long? lastPriceTimestamp = default, decimal? change = default,
            decimal? changePercent = default, decimal? highPrice = default,
            decimal? lowPrice = default, decimal? accruedInterest = default,
            decimal? volume = default,
            long? openInterest = default, decimal? openPrice = default,
            int? yield = default, decimal? lotsize = default, decimal? lotvalue = default,
            decimal? facevalue = default, string? type = default,
            int? totalAskVol = default, int? totalBidVol = default)
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

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseSymbol"]/Member[@name="symbol"]/*' />
        [DataMember(Name = "symbol", EmitDefaultValue = false)]
        public string? Symbol { get; private set; }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseSymbol"]/Member[@name="exchange"]/*' />
        [DataMember(Name = "exchange", EmitDefaultValue = false)]
        public Exchange Exchange { get; private set; }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseSymbol"]/Member[@name="description"]/*' />
        [DataMember(Name = "description", EmitDefaultValue = false)]
        public string? Description { get; set; }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseSymbol"]/Member[@name="ask"]/*' />
        [DataMember(Name = "ask", EmitDefaultValue = false)]
        public decimal? Ask { get; set; }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseSymbol"]/Member[@name="bid"]/*' />
        [DataMember(Name = "bid", EmitDefaultValue = false)]
        public decimal? Bid { get; set; }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseSymbol"]/Member[@name="askVol"]/*' />
        [DataMember(Name = "ask_vol", EmitDefaultValue = false)]
        public int? AskVol { get; set; }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseSymbol"]/Member[@name="bidVol"]/*' />
        [DataMember(Name = "bid_vol", EmitDefaultValue = false)]
        public int? BidVol { get; set; }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseSymbol"]/Member[@name="obMsTimestamp"]/*' />
        [DataMember(Name = "ob_ms_timestamp", EmitDefaultValue = false)]
        public long? ObMsTimestamp { get; set; }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseSymbol"]/Member[@name="prevClosePrice"]/*' />
        [DataMember(Name = "prev_close_price", EmitDefaultValue = false)]
        public decimal? PrevClosePrice { get; set; }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseSymbol"]/Member[@name="lastPrice"]/*' />
        [DataMember(Name = "last_price", EmitDefaultValue = false)]
        public decimal? LastPrice { get; set; }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseSymbol"]/Member[@name="lastPriceTimestamp"]/*' />
        [DataMember(Name = "last_price_timestamp", EmitDefaultValue = false)]
        public long? LastPriceTimestamp { get; set; }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseSymbol"]/Member[@name="change"]/*' />
        [DataMember(Name = "change", EmitDefaultValue = false)]
        public decimal? Change { get; set; }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseSymbol"]/Member[@name="changePercent"]/*' />
        [DataMember(Name = "change_percent", EmitDefaultValue = false)]
        public decimal? ChangePercent { get; set; }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseSymbol"]/Member[@name="highPrice"]/*' />
        [DataMember(Name = "high_price", EmitDefaultValue = false)]
        public decimal? HighPrice { get; set; }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseSymbol"]/Member[@name="lowPrice"]/*' />
        [DataMember(Name = "low_price", EmitDefaultValue = false)]
        public decimal? LowPrice { get; set; }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseSymbol"]/Member[@name="accruedInt"]/*' />
        [DataMember(Name = "accruedInt", EmitDefaultValue = false)]
        public decimal? AccruedInterest { get; set; }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseSymbol"]/Member[@name="volume"]/*' />
        [DataMember(Name = "volume", EmitDefaultValue = false)]
        public decimal? Volume { get; set; }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseSymbol"]/Member[@name="openInterest"]/*' />
        [DataMember(Name = "open_interest", EmitDefaultValue = false)]
        public long? OpenInterest { get; set; }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseSymbol"]/Member[@name="openPrice"]/*' />
        [DataMember(Name = "open_price", EmitDefaultValue = false)]
        public decimal? OpenPrice { get; set; }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseSymbol"]/Member[@name="yield"]/*' />
        [DataMember(Name = "yield", EmitDefaultValue = false)]
        public int? Yield { get; set; }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseSymbol"]/Member[@name="lotsize"]/*' />
        [DataMember(Name = "lotsize", EmitDefaultValue = false)]
        public decimal? Lotsize { get; set; }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseSymbol"]/Member[@name="lotvalue"]/*' />
        [DataMember(Name = "lotvalue", EmitDefaultValue = false)]
        public decimal? Lotvalue { get; set; }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseSymbol"]/Member[@name="facevalue"]/*' />
        [DataMember(Name = "facevalue", EmitDefaultValue = false)]
        public decimal? Facevalue { get; set; }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseSymbol"]/Member[@name="type"]/*' />
        [DataMember(Name = "type", EmitDefaultValue = false)]
        public string? Type { get; set; }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseSymbol"]/Member[@name="totalBidVol"]/*' />
        [DataMember(Name = "total_bid_vol", EmitDefaultValue = false)]
        public int? TotalBidVol { get; set; }

        /// <include file='../../XmlDocs/CoreModels.xml' path='Docs/Members[@name="responseSymbol"]/Member[@name="totalAskVol"]/*' />
        [DataMember(Name = "total_ask_vol", EmitDefaultValue = false)]
        public int? TotalAskVol { get; set; }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class SymbolSimple {").Append(Environment.NewLine);
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

        public override int GetHashCode() => Utilities.Utilities.GetHashCodeHelper(
            [
                Symbol?.GetHashCode() ?? 0,
                Exchange.GetHashCode(),
            ]
        );

        private static bool EqualsHelper(SymbolSimple? first, SymbolSimple? second) =>
            first?.Symbol == second?.Symbol &&
            first?.Exchange == second?.Exchange &&
            first?.Description == second?.Description &&
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


        public bool Equals(SymbolSimple? other)
        {
            if (this == (object?)other)
                return true;

            if ((object?)other == null)
                return false;

            if (GetType() != other.GetType())
                return false;

            return EqualsHelper(this, other);
        }

        public override bool Equals(object? obj) => Equals(obj as SymbolSimple);

        private static bool Equals(SymbolSimple? first, SymbolSimple? second) =>
            first?.Equals(second) ?? first == (object?)second;

        public static bool operator ==(SymbolSimple? first, SymbolSimple? second) => Equals(first, second);

        public static bool operator !=(SymbolSimple? first, SymbolSimple? second) => !Equals(first, second);

        IEnumerable<ValidationResult> IValidatableObject.Validate(ValidationContext validationContext)
        {
            yield break;
        }
    }
}
