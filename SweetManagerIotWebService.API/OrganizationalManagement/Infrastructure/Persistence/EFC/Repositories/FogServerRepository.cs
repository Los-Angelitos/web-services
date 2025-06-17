using Microsoft.EntityFrameworkCore;
using SweetManagerIotWebService.API.OrganizationalManagement.Domain.Model.Entities;
using SweetManagerIotWebService.API.OrganizationalManagement.Domain.Repositories;
using SweetManagerIotWebService.API.Shared.Infrastructure.Persistence.EFC.Configuration;
using SweetManagerIotWebService.API.Shared.Infrastructure.Persistence.EFC.Repositories;

namespace SweetManagerIotWebService.API.OrganizationalManagement.Infrastructure.Persistence.EFC.Repositories
{
    public class FogServerRepository(SweetManagerContext context) : BaseRepository<FogServer>(context), IFogServerRepository
    {
        public async Task<FogServer?> FindByHotelIdAsync(int hotelId)
            => await Context.Set<FogServer>().Where(a => a.HotelId.Equals(hotelId)).FirstOrDefaultAsync(); 
    }
}