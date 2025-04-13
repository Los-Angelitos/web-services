using SweetManagerIotWebService.API.OrganizationalManagement.Domain.Model.Commands;
using SweetManagerIotWebService.API.OrganizationalManagement.Interfaces.REST.Resources;

namespace SweetManagerIotWebService.API.OrganizationalManagement.Interfaces.REST.Transform;

public class CreateHotelCommandFromResourceAssembler
{
    public static CreateHotelCommand ToCommandFromResource(CreateHotelResource resource)
    {
        return new CreateHotelCommand(resource.OwnerId, resource.Name, resource.Description, resource.Email, resource.Address, resource.Phone);
    }
}