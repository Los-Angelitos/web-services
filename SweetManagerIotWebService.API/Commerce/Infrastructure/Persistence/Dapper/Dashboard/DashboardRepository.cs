using System.Data;
using Dapper;
using SweetManagerIotWebService.API.Commerce.Domain.Repositories;

namespace SweetManagerIotWebService.API.Commerce.Infrastructure.Persistence.Dapper.Dashboard;

public class DashboardRepository(IDbConnection dbConnection) : IDashboardRepository
{
    public async Task<IEnumerable<dynamic>> FindWeeklyComparativeIncomesAsync(int hotelId)
    {
        string query = $"SELECT " +
                       $"WEEK(pc.created_at) AS week_number, " +
                       $"YEAR(pc.created_at) AS year_number, " +
                       $"SUM(pc.final_amount) AS total_income, " +
                       $"SUM(po.final_amount) AS total_expense, " +
                       $"(SUM(pc.final_amount) - SUM(po.final_amount)) AS total_profit " +
                       $"FROM payments_customers pc " +
                       $"LEFT JOIN payments_owners po ON WEEK(pc.created_at) = WEEK(po.created_at) AND YEAR(pc.created_at) = YEAR(po.created_at) " +
                       $"JOIN hotels ho ON po.owners_id = ho.owners_id " +
                       $"WHERE ho.id = {hotelId} " +
                       $"GROUP BY WEEK(pc.created_at), YEAR(pc.created_at) " +
                       $"ORDER BY year_number, week_number";

        var result = await dbConnection.QueryAsync<dynamic>(query, commandType: CommandType.Text);
        return result;
    }

    public async Task<IEnumerable<dynamic>> FindMonthlyComparativeIncomesAsync(int hotelId)
    {
        string query = $"SELECT " +
                       $"MONTH(pc.created_at) AS month_number, " +
                       $"YEAR(pc.created_at) AS year_number, " +
                       $"SUM(pc.final_amount) AS total_income, " +
                       $"SUM(po.final_amount) AS total_expense, " +
                       $"(SUM(pc.final_amount) - SUM(po.final_amount)) AS total_profit " +
                       $"FROM payments_customers pc " +
                       $"LEFT JOIN payments_owners po ON MONTH(pc.created_at) = MONTH(po.created_at) AND YEAR(pc.created_at) = YEAR(po.created_at) " +
                       $"JOIN hotels ho ON po.owners_id = ho.owners_id " +
                       $"WHERE ho.id = {hotelId} " +
                       $"GROUP BY MONTH(pc.created_at), YEAR(pc.created_at) " +
                       $"ORDER BY year_number, month_number";

        var result = await dbConnection.QueryAsync<dynamic>(query, commandType: CommandType.Text);
        return result;
    }

}