using SweetManagerIotWebService.API.Reservations.Domain.Model.Commands.SmokeSensor;
using SweetManagerIotWebService.API.Reservations.Domain.Model.Commands.Thermostat;
using SweetManagerIotWebService.API.Reservations.Interfaces.REST.Resources.SmokeSensor;
using SweetManagerIotWebService.API.Reservations.Interfaces.REST.Resources.Thermostat;

namespace SweetManagerIotWebService.API.Reservations.Interfaces.REST.Transform.SmokeSensor;

public class UpdateSmokeSensorCommandFromResourceAssembler
{
    public static UpdateSmokeSensorCommand ToCommandFromResource(UpdateSmokeSensorResource resource)
    {
        return new UpdateSmokeSensorCommand(
            resource.Id,
            resource.RoomId,
            resource.LastAnalogicValue,
            resource.IpAddress,
            resource.MacAddress,
            resource.State,
            resource.LastAlertTime
        );
    }
}