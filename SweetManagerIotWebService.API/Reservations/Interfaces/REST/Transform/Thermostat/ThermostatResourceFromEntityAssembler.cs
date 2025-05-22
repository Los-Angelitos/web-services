using SweetManagerIotWebService.API.Reservations.Interfaces.REST.Resources.Thermostat;

namespace SweetManagerIotWebService.API.Reservations.Interfaces.REST.Transform.Thermostat;

public class ThermostatResourceFromEntityAssembler
{
    public static ThermostatResource FromEntity(Domain.Model.Aggregates.Thermostat thermostat)
    {
        return new ThermostatResource(
            thermostat.Id,
            thermostat.RoomId,
            thermostat.IpAddress,
            thermostat.MacAddress,
            thermostat.Temperature,
            thermostat.State,
            thermostat.LastUpdate);
    }
}