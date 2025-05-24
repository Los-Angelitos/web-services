using SweetManagerIotWebService.API.Reservations.Domain.Model.Aggregates;
using SweetManagerIotWebService.API.Reservations.Domain.Model.Queries;
using SweetManagerIotWebService.API.Reservations.Domain.Repositories;
using SweetManagerIotWebService.API.Reservations.Domain.Services.Thermostat;

namespace SweetManagerIotWebService.API.Reservations.Application.Internal.QueryServices;

public class ThermostatQueryService : IThermostatQueryServices
{
    private readonly IThermostatRepositoy _thermostatRepositoy;

    public ThermostatQueryService(IThermostatRepositoy thermostatRepositoy)
    {
        _thermostatRepositoy = thermostatRepositoy;
    }

    public async Task<Thermostat?> Handle(GetThermostatByIdQuery query)
    {
        return await _thermostatRepositoy.FindByIdAsync(query.id);
    }

    public async Task<IEnumerable<Thermostat>> Handle(GetThermostatByRoomIdQuery query)
    {
        
        return await _thermostatRepositoy.FindByRoomIdAsync(query.roomId);
    }

    public async Task<IEnumerable<Thermostat>> Handle(GetAllThermostatsByHotelIdQuery query)
    {
        return await _thermostatRepositoy.FindAllThermostats(query.HotelId);
    }
}