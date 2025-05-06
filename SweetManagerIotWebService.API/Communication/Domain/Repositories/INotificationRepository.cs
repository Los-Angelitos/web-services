using SweetManagerIotWebService.API.Communication.Domain.Model.Aggregates;
using SweetManagerIotWebService.API.Shared.Domain.Repositories;

namespace SweetManagerIotWebService.API.Communication.Domain.Repositories;

public interface INotificationRepository : IBaseRepository<Notification>
{

    Task<IEnumerable<Notification>> GetNotificationsByHotelIdAsync(int hotelId);
    Task<IEnumerable<Notification>> GetNotificationsBySenderIdAsync(int senderId);
    Task<IEnumerable<Notification>> GetNotificationsByReceiverIdAsync(int receiverId);
    Task<IEnumerable<Notification>> GetNotificationsBySenderAndReceiverIdAsync(int senderId, int receiverId);
}