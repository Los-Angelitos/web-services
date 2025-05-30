using SweetManagerIotWebService.API.Reservations.Domain.Model.Aggregates;
using SweetManagerIotWebService.API.Reservations.Domain.Model.Queries;
using SweetManagerIotWebService.API.Reservations.Domain.Repositories;
using SweetManagerIotWebService.API.Reservations.Domain.Services.SmokeSensor;

namespace SweetManagerIotWebService.API.Reservations.Application.Internal.QueryServices;

public class SmokeSensorQueryService : ISmokeSensorQueryServices
{
    private readonly ISmokeSensorRepositoy _smokesensorRepositoy;

    public SmokeSensorQueryService(ISmokeSensorRepositoy SmokeSensorRepositoy)
    {
        _smokesensorRepositoy = SmokeSensorRepositoy;
    }

    public async Task<SmokeSensor?> Handle(GetSmokeSensorByIdQuery query)
    {
        return await _smokesensorRepositoy.FindByIdAsync(query.id);
    }

    public async Task<IEnumerable<SmokeSensor>> Handle(GetSmokeSensorByRoomIdQuery query)
    {
        
        return await _smokesensorRepositoy.FindByRoomIdAsync(query.roomId);
    }

    public async Task<IEnumerable<SmokeSensor>> Handle(GetAllSmokeSensorsByHotelIdQuery query)
    {
        return await _smokesensorRepositoy.FindAllSmokeSensors(query.HotelId);
    }
}