namespace SweetManagerIotWebService.API.Reservations.Interfaces.REST.Resources.SmokeSensor;

public record UpdateSmokeSensorStateResource(
    int Id,
    string? State);