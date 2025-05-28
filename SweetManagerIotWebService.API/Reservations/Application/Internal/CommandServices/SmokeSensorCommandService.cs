using SweetManagerIotWebService.API.Reservations.Domain.Model.Aggregates;
using SweetManagerIotWebService.API.Reservations.Domain.Model.Commands.SmokeSensor;
using SweetManagerIotWebService.API.Reservations.Domain.Model.Commands.SmokeSensor;
using SweetManagerIotWebService.API.Reservations.Domain.Repositories;
using SweetManagerIotWebService.API.Reservations.Domain.Services.SmokeSensor;
using SweetManagerIotWebService.API.Reservations.Domain.Services.SmokeSensor;
using SweetManagerIotWebService.API.Shared.Domain.Repositories;

namespace SweetManagerIotWebService.API.Reservations.Application.Internal.CommandServices;

public class SmokeSensorCommandService(ISmokeSensorRepositoy SmokeSensorRepositoy, IUnitOfWork unitOfWork) : ISmokeSensorCommandService
{
    
    ISmokeSensorRepositoy _SmokeSensorRepositoy = SmokeSensorRepositoy;
    IUnitOfWork _unitOfWork = unitOfWork;
    
    public async Task<bool> Handle(CreateSmokeSensorCommand command)
    {
        if (command.RoomId is null)
            throw new ArgumentException("RoomId is required.");
        if (command.LastAnalogicValue is null)
            throw new ArgumentException("LastAnalogicValue is required.");
        if (command.IpAddress is null)
            throw new ArgumentException("IpAddress is required.");
        if (command.State is null)
            throw new ArgumentException("State is required.");
       

        var SmokeSensor = new SmokeSensor(command);
        await _SmokeSensorRepositoy.AddAsync(SmokeSensor);
        await _unitOfWork.CommitAsync();

        return true;
    }
    
    public async Task<bool> Handle(UpdateSmokeSensorStateCommand command)
    {
        if (command.State is null)
            throw new ArgumentException("State is required.");
        
        try
        {
            await _SmokeSensorRepositoy.UpdateSmokeSensorState(command.Id, command.State);
            return true; 
        }
        catch (Exception e)
        {
            return false;
        }
    }
    
    public async Task<bool> Handle(UpdatSmokeSensorAnalogicValueCommand command)
    {
        if (command.LastAnalogicValue is null)
            throw new ArgumentException("LastAnalogicValue is required.");
        
        try
        {
            await _SmokeSensorRepositoy.UpdateSmokeSensorAnalogicValue(command.Id, command.LastAnalogicValue);
            return true; 
        }
        catch (Exception e)
        {
            return false;
        }
    }
    public async Task<bool> Handle(UpdateSmokeSensorCommand command)
    {
        if (command.RoomId is null)
            throw new ArgumentException("RoomId is required.");
        if (command.State is null)
            throw new ArgumentException("State is required.");

        var smokesensor = new SmokeSensor(command);
        await _SmokeSensorRepositoy.UpdateSmokeSensor(smokesensor.Id, smokesensor.RoomId, smokesensor.IpAddress, smokesensor.MacAddress, smokesensor.LastAnalogicValue, smokesensor.State, smokesensor.LastAlertTime);
        await _unitOfWork.CommitAsync();

        return true;
    }
}