using SweetManagerIotWebService.API.Commerce.Domain.Model.Aggregates;

namespace SweetManagerIotWebService.API.Commerce.Domain.Repositories;

public interface IPaymentOwnerRepository
{
    Task<IEnumerable<PaymentOwner>> FindByOwnerIdAsync(int ownerId);
}