namespace SweetManagerIotWebService.API.Reservations.Domain.Model.Queries;

public record GetAllRoomsByBookingAvailabilityInARangeQuery(DateTime Start, DateTime End);