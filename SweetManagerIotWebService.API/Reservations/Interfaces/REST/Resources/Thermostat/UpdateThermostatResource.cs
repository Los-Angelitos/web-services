namespace SweetManagerIotWebService.API.Reservations.Interfaces.REST.Resources.Thermostat;

public record UpdateThermostatResource(
    int Id,
    int? RoomId,
    string? IpAddress,
    string? MacAddress,
    double? Temperature,
    string? State,
    DateTime? LastUpdate);