namespace SweetManagerIotWebService.API.Inventory.Domain.Model.Commands;

public record CreateRfidCardCommand(int? RoomId, string? apiKey, string? uId);