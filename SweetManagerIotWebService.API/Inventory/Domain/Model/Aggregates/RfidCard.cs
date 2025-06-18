using SweetManagerIotWebService.API.Inventory.Domain.Model.Commands;
using SweetManagerIotWebService.API.Reservations.Domain.Model.Aggregates;

namespace SweetManagerIotWebService.API.Inventory.Domain.Model.Aggregates;

public partial class RfidCard
{
    public int Id { get; set;  }
    
    public int? RoomId { get; set;  }
    
    public string? apiKey { get; set;  }
    
    public string ? uId { get; set;  }
    
    public virtual Room? Room { get; set;  }
    
    public RfidCard(int id, int? roomId, string? apiKey, string? uId)
    {
        Id = id;
        RoomId = roomId;
        this.apiKey = apiKey;
        this.uId = uId;
    }
    
    public RfidCard(CreateRfidCardCommand command)
    {
        RoomId = command.RoomId;
        apiKey = command.apiKey;
        uId = command.uId;
    }
}