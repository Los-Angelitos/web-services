using SweetManagerIotWebService.API.OrganizationalManagement.Domain.Model.Commands;
using SweetManagerIotWebService.API.OrganizationalManagement.Domain.Model.Entities;

namespace SweetManagerIotWebService.API.OrganizationalManagement.Domain.Services
{
    public interface IMultimediaCommandService
    {
        Task<Multimedia?> Handle(CreateMultimediaCommand command);

        Task<Multimedia?> Handle(UpdateMultimediaCommand command);
    }
}