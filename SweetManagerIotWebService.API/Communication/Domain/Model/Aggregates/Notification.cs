using System;
using System.Collections.Generic;

namespace SweetManagerIotWebService.API.Communication.Domain.Model.Aggregates;

public partial class Notification
{
    public int Id { get; set; }

    public string? Title { get; set; }

    public string? Content { get; set; }

    public string? SenderType { get; set; }

    public int? SenderId { get; set; }

    public int? ReceiverId { get; set; }
}