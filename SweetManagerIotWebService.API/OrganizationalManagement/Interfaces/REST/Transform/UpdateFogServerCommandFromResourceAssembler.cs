using SweetManagerIotWebService.API.OrganizationalManagement.Domain.Model.Commands;
using SweetManagerIotWebService.API.OrganizationalManagement.Interfaces.REST.Resources;

namespace SweetManagerIotWebService.API.OrganizationalManagement.Interfaces.REST.Transform
{
    public static class UpdateFogServerCommandFromResourceAssembler
    {
        public static UpdateFogServerCommand ToCommandFromResource(int Id, UpdateFogServerResource resource)
        {
            return new UpdateFogServerCommand(Id, resource.IpAddress, resource.SubnetMask);
        }
    }
}
