using SweetManagerIotWebService.API.Inventory.Domain.Model.Aggregates;
using SweetManagerIotWebService.API.Inventory.Domain.Repositories;
using SweetManagerIotWebService.API.Shared.Infrastructure.Persistence.EFC.Configuration;
using SweetManagerIotWebService.API.Shared.Infrastructure.Persistence.EFC.Repositories;

namespace SweetManagerIotWebService.API.Inventory.Infrastructure.Persistence.Repositories;

public class RfidCardRepository(SweetManagerContext context) : BaseRepository<RfidCard>(context), IRfidCardRepository
{
    
}