using SweetManagerIotWebService.API.Commerce.Domain.Model.Aggregates;

namespace SweetManagerIotWebService.API.Commerce.Domain.Repositories;

public interface IPaymentCustomerRepository
{
    Task<IEnumerable<PaymentCustomer>> FindByCustomerIdAsync(int customerId);
}