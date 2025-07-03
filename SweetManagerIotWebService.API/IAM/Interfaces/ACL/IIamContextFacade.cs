using SweetManagerIotWebService.API.IAM.Domain.Model.Aggregates;
using SweetManagerIotWebService.API.IAM.Domain.Model.Entities.Preferences;

namespace SweetManagerIotWebService.API.IAM.Interfaces.ACL
{
    public interface IIamContextFacade
    {
        Task<Admin?> FetchAdminByUserId(int id);

        Task<Owner?> FetchOwnerByUserId(int id);

        Task<GuestPreference?> FetchGuestPreferenceById(int id);

    }
}
