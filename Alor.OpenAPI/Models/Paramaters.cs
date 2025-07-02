using Alor.OpenAPI.Enums;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text;
using SpanJson;

namespace Alor.OpenAPI.Models
{
    [DataContract]
    public sealed class Parameters : IEquatable<Parameters>, IValidatableObject
    {
        public Parameters() { }

        [JsonConstructor]
        public Parameters(string? guid = default, string? portfolio = default, string? code = default,
            string? instrumentGroup = default, Exchange exchange = default, int? depth = default,
            string? tf = default, DateTime? from = default, bool? skipHistory = default,
            bool? splitAdjust = default, CandleSliceMode sliceMode = default, bool? includeVirtualTrades = default,
            List<OrderStatus>? orderStatuses = default, bool? confirm = default)
        {
            Guid = guid;
            Portfolio = portfolio;
            Code = code;
            InstrumentGroup = instrumentGroup;
            Exchange = exchange;
            Depth = depth;
            Tf = tf;
            From = from;
            SkipHistory = skipHistory;
            SplitAdjust = splitAdjust;
            SliceMode = sliceMode;
            IncludeVirtualTrades = includeVirtualTrades;
            OrderStatuses = orderStatuses;
            Confirm = confirm;
        }

        /// <include file='../XmlDocs/CoreModels.xml' path='Docs/Members[@name="fieldGuidWs"]/Member[@name="fieldGuidWs"]/*' />
        [DataMember(Name = "guid")]
        public string? Guid { get; init; }

        /// <include file='../XmlDocs/CoreModels.xml' path='Docs/Members[@name="objectUserPortfolioOnly"]/Member[@name="portfolio"]/*' />
        [DataMember(Name = "portfolio")]
        public string? Portfolio { get; init; }

        /// <include file='../XmlDocs/CoreModels.xml' path='Docs/Members[@name="fieldTicker"]/Member[@name="fieldTicker"]/*' />
        [DataMember(Name = "code")]
        public string? Code { get; init; }

        /// <include file='../XmlDocs/CoreModels.xml' path='Docs/Members[@name="fieldBoard"]/Member[@name="fieldBoard"]/*' />
        [DataMember(Name = "instrumentGroup")]
        public string? InstrumentGroup { get; init; }

        /// <include file='../XmlDocs/CoreModels.xml' path='Docs/Members[@name="fieldExchangeCode"]/Member[@name="fieldExchangeCode"]/*' />
        [DataMember(Name = "exchange")]
        public Exchange? Exchange { get; init; }

        /// <include file='../XmlDocs/CoreModels.xml' path='Docs/Members[@name="wsSubOrderBookGetAndSubscribe"]/Member[@name="depth"]/*' />
        [DataMember(Name = "depth")]
        public int? Depth { get; init; }

        /// <include file='../XmlDocs/CoreModels.xml' path='Docs/Members[@name="wsSubBarsGetAndSubscribe"]/Member[@name="tf"]/*' />
        [DataMember(Name = "tf")]
        public string? Tf { get; init; }

        /// <include file='../XmlDocs/CoreModels.xml' path='Docs/Members[@name="wsSubBarsGetAndSubscribe"]/Member[@name="from"]/*' />
        [DataMember(Name = "from")]
        public DateTime? From { get; init; }

        /// <include file='../XmlDocs/CoreModels.xml' path='Docs/Members[@name="wsSubBarsGetAndSubscribe"]/Member[@name="skipHistory"]/*' />
        [DataMember(Name = "skipHistory")] 
        public bool? SkipHistory { get; init; }

        /// <include file='../XmlDocs/CoreModels.xml' path='Docs/Members[@name="wsSubBarsGetAndSubscribe"]/Member[@name="splitAdjust"]/*' />
        [DataMember(Name = "splitAdjust")]
        public bool? SplitAdjust { get; init; }

        /// <include file='../XmlDocs/CoreModels.xml' path='Docs/Members[@name="wsSubBarsGetAndSubscribe"]/Member[@name="sliceMode"]/*' />
        [DataMember(Name = "sliceMode")]
        public CandleSliceMode? SliceMode { get; init; }

        /// <include file='../XmlDocs/CoreModels.xml' path='Docs/Members[@name="wsSubAllTradesGetAndSubscribe"]/Member[@name="includeVirtualTrades"]/*' />
        [DataMember(Name = "includeVirtualTrades")]
        public bool? IncludeVirtualTrades { get; init; }

