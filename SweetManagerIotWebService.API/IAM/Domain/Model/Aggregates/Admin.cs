using System;
using System.Collections.Generic;
using SweetManagerIotWebService.API.IAM.Domain.Model.Entities;
using SweetManagerIotWebService.API.IAM.Domain.Model.Entities.Credentials;

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

    public virtual AdminCredential? AdminCredential { get; set; }

    public virtual Role? Role { get; set; }
}
