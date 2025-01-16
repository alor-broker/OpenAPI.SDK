using System.Runtime.Serialization;

namespace Alor.OpenAPI.Enums
{
    /// <include file='../XmlDocs/CoreModels.xml' path='Docs/Members[@name="fieldExchangeCode"]/Member[@name="fieldExchangeCode"]/*' />
    public enum Exchange
    {
        [EnumMember(Value = "MOEX")] MOEX = 1,
        [EnumMember(Value = "SPBX")] SPBX = 2
    }
}
