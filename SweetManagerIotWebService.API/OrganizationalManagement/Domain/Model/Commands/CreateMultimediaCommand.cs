using SweetManagerIotWebService.API.OrganizationalManagement.Domain.Model.ValueObjects;

namespace SweetManagerIotWebService.API.OrganizationalManagement.Domain.Model.Commands
{
    public record CreateMultimediaCommand(int HotelId, string? Url, string Type, int Position);

}