﻿using SweetManagerIotWebService.API.Commerce.Domain.Model.Commands;
using SweetManagerIotWebService.API.Commerce.Domain.Model.ValueObjects;
using SweetManagerIotWebService.API.Commerce.Interfaces.REST.Resources;

namespace SweetManagerIotWebService.API.Commerce.Interfaces.REST.Transform;

public static class CreateSubscriptionCommandFromResourceAssembler
{
    public static CreateSubscriptionCommand ToCommandFromResource(CreateSubscriptionResource resource)
    {
        if (!Enum.TryParse<ESubscriptionTypes>(resource.Name, true, out var name))
        {
            throw new ArgumentException($"Invalid value for Subscription type: {resource.Name}");
        }
        
        if (!Enum.TryParse<EStates>(resource.Status, true, out var status))
        {
            throw new ArgumentException($"Invalid value for Status: {resource.Status}");
        }
        
        return new CreateSubscriptionCommand(
            name,
            resource.Content,
            resource.Price,
            status);
    }
}