using System;
using System.Collections.Generic;
using SweetManagerIotWebService.API.Reservations.Domain.Model.Entities;

namespace SweetManagerIotWebService.API.Reservations.Domain.Model.Aggregates;

public partial class Room
{
    public int Id { get; set; }

    public int? TypeRoomId { get; set; }

    public int? HotelId { get; set; }

    public string? State { get; set; }

    public virtual ICollection<Booking> Bookings { get; set; } = new List<Booking>();

    public virtual Hotel? Hotel { get; set; }

    public virtual TypeRoom? TypeRoom { get; set; }
}