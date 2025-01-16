using Alor.OpenAPI.Enums;
using System.Runtime.Serialization;
using System.Text;

namespace Alor.OpenAPI.Models
{
    [DataContract]
    public sealed class Parameters
    {
        /// <include file='../XmlDocs/CoreModels.xml' path='Docs/Members[@name="fieldGuidWs"]/Member[@name="fieldGuidWs"]/*' />
        [DataMember(Name = "guid")]
        public string? Guid { get; set; }

        /// <include file='../XmlDocs/CoreModels.xml' path='Docs/Members[@name="objectUserPortfolioOnly"]/Member[@name="portfolio"]/*' />
        [DataMember(Name = "portfolio")]
        public string? Portfolio { get; set; }

        /// <include file='../XmlDocs/CoreModels.xml' path='Docs/Members[@name="fieldTicker"]/Member[@name="fieldTicker"]/*' />
        [DataMember(Name = "code")]
        public string? Code { get; set; }

        /// <include file='../XmlDocs/CoreModels.xml' path='Docs/Members[@name="fieldBoard"]/Member[@name="fieldBoard"]/*' />
        [DataMember(Name = "instrumentGroup")]
        public string? InstrumentGroup { get; set; }

        /// <include file='../XmlDocs/CoreModels.xml' path='Docs/Members[@name="fieldExchangeCode"]/Member[@name="fieldExchangeCode"]/*' />
        [DataMember(Name = "exchange")]
        public Exchange? Exchange { get; set; }

        /// <include file='../XmlDocs/CoreModels.xml' path='Docs/Members[@name="wsSubOrderBookGetAndSubscribe"]/Member[@name="depth"]/*' />
        [DataMember(Name = "depth")]
        public int? Depth { get; set; }

        /// <include file='../XmlDocs/CoreModels.xml' path='Docs/Members[@name="wsSubBarsGetAndSubscribe"]/Member[@name="tf"]/*' />
        [DataMember(Name = "tf")]
        public string? Tf { get; set; }

        /// <include file='../XmlDocs/CoreModels.xml' path='Docs/Members[@name="wsSubBarsGetAndSubscribe"]/Member[@name="from"]/*' />
        [DataMember(Name = "from")]
        public DateTime? From { get; set; }

        /// <include file='../XmlDocs/CoreModels.xml' path='Docs/Members[@name="wsSubBarsGetAndSubscribe"]/Member[@name="skipHistory"]/*' />
        [DataMember(Name = "skipHistory")] 
        public bool? SkipHistory { get; set; }

        /// <include file='../XmlDocs/CoreModels.xml' path='Docs/Members[@name="wsSubBarsGetAndSubscribe"]/Member[@name="splitAdjust"]/*' />
        [DataMember(Name = "splitAdjust")]
        public bool? SplitAdjust { get; set; }

        /// <include file='../XmlDocs/CoreModels.xml' path='Docs/Members[@name="wsSubBarsGetAndSubscribe"]/Member[@name="sliceMode"]/*' />
        [DataMember(Name = "sliceMode")]
        public CandleSliceMode? SliceMode { get; set; }

        /// <include file='../XmlDocs/CoreModels.xml' path='Docs/Members[@name="wsSubAllTradesGetAndSubscribe"]/Member[@name="includeVirtualTrades"]/*' />
        [DataMember(Name = "includeVirtualTrades")]
        public bool? IncludeVirtualTrades { get; set; }

        /// <include file='../XmlDocs/CoreModels.xml' path='Docs/Members[@name="wsSubOrdersGetAndSubscribe"]/Member[@name="orderStatuses"]/*' />
        [DataMember(Name = "orderStatuses")]
        public List<OrderStatus>? OrderStatuses { get; set; }


        public string ToJson() => Encoding.UTF8.GetString(SpanJson.JsonSerializer.Generic.Utf8.Serialize(this));
    }
}
