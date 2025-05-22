using SweetManagerIotWebService.API.Reservations.Domain.Model.Commands.Thermostat;
using SweetManagerIotWebService.API.Reservations.Interfaces.REST.Resources.Thermostat;

namespace SweetManagerIotWebService.API.Reservations.Interfaces.REST.Transform.Thermostat;

public class UpdateThermostatTemperatureCommandFromResourceAssembler
{
    public static UpdateThermostatTemperatureCommand ToCommandFromResource(UpdateThermostatTemperatureResource resource)
    {
        return new UpdateThermostatTemperatureCommand(
            resource.Id,
            resource.Temperature);
    }
}