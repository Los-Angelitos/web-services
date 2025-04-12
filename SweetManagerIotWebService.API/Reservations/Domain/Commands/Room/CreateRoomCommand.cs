using SweetManagerIotWebService.API.Reservations.Domain.Model.Entities;

namespace SweetManagerIotWebService.API.Reservations.Domain.Commands.Room;

public record CreateRoomCommand(
    int Id, int? TypeRoomId, 
    int? HotelId, string? State, ICollection<Booking> Bookings, Hotel? Hotel, TypeRoom? TypeRoom);