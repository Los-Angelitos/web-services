using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using SweetManagerIotWebService.API.Commerce.Domain.Model.Aggregates;
using SweetManagerIotWebService.API.IAM.Domain.Model.Entities;
using SweetManagerIotWebService.API.Reservations.Domain.Model.Aggregates;
using SweetManagerIotWebService.API.Reservations.Domain.Model.Commands.Booking;

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

    [JsonIgnore]
    public virtual Room? Room { get; set; }
    
    public Booking(int id, int? paymentCustomerId, int? roomId, string? description, DateTime? startDate, DateTime? finalDate, decimal? priceRoom, int? nightCount, decimal? amount, string? state, int? preferenceId)
    {
        Id = id;
        PaymentCustomerId = paymentCustomerId;
        RoomId = roomId;
        Description = description;
        StartDate = startDate;
        FinalDate = finalDate;
        PriceRoom = priceRoom;
        NightCount = nightCount;
        Amount = amount;
        State = state?.ToUpper();
        PreferenceId = preferenceId;
    }
    
    public Booking(CreateBookingCommand command)
    {
        PaymentCustomerId = command.PaymentCustomerId;
        RoomId = command.RoomId;
        Description = command.Description;
        StartDate = command.StartDate;
        FinalDate = command.FinalDate;
        PriceRoom = command.PriceRoom;
        NightCount = command.NightCount;
        Amount = command.Amount;
        State = command.State?.ToUpper();
        PreferenceId = command.PreferenceId;
    }
    
    public Booking(UpdateBookingStateCommand command)
    {
        Id = command.Id;
        State = command.State?.ToUpper();
    }
    
    public Booking(UpdateBookingEndDateCommand command)
    {
        Id = command.Id;
        FinalDate = command.EndDate;
    }
}
