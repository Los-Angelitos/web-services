using SweetManagerIotWebService.API.Reservations.Domain.Model.Commands.Room;
using SweetManagerIotWebService.API.Reservations.Interfaces.REST.Resources.Room;

namespace SweetManagerIotWebService.API.Reservations.Interfaces.REST.Transform.Room
{
    public static class BulkRoomsCommandFromResourceAssembler
    {
        public static BulkRoomsCommand ToCommandFromResource(BulkRoomsResource resource)
        {
            return new BulkRoomsCommand(resource.Count,resource.TypeRoomId, resource.HotelId);
        }
    }
}
