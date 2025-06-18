using Microsoft.EntityFrameworkCore;
using SweetManagerIotWebService.API.Inventory.Domain.Model.Aggregates;
using SweetManagerIotWebService.API.Inventory.Domain.Repositories;
using SweetManagerIotWebService.API.Shared.Infrastructure.Persistence.EFC.Configuration;
using SweetManagerIotWebService.API.Shared.Infrastructure.Persistence.EFC.Repositories;

namespace SweetManagerIotWebService.API.Inventory.Infrastructure.Persistence.Repositories;

public class RfidCardRepository(SweetManagerContext context) : BaseRepository<RfidCard>(context), IRfidCardRepository
{
    public async Task<IEnumerable<RfidCard>> FindByHotelIdAsync(int hotelId)
    {
        var rfids = await context.RfidCards
            .Where(rfid => rfid.Room != null && rfid.Room.HotelId == hotelId)
            .ToListAsync();

        return rfids;
    }
}