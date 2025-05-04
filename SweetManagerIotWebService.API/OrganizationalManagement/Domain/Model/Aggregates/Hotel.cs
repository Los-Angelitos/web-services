using System;
using System.Collections.Generic;
using SweetManagerIotWebService.API.IAM.Domain.Model.Aggregates;
using SweetManagerIotWebService.API.Reservations.Domain.Model.Aggregates;

namespace SweetManagerIotWebService.API;

public partial class Hotel
{
    public int Id { get; set; }

    public int? OwnerId { get; set; }

    public string? Name { get; set; }

    public string? Description { get; set; }

    public string? Email { get; set; }

    public string? Address { get; set; }

    public string? Phone { get; set; }

    public virtual Owner? Owner { get; set; }

    public virtual ICollection<Room> Rooms { get; set; } = new List<Room>();

    public virtual ICollection<Supply> Supplies { get; set; } = new List<Supply>();

    public virtual ICollection<Admin> Admins { get; set; } = new List<Admin>();
}
