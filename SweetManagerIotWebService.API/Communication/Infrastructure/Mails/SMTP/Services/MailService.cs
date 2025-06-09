using Microsoft.Extensions.Options;
using SweetManagerIotWebService.API.Communication.Application.Internal.OutboundServices;
using SweetManagerIotWebService.API.Communication.Infrastructure.Mails.SMTP.Configuration;
using System.Net;
using System.Net.Mail;

namespace SweetManagerIotWebService.API.Communication.Infrastructure.Mails.SMTP.Services
{
    public class MailService(IOptions<MailSettings> mailSettings) : IMailService
    {
        private readonly MailSettings _mailSettings = mailSettings.Value;

        public void SendEmail(string subject, string body, string recipient)
        {
            try
            {
                using var cts = new CancellationTokenSource(TimeSpan.FromSeconds(10));
                CancellationToken token = cts.Token;

                var from = _mailSettings.Username;
                var password = _mailSettings.Password;

                var message = new MailMessage();
                message.From = new MailAddress(from!);
                message.Subject = subject;
                message.To.Add(new MailAddress(recipient));
                message.Body = body;
                message.IsBodyHtml = true;

                using var smtpClient = new SmtpClient("smtp.gmail.com")
                {
                    Port = _mailSettings.Port,
                    Credentials = new NetworkCredential(from, password),
                    EnableSsl = true
                };

                smtpClient.SendAsync(message, token);
            }
            catch(Exception ex)
            {
                throw new Exception($"There was an error sending the mail: {ex.Message}");
            }
        }
    }
}
