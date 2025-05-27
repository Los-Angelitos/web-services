using System;
using System.Collections.Generic;
using SweetManagerIotWebService.API.Commerce.Domain.Model.Aggregates;
using SweetManagerIotWebService.API.IAM.Domain.Model.Commands.Authentication;
using SweetManagerIotWebService.API.IAM.Domain.Model.Entities.Credentials;
using SweetManagerIotWebService.API.IAM.Domain.Model.Entities.Preferences;
using SweetManagerIotWebService.API.IAM.Domain.Model.Entities.Roles;

namespace SweetManagerIotWebService.API.IAM.Domain.Model.Aggregates;

public partial class Guest
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Surname { get; set; }

    public string? Email { get; set; }

    public string? Phone { get; set; }

    public string? State { get; set; }

    public int? RoleId { get; set; }

    public string? PhotoURL { get; set; }

    public virtual GuestCredential? GuestCredential { get; set; }

    public virtual ICollection<GuestPreference> GuestPreferences { get; set; } = new List<GuestPreference>();

    public virtual ICollection<PaymentCustomer> PaymentCustomers { get; set; } = new List<PaymentCustomer>();

    public virtual Role? Role { get; set; }

    public Guest() { }

    public Guest(int id, string name, string surname, string phone, string email, string state, int roleId, string photoURL)
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

    public Guest(UpdateUserCommand command)
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

    public Guest Update(UpdateUserCommand command)
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
