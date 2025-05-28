namespace SweetManagerIotWebService.API.Reservations.Interfaces.REST.Resources.SmokeSensor;

public record UpdateSmokeSensorAnalogicValueResource(
    int Id,
    double? LastAnalogicValue);