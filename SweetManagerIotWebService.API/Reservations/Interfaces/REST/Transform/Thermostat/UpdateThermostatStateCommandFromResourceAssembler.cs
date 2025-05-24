using SweetManagerIotWebService.API.Reservations.Domain.Model.Commands.Thermostat;
using SweetManagerIotWebService.API.Reservations.Interfaces.REST.Resources.Thermostat;

namespace SweetManagerIotWebService.API.Reservations.Interfaces.REST.Transform.Thermostat;

public class UpdateThermostatStateCommandFromResourceAssembler
{
    public static UpdateThermostatStateCommand ToCommandFromResource(UpdateThermostatStateResource resource)
    {
        return new UpdateThermostatStateCommand(
            resource.Id,
            resource.State);
    }
}