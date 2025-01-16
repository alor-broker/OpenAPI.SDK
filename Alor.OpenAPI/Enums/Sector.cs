using System.Runtime.Serialization;

namespace Alor.OpenAPI.Enums
{
    /// <include file='../XmlDocs/CoreModels.xml' path='Docs/Members[@name="querySectorOptional"]/Member[@name="querySectorOptional"]/*' />
    public enum Sector
    {
        [EnumMember(Value = "FORTS")] FORTS = 1,
        [EnumMember(Value = "FOND")] FOND = 2,
        [EnumMember(Value = "CURR")] CURR = 3
    }
}