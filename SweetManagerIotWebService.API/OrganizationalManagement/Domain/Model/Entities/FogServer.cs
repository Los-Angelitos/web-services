using SweetManagerIotWebService.API.OrganizationalManagement.Domain.Model.Aggregates;
using SweetManagerIotWebService.API.OrganizationalManagement.Domain.Model.Commands;

namespace SweetManagerIotWebService.API.OrganizationalManagement.Domain.Model.Entities
{
    public class FogServer
    {
        public int Id { get; private set; }

        public string IpAddress { get; private set; }

        public string SubnetMask { get; private set; }

        public int HotelId { get; private set; }

        public virtual Hotel Hotel { get; private set; } = null!;

        public FogServer() { }

        public FogServer(string ipAddress, string subnetMask, int hotelId)
        {
            IpAddress = ipAddress;
            SubnetMask = subnetMask;
            HotelId = hotelId;
        }

        public FogServer(CreateFogServerCommand command)
        {
            IpAddress = command.IpAddress;
            SubnetMask = command.SubnetMask;
            HotelId = command.HotelId;
        }

        public void Update(UpdateFogServerCommand command)
        {
            IpAddress = command.IpAddress;
            SubnetMask = command.SubnetMask;
        }
    }
}
