using System;
using System.Collections.Generic;
using SweetManagerIotWebService.API.IAM.Domain.Model.Aggregates;

namespace SweetManagerIotWebService.API.IAM.Domain.Model.Entities.Credentials;

public partial class OwnerCredential
{
    public int OwnerId { get; set; }

    public string? Code { get; set; }

    public virtual Owner Owner { get; set; } = null!;
}
