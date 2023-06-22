namespace Pragmatic.Core.DAL.DataAccess
{
    public interface ISqlDataAccess
    {
        Task DeleteDataAsync<T>(string storedProcedure, T parameters, string connectionStringName);
        Task<T> InsertDataAsync<T, U>(string storedProcedure, U parameters, string connectionStringName);
        Task<List<T>> LoadDataAsync<T, U>(string storedProcedure, U parameters, string connectionStringName);
        Task UpdateDataAsync<T>(string storedProcedure, T parameters, string connectionStringName);
    }
}