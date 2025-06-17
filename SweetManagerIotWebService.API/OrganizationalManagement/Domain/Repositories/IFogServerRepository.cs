using SweetManagerIotWebService.API.OrganizationalManagement.Domain.Model.Entities;
using SweetManagerIotWebService.API.Shared.Domain.Repositories;

namespace SweetManagerIotWebService.API.OrganizationalManagement.Domain.Repositories
{
    public interface IFogServerRepository : IBaseRepository<FogServer>
    {
        Task<FogServer?> FindByHotelIdAsync(int hotelId);

    }
}
