﻿using System;
using System.Collections.Generic;
using SweetManagerIotWebService.API.IAM.Domain.Model.Aggregates;

namespace SweetManagerIotWebService.API.IAM.Domain.Model.Entities;

public partial class AdminCredential
{
    public int AdminId { get; set; }

    public string? Code { get; set; }

    public virtual Admin Admin { get; set; } = null!;
}