        /// <include file='../XmlDocs/CoreModels.xml' path='Docs/Members[@name="wsSubOrdersGetAndSubscribe"]/Member[@name="orderStatuses"]/*' />
        [DataMember(Name = "orderStatuses")]
        public List<OrderStatus>? OrderStatuses { get; init; }

        /// <include file='../XmlDocs/CoreModels.xml' path='Docs/Members[@name="wsPingStatus"]/Member[@name="confirm"]/*' />
        [DataMember(Name = "confirm")]
        public bool? Confirm { get; init; }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class Parameters {").Append(Environment.NewLine);
            sb.Append("  Guid: ").Append(Guid).Append(Environment.NewLine);
            sb.Append("  Portfolio: ").Append(Portfolio).Append(Environment.NewLine);
            sb.Append("  Code: ").Append(Code).Append(Environment.NewLine);
            sb.Append("  InstrumentGroup: ").Append(InstrumentGroup).Append(Environment.NewLine);
            sb.Append("  Exchange: ").Append(Exchange).Append(Environment.NewLine);
            sb.Append("  Depth: ").Append(Depth).Append(Environment.NewLine);
            sb.Append("  Tf: ").Append(Tf).Append(Environment.NewLine);
            sb.Append("  From: ").Append(From).Append(Environment.NewLine);
            sb.Append("  SkipHistory: ").Append(SkipHistory).Append(Environment.NewLine);
            sb.Append("  SplitAdjust: ").Append(SplitAdjust).Append(Environment.NewLine);
            sb.Append("  SliceMode: ").Append(SliceMode).Append(Environment.NewLine);
            sb.Append("  IncludeVirtualTrades: ").Append(IncludeVirtualTrades).Append(Environment.NewLine);
            sb.Append("  OrderStatuses: ").Append(OrderStatuses == null ? "null" : string.Join(", ", OrderStatuses.Select(x => x.ToString()))).Append(Environment.NewLine);
            sb.Append('}').Append(Environment.NewLine);
            return sb.ToString();
        }

        public string ToJson() => Encoding.UTF8.GetString(JsonSerializer.Generic.Utf8.Serialize(this));

        public override int GetHashCode()
        {
            var hash = new HashCode();
            hash.Add(Guid);
            hash.Add(Portfolio);
            hash.Add(Code);
            hash.Add(InstrumentGroup);
            hash.Add(Exchange);
            hash.Add(Depth);
            hash.Add(Tf);
            hash.Add(From);
            hash.Add(SkipHistory);
            hash.Add(SplitAdjust);
            hash.Add(SliceMode);
            hash.Add(IncludeVirtualTrades);

            if (OrderStatuses == null) return hash.ToHashCode();
            foreach (var item in OrderStatuses)
            {
                hash.Add(item.GetHashCode());
            }

            return hash.ToHashCode();
        }

        private static bool EqualsHelper(Parameters? first, Parameters? second) =>
            first?.Guid == second?.Guid &&
            first?.Portfolio == second?.Portfolio &&
            first?.Code == second?.Code &&
            first?.InstrumentGroup == second?.InstrumentGroup &&
            first?.Exchange == second?.Exchange &&
            first?.Depth == second?.Depth &&
            first?.Tf == second?.Tf &&
            first?.From == second?.From &&
            first?.SkipHistory == second?.SkipHistory &&
            first?.SplitAdjust == second?.SplitAdjust &&
            first?.SliceMode == second?.SliceMode &&
            first?.IncludeVirtualTrades == second?.IncludeVirtualTrades &&
            first?.OrderStatuses != null && second?.OrderStatuses != null
                ? first.OrderStatuses.SequenceEqual(second.OrderStatuses)
                : first?.OrderStatuses == null && second?.OrderStatuses == null;

        public bool Equals(Parameters? other)
        {
            if (this == (object?)other)
                return true;

            if ((object?)other == null)
                return false;

            return GetType() == other.GetType() && EqualsHelper(this, other);
        }

        public override bool Equals(object? obj) => Equals(obj as Parameters);

        private static bool Equals(Parameters? first, Parameters? second) =>
            first?.Equals(second) ?? first == (object?)second;

        public static bool operator ==(Parameters? first, Parameters? second) => Equals(first, second);

        public static bool operator !=(Parameters? first, Parameters? second) => !Equals(first, second);

        IEnumerable<ValidationResult> IValidatableObject.Validate(ValidationContext validationContext)
        {
            yield break;
        }
    }
}
