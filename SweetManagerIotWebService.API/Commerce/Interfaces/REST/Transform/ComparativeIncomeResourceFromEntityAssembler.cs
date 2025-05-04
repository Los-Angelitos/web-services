using SweetManagerIotWebService.API.Commerce.Interfaces.REST.Resources;

namespace SweetManagerIotWebService.API.Commerce.Interfaces.REST.Transform;

public static class ComparativeIncomeResourceFromEntityAssembler
{
    public static ComparativeIncomeResource ToResourceFromEntity(dynamic entity)
    {
        return new ComparativeIncomeResource(entity.week_number, entity.total_income, entity.total_expense,
            entity.total_profit);
    }
}