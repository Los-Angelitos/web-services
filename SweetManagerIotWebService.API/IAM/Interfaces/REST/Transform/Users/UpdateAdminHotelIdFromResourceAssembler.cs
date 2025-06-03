using SweetManagerIotWebService.API.IAM.Domain.Model.Commands.Authentication;
using SweetManagerIotWebService.API.IAM.Interfaces.REST.Resources.Users;

namespace SweetManagerIotWebService.API.IAM.Interfaces.REST.Transform.Users
{
    public static class UpdateAdminHotelIdFromResourceAssembler
    {
        public static UpdateAdminHotelIdCommand ToCommandFromResource(UpdateAdminHotelIdResource resource, int id)
        {
            return new UpdateAdminHotelIdCommand(id, resource.HotelId);
        }
    }
}