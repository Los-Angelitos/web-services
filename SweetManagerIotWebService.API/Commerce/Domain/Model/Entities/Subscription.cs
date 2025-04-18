﻿using System;
using System.Collections.Generic;

namespace SweetManagerIotWebService.API.Commerce.Domain.Model.Entities;

public partial class Subscription
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Content { get; set; }

    public decimal? Price { get; set; }

    public string? Status { get; set; }

    public virtual ICollection<ContractOwner> ContractOwners { get; set; } = new List<ContractOwner>();
}
