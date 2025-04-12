using SweetManagerIotWebService.API.Commerce.Domain.Model.Entities;
using SweetManagerIotWebService.API.Commerce.Domain.Model.Queries;

namespace SweetManagerIotWebService.API.Commerce.Domain.Services;

public interface IContractOwnerQueryService
{
    Task<IEnumerable<ContractOwner>> Handle(GetAllContractOwnersQuery query);
    Task<ContractOwner?> Handle(GetContractOwnerByIdQuery query);
    Task<IEnumerable<ContractOwner>> Handle(GetContractOwnerByOwnerIdQuery query);
    Task<IEnumerable<ContractOwner>> Handle(GetContractOwnerBySubscriptionIdQuery query);
}