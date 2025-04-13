using SweetManagerIotWebService.API.OrganizationalManagement.Domain.Model.Commands;
using SweetManagerIotWebService.API.OrganizationalManagement.Domain.Repositories;
using SweetManagerIotWebService.API.OrganizationalManagement.Domain.Services;
using SweetManagerIotWebService.API.Shared.Domain.Repositories;

namespace SweetManagerIotWebService.API.OrganizationalManagement.Application.Internal.CommandServices;

public class HotelCommandService(IHotelRepository hotelRepository, IUnitOfWork unitOfWork) : IHotelCommandService
{
    public async Task<Hotel?> Handle(CreateHotelCommand command)
    {
        var hotel = new Hotel(command);
        try
        {
            await hotelRepository.AddAsync(hotel);
            await unitOfWork.CommitAsync();
            return hotel;
        }catch (Exception ex)
        {
            Console.WriteLine($"Error creating hotel: {ex.Message}");
            return null;
        }
        
    }
}