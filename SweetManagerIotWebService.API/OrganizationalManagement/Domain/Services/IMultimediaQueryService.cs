using SweetManagerIotWebService.API.OrganizationalManagement.Domain.Model.Entities;
using SweetManagerIotWebService.API.OrganizationalManagement.Domain.Model.Queries;

namespace SweetManagerIotWebService.API.OrganizationalManagement.Domain.Services
{
    public interface IMultimediaQueryService
    {
        Task<IEnumerable<Multimedia>> Handle(GetAllDetailMultimediaByHotelIdQuery query);

        Task<Multimedia?> Handle(GetMainMultimediaByHotelIdQuery query);

        Task<Multimedia?> Handle(GetLogoMultimediaByHotelIdQuery query);
    }
}