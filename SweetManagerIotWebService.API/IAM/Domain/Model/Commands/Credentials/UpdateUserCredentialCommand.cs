namespace SweetManagerIotWebService.API.IAM.Domain.Model.Commands.Credentials
{
    public record UpdateUserCredentialCommand(int UserId, string Code);
}