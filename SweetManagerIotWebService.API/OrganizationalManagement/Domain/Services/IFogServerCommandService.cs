using SweetManagerIotWebService.API.OrganizationalManagement.Domain.Model.Commands;
using SweetManagerIotWebService.API.OrganizationalManagement.Domain.Model.Entities;

namespace SweetManagerIotWebService.API.OrganizationalManagement.Domain.Services
{
    public interface IFogServerCommandService
    {
        Task<FogServer?> Handle(CreateFogServerCommand command);

        Task<FogServer?> Handle(UpdateFogServerCommand command);

    }
}
