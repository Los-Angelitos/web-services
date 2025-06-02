using SweetManagerIotWebService.API.OrganizationalManagement.Domain.Model.Entities;
using SweetManagerIotWebService.API.Shared.Domain.Repositories;

namespace SweetManagerIotWebService.API.OrganizationalManagement.Domain.Repositories
{
    public interface IMultimediaRepository : IBaseRepository<Multimedia>
    {
        Task<IEnumerable<Multimedia>> FindAllDetailsByHotelId(int hotelId);

        Task<Multimedia?> FindMainByHotelId(int hotelId);
        
        Task<Multimedia?> FindLogoByHotelId(int hotelId);
    }
}
