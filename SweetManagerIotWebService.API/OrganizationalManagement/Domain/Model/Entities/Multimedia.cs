using SweetManagerIotWebService.API.OrganizationalManagement.Domain.Model.Aggregates;
using SweetManagerIotWebService.API.OrganizationalManagement.Domain.Model.Commands;
using SweetManagerIotWebService.API.OrganizationalManagement.Domain.Model.ValueObjects;

namespace SweetManagerIotWebService.API.OrganizationalManagement.Domain.Model.Entities
{
    public class Multimedia
    {
        public int Id { get; private set; }

        public int HotelId { get; private set; }

        public string? Url { get; private set; }

        public ETypeMultimedia Type { get; private set; }

        public int Position { get; private set; }

        public virtual Hotel Hotel { get; } = null!;

        public Multimedia() { }

        public Multimedia(CreateMultimediaCommand command)
        {
            HotelId = command.HotelId;
            Url = command.Url;
            Type = Enum.Parse<ETypeMultimedia>(command.Type);
            Position = command.Position;
            ValidateBeforeInsert();
        }

        public void UpdateData(UpdateMultimediaCommand command)
        {
            Id = command.Id;
            HotelId = command.HotelId;
            Url = command.Url;
            Type = Enum.Parse<ETypeMultimedia>(command.Type);
            Position = command.Position;
            ValidateBeforeUpdate();
        }

        private void ValidateBeforeInsert()
        {
            if (HotelId == 0)
                throw new Exception("Hotel ID cannot be zero.");
            else if (string.IsNullOrEmpty(Url))
                throw new Exception("URL cannot be empty or null.");
            else if (Position < 1 || Position > 3)
                throw new Exception("Position must be between 1 and 3");
        }

        private void ValidateBeforeUpdate()
        {
            if (Id == 0)
                throw new Exception("ID cannot be zero.");
            else if (HotelId == 0)
                throw new Exception("Hotel ID cannot be zero.");
            else if (string.IsNullOrEmpty(Url))
                throw new Exception("URL cannot be empty or null.");
            else if (Position < 1 || Position > 3)
                throw new Exception("Position must be between 1 and 3");
        }
    }
}