using SweetManagerIotWebService.API.OrganizationalManagement.Domain.Model.Aggregates;

namespace SweetManagerIotWebService.API.OrganizationalManagement.Interfaces.ACL
{
    public interface IOrganizationManagementContextFacade
    {
        Task<int> FetchOwnerIdByHotelId(int hotelId);

    }
}
