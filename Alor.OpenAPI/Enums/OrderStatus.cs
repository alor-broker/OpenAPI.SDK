using System.Runtime.Serialization;

namespace Alor.OpenAPI.Enums
{
    /// <include file='../XmlDocs/CoreModels.xml' path='Docs/Members[@name="fieldStatusOrder"]/Member[@name="fieldStatusOrder"]/*' />
    public enum OrderStatus
    {
        [EnumMember(Value = "working")] Working = 1,
        [EnumMember(Value = "filled")] Filled = 2,
        [EnumMember(Value = "canceled")] Canceled = 3,
        [EnumMember(Value = "rejected")] Rejected = 4
    }
}
