using System.Runtime.Serialization;

namespace Alor.OpenAPI.Enums
{
    /// <include file='../XmlDocs/CoreModels.xml' path='Docs/Members[@name="fieldExecutionPolicy"]/Member[@name="fieldExecutionPolicy"]/*' />
    public enum ExecutionPolicy
    {
        [EnumMember(Value = "OnExecuteOrCancel")] OnExecuteOrCancel = 1,
        [EnumMember(Value = "IgnoreCancel")] IgnoreCancel = 2,
        [EnumMember(Value = "TriggerBracketOrders")] TriggerBracketOrders = 3
    }
}
