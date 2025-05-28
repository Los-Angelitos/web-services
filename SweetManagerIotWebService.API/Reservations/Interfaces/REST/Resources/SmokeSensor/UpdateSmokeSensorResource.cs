namespace SweetManagerIotWebService.API.Reservations.Interfaces.REST.Resources.SmokeSensor;

public record UpdateSmokeSensorResource(
    int Id,
    int? RoomId,
    string? IpAddress,
    string? MacAddress,
    double? LastAnalogicValue,
    string? State,
    DateTime? LastAlertTime);