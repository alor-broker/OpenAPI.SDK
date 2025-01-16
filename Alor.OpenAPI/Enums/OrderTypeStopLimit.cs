using System.Runtime.Serialization;

namespace Alor.OpenAPI.Enums
{
    /// <include file='../XmlDocs/CoreModels.xml' path='Docs/Members[@name="fieldOrderTypeStopLimit"]/Member[@name="fieldOrderTypeStopLimit"]/*' />
    public enum OrderTypeStopLimit
    {
        [EnumMember(Value = "stop")] Stop = 1,
        [EnumMember(Value = "stoplimit")] Stoplimit = 2
    }
}