using Microsoft.EntityFrameworkCore;
using SweetManagerIotWebService.API.OrganizationalManagement.Domain.Model.Entities;
using SweetManagerIotWebService.API.OrganizationalManagement.Domain.Repositories;
using SweetManagerIotWebService.API.Shared.Infrastructure.Persistence.EFC.Configuration;
using SweetManagerIotWebService.API.Shared.Infrastructure.Persistence.EFC.Repositories;

namespace SweetManagerIotWebService.API.OrganizationalManagement.Infrastructure.Persistence.EFC.Repositories
{
    public class MultimediaRepository(SweetManagerContext context) : BaseRepository<Multimedia>(context),
        IMultimediaRepository
    {
        public async Task<IEnumerable<Multimedia>> FindAllDetailsByHotelId(int hotelId)
        => await Context.Set<Multimedia>().Where(m => m.HotelId.Equals(hotelId) && 
        m.Type == Domain.Model.ValueObjects.ETypeMultimedia.DETAIL).ToListAsync();


        public async Task<Multimedia?> FindMainByHotelId(int hotelId)
        => await Context.Set<Multimedia>().Where(m => m.HotelId.Equals(hotelId) && 
        m.Type == Domain.Model.ValueObjects.ETypeMultimedia.MAIN).FirstOrDefaultAsync();
        
        public async Task<Multimedia?> FindLogoByHotelId(int hotelId)
        => await Context.Set<Multimedia>().Where(m => m.HotelId.Equals(hotelId) && 
        m.Type == Domain.Model.ValueObjects.ETypeMultimedia.LOGO).FirstOrDefaultAsync();
    }
}