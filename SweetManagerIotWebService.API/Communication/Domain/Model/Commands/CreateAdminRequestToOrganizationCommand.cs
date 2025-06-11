namespace SweetManagerIotWebService.API.Communication.Domain.Model.Commands
{
    public record CreateAdminRequestToOrganizationCommand(int AdminId, string AdditionalMessage, int HotelId);
}