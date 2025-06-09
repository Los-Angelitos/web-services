namespace SweetManagerIotWebService.API.Communication.Application.Internal.OutboundServices
{
    public interface IMailService
    {
        void SendEmail(string subject, string body, string recipient);
    }
}
