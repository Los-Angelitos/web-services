using SweetManagerIotWebService.API.OrganizationalManagement.Domain.Model.Commands;
using SweetManagerIotWebService.API.OrganizationalManagement.Interfaces.REST.Resources;

namespace SweetManagerIotWebService.API.OrganizationalManagement.Interfaces.REST.Transform
{
    public static class CreateMultimediaCommandFromResourceAssembler
    {
        public static CreateMultimediaCommand ToCommandFromResource(CreateMultimediaResource resource)
        => new CreateMultimediaCommand(resource.HotelId, resource.Url, resource.Type, resource.Position);
    }
}