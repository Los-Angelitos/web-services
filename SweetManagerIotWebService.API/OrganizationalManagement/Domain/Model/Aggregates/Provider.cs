using SweetManagerIotWebService.API.Inventory.Domain.Model.Aggregates;
using SweetManagerIotWebService.API.OrganizationalManagement.Domain.Model.Commands;
using SweetManagerIotWebService.API.OrganizationalManagement.Domain.Model.ValueObjects;

namespace SweetManagerIotWebService.API.OrganizationalManagement.Domain.Model.Aggregates;

public partial class Provider
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Email { get; set; }

    public string? Phone { get; set; }

    public State? State { get; set; }

    public int HotelId { get; set; }

    public virtual ICollection<Supply> Supplies { get; set; } = new List<Supply>();

    public virtual Hotel Hotel { get; set; } = null!;

    public Provider() {}

    public Provider(string name, string email, string phone, string state)
    {
        Name = name;
        Email = email;
        Phone = phone;
        State = Enum.TryParse<State>(state, true, out var stateEnum) ? stateEnum : throw new ArgumentException("Invalid state, use 'Active' or 'Inactive'");
    }

    public Provider(CreateProviderCommand command)
    {
        Name = command.Name;
        Email = command.Email;
        Phone = command.Phone;
        State = Enum.TryParse<State>(command.State, true, out var stateEnum) ? stateEnum : throw new ArgumentException("Invalid state, use 'Active' or 'Inactive'");
    }
    
    public void UpdateData(UpdateProviderCommand command)
    {
        Name = command.Name;
        Email = command.Email;
        Phone = command.Phone;
    }
    
    public void UpdateState(string state)
    {
        State = Enum.TryParse<State>(state, true, out var stateEnum) ? stateEnum : throw new ArgumentException("Invalid state, use 'Active' or 'Inactive'");
    }

    public void DisableProvider()
    {
        State = ValueObjects.State.Inactive;
    }
    
    public bool IsActive()
    {
        return State == ValueObjects.State.Active;
    }
}
