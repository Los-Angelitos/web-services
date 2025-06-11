using SweetManagerIotWebService.API.Communication.Domain.Model.Commands;
using SweetManagerIotWebService.API.Communication.Interfaces.REST.Resources;

namespace SweetManagerIotWebService.API.Communication.Interfaces.REST.Transform
{
    public static class CreateAdminRequestCommandFromResourceAssembler
    {
        public static CreateAdminRequestToOrganizationCommand ToCommandFromResource(CreateAdminRequestToOrganizationResource resource)
        {
            return new CreateAdminRequestToOrganizationCommand(resource.AdminId, resource.AdditionalMessage, resource.HotelId);
        }
    }
}
