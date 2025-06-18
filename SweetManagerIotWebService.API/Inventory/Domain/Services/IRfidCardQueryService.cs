using SweetManagerIotWebService.API.Inventory.Domain.Model.Aggregates;
using SweetManagerIotWebService.API.Inventory.Domain.Model.Queries.RFID;

namespace SweetManagerIotWebService.API.Inventory.Domain.Services;

public interface IRfidCardQueryService
{
    Task<IEnumerable<RfidCard>> Handle(GetAllRfidCardsQuery query);
    Task<RfidCard?> Handle(GetRfidCardByIdQuery query);
}