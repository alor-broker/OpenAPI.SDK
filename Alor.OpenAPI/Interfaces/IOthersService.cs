using Alor.OpenAPI.Core;

namespace Alor.OpenAPI.Interfaces
{
    public interface IOthersService
    {
        /// <include file='../XmlDocs/IOthersService.xml' path='Docs/Members[@name="IOthersService"]/Member[@name="MdV2TimeGetAsync"]/*' />
        public Task<long> MdV2TimeGetAsync();
    }
}
