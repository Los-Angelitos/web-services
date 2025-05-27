namespace SweetManagerIotWebService.API.OrganizationalManagement.Interfaces.REST.Resources
{
    public record MultimediaResource(int Id, int HotelId, string? Url, string Type, int Position);
}