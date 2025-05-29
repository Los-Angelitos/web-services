using Microsoft.EntityFrameworkCore;
using SweetManagerIotWebService.API.Reservations.Domain.Model.Aggregates;
using SweetManagerIotWebService.API.Reservations.Domain.Model.Commands.SmokeSensor;
using SweetManagerIotWebService.API.Reservations.Domain.Repositories;
using SweetManagerIotWebService.API.Shared.Infrastructure.Persistence.EFC.Configuration;
using SweetManagerIotWebService.API.Shared.Infrastructure.Persistence.EFC.Repositories;

namespace SweetManagerIotWebService.API.Reservations.Infrastructure.Persistence.EFC.Repositories;

public class SmokeSensorRepository(SweetManagerContext context) : BaseRepository<SmokeSensor>(context), ISmokeSensorRepositoy
{
    public async Task<IEnumerable<SmokeSensor>> FindByRoomIdAsync(int roomId)
    {
        var SmokeSensors = Context.Set<SmokeSensor>()
            .Where(t => t.RoomId == roomId);
        return await SmokeSensors.ToListAsync();
    }

    public async Task<IEnumerable<SmokeSensor>> FindById(int id)
    {
        var SmokeSensors = Context.Set<SmokeSensor>()
            .Where(t => t.Id == id);
        return await SmokeSensors.ToListAsync();
    }

    public async Task<IEnumerable<SmokeSensor>> FindAllSmokeSensors(int hotelId)
    {
        var query = from t in Context.Set<SmokeSensor>()
            join r in Context.Set<Room>() on t.RoomId equals r.Id
            where r.HotelId == hotelId
            select t;
        
        return await query.ToListAsync();
    }
    
    public async Task<bool> UpdateSmokeSensorState(int id, string state)
    {
        var SmokeSensor = await Context.Set<SmokeSensor>().FindAsync(id);
        if (SmokeSensor == null)
            return false;
        SmokeSensor.State = state;
        await Context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> UpdateSmokeSensorAnalogicValue(int id, double? lastAnalogicValue)
    {
        var SmokeSensor = Context.Set<SmokeSensor>().Find(id);
        if (SmokeSensor == null)
            return false;
        SmokeSensor.LastAnalogicValue = lastAnalogicValue;
        await Context.SaveChangesAsync();
        return true;
    }


    public async Task<bool> UpdateSmokeSensor(int id, int? roomId, string? ipAddress, string? macAddress,
        double? temperature, string? state, DateTime? lastUpdate)
    {
        var smokeSensor = await Context.Set<SmokeSensor>().FindAsync(id);
        if (smokeSensor == null)
            return false;

        smokeSensor.RoomId = roomId;
        smokeSensor.IpAddress = ipAddress;
        smokeSensor.MacAddress = macAddress;
        smokeSensor.LastAnalogicValue = temperature;
        smokeSensor.State = state;
        smokeSensor.LastAlertTime = lastUpdate;

        await Context.SaveChangesAsync();
        return true;
    }

}