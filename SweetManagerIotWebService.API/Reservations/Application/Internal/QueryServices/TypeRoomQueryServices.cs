using SweetManagerIotWebService.API.Reservations.Domain.Model.Entities;
using SweetManagerIotWebService.API.Reservations.Domain.Model.Queries;
using SweetManagerIotWebService.API.Reservations.Domain.Repositories;
using SweetManagerIotWebService.API.Reservations.Domain.Services.TypeRoom;

namespace SweetManagerIotWebService.API.Reservations.Application.Internal.QueryServices;

public class TypeRoomQueryServices(ITypeRoomRepository typeRoomRepository) : ITypeRoomQueryService
{
    public Task<IEnumerable<TypeRoom>> Handle(GetAllTypeRoomsQuery query)
    {
        return typeRoomRepository.FindAllByHotelIdAsync(query.HotelId);
    }

    public Task<TypeRoom?> Handle(GetTypeRoomByIdQuery query)
    {
        return typeRoomRepository.FindByIdAsync(query.Id);
    }
    
    public async Task<decimal?> Handle(GetMinimumPriceTypeRoomByHotelId query)
    {
        var typeRooms = await typeRoomRepository.FindAllByHotelIdAsync(query.hotelId);
        return typeRooms.Min(tr => tr.Price);
    }

}