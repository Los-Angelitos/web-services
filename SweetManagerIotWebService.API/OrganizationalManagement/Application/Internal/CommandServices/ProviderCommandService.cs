using SweetManagerIotWebService.API.OrganizationalManagement.Domain.Model.Aggregates;
using SweetManagerIotWebService.API.OrganizationalManagement.Domain.Model.Commands;
using SweetManagerIotWebService.API.OrganizationalManagement.Domain.Repositories;
using SweetManagerIotWebService.API.OrganizationalManagement.Domain.Services;
using SweetManagerIotWebService.API.Shared.Domain.Repositories;

namespace SweetManagerIotWebService.API.OrganizationalManagement.Application.Internal.CommandServices;

public class ProviderCommandService(IProviderRepository providerRepository, IUnitOfWork unitOfWork) : IProviderCommandService
{
    public async Task<Provider?> Handle(CreateProviderCommand command)
    {
        var provider = new Provider(command);
        
        await providerRepository.AddAsync(provider);
        await unitOfWork.CommitAsync();
        return provider;
        
    }
}