using System.Runtime.Serialization;

namespace Alor.OpenAPI.Enums
{
    /// <include file='../XmlDocs/CoreModels.xml' path='Docs/Members[@name="fieldStatusOrderGroup"]/Member[@name="fieldStatusOrderGroup"]/*' />
    public enum OrderGroupStatus
    {
        [EnumMember(Value = "Active")] Active = 1,
        [EnumMember(Value = "Filled")] Filled = 2,
        [EnumMember(Value = "Canceled")] Canceled = 3
    }
}
