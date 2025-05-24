namespace SweetManagerIotWebService.API.Reservations.Interfaces.REST.Resources.Thermostat;

public record UpdateThermostatStateResource(
    int Id,
    string? State);