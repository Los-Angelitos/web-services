using SweetManagerIotWebService.API.OrganizationalManagement.Domain.Model.ValueObjects;

namespace SweetManagerIotWebService.API.OrganizationalManagement.Domain.Model.Commands
{
    public record UpdateMultimediaCommand(int Id, int HotelId, string? Url, string Type, int Position);
}