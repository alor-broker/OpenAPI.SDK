using System.Runtime.Serialization;

namespace Alor.OpenAPI.Enums
{
    /// <include file='../XmlDocs/CoreModels.xml' path='Docs/Members[@name="queryMarketOptional"]/Member[@name="queryMarketOptional"]/*' />
    public enum Market
    {
        [EnumMember(Value = "FORTS")] FORTS = 1,
        [EnumMember(Value = "FOND")] FOND = 2,
        [EnumMember(Value = "CURR")] CURR = 3,
        [EnumMember(Value = "SPBX")] SPBX = 4

    }
}