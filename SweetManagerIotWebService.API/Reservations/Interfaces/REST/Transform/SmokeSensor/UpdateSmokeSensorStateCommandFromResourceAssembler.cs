using SweetManagerIotWebService.API.Reservations.Domain.Model.Commands.SmokeSensor;
using SweetManagerIotWebService.API.Reservations.Domain.Model.Commands.Thermostat;
using SweetManagerIotWebService.API.Reservations.Interfaces.REST.Resources.SmokeSensor;
using SweetManagerIotWebService.API.Reservations.Interfaces.REST.Resources.Thermostat;

namespace SweetManagerIotWebService.API.Reservations.Interfaces.REST.Transform.SmokeSensor;

public class UpdateSmokeSensorStateCommandFromResourceAssembler
{
    public static UpdateSmokeSensorStateCommand ToCommandFromResource(UpdateSmokeSensorStateResource resource)
    {
        return new UpdateSmokeSensorStateCommand(
            resource.Id,
            resource.State);
    }
}