using Microsoft.EntityFrameworkCore;
using SweetManagerIotWebService.API.Reservations.Domain.Model.Aggregates;
using SweetManagerIotWebService.API.Reservations.Domain.Repositories;
using SweetManagerIotWebService.API.Shared.Infrastructure.Persistence.EFC.Configuration;
using SweetManagerIotWebService.API.Shared.Infrastructure.Persistence.EFC.Repositories;

namespace SweetManagerIotWebService.API.Reservations.Infrastructure.Persistence.EFC.Repositories;

public class ThermostatRepository(SweetManagerContext context) : BaseRepository<Thermostat>(context), IThermostatRepository
{
    public async Task<IEnumerable<Thermostat>> FindByRoomIdAsync(int roomId)
    {
        var thermostats = Context.Set<Thermostat>()
            .Where(t => t.RoomId == roomId);
        return await thermostats.ToListAsync();
    }

    public async Task<IEnumerable<Thermostat>> FindById(int id)
    {
        var thermostats = Context.Set<Thermostat>()
            .Where(t => t.Id == id);
        return await thermostats.ToListAsync();
    }

    public async Task<IEnumerable<Thermostat>> FindAllThermostats(int hotelId)
    {
        var query = from t in Context.Set<Thermostat>()
            join r in Context.Set<Room>() on t.RoomId equals r.Id
            where r.HotelId == hotelId
            select t;
        
        return await query.ToListAsync();
    }
    
    public async Task<bool> UpdateThermostatState(int id, string state)
    {
        var thermostat = await Context.Set<Thermostat>().FindAsync(id);
        if (thermostat == null)
            return false;
        thermostat.State = state;
        await Context.SaveChangesAsync();
        return true;
    }
    
    public async Task<bool> UpdateThermostatTemperature(int id, double? temperature)
    {
        var thermostat = await Context.Set<Thermostat>().FindAsync(id);
        if (thermostat == null)
            return false;
        thermostat.Temperature = temperature;
        await Context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> UpdateThermostat(int id, int? roomId, string? ipAddress, string? macAddress,
        double? temperature, string? state,
        DateTime? lastUpdate)
    {
        var thermostat = await Context.Set<Thermostat>().FindAsync(id);
        if (thermostat == null)
            return false;
        thermostat = new Thermostat(id, roomId, temperature, ipAddress, macAddress, state, lastUpdate);
        await Context.SaveChangesAsync();
        return true;
    }
}