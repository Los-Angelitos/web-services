namespace SweetManagerIotWebService.API.Reservations.Interfaces.REST.Resources.Thermostat;

public record UpdateThermostatTemperatureResource(
    int Id,
    double? Temperature);