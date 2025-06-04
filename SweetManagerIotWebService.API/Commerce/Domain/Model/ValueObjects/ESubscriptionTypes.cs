namespace SweetManagerIotWebService.API.Commerce.Domain.Model.ValueObjects;

public enum ESubscriptionTypes
{
    BASIC,
    REGULAR,
    PREMIUM
}

public static class SubscriptionTypeMetadata
{
    private static readonly Dictionary<ESubscriptionTypes, (string Description, decimal Price)> Metadata =
        new()
        {
            { ESubscriptionTypes.BASIC, ("Access to IoT Technology management and Collaborative administration", 29.99m) },
            { ESubscriptionTypes.REGULAR, ("Access to IoT Technology management, Collaborative administration and Access to dynamic dashboards of enterprise management", 58.99m) },
            { ESubscriptionTypes.PREMIUM, ("Access to IoT Technology management, Collaborative administration, Access to dynamic dashboards of enterprise management and Maintenance and support 24/7", 110.69m) }
        };

    public static string GetDescription(ESubscriptionTypes type) => Metadata[type].Description;

    public static decimal GetPrice(ESubscriptionTypes type) => Metadata[type].Price;
}
