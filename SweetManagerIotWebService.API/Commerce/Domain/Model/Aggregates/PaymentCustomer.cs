using System;
using System.Collections.Generic;
using SweetManagerIotWebService.API.IAM.Domain.Model.Aggregates;

namespace SweetManagerIotWebService.API.Commerce.Domain.Model.Aggregates;

public partial class PaymentCustomer
{
    public int Id { get; set; }

    public int? GuestId { get; set; }

    public decimal? FinalAmount { get; set; }

    public virtual ICollection<Booking> Bookings { get; set; } = new List<Booking>();

    public virtual Guest? Guest { get; set; }
}
