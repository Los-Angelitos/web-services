namespace SweetManagerIotWebService.API.Inventory.Interfaces.REST.Resources;

public record CreateRfidCardResource(int? RoomId, string? ApiKey, string? UId);