namespace SweetManagerIotWebService.API.OrganizationalManagement.Domain.Model.Commands
{
    public record CreateFogServerCommand(string IpAddress, string SubnetMask, int HotelId);

}