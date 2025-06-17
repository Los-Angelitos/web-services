namespace SweetManagerIotWebService.API.OrganizationalManagement.Interfaces.REST.Resources
{
    public record CreateFogServerResource(string IpAddress, string SubnetMask, int HotelId);
}