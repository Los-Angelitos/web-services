using SweetManagerIotWebService.API.Reservations.Domain.Model.Queries;

namespace SweetManagerIotWebService.API.Reservations.Domain.Services.Thermostat;

public interface IThermostatQueryServices
{
    Task<IEnumerable<Model.Aggregates.Thermostat>> Handle(GetAllThermostatsByHotelIdQuery query);

    Task<Model.Aggregates.Thermostat?> Handle(GetThermostatByIdQuery query);

    Task<IEnumerable<Model.Aggregates.Thermostat>> Handle(GetThermostatByRoomIdQuery query);
    
}