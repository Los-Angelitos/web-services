using SweetManagerIotWebService.API.Reservations.Domain.Model.Commands.Thermostat;
using SweetManagerIotWebService.API.Reservations.Interfaces.REST.Resources.Thermostat;

namespace SweetManagerIotWebService.API.Reservations.Interfaces.REST.Transform.Thermostat;

public class UpdateThermostatCommandFromResourceAssembler
{
    public static UpdateThermostatCommand ToCommandFromResource(UpdateThermostatResource resource)
    {
        return new UpdateThermostatCommand(
            resource.Id,
            resource.RoomId,
            resource.Temperature,
            resource.IpAddress,
            resource.MacAddress,
            resource.State,
            resource.LastUpdate
        );
    }
}