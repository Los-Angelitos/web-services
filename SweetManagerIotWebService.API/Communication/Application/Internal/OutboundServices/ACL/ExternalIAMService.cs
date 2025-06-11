using SweetManagerIotWebService.API.Communication.Domain.Model.ValueObjects;
using SweetManagerIotWebService.API.IAM.Interfaces.ACL;

namespace SweetManagerIotWebService.API.Communication.Application.Internal.OutboundServices.ACL
{
    public class ExternalIAMService(IIamContextFacade iamContextFacade)
    {
        public async Task<RecoveredAdmin?> FetchAdminById(int id)
        {
            var user = await iamContextFacade.FetchAdminByUserId(id);

            if (user is null) return await Task.FromResult<RecoveredAdmin?>(null);

            return new RecoveredAdmin(user.Name!, string.Concat(user.Name, " ", user.Surname), user.Email!, user.Phone!);
        }

        public async Task<RecoveredOwner?> FetchOwnerNameAndEmailById(int id)
        {
            var owner = await iamContextFacade.FetchOwnerByUserId(id);

            if (owner is null) return await Task.FromResult<RecoveredOwner?>(null);

            return new RecoveredOwner(owner.Name!, owner.Email!);
        }
    }
}
