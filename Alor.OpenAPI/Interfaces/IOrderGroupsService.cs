using Alor.OpenAPI.Core;
using Alor.OpenAPI.Enums;
using Alor.OpenAPI.Models;

namespace Alor.OpenAPI.Interfaces
{
    public interface IOrderGroupsService
    {
        /// <include file='../XmlDocs/IOrderGroupsService.xml' path='Docs/Members[@name="IOrderGroupsService"]/Member[@name="CommandapiApiOrderGroupsGetAsync"]/*' />
        public Task<ICollection<ResponseOrderGroupInfo>> CommandapiApiOrderGroupsGetAsync();

        /// <include file='../XmlDocs/IOrderGroupsService.xml' path='Docs/Members[@name="IOrderGroupsService"]/Member[@name="CommandapiApiOrderGroupsPostAsync"]/*' />
        public Task<BodyresponseOrderGroup> CommandapiApiOrderGroupsPostAsync(
            ICollection<RequestOrderGroupItem> orders, ExecutionPolicy executionPolicy);

        /// <include file='../XmlDocs/IOrderGroupsService.xml' path='Docs/Members[@name="IOrderGroupsService"]/Member[@name="CommandapiApiOrderGroupsOrderGroupIdGetAsync"]/*' />
        public Task<ResponseOrderGroupInfo> CommandapiApiOrderGroupsOrderGroupIdGetAsync(string orderGroupId);

        /// <include file='../XmlDocs/IOrderGroupsService.xml' path='Docs/Members[@name="IOrderGroupsService"]/Member[@name="CommandapiApiOrderGroupsOrderGroupIdPutAsync"]/*' />
        public Task<string> CommandapiApiOrderGroupsOrderGroupIdPutAsync(string orderGroupId,
            ICollection<RequestOrderGroupItem> orders, ExecutionPolicy executionPolicy);

        /// <include file='../XmlDocs/IOrderGroupsService.xml' path='Docs/Members[@name="IOrderGroupsService"]/Member[@name="CommandapiApiOrderGroupsOrderGroupIdDeleteAsync"]/*' />
        public Task<string> CommandapiApiOrderGroupsOrderGroupIdDeleteAsync(string orderGroupId);
    }
}
