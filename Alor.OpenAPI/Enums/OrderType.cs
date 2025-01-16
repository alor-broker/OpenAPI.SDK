using System.Runtime.Serialization;

namespace Alor.OpenAPI.Enums
{
    /// <include file='../XmlDocs/CoreModels.xml' path='Docs/Members[@name="fieldOrderTypeAll"]/Member[@name="fieldOrderTypeAll"]/*' />
    public enum OrderType
    {
        [EnumMember(Value = "Limit")] Limit = 1,
        [EnumMember(Value = "Market")] Market = 2,
        [EnumMember(Value = "Stop")] Stop = 3,
        [EnumMember(Value = "StopLimit")] StopLimit = 4
    }
}
