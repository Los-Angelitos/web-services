namespace SweetManagerIotWebService.API.IAM.Domain.Model.Commands
{
    public record SignUpUserCommand(int Id, string Name, string Surname, string Phone, string Email, int RoleId, string State);
}