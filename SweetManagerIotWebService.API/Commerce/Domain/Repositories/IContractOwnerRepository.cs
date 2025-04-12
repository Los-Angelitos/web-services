using SweetManagerIotWebService.API.Commerce.Domain.Model.Entities;

namespace SweetManagerIotWebService.API.Commerce.Domain.Repositories;

public interface IContractOwnerRepository
{
    Task<IEnumerable<ContractOwner>> FindByOwnerIdAsync(int ownerId);
    
    Task<IEnumerable<ContractOwner>> FindBySubscriptionIdAsync(int subscriptionId);
}