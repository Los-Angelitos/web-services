namespace SweetManagerIotWebService.API.Communication.Domain.Model.Exceptions
{
    public class ExternalServicesProcessFailedException() : InvalidOperationException("External or internal bounded contexts operations failed.");
}