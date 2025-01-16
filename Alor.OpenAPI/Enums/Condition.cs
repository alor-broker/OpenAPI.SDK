using System.Runtime.Serialization;

namespace Alor.OpenAPI.Enums
{
    /// <include file='../XmlDocs/CoreModels.xml' path='Docs/Members[@name="fieldExecutionCondition"]/Member[@name="fieldExecutionCondition"]/*' />
    public enum Condition
    {
        [EnumMember(Value = "More")] More = 1,
        [EnumMember(Value = "Less")] Less = 2,
        [EnumMember(Value = "MoreOrEqual")] MoreOrEqual = 3,
        [EnumMember(Value = "LessOrEqual")] LessOrEqual = 4
    }
}
