namespace SweetManagerIotWebService.API.Commerce.Domain.Repositories;

public interface IDashboardRepository
{
    Task<IEnumerable<dynamic>> FindComparativeIncomesAsync(int hotelId);
}