﻿using SweetManagerIotWebService.API.IAM.Domain.Model.Commands.Authentication;
using SweetManagerIotWebService.API.IAM.Domain.Model.Entities.Credentials;
using SweetManagerIotWebService.API.IAM.Domain.Model.Entities.Roles;
using SweetManagerIotWebService.API.OrganizationalManagement.Domain.Model.Aggregates;

namespace SweetManagerIotWebService.API.IAM.Domain.Model.Aggregates;

public partial class Admin
{
    public int Id { get; private set; }

    public string? Name { get; private set; }

    public string? Surname { get; private set; }

    public string? Phone { get; private set; }

    public string? Email { get; private set; }

    public string? State { get; private set; }

    public int? RoleId { get; private set; }

    public int? HotelId { get; private set; }

    public string? PhotoURL { get; private set; }

    public virtual AdminCredential? AdminCredential { get; set; }

    public virtual Role? Role { get; set; }

    public virtual Hotel? Hotel { get; set; }

    public Admin() { }

    public Admin(int id, string name, string surname, string phone, string email, string state, int roleId, string photoURL)
    {
        Id = id;
        Name = name;
        Surname = surname;
        Phone = phone;
        Email = email;
        State = state;
        RoleId = roleId;
        PhotoURL = photoURL;
    }

    public Admin(UpdateUserCommand command)
    {
        Id = command.Id;
        Name = command.Name;
        Surname = command.Surname;
        Phone = command.Phone;
        Email = command.Email;
        State = command.State;
        PhotoURL = command.PhotoURL;
        ValidateBeforeInsert();
    }

    public Admin Update(UpdateUserCommand command)
    {
        Id = command.Id;
        Name = command.Name;
        Surname = command.Surname;
        Phone = command.Phone;
        Email = command.Email;
        State = command.State;
        PhotoURL = command.PhotoURL;
        ValidateBeforeUpdate();
        return this;
    }

    public void ValidateBeforeInsert()
    {
        if (string.IsNullOrEmpty(Name))
            throw new ArgumentException("Name cannot be null or empty.");
        else if (string.IsNullOrEmpty(Surname))
            throw new ArgumentException("Surname cannot be null or empty.");
        else if (string.IsNullOrEmpty(Email))
            throw new ArgumentException("Email cannot be null or empty.");
        else if (!System.Text.RegularExpressions.Regex.IsMatch(Email!, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            throw new ArgumentException("Email has not a valid format.");
        else if (string.IsNullOrEmpty(Phone))
            throw new ArgumentException("Phone cannot be null or empty");
        else if (!System.Text.RegularExpressions.Regex.IsMatch(Phone, @"^\d{9}$"))
            throw new ArgumentException("Phone has not a valid format.");
    }

    public void ValidateBeforeUpdate()
    {
        if (Id == 0)
            throw new ArgumentException("ID cannot be zero.");
        else if (string.IsNullOrEmpty(Name))
            throw new ArgumentException("Name cannot be null or empty.");
        else if (string.IsNullOrEmpty(Surname))
            throw new ArgumentException("Surname cannot be null or empty.");
        else if (string.IsNullOrEmpty(Email))
            throw new ArgumentException("Email cannot be null or empty.");
        else if (!System.Text.RegularExpressions.Regex.IsMatch(Email!, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            throw new ArgumentException("Email has not a valid format.");
        else if (string.IsNullOrEmpty(Phone))
            throw new ArgumentException("Phone cannot be null or empty");
        else if (!System.Text.RegularExpressions.Regex.IsMatch(Phone, @"^\d{9}$"))
            throw new ArgumentException("Phone has not a valid format.");
    }
}