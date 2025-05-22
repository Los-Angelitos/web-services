namespace SweetManagerIotWebService.API.Reservations.Interfaces.REST.Resources.Thermostat;

public record CreateThermostatResource(
    int? RoomId,
    string? IpAddress,
    string? MacAddress,
    double? Temperature,
    string? State,
    DateTime? LastUpdate);