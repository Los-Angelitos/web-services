using SweetManagerIotWebService.API.OrganizationalManagement.Domain.Model.Commands;
using SweetManagerIotWebService.API.OrganizationalManagement.Interfaces.REST.Resources;

namespace SweetManagerIotWebService.API.OrganizationalManagement.Interfaces.REST.Transform
{
    public static class CreateFogServerCommandFromResourceAssembler
    {
        public static CreateFogServerCommand ToCommandFromResource(CreateFogServerResource resource)
        {
            return new CreateFogServerCommand(resource.IpAddress, resource.SubnetMask, resource.HotelId);
        }
    }
}
