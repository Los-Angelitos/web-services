using SweetManagerIotWebService.API.Reservations.Domain.Model.Commands.Thermostat;
using SweetManagerIotWebService.API.Reservations.Interfaces.REST.Resources.Thermostat;

namespace SweetManagerIotWebService.API.Reservations.Interfaces.REST.Transform.Thermostat;

public class CreateThermostatCommandFromResourceAssembler  
{
    public static CreateThermostatCommand ToCommandFromResource(CreateThermostatResource resource)
    {
        return new CreateThermostatCommand(
            resource.RoomId,
            resource.Temperature,
            resource.IpAddress,
            resource.MacAddress,
            resource.State,
            resource.LastUpdate
            );
    }
}