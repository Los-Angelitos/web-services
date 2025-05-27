namespace SweetManagerIotWebService.API.OrganizationalManagement.Interfaces.REST.Resources
{
    public record UpdateMultimediaResource(int Id, int HotelId, string? Url, string Type, int Position);
}