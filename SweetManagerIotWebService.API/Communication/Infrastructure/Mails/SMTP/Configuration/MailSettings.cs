namespace SweetManagerIotWebService.API.Communication.Infrastructure.Mails.SMTP.Configuration
{
    public class MailSettings
    {
        public string? Username { get; set; }

        public string? Password { get; set; }
        
        public int Port { get; set; }
    }
}
