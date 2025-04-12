using System;
using System.Collections.Generic;
using SweetManagerIotWebService.API.Commerce.Domain.Model.Aggregates;
using SweetManagerIotWebService.API.Commerce.Domain.Model.Entities;
using SweetManagerIotWebService.API.IAM.Domain.Model.Entities.Credentials;
using SweetManagerIotWebService.API.IAM.Domain.Model.Entities.Roles;

namespace SweetManagerIotWebService.API.IAM.Domain.Model.Aggregates;

public partial class Owner
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Surname { get; set; }

    public string? Phone { get; set; }

    public string? Email { get; set; }

    public string? State { get; set; }

    public int? RoleId { get; set; }

    public virtual ICollection<ContractOwner> ContractOwners { get; set; } = new List<ContractOwner>();

    public virtual ICollection<Hotel> Hotels { get; set; } = new List<Hotel>();

    public virtual OwnerCredential? OwnerCredential { get; set; }

    public virtual ICollection<PaymentOwner> PaymentOwners { get; set; } = new List<PaymentOwner>();

    public virtual Role? Role { get; set; }
}
