using SweetManagerIotWebService.API.Reservations.Domain.Model.Aggregates;
using SweetManagerIotWebService.API.Shared.Domain.Repositories;

namespace SweetManagerIotWebService.API.Reservations.Domain.Repositories;

public interface IThermostatRepository : IBaseRepository<Thermostat>
{
    Task<IEnumerable<Thermostat>> FindByRoomIdAsync(int roomId);
    
    Task<IEnumerable<Thermostat>>  FindById(int id);
    
    Task<IEnumerable<Thermostat>>  FindAllThermostats(int hotelId);
    
    Task<bool> UpdateThermostatState(int id, string state);

    Task<bool> UpdateThermostatTemperature(int id, double? temperature);
    
    Task<bool> UpdateThermostat(int id, int? roomId, string? ipAddress, string? macAddress,
        double? temperature, string? state, DateTime? lastUpdate);
}