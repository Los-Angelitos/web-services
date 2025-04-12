using SweetManagerIotWebService.API.IAM.Domain.Model.Aggregates;
using SweetManagerIotWebService.API.Shared.Domain.Repositories;

namespace SweetManagerIotWebService.API.IAM.Domain.Repositories.Users
{
    public interface IAdminRepository : IBaseRepository<Admin>
    {
        Task<IEnumerable<Admin>> FindAllAsync();


    }
}