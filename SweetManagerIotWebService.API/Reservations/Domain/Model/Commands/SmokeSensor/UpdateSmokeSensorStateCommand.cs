namespace SweetManagerIotWebService.API.Reservations.Domain.Model.Commands.SmokeSensor;

public record UpdateSmokeSensorStateCommand(
    int Id,
    string? State);