using SweetManagerIotWebService.API.Reservations.Domain.Model.Aggregates;
using SweetManagerIotWebService.API.Reservations.Domain.Model.Commands.Thermostat;
using SweetManagerIotWebService.API.Reservations.Domain.Repositories;
using SweetManagerIotWebService.API.Reservations.Domain.Services.Thermostat;
using SweetManagerIotWebService.API.Shared.Domain.Repositories;

namespace SweetManagerIotWebService.API.Reservations.Application.Internal.CommandServices;

public class ThermostatCommandService(IThermostatRepositoy thermostatRepositoy, IUnitOfWork unitOfWork) : IThermostatCommandService
{
    
    IThermostatRepositoy _thermostatRepositoy = thermostatRepositoy;
    IUnitOfWork _unitOfWork = unitOfWork;
    
    public async Task<bool> Handle(CreateThermostatCommand command)
    {
        if (command.RoomId is null)
            throw new ArgumentException("RoomId is required.");
        if (command.Temperature is null)
            throw new ArgumentException("Temperature is required.");
        if (command.IpAddress is null)
            throw new ArgumentException("IpAddress is required.");
        if (command.State is null)
            throw new ArgumentException("State is required.");
       

        var thermostat = new Thermostat(command);
        await _thermostatRepositoy.AddAsync(thermostat);
        await _unitOfWork.CommitAsync();

        return true;
    }
    
    public async Task<bool> Handle(UpdateThermostatStateCommand command)
    {
        if (command.State is null)
            throw new ArgumentException("State is required.");
        
        try
        {
            await _thermostatRepositoy.UpdateThermostatState(command.Id, command.State);
            return true; 
        }
        catch (Exception e)
        {
            return false;
        }
    }
    
    public async Task<bool> Handle(UpdateThermostatTemperatureCommand command)
    {
        if (command.Temperature is null)
            throw new ArgumentException("Temperature is required.");
        try
        {
            await _thermostatRepositoy.UpdateThermostatTemperature(command.Id, command.Temperature);
            return true; 
        }
        catch (Exception e)
        {
            return false;
        }
    }
    
    public async Task<bool> Handle(UpdateThermostatCommand command)
    {
        if (command.RoomId is null)
            throw new ArgumentException("RoomId is required.");
        if (command.Temperature is null)
            throw new ArgumentException("Temperature is required.");
        if (command.IpAddress is null)
            throw new ArgumentException("IpAddress is required.");
        if (command.State is null)
            throw new ArgumentException("State is required.");

        var thermostat = new Thermostat(command);
        await _thermostatRepositoy.UpdateThermostat(thermostat.Id, thermostat.RoomId, thermostat.IpAddress, thermostat.MacAddress, thermostat.Temperature, thermostat.State, thermostat.LastUpdate);
        await _unitOfWork.CommitAsync();

        return true;
    }
}