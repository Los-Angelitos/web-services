namespace SweetManagerIotWebService.API.Reservations.Domain.Model.Commands.SmokeSensor;

public record UpdatSmokeSensorAnalogicValueCommand(
    int Id,
    double? LastAnalogicValue);