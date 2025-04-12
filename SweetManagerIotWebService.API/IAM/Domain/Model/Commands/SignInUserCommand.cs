namespace SweetManagerIotWebService.API.IAM.Domain.Model.Commands
{
    public record SignInUserCommand(string email, string password, string role);

}