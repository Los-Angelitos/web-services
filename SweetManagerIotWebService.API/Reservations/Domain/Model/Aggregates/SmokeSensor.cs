using SweetManagerIotWebService.API.Reservations.Domain.Model.Commands.SmokeSensor;
using SweetManagerIotWebService.API.Reservations.Domain.Model.Commands.Thermostat;

namespace SweetManagerIotWebService.API.Reservations.Domain.Model.Aggregates;

public partial class SmokeSensor
{
    public int Id { get; set;  }
    
    public int? RoomId { get; set;  }
    
    public string? IpAddress { get; set;  }
    
    public double ? LastAnalogicValue { get; set;  }
    
    public string? MacAddress { get; set;  }
    
    public string? State { get; set;  }
    
    public DateTime ? LastAlertTime { get; set;  }
    
    public virtual Room? Room { get; set;  }
    
    public SmokeSensor(int id, int? roomId, double? lastAnalogicValue , string? ipAddress, string? macAddress, string? state, DateTime? lastAlertTime)
    {
        Id = id;
        RoomId = roomId;
        LastAnalogicValue = lastAnalogicValue;
        IpAddress = ipAddress;
        MacAddress = macAddress;
        State = state?.ToUpper();
        LastAlertTime = lastAlertTime;
    }
    
    public SmokeSensor(CreateSmokeSensorCommand command)
    {
        RoomId = command.RoomId;
        LastAnalogicValue = command.LastAnalogicValue;
        IpAddress = command.IpAddress;
        MacAddress = command.MacAddress;
        State = command.State?.ToUpper();
        LastAlertTime = command.LastAlertTime;
    }
    
    public SmokeSensor(UpdateSmokeSensorCommand command)
    {
        Id = command.Id;
        RoomId = command.RoomId;
        LastAnalogicValue = command.LastAnalogicValue;
        IpAddress = command.IpAddress;
        MacAddress = command.MacAddress;
        State = command.State?.ToUpper();
        LastAlertTime = command.LastAlertTime;
    }
    public SmokeSensor(UpdateSmokeSensorStateCommand command)
    {
        Id = command.Id;
        State = command.State?.ToUpper();
    }
    
    public SmokeSensor(UpdatSmokeSensorAnalogicValueCommand command)
    {
        Id = command.Id;
        LastAnalogicValue = command.LastAnalogicValue;
    }
    

    
    
    
}