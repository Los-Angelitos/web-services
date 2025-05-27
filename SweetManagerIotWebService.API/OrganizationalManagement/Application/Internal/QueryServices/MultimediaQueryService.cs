using SweetManagerIotWebService.API.OrganizationalManagement.Domain.Model.Entities;
using SweetManagerIotWebService.API.OrganizationalManagement.Domain.Model.Queries;
using SweetManagerIotWebService.API.OrganizationalManagement.Domain.Repositories;
using SweetManagerIotWebService.API.OrganizationalManagement.Domain.Services;

namespace SweetManagerIotWebService.API.OrganizationalManagement.Application.Internal.QueryServices
{
    public class MultimediaQueryService(IMultimediaRepository multimediaRepository) : IMultimediaQueryService
    {
        public async Task<IEnumerable<Multimedia>> Handle(GetAllDetailMultimediaByHotelIdQuery query)
        => await multimediaRepository.FindAllDetailsByHotelId(query.HotelId);

        public async Task<Multimedia?> Handle(GetMainMultimediaByHotelIdQuery query)
        => await multimediaRepository.FindMainByHotelId(query.HotelId);

    }
}
