using System.Runtime.Serialization;

namespace Alor.OpenAPI.Enums
{
    /// <include file='../XmlDocs/CoreModels.xml' path='Docs/Members[@name="fieldRiskStatus"]/Member[@name="fieldRiskStatus"]/*' />
    public enum RiskStatus
    {
        [EnumMember(Value = "Ok")] Ok = 1,
        [EnumMember(Value = "Demand")] Demand = 2,
        [EnumMember(Value = "ToClose")] ToClose = 3
    }
}