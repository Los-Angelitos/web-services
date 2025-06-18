namespace SweetManagerIotWebService.API.Inventory.Interfaces.REST.Resources;

public record RfidCardResource(int Id, int? RoomId, string? ApiKey, string? UId);