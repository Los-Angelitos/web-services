﻿namespace SweetManagerIotWebService.API.Reservations.Domain.Model.Commands.Thermostat;

public record CreateThermostatCommand(
    int? RoomId,
    double? Temperature,
    string? IpAddress,
    string? MacAddress,
    string? State,
    DateTime? LastUpdate);