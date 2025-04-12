using SweetManagerIotWebService.API.IAM.Domain.Model.Aggregates;
using SweetManagerIotWebService.API.IAM.Domain.Model.Queries.Users;

namespace SweetManagerIotWebService.API.IAM.Domain.Services.QueryServices.Users
{
    public interface IOwnerQueryService
    {
        Task<IEnumerable<Owner>> Handle(GetAllUsersQuery query);

        Task<Owner?> Handle(GetUserByIdQuery query);

        Task<Owner?> Handle(GetOwnerFromAnOrganizationQuery query);
        
    }
}