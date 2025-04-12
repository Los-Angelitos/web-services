﻿using System;
using System.Collections.Generic;
using SweetManagerIotWebService.API.Commerce.Domain.Model.Entities;
using SweetManagerIotWebService.API.Commerce.Domain.Model.ValueObjects;

namespace SweetManagerIotWebService.API.Commerce.Domain.Model.Aggregates;

public partial class Subscription
{
    public int Id { get; set; }

    public ESubscriptionTypes Name { get; set; }

    public string? Content { get; set; }

    public decimal? Price { get; set; }

    public string? Status { get; set; }

    public virtual ICollection<ContractOwner> ContractOwners { get; set; } = new List<ContractOwner>();
}
