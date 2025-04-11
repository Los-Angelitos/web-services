using System;
using System.Collections.Generic;
using SweetManagerIotWebService.API.IAM.Domain.Model.Entities;

namespace SweetManagerIotWebService.API.IAM.Domain.Model.Aggregates;

public partial class Admin
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Surname { get; set; }

    public string? Phone { get; set; }

    public string? Email { get; set; }

    public int? RoleId { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual AdminCredential? AdminCredential { get; set; }

    public virtual Role? Role { get; set; }
}
