namespace SweetManagerIotWebService.API.Commerce.Interfaces.REST.Resources;

public record ComparativeIncomeResource(int? WeekNumbers, decimal TotalIncome, decimal TotalExpense, decimal TotalProfit);