using SweetManagerIotWebService.API.Inventory.Domain.Model.Commands;
using SweetManagerIotWebService.API.Inventory.Domain.Repositories;
using SweetManagerIotWebService.API.Inventory.Domain.Services;
using SweetManagerIotWebService.API.Shared.Domain.Repositories;
using SweetManagerIotWebService.API.Inventory.Domain.Model.Exceptions.Supply;

namespace SweetManagerIotWebService.API.Inventory.Application.Internal.CommandServices;

public class SupplyCommandService(ISupplyRepository supplyRepository, IUnitOfWork unitOfWork) : ISupplyCommandService
{

    public async Task<bool> Handle(CreateSupplyCommand command)
    {
        try
        {

            if (string.IsNullOrWhiteSpace(command.Name))
                throw new InvalidSupplyNameException("The name of the supply cannot be empty.");
        
            if (command.Price <= 0)
                throw new InvalidSupplyPriceException("The price of the supply must be greater than zero.");
        
            if (command.Stock < 0)
                throw new InvalidSupplyStockException("The stock of the supply cannot be negative.");

            
            await supplyRepository.AddAsync(new (command));
            await unitOfWork.CommitAsync();
            return true;
        }
        catch (Exception e)
        {
            
            return false;
        } 
    }
    
    public async Task<bool> Handle(UpdateSupplyCommand command)
    {
        try
        {
            var existingSupply = await supplyRepository.FindByIdAsync(command.Id);

            if (existingSupply == null)
                throw new SupplyNotFoundException($"The supply with ID {command.Id} was not found.");
            
            if (string.IsNullOrWhiteSpace(command.Name))
                throw new InvalidSupplyNameException("The name of the supply cannot be empty.");
        
            if (command.Price <= 0)
                throw new InvalidSupplyPriceException("The price of the supply must be greater than zero.");
        
            if (command.Stock < 0)
                throw new InvalidSupplyStockException("The stock of the supply cannot be negative.");
            
            
            existingSupply.Update(command);
            await unitOfWork.CommitAsync();

            return true;
        }
        catch (Exception e)
        {
            return false;
        }
    }

    public async Task<bool> Handle(UpdateProviderOnSupplyCommand command)
    {
        if (await supplyRepository.FindByIdAsync(command.Id) is null)
            throw new SupplyNotFoundException("No supply found with the given id");

        var result = await supplyRepository.ExecuteUpdateProviderIdAsync(command.Id, command.ProviderId);

        await unitOfWork.CommitAsync();

        return result;
    }
}