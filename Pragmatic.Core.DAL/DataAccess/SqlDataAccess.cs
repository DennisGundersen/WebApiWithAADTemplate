using Dapper;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Pragmatic.Core.DAL.DataAccess;

public class SqlDataAccess : ISqlDataAccess
{
    private readonly IConfiguration config;

    public SqlDataAccess(IConfiguration _config)
    {
        config = _config;
    }

    public async Task<List<T>> LoadDataAsync<T, U>(string storedProcedure, U parameters, string connectionStringName)
    {
        string connectionString = config.GetConnectionString(connectionStringName);

        using IDbConnection connection = new SqlConnection(connectionString);

        var rows = await connection.QueryAsync<T>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);

        return rows.ToList();
    }

    public async Task<T> InsertDataAsync<T, U>(string storedProcedure, U parameters, string connectionStringName)
    {
        string connectionString = config.GetConnectionString(connectionStringName);

        using IDbConnection connection = new SqlConnection(connectionString);

        // Returns a copy of the newly inserted row (complete with new ID)
        var result = await connection.QuerySingleAsync<T>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);

        return result;
    }

    public Task UpdateDataAsync<T>(string storedProcedure, T parameters, string connectionStringName)
    {
        string connectionString = config.GetConnectionString(connectionStringName);

        using IDbConnection connection = new SqlConnection(connectionString);

        // No need to await as nothing is returned, so just return Task
        return connection.ExecuteAsync(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
    }

    public Task DeleteDataAsync<T>(string storedProcedure, T parameters, string connectionStringName)
    {
        string connectionString = config.GetConnectionString(connectionStringName);

        using IDbConnection connection = new SqlConnection(connectionString);

        // No need to await as nothing is returned, so just return Task
        return connection.ExecuteAsync(storedProcedure, new { Id = parameters }, commandType: CommandType.StoredProcedure);
    }
}