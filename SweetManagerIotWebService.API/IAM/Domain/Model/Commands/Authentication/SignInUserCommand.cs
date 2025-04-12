namespace SweetManagerIotWebService.API.IAM.Domain.Model.Commands.Authentication
{
    public record SignInUserCommand(string email, string password, string role);

}