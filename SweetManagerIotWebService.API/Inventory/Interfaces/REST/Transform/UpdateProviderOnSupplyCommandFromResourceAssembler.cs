using SweetManagerIotWebService.API.Inventory.Domain.Model.Commands;
using SweetManagerIotWebService.API.Inventory.Interfaces.REST.Resources;

namespace SweetManagerIotWebService.API.Inventory.Interfaces.REST.Transform
{
    public static class UpdateProviderOnSupplyCommandFromResourceAssembler
    {
        public static UpdateProviderOnSupplyCommand ToCommandFromResource(int id, UpdateProviderOnSupplyResource resource)
        {
            return new UpdateProviderOnSupplyCommand(id, resource.ProviderId);
        }
    }
}
