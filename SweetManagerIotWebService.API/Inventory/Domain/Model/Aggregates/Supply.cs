using System;
using System.Collections.Generic;
using SweetManagerIotWebService.API.Inventory.Domain.Model.Entities;
using SweetManagerIotWebService.API.OrganizationalManagement.Domain.Model.Aggregates;

namespace SweetManagerIotWebService.API;

public partial class Supply
{
    public int Id { get; set; }

    public int? ProviderId { get; set; }

    public int? HotelId { get; set; }

    public string? Name { get; set; }

    public decimal? Price { get; set; }

    public int? Stock { get; set; }

    public string? State { get; set; }

    public virtual Hotel? Hotel { get; set; }

    public virtual Provider? Provider { get; set; }

    public virtual ICollection<SupplyRequest> SupplyRequests { get; set; } = new List<SupplyRequest>();
}
