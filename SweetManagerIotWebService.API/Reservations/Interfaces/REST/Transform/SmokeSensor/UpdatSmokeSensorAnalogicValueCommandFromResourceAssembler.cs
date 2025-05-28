using SweetManagerIotWebService.API.Reservations.Domain.Model.Commands.SmokeSensor;
using SweetManagerIotWebService.API.Reservations.Domain.Model.Commands.Thermostat;
using SweetManagerIotWebService.API.Reservations.Interfaces.REST.Resources.SmokeSensor;
using SweetManagerIotWebService.API.Reservations.Interfaces.REST.Resources.Thermostat;

namespace SweetManagerIotWebService.API.Reservations.Interfaces.REST.Transform.SmokeSensor;

public class UpdatSmokeSensorAnalogicValueCommandFromResourceAssembler
{
    public static UpdatSmokeSensorAnalogicValueCommand ToCommandFromResource(UpdateSmokeSensorAnalogicValueResource resource)
    {
        return new UpdatSmokeSensorAnalogicValueCommand(
            resource.Id,
            resource.LastAnalogicValue);
    }
}