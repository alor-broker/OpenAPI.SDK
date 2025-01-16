using System.Runtime.Serialization;

namespace Alor.OpenAPI.Enums
{
    /// <include file='../XmlDocs/CoreModels.xml' path='Docs/Members[@name="fieldSideOption"]/Member[@name="fieldSideOption"]/*' />
    public enum OptionSide
    {
        [EnumMember(Value = "Call")] Call = 1,
        [EnumMember(Value = "Put")] Put = 2
    }
}
