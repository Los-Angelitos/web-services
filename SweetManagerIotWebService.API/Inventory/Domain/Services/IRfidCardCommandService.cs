using SweetManagerIotWebService.API.Inventory.Domain.Model.Aggregates;
using SweetManagerIotWebService.API.Inventory.Domain.Model.Commands;

namespace SweetManagerIotWebService.API.Inventory.Domain.Services;

public interface IRfidCardCommandService
{
    Task<RfidCard?> Handle(CreateRfidCardCommand command);
}