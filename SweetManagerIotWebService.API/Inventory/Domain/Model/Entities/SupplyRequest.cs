using System;
using System.Collections.Generic;
using SweetManagerIotWebService.API.Commerce.Domain.Model.Aggregates;

namespace SweetManagerIotWebService.API.Inventory.Domain.Model.Entities;

public partial class SupplyRequest
{
    public int Id { get; set; }

    public int? PaymentOwnerId { get; set; }

    public int? SupplyId { get; set; }

    public int? Count { get; set; }

    public decimal? Amount { get; set; }

    public virtual PaymentOwner? PaymentOwner { get; set; }

    public virtual Supply? Supply { get; set; }
}