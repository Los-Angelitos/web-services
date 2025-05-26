using SweetManagerIotWebService.API.Communication.Domain.Model.Aggregates;
using SweetManagerIotWebService.API.Communication.Domain.Model.Queries;

namespace SweetManagerIotWebService.API.Communication.Domain.Services;

public interface INotificationQueryService
{
    Task<Notification?> Handle(GetNotificationByIdQuery query);
    
    Task<IEnumerable<Notification>> Handle(GetNotificationBySenderIdQuery query);
    
    Task<IEnumerable<Notification>> Handle(GetNotificationByReceiverIdQuery query);
    
    Task<IEnumerable<Notification>> Handle(GetNotificationBySenderAndReceiverIdQuery query);
    
    Task<IEnumerable<Notification>> Handle(GetNotificationsByHotelIdQuery query);
    
}