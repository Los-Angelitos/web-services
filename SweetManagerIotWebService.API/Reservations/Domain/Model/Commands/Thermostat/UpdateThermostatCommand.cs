namespace SweetManagerIotWebService.API.Reservations.Domain.Model.Commands.Thermostat;

public record UpdateThermostatCommand(
    int Id,
    int? RoomId,
    double? Temperature,
    string? IpAddress,
    string? MacAddress,
    string? State,
    DateTime? LastUpdate);
