using SweetManagerIotWebService.API.IAM.Domain.Model.Aggregates;
using SweetManagerIotWebService.API.IAM.Domain.Model.Queries.Users;
using SweetManagerIotWebService.API.IAM.Domain.Services.CommandServices.Users;
using SweetManagerIotWebService.API.IAM.Domain.Services.QueryServices.Users;

namespace SweetManagerIotWebService.API.IAM.Interfaces.ACL.Services
{
    public class IamContextFacade(IAdminQueryService adminQueryService, IOwnerQueryService ownerQueryService) : IIamContextFacade
    {
        public async Task<Admin?> FetchAdminByUserId(int id)
        {
            try
            {
                var admin = await adminQueryService.Handle(new GetUserByIdQuery(id));

                return admin;
            }
            catch(Exception)
            {
                return null;
            }
        }

        public async Task<Owner?> FetchOwnerByUserId(int id)
        {
            try
            {
                var owner = await ownerQueryService.Handle(new GetUserByIdQuery(id));

                return owner;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
