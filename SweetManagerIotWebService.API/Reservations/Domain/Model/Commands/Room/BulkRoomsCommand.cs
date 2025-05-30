namespace SweetManagerIotWebService.API.Reservations.Domain.Model.Commands.Room
{
    public record BulkRoomsCommand(int Count, int RoomTypeId, int HotelId);
}
