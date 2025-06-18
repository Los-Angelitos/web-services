using SweetManagerIotWebService.API.Inventory.Domain.Model.Aggregates;
using SweetManagerIotWebService.API.Inventory.Domain.Model.Commands;
using SweetManagerIotWebService.API.Inventory.Domain.Repositories;
using SweetManagerIotWebService.API.Inventory.Domain.Services;
using SweetManagerIotWebService.API.Shared.Domain.Repositories;

namespace SweetManagerIotWebService.API.Inventory.Application.Internal.CommandServices;

public class RfidCardCommandService(IRfidCardRepository rfidCardRepository, IUnitOfWork unitOfWork) : IRfidCardCommandService
{
    public async Task<RfidCard?> Handle(CreateRfidCardCommand command)
    {
        var rfidCard = new RfidCard(command);
        try
        {
            await rfidCardRepository.AddAsync(rfidCard);
            await unitOfWork.CommitAsync();
            return rfidCard;
        } catch (Exception e)
        {
            Console.WriteLine($"An error occurred while creating the RFID Card: {e.Message}");
            return null;
        }
    }
}