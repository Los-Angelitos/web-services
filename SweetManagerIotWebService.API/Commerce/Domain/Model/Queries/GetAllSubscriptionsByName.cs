﻿using SweetManagerIotWebService.API.Commerce.Domain.Model.ValueObjects;

namespace SweetManagerIotWebService.API.Commerce.Domain.Model.Queries;

public record GetAllSubscriptionsByName(ESubscriptionTypes Name);