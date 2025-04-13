using SweetManagerIotWebService.API.OrganizationalManagement.Domain.Model.Aggregates;
using SweetManagerIotWebService.API.OrganizationalManagement.Domain.Model.Queries;
using SweetManagerIotWebService.API.OrganizationalManagement.Domain.Repositories;
using SweetManagerIotWebService.API.OrganizationalManagement.Domain.Services;

namespace SweetManagerIotWebService.API.OrganizationalManagement.Application.Internal.QueryServices;

public class ProviderQueryService(IProviderRepository providerRepository) : IProviderQueryService
{
    public async Task<Provider?> Handle(GetProviderByIdQuery query)
    {
        return await providerRepository.FindByIdAsync(query.providerId);
    }
}