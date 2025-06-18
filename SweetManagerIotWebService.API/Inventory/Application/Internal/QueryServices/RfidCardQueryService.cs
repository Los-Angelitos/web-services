using SweetManagerIotWebService.API.Inventory.Domain.Model.Aggregates;
using SweetManagerIotWebService.API.Inventory.Domain.Model.Queries.RFID;
using SweetManagerIotWebService.API.Inventory.Domain.Repositories;
using SweetManagerIotWebService.API.Inventory.Domain.Services;

namespace SweetManagerIotWebService.API.Inventory.Application.Internal.QueryServices;

public class RfidCardQueryService(IRfidCardRepository rfidCardRepository) : IRfidCardQueryService
{
    public async Task<IEnumerable<RfidCard>> Handle(GetAllRfidCardsQuery query)
    {
        return await rfidCardRepository.ListAsync();
    }
}