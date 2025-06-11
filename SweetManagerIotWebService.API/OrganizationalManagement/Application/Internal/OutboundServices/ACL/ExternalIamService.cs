using SweetManagerIotWebService.API.IAM.Interfaces.ACL;
using SweetManagerIotWebService.API.OrganizationalManagement.Domain.Model.ValueObjects;

namespace SweetManagerIotWebService.API.OrganizationalManagement.Application.Internal.OutboundServices.ACL
{
    public class ExternalIamService(IIamContextFacade iamContextFacade)
    {
        public async Task<RecoveredOwner?> FetchOwnerByUserId(int id)
        {
            try
            {
                var owner = await iamContextFacade.FetchOwnerByUserId(id);

                if (owner is null) return await Task.FromResult<RecoveredOwner?>(null);

                return new RecoveredOwner(owner.Name!, owner.Email!);
            }
            catch(Exception)
            {
                return null;
            }
        }
    }
}
