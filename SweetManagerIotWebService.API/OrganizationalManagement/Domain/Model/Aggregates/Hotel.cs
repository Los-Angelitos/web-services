﻿using SweetManagerIotWebService.API.Communication.Domain.Model.Aggregates;
using SweetManagerIotWebService.API.IAM.Domain.Model.Aggregates;
using SweetManagerIotWebService.API.Inventory.Domain.Model.Aggregates;
using SweetManagerIotWebService.API.OrganizationalManagement.Domain.Model.Commands;
using SweetManagerIotWebService.API.OrganizationalManagement.Domain.Model.Entities;
using SweetManagerIotWebService.API.OrganizationalManagement.Domain.Model.ValueObjects;
using SweetManagerIotWebService.API.Reservations.Domain.Model.Aggregates;

namespace SweetManagerIotWebService.API.OrganizationalManagement.Domain.Model.Aggregates;

public partial class Hotel
{
    public int Id { get; set; }

    public int OwnerId { get; set; }

    public string? Name { get; set; }

    public string? Description { get; set; }

    public string? Email { get; set; }

    public string? Address { get; set; }

    public string? Phone { get; set; }
    
    public ECategory? Category { get; set; }

    public virtual Owner? Owner { get; set; }

    public virtual ICollection<Room> Rooms { get; set; } = new List<Room>();

    public virtual ICollection<Supply> Supplies { get; set; } = new List<Supply>();

    public virtual ICollection<Admin> Admins { get; set; } = new List<Admin>();

    public virtual ICollection<Notification> Notifications { get; set; } = new List<Notification>();

    public virtual ICollection<Multimedia> Multimedias { get; set; } = new List<Multimedia>();

    public virtual ICollection<Provider> Providers { get; set; } = new List<Provider>();

    public virtual FogServer FogServer { get; set; } = null!;

    public Hotel()
    {
        // asd
    }
    
    public Hotel(string name, string description, string email, string address, string phone, string category)
    {
        Name = name;
        Description = description;
        Email = email;
        Address = address;
        Phone = phone;
        Category = Enum.Parse<ECategory>(category);
    }
    public Hotel(CreateHotelCommand command)
    {
        OwnerId = command.OwnerId;
        Name = command.Name;
        Description = command.Description;
        Email = command.Email;
        Address = command.Address;
        Phone = command.Phone;
        Category = Enum.Parse<ECategory>(command.Category);

        
        /*
        // rooms from command, fill the collection
        foreach (var room in command.Rooms)
        {
            Rooms.Add(new Room(room));
        }
        */
    }
    
    public void UpdateData(UpdateHotelCommand command)
    {
        Description = command.Description;
        Email = command.Email;
        Address = command.Address;
        Phone = command.Phone;
        OwnerId = command.OwnerId;
    }
}
