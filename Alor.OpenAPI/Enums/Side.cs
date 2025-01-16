using System.Runtime.Serialization;

namespace Alor.OpenAPI.Enums
{
    /// <include file='../XmlDocs/CoreModels.xml' path='Docs/Members[@name="fieldSideCommon"]/Member[@name="fieldSideCommon"]/*' />
    public enum Side
    {
        [EnumMember(Value = "buy")] Buy = 1,
        [EnumMember(Value = "sell")] Sell = 2
    }
}
