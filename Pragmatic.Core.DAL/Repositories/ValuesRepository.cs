using Pragmatic.Common.Entities;
using Pragmatic.Core.DAL.DataAccess;
using System.Xml.Serialization;

namespace Pragmatic.Core.DAL.Repositories;

public class ValuesRepository : IValuesRepository
{
    private readonly ISqlDataAccess sql;

    public ValuesRepository(ISqlDataAccess _sql)
    {
        sql = _sql;
    }

    public async Task<List<ValueModel>> GetValuesAsync()
    {
        var rows = await sql.LoadDataAsync<ValueModel, dynamic>($"{SqlSchema.Schema}.spValues_Select", new { }, "Default");
        return rows.ToList();
    }

    public async Task<ValueModel> GetValueByIdAsync(int Id)
    {
        var results = await sql.LoadDataAsync<ValueModel, dynamic>($"{SqlSchema.Schema}.spValues_SelectById", new { Id }, "Default");
        return results.FirstOrDefault();
    }

    public async Task<ValueModel> CreateValueAsync(ValueModel Value)
    {
        var results = await sql.InsertDataAsync<ValueModel, ValueModel>($"{SqlSchema.Schema}.spValues_Insert", Value, "Default");
        return results;
    }

    public Task UpdateValueAsync(ValueModel Value)
    {
        return sql.UpdateDataAsync($"{SqlSchema.Schema}.spValues_Update", Value, "Default");
    }

    public Task DeleteValueByIdAsync(int Id)
    {
        return sql.DeleteDataAsync($"{SqlSchema.Schema}.spValues_DeleteById", Id, "Default");
    }

}
