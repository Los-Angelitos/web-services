using SweetManagerIotWebService.API.OrganizationalManagement.Domain.Model.Entities;
using SweetManagerIotWebService.API.OrganizationalManagement.Domain.Model.Queries;
using SweetManagerIotWebService.API.OrganizationalManagement.Domain.Repositories;
using SweetManagerIotWebService.API.OrganizationalManagement.Domain.Services;

namespace SweetManagerIotWebService.API.OrganizationalManagement.Application.Internal.QueryServices
{
    public class FogServerQueryService(IFogServerRepository fogServerRepository) : IFogServerQueryService
    {
        public async Task<FogServer?> Handle(GetFogServerByHotelIdQuery query)
         => await fogServerRepository.FindByHotelIdAsync(query.HotelId);

        public async Task<FogServer?> Handle(GetFogServerByIdQuery query)
         => await fogServerRepository.FindByIdAsync(query.Id);

    }
}
