using SweetManagerIotWebService.API.Reservations.Domain.Model.Commands.SmokeSensor;
using SweetManagerIotWebService.API.Reservations.Interfaces.REST.Resources.SmokeSensor;

namespace SweetManagerIotWebService.API.Reservations.Interfaces.REST.Transform.SmokeSensor;

public class CreateSmokeSensorCommandFromResourceAssembler  
{
    public static CreateSmokeSensorCommand ToCommandFromResource(CreateSmokeSensorResource resource)
    {
        return new CreateSmokeSensorCommand(
            resource.RoomId,
            resource.LastAnalogicValue,
            resource.IpAddress,
            resource.MacAddress,
            resource.State,
            resource.LastAlertTime
            );
    }
}