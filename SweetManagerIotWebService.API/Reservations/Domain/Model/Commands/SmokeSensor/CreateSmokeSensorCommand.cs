namespace SweetManagerIotWebService.API.Reservations.Domain.Model.Commands.SmokeSensor;

public record CreateSmokeSensorCommand(
    int? RoomId,
    double? LastAnalogicValue,
    string? IpAddress,
    string? MacAddress,
    string? State,
    DateTime? LastAlertTime);