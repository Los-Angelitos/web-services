using SweetManagerIotWebService.API.Communication.Domain.Model.Aggregates;
using SweetManagerIotWebService.API.Communication.Domain.Model.Commands;
using SweetManagerIotWebService.API.Communication.Domain.Model.Queries;
using SweetManagerIotWebService.API.Communication.Domain.Repositories;
using SweetManagerIotWebService.API.Communication.Domain.Services;

namespace SweetManagerIotWebService.API.Communication.Application.Internal.QueryServices;

public class NotificationQueryService(INotificationRepository notificationRepository) : INotificationQueryService
{
    public async Task<Notification?> Handle(GetNotificationByIdQuery query)
    {
        return await notificationRepository.FindByIdAsync(query.NotificationId);
    }

    public async Task<IEnumerable<Notification>> Handle(GetNotificationBySenderIdQuery query)
    {
        return await notificationRepository.GetNotificationsBySenderIdAsync(query.SenderId);
    }

    public async Task<IEnumerable<Notification>> Handle(GetNotificationByReceiverIdQuery query)
    {
        return await notificationRepository.GetNotificationsByReceiverIdAsync(query.ReceiverId);
    }

    public async Task<IEnumerable<Notification>> Handle(GetNotificationBySenderAndReceiverIdQuery query)
    {
        return await notificationRepository.GetNotificationsBySenderAndReceiverIdAsync(query.SenderId, query.ReceiverId);
    }

    public async Task<IEnumerable<Notification>> Handle(GetNotificationsByHotelIdQuery query)
    {
        return await notificationRepository.GetNotificationsByHotelIdAsync(query.hotelId);
    }
}