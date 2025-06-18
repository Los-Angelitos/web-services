using SweetManagerIotWebService.API.Inventory.Domain.Model.Aggregates;
using SweetManagerIotWebService.API.Inventory.Interfaces.REST.Resources;

namespace SweetManagerIotWebService.API.Inventory.Interfaces.REST.Transform;

public static class RfidCardResourceFromEntityAssembler
{
    public static RfidCardResource ToResourceFromEntity(RfidCard rfidCard)
    {
        return new RfidCardResource(
            rfidCard.Id,
            rfidCard.RoomId,
            rfidCard.apiKey,
            rfidCard.uId);
    }
}