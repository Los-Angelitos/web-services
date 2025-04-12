using SweetManagerIotWebService.API.Commerce.Domain.Model.Aggregates;
using SweetManagerIotWebService.API.Commerce.Domain.Model.ValueObjects;

namespace SweetManagerIotWebService.API.Commerce.Domain.Repositories;

public interface ISubscriptionRepository
{
    Task<IEnumerable<Subscription>> FindByNameAsync(ESubscriptionTypes name);
    
    Task<IEnumerable<Subscription>> FindByStatusAsync(EStates status);
}