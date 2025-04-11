using System;
using System.Collections.Generic;
using SweetManagerIotWebService.API.IAM.Domain.Model.Aggregates;

namespace SweetManagerIotWebService.API.Commerce.Domain.Model.Entities;

public partial class ContractOwner
{
    public int Id { get; set; }

    public int? OwnerId { get; set; }

    public DateTime? StartDate { get; set; }

    public DateTime? FinalDate { get; set; }

    public int? SubscriptionId { get; set; }

    public string? Status { get; set; }

    public virtual Owner? Owner { get; set; }

    public virtual Subscription? Subscription { get; set; }
}
