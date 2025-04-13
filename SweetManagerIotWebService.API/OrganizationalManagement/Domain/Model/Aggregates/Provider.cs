using System;
using System.Collections.Generic;
using SweetManagerIotWebService.API.OrganizationalManagement.Domain.Model.Commands;

namespace SweetManagerIotWebService.API.OrganizationalManagement.Domain.Model.Aggregates;

public partial class Provider
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Email { get; set; }

    public string? Phone { get; set; }

    public string? State { get; set; }

    public virtual ICollection<Supply> Supplies { get; set; } = new List<Supply>();
    
    public Provider() {}

    public Provider(CreateProviderCommand command)
    {
        Name = command.Name;
        Email = command.Email;
        Phone = command.Phone;
        State = command.State;
    }
}
