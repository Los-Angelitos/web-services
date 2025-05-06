using System;
using System.Collections.Generic;
using SweetManagerIotWebService.API.Communication.Domain.Model.Commands;

namespace SweetManagerIotWebService.API.Communication.Domain.Model.Aggregates;

public partial class Notification
{
    public Notification()
    {
    }

    public Notification(CreateNotificationCommand command)
    {
        Title = command.Title;
        Content = command.Content;
        SenderType = command.SenderType;
        SenderId = command.SenderId;
        ReceiverId = command.ReceiverId;
        HotelId = command.HotelId;
    }

    public int Id { get; set; }

    public string? Title { get; set; }

    public string? Content { get; set; }

    public string? SenderType { get; set; }

    public int? SenderId { get; set; }

    public int? ReceiverId { get; set; }
    
    public int? HotelId { get; set; }
    
    public virtual Hotel? Hotel { get; set; }
}