using SweetManagerIotWebService.API.Communication.Application.Internal.OutboundServices;
using SweetManagerIotWebService.API.Communication.Application.Internal.OutboundServices.ACL;
using SweetManagerIotWebService.API.Communication.Domain.Model.Aggregates;
using SweetManagerIotWebService.API.Communication.Domain.Model.Commands;
using SweetManagerIotWebService.API.Communication.Domain.Model.Exceptions;
using SweetManagerIotWebService.API.Communication.Domain.Repositories;
using SweetManagerIotWebService.API.Communication.Domain.Services;
using SweetManagerIotWebService.API.Shared.Domain.Repositories;
using SweetManagerIotWebService.API.Shared.Infrastructure.miscellaneous.templates;

namespace SweetManagerIotWebService.API.Communication.Application.Internal.CommandServices;

public class NotificationCommandService(INotificationRepository notificationRepository, IUnitOfWork unitOfWork,
    IMailService mailService, ExternalIAMService externalIAMService, 
    ExternalOrganizationManagementService externalOrganizationManagementService) : INotificationCommandService
{
    public async Task<Notification?> Handle(CreateNotificationCommand command)
    {
        var notification = new Notification(command);
        try
        {
            await notificationRepository.AddAsync(notification);
            await unitOfWork.CommitAsync();
            return notification;
        } catch (Exception e)
        {
            Console.WriteLine($"An error occurred while creating the notification: {e.Message}");
            return null;
        }
    }

    public async Task<bool> Handle(CreateAdminRequestToOrganizationCommand command)
    {
        var recoveredUser = await externalIAMService.FetchAdminById(command.AdminId) ?? throw new AnyUserExistWithTheGivenIdException();

        var ownerId = await externalOrganizationManagementService.FetchOwnerIdByHotelId(command.HotelId) ?? throw new ExternalServicesProcessFailedException();

        var ownerContact = await externalIAMService.FetchOwnerNameAndEmailById(ownerId.Id);

        string body = MailTemplates.GenerateAdminRequestToOrganization(recoveredUser.Name, recoveredUser.FullName, recoveredUser.Email, recoveredUser.Phone, command.AdditionalMessage, ownerContact?.Name!, command.HotelId);

        string subject = $"SOLICITUD DE TRABAJO - {recoveredUser.FullName}";
        
        mailService.SendEmail(subject, body, ownerContact?.Email!);

        return true;
    }
}