using System.Runtime.Serialization;

namespace Alor.OpenAPI.Enums
{
    /// <include file='../XmlDocs/CoreModels.xml' path='Docs/Members[@name="fieldOrderTypeLimitMarket"]/Member[@name="fieldOrderTypeLimitMarket"]/*' />
    public enum Type
    {
        [EnumMember(Value = "limit")] Limit = 1,
        [EnumMember(Value = "market")] Market = 2
    }
}
