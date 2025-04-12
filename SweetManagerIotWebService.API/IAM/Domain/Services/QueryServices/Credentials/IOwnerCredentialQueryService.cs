using SweetManagerIotWebService.API.IAM.Domain.Model.Entities.Credentials;

namespace SweetManagerIotWebService.API.IAM.Domain.Services.QueryServices.Credentials
{
    public interface IOwnerCredentialQueryService
    {
        Task<OwnerCredential?> FindByIdAsync(int Id);
    }
}