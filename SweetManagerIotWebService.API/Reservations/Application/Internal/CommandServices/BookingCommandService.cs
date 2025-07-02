using SweetManagerIotWebService.API.Reservations.Domain.Model.Commands.Booking;
using SweetManagerIotWebService.API.Reservations.Domain.Repositories;
using SweetManagerIotWebService.API.Reservations.Domain.Services.Booking;
using SweetManagerIotWebService.API.Shared.Domain.Repositories;

namespace SweetManagerIotWebService.API.Reservations.Application.Internal.CommandServices;

public class BookingCommandService(IBookingRepository bookingRepository, IUnitOfWork unitOfWork,
        IRoomRepository roomRepository) : IBookingCommandServices
{

    public async Task<bool> Handle(CreateBookingCommand command)
    {
        var booking = new Booking(command);
        
        await bookingRepository.AddAsync(booking);

        await roomRepository.UpdateRoomStateAsync(command.RoomId, "INACTIVE");
        
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