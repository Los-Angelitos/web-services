namespace SweetManagerIotWebService.API.Reservations.Domain.Model.Commands.Thermostat;

public record UpdateThermostatStateCommand(
    int Id,
    string? State);