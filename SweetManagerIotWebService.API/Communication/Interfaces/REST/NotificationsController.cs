using System.Net.Mime;
using Microsoft.AspNetCore.Mvc;
using SweetManagerIotWebService.API.Communication.Application.Internal.QueryServices;
using SweetManagerIotWebService.API.Communication.Domain.Model.Queries;
using SweetManagerIotWebService.API.Communication.Domain.Services;
using SweetManagerIotWebService.API.Communication.Interfaces.REST.Resources;
using SweetManagerIotWebService.API.Communication.Interfaces.REST.Transform;

namespace SweetManagerIotWebService.API.Communication.Interfaces.REST;

[ApiController]
[Route("api/v1/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
public class NotificationsController(INotificationCommandService notificationCommandService, INotificationQueryService notificationQueryService):ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> CreateNotification(CreateNotificationResource resource)
    {
        var createNotificationCommand = CreateNotificationCommandFromResourceAssembler.ToCommandFromResource(resource);
        var notification = await notificationCommandService.Handle(createNotificationCommand);
        if (notification is null) return BadRequest();
        var notificationResource = NotificationResourceFromEntityAssembler.ToResourceFromEntity(notification);
        return CreatedAtAction(nameof(GetNotificationById), new { notificationId = notificationResource.Id }, notificationResource);
    }

    [HttpGet("{notificationId:int}")]
    public async Task<IActionResult> GetNotificationById(int notificationId)
    {
        var getNotificationByIdQuery = new GetNotificationByIdQuery(notificationId);
        var notification = await notificationQueryService.Handle(getNotificationByIdQuery);
        if (notification == null) return NotFound();
        var notificationResource = NotificationResourceFromEntityAssembler.ToResourceFromEntity(notification);
        return Ok(notificationResource);
    }
    
    [HttpGet("get-all-notifications-by-hotelId")]
    public async Task <IActionResult> GetNotificationsByHotelId([FromQuery] int hotelId)
    {
        var notifications = await notificationQueryService.Handle(new GetNotificationsByHotelIdQuery(hotelId));
        if (notifications is null)
            return BadRequest();
        return Ok(notifications);
    }
    
    [HttpGet("get-notifications-by-senderId")]
    public async Task<IActionResult> GetNotificationsBySenderId([FromQuery] int senderId)
    {
        var notifications = await notificationQueryService.Handle(new GetNotificationBySenderIdQuery(senderId));
        if (notifications is null)
            return BadRequest();
        return Ok(notifications);
    }
    
    [HttpGet("get-notifications-by-receiverId")]
    public async Task<IActionResult> GetNotificationsByReceiverId([FromQuery] int receiverId)
    {
        var notifications = await notificationQueryService.Handle(new GetNotificationByReceiverIdQuery(receiverId));
        if (notifications is null)
            return BadRequest();
        return Ok(notifications);
    }
    
    [HttpGet("get-notifications-by-sender-and-receiverId")]
    public async Task<IActionResult> GetNotificationsBySenderAndReceiverId([FromQuery] int senderId, [FromQuery] int receiverId)
    {
        var notifications = await notificationQueryService.Handle(new GetNotificationBySenderAndReceiverIdQuery(senderId, receiverId));
        if (notifications is null)
            return BadRequest();
        return Ok(notifications);
    }
    
    
}