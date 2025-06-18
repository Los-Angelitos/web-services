using SweetManagerIotWebService.API.Inventory.Domain.Model.Commands;
using SweetManagerIotWebService.API.Inventory.Interfaces.REST.Resources;

namespace SweetManagerIotWebService.API.Inventory.Interfaces.REST.Transform;

public static class CreateRfidCardCommandFromResourceAssembler
{
    public static CreateRfidCardCommand ToCommandFromResource(CreateRfidCardResource resource)
    {
        return new CreateRfidCardCommand(
            resource.RoomId,
            resource.ApiKey,
            resource.UId);
    }
}