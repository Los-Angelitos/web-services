using SweetManagerIotWebService.API.OrganizationalManagement.Application.Internal.OutboundServices.ACL;
using SweetManagerIotWebService.API.OrganizationalManagement.Domain.Model.Queries;
using SweetManagerIotWebService.API.OrganizationalManagement.Domain.Services;

namespace SweetManagerIotWebService.API.OrganizationalManagement.Interfaces.ACL.Services
{
    public class OrganizationManagementContextFacade(IHotelQueryService hotelQueryService, ExternalIamService externalIamService) : IOrganizationManagementContextFacade
    {
        public async Task<int> FetchOwnerIdByHotelId(int hotelId)
        {
            try
            {
                var hotel = await hotelQueryService.Handle(new GetHotelByIdQuery(hotelId));

                if (hotel is null) return 0;

                return hotel.OwnerId;
            }
            catch(Exception)
            {
                return 0;
            }
        }
    }
}
