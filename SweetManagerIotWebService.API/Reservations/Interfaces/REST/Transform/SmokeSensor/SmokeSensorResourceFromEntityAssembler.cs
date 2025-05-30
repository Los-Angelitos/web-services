using SweetManagerIotWebService.API.Reservations.Interfaces.REST.Resources.SmokeSensor;

namespace SweetManagerIotWebService.API.Reservations.Interfaces.REST.Transform.SmokeSensor;

public class SmokeSensorResourceFromEntityAssembler
{
    public static SmokeSensorResource FromEntity(Domain.Model.Aggregates.SmokeSensor SmokeSensor)
    {
        return new SmokeSensorResource(
            SmokeSensor.Id,
            SmokeSensor.RoomId,
            SmokeSensor.IpAddress,
            SmokeSensor.MacAddress,
            SmokeSensor.LastAnalogicValue,
            SmokeSensor.State,
            SmokeSensor.LastAlertTime);
    }
}