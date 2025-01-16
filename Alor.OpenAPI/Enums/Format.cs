using System.Runtime.Serialization;

namespace Alor.OpenAPI.Enums
{
    /// <include file='../XmlDocs/CoreModels.xml' path='Docs/Members[@name="fieldFormat"]/Member[@name="fieldFormat"]/*' />
    public enum Format
    {
        [EnumMember(Value = "Simple")] Simple = 1,
        [EnumMember(Value = "Slim")] Slim = 2,
        [EnumMember(Value = "Heavy")] Heavy = 3
    }
}
