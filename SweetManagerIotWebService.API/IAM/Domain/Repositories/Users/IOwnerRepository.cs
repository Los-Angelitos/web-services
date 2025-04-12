using SweetManagerIotWebService.API.IAM.Domain.Model.Aggregates;
using SweetManagerIotWebService.API.Shared.Domain.Repositories;

namespace SweetManagerIotWebService.API.IAM.Domain.Repositories.Users
{
    public interface IOwnerRepository : IBaseRepository<Owner>
    {
        Task<IEnumerable<Owner>> FindAllAsync();

    }
}