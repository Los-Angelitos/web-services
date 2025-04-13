using Microsoft.EntityFrameworkCore;
using SweetManagerIotWebService.API.OrganizationalManagement.Domain.Repositories;
using SweetManagerIotWebService.API.Shared.Infrastructure.Persistence.EFC.Configuration;
using SweetManagerIotWebService.API.Shared.Infrastructure.Persistence.EFC.Repositories;

namespace SweetManagerIotWebService.API.OrganizationalManagement.Infrastructure.Persistence.EFC.Repositories;

public class HotelRepository(SweetManagerContext context) : BaseRepository<Hotel>(context), IHotelRepository
{
    public async Task<Hotel?> FindByNameAndEmailAsync(string name, string email)
    {
        return await context.Set<Hotel>()
            .Where(h => h.Name == name && h.Email == email)
            .FirstOrDefaultAsync();
    }
}