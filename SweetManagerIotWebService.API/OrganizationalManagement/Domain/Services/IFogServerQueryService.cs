using SweetManagerIotWebService.API.OrganizationalManagement.Domain.Model.Entities;
using SweetManagerIotWebService.API.OrganizationalManagement.Domain.Model.Queries;

namespace SweetManagerIotWebService.API.OrganizationalManagement.Domain.Services
{
    public interface IFogServerQueryService
    {
        Task<FogServer?> Handle(GetFogServerByHotelIdQuery query);

        Task<FogServer?> Handle(GetFogServerByIdQuery query);

    }
}
