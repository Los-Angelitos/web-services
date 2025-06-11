using SweetManagerIotWebService.API.IAM.Domain.Model.Aggregates;

namespace SweetManagerIotWebService.API.IAM.Interfaces.ACL
{
    public interface IIamContextFacade
    {
        Task<Admin?> FetchAdminByUserId(int id);

        Task<Owner?> FetchOwnerByUserId(int id);
    }
}
