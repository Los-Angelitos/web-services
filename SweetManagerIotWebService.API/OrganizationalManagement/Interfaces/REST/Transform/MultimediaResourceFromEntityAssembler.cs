using SweetManagerIotWebService.API.OrganizationalManagement.Domain.Model.Entities;
using SweetManagerIotWebService.API.OrganizationalManagement.Interfaces.REST.Resources;

namespace SweetManagerIotWebService.API.OrganizationalManagement.Interfaces.REST.Transform
{
    public static class MultimediaResourceFromEntityAssembler
    {
        public static MultimediaResource ToResourceFromEntity(Multimedia entity)
        => new MultimediaResource(entity.Id, entity.HotelId, entity.Url, entity.Type.ToString(), entity.Position);
    }
}