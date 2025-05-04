using System;
using System.Collections.Generic;
using SweetManagerIotWebService.API.Commerce.Domain.Model.Aggregates;
using SweetManagerIotWebService.API.IAM.Domain.Model.Entities.Preferences;
using SweetManagerIotWebService.API.Reservations.Domain.Model.Aggregates;

namespace SweetManagerIotWebService.API;

public partial class Booking
{
    public int Id { get; set; }

    public int? PaymentCustomerId { get; set; }

    public int? RoomId { get; set; }

    public string? Description { get; set; }

    public DateTime? StartDate { get; set; }

    public DateTime? FinalDate { get; set; }

    public decimal? PriceRoom { get; set; }

    public int? NightCount { get; set; }

    public decimal? Amount { get; set; }

    public string? State { get; set; }

    public int? PreferenceId { get; set; }

    public virtual PaymentCustomer? PaymentCustomer { get; set; }

    public virtual GuestPreference? Preference { get; set; }

    public virtual Room? Room { get; set; }
}
