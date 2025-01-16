using System.Runtime.Serialization;

namespace Alor.OpenAPI.Enums
{
    /// <include file='../XmlDocs/CoreModels.xml' path='Docs/Members[@name="fieldClientType"]/Member[@name="fieldClientType"]/*' />
    public enum ClientType
    {
        [EnumMember(Value = "StandardRisk")] StandardRisk = 1,
        [EnumMember(Value = "HighRisk")] HighRisk = 2,
        [EnumMember(Value = "Special")] Special = 3
    }
}
