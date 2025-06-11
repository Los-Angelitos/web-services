namespace SweetManagerIotWebService.API.Communication.Interfaces.REST.Resources
{
    public record CreateAdminRequestToOrganizationResource(int AdminId, string AdditionalMessage, int HotelId);
}
