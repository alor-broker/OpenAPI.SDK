using System.Runtime.Serialization;

namespace Alor.OpenAPI.Enums
{
    /// <include file='../XmlDocs/CoreModels.xml' path='Docs/Members[@name="fieldExecutionCondition"]/Member[@name="fieldExecutionCondition"]/*' />
    public enum Condition
    {
        [EnumMember(Value = "more")] More = 1,
        [EnumMember(Value = "less")] Less = 2,
        [EnumMember(Value = "moreorequal")] MoreOrEqual = 3,
        [EnumMember(Value = "lessorequal")] LessOrEqual = 4
    }
}
