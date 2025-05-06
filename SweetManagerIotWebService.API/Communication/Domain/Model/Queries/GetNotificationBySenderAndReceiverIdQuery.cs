namespace SweetManagerIotWebService.API.Communication.Domain.Model.Queries;

public record GetNotificationBySenderAndReceiverIdQuery(int SenderId, int ReceiverId);