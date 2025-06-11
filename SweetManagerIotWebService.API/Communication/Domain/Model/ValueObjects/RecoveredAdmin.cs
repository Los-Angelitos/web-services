using SweetManagerIotWebService.API.IAM.Domain.Model.Aggregates;

namespace SweetManagerIotWebService.API.Communication.Domain.Model.ValueObjects
{
    public record RecoveredAdmin(string Name, string FullName, string Email, string Phone);
}
