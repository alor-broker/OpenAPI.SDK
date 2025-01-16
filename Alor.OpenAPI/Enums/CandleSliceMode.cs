using System.Runtime.Serialization;

namespace Alor.OpenAPI.Enums
{
    /// <include file='../XmlDocs/CoreModels.xml' path='Docs/Members[@name="candleSliceMode"]/Member[@name="candleSliceMode"]/*' />
    public enum CandleSliceMode
    {
        [EnumMember(Value = "EqualIntervals")] EqualIntervals = 1,
        [EnumMember(Value = "DailyIntervals")] DailyIntervals = 2
    }
}
