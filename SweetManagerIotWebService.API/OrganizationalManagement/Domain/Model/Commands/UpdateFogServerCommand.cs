namespace SweetManagerIotWebService.API.OrganizationalManagement.Domain.Model.Commands
{
    public record UpdateFogServerCommand(int Id, string IpAddress, string SubnetMask, int HotelId);

}