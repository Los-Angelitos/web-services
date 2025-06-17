using SweetManagerIotWebService.API.OrganizationalManagement.Domain.Model.Entities;
using SweetManagerIotWebService.API.OrganizationalManagement.Interfaces.REST.Resources;

namespace SweetManagerIotWebService.API.OrganizationalManagement.Interfaces.REST.Transform
{
    public static class FogServerResourceFromEntityAssembler
    {
        public static FogServerResource? ToResourceFromEntity(FogServer entity)
        {
            return new FogServerResource(entity.Id, entity.IpAddress, entity.SubnetMask, entity.HotelId);
        }
    }
}
