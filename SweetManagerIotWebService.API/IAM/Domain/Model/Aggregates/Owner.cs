using System;
using System.Collections.Generic;
using SweetManagerIotWebService.API.Commerce.Domain.Model.Aggregates;
using SweetManagerIotWebService.API.Commerce.Domain.Model.Entities;
using SweetManagerIotWebService.API.IAM.Domain.Model.Commands.Authentication;
using SweetManagerIotWebService.API.IAM.Domain.Model.Entities.Credentials;
using SweetManagerIotWebService.API.IAM.Domain.Model.Entities.Roles;

namespace SweetManagerIotWebService.API.IAM.Domain.Model.Aggregates;

public partial class Owner
{
    public int Id { get; private set; }

    public string? Name { get; private set; }

    public string? Surname { get; private set; }

    public string? Phone { get; private set; }

    public string? Email { get; private set; }

    public string? State { get; private set; }

    public int? RoleId { get; private set; }

    public string? PhotoURL { get; private set; }

    public virtual ICollection<ContractOwner> ContractOwners { get; set; } = new List<ContractOwner>();

    public virtual ICollection<Hotel> Hotels { get; set; } = new List<Hotel>();

    public virtual OwnerCredential? OwnerCredential { get; set; }

    public virtual ICollection<PaymentOwner> PaymentOwners { get; set; } = new List<PaymentOwner>();

    public virtual Role? Role { get; set; }

    public Owner() { }

    public Owner(int id, string name, string surname, string phone, string email, string state, int roleId, string photoURL)
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

    public Owner(UpdateUserCommand command)
    {
        Id = command.Id;
        Name = command.Name;
        Surname = command.Surname;
        Phone = command.Phone;
        Email = command.Email;
        State = command.State;
        PhotoURL = command.PhotoURL;
    }

    public Owner Update(UpdateUserCommand command)
    {
        Id = command.Id;
        Name = command.Name;
        Surname = command.Surname;
        Phone = command.Phone;
        Email = command.Email;
        State = command.State;
        PhotoURL = command.PhotoURL;

        return this;
    }
}
