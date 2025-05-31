using SweetManagerIotWebService.API.Commerce.Domain.Model.Commands;
using SweetManagerIotWebService.API.Commerce.Domain.Model.Queries;
using SweetManagerIotWebService.API.Commerce.Domain.Services;
using SweetManagerIotWebService.API.Shared.Infrastructure.Persistence.EFC.Configuration;

namespace SweetManagerIotWebService.API.Commerce.Infrastructure.Population.Subscriptions;

public class SubscriptionsInitializer(ISubscriptionCommandService subscriptionCommandService, ISubscriptionQueryService subscriptionQueryService,
    SweetManagerContext context)
{
    public async Task InitializeAsync()
    {
        // Check if the subscription table is empty
        var result = await subscriptionQueryService.Handle(new GetAllSubscriptionsQuery());

        if (!result.Any())
        {
            // Prepopulate the empty table
            await subscriptionCommandService.Handle(new SeedSubscriptionsCommand());
        }
    }
}