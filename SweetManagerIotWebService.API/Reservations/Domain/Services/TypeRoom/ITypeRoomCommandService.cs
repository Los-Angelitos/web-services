using SweetManagerIotWebService.API.Reservations.Domain.Model.Commands.TypeRoom;
using SweetManagerIotWebService.API.Reservations.Domain.Model.Entities;

namespace SweetManagerIotWebService.API.Reservations.Domain.Services.TypeRoom;

public interface ITypeRoomCommandService
{
    Task<Domain.Model.Entities.TypeRoom?> Handle(CreateTypeRoomCommand command);

}