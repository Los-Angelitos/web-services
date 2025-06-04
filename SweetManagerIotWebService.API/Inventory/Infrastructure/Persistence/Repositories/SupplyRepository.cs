using Microsoft.EntityFrameworkCore;
using SweetManagerIotWebService.API.Commerce.Domain.Model.Aggregates;
using SweetManagerIotWebService.API.IAM.Domain.Model.Aggregates;
using SweetManagerIotWebService.API.Inventory.Domain.Model.Aggregates;
using SweetManagerIotWebService.API.Inventory.Domain.Model.Entities;
using SweetManagerIotWebService.API.Inventory.Domain.Repositories;
using SweetManagerIotWebService.API.OrganizationalManagement.Domain.Model.Aggregates;
using SweetManagerIotWebService.API.Shared.Infrastructure.Persistence.EFC.Configuration;
using SweetManagerIotWebService.API.Shared.Infrastructure.Persistence.EFC.Repositories;

namespace SweetManagerIotWebService.API.Inventory.Infrastructure.Persistence.Repositories;

public class SupplyRepository(SweetManagerContext context) : BaseRepository<Supply>(context), ISupplyRepository
{

    public async Task<bool> ExecuteUpdateProviderIdAsync(int id, int providerId)
     => await Context.Set<Supply>().Where(s => s.Id.Equals(id))
        .ExecuteUpdateAsync(s => s.SetProperty(u => u.ProviderId, providerId)) > 0;

    public async Task<IEnumerable<Supply>> FindByProviderId(int providerId)
    {
        return await Context.Set<Supply>().Where(s => s.ProviderId == providerId).ToListAsync();
    }
    
    public async Task<IEnumerable<Supply>> FindSuppliesByHotelIdAsync(int hotelId)
    {
        return await Context.Set<Supply>()
            .Where(s => s.HotelId == hotelId)
            .ToListAsync();
    }
}