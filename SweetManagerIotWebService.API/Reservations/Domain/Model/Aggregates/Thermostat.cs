using SweetManagerIotWebService.API.Reservations.Domain.Model.Commands.Thermostat;

namespace SweetManagerIotWebService.API.Reservations.Domain.Model.Aggregates;

public partial class Thermostat
{
    public int Id { get; set;  }
    
    public int? RoomId { get; set;  }
    
    public double ? Temperature { get; set;  }
    
    public string? IpAddress { get; set;  }
    
    public string? MacAddress { get; set;  }
    
    public string? State { get; set;  }
    
    public DateTime ? LastUpdate { get; set;  }
    
    public virtual Room? Room { get; set;  }
    
    public Thermostat(int id, int? roomId, double? temperature, string? ipAddress, string? macAddress, string? state, DateTime? lastUpdate)
    {
        Id = id;
        RoomId = roomId;
        Temperature = temperature;
        IpAddress = ipAddress;
        MacAddress = macAddress;
        State = state?.ToUpper();
        LastUpdate = lastUpdate;
    }
    
    public Thermostat(CreateThermostatCommand command)
    {
        RoomId = command.RoomId;
        Temperature = command.Temperature;
        IpAddress = command.IpAddress;
        MacAddress = command.MacAddress;
        State = command.State?.ToUpper();
        LastUpdate = command.LastUpdate;
    }
    
    public Thermostat(UpdateThermostatCommand command)
    {
        Id = command.Id;
        RoomId = command.RoomId;
        Temperature = command.Temperature;
        IpAddress = command.IpAddress;
        MacAddress = command.MacAddress;
        State = command.State?.ToUpper();
        LastUpdate = command.LastUpdate;
    }
    public Thermostat(UpdateThermostatStateCommand command)
    {
        Id = command.Id;
        State = command.State?.ToUpper();
    }
    
    public Thermostat(UpdateThermostatTemperatureCommand command)
    {
        Id = command.Id;
        Temperature = command.Temperature;
    }
    
    
    
    
}