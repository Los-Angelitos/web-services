using SweetManagerIotWebService.API.OrganizationalManagement.Domain.Model.Commands;
using SweetManagerIotWebService.API.OrganizationalManagement.Interfaces.REST.Resources;

namespace SweetManagerIotWebService.API.OrganizationalManagement.Interfaces.REST.Transform
{
    public static class UpdateMultimediaCommandFromResourceAssembler
    {
        public static UpdateMultimediaCommand ToCommandFromResource(UpdateMultimediaResource resource)
        => new UpdateMultimediaCommand(resource.Id,resource.HotelId, resource.Url, resource.Type, resource.Position);
    }
}