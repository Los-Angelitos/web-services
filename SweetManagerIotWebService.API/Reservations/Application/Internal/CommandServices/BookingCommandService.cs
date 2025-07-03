using SweetManagerIotWebService.API.Reservations.Application.Internal.OutboundServices.ACL;
using SweetManagerIotWebService.API.Reservations.Domain.Model.Aggregates;
using SweetManagerIotWebService.API.Reservations.Domain.Model.Commands.Booking;
using SweetManagerIotWebService.API.Reservations.Domain.Repositories;
using SweetManagerIotWebService.API.Reservations.Domain.Services.Booking;
using SweetManagerIotWebService.API.Shared.Domain.Repositories;

namespace SweetManagerIotWebService.API.Reservations.Application.Internal.CommandServices;

public class BookingCommandService(IBookingRepository bookingRepository, IUnitOfWork unitOfWork,
        IRoomRepository roomRepository, IThermostatRepository thermostatRepository, ExternalIAMService externalIAMService) : IBookingCommandServices
{

    public async Task<bool> Handle(CreateBookingCommand command)
    {
        var booking = new Booking(command);

        await bookingRepository.AddAsync(booking);

        await roomRepository.UpdateRoomStateAsync(command.RoomId, "INACTIVE");

        var temperature = await externalIAMService.FetchGuestPreferenceById(command.PreferenceId);

        var thermostats = await thermostatRepository.FindByRoomIdAsync(command.RoomId);

        foreach(var device in thermostats)
        {
            await thermostatRepository.UpdateThermostatTemperature(device.Id, temperature!.Value);
        }

        await unitOfWork.CommitAsync();
        
        return true;
    }
    
    public async Task<bool> Handle(UpdateBookingStateCommand command)
    {
        try
        {
            await bookingRepository.UpdateBookingStateAsync(command.Id, command.State);
            return true; 
        }
        catch (Exception e)
        {
            return false;
        }
    }
    
    public async Task<bool> Handle(UpdateBookingEndDateCommand command)
    {
        try
        {
            await bookingRepository.UpdateBookingEndDateAsync(command.Id, command.EndDate);
            return true; 
        }
        catch (Exception e)
        {
            return false;
        }
    }
}