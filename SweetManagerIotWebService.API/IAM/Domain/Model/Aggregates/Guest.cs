using System;
using System.Collections.Generic;
using SweetManagerIotWebService.API.Commerce.Domain.Model.Aggregates;
using SweetManagerIotWebService.API.IAM.Domain.Model.Entities;

namespace SweetManagerIotWebService.API.IAM.Domain.Model.Aggregates;

public partial class Guest
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Surname { get; set; }

    public string? Email { get; set; }

    public string? Phone { get; set; }

    public string? State { get; set; }

    public virtual GuestCredential? GuestCredential { get; set; }

    public virtual ICollection<GuestPreference> GuestPreferences { get; set; } = new List<GuestPreference>();

    public virtual ICollection<PaymentCustomer> PaymentCustomers { get; set; } = new List<PaymentCustomer>();
}
