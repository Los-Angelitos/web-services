namespace SweetManagerIotWebService.API.Reservations.Domain.Model.Commands.Thermostat;

public record UpdateThermostatTemperatureCommand(
    int Id,
    double? Temperature);