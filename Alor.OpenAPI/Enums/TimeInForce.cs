using System.Runtime.Serialization;

namespace Alor.OpenAPI.Enums
{
    /// <include file='../XmlDocs/CoreModels.xml' path='Docs/Members[@name="fieldExecutionPeriod"]/Member[@name="fieldExecutionPeriod"]/*' />
    public enum TimeInForce
    {
        [EnumMember(Value = "oneday")] OneDay = 1,
        [EnumMember(Value = "immediateorcancel")] ImmediateOrCancel = 2,
        [EnumMember(Value = "fillorkill")] FillOrKill = 3,
        [EnumMember(Value = "goodtillcancelled")] GoodTillCancelled = 4
    }
}
