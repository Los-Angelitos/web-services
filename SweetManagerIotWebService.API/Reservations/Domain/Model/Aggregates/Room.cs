using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using SweetManagerIotWebService.API.Reservations.Domain.Commands.Room;
using SweetManagerIotWebService.API.Reservations.Domain.Model.Commands.Room;
using SweetManagerIotWebService.API.Reservations.Domain.Model.Entities;

namespace SweetManagerIotWebService.API.Reservations.Domain.Model.Aggregates;

public partial class Room
{
    public int Id { get; set; }
    public int? TypeRoomId { get; set; }
    public int? HotelId { get; set; }
    public string? State { get; set; } 
    
    [JsonIgnore]
    public virtual ICollection<Booking> Bookings { get; set; } = new List<Booking>();

    public virtual Hotel? Hotel { get; set; }

    public virtual TypeRoom? TypeRoom { get; set; }

    public Room()
    {
        this.TypeRoomId = 0;
        this.HotelId = 0;
        this.State = string.Empty;
    }
    public Room(int id, int typeRoomId, int hotelId, string state)
    {
        Id = id;
        TypeRoomId = typeRoomId;
        HotelId = hotelId;
        State = state.ToUpper(); 
    }

    public Room(CreateRoomCommand command)
    {
        TypeRoomId = command.TypeRoomId;
        HotelId = command.HotelId;
        State = command.State?.ToUpper();
    }

    public Room(UpdateRoomStateCommand command)
    {
        this.Id = command.Id;
        this.State = command.State;
    }
}