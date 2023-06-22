using Pragmatic.Common.Entities;

namespace Pragmatic.Core.DAL.Repositories
{
    public interface IValuesRepository
    {
        Task<ValueModel> CreateValueAsync(ValueModel Value);
        Task DeleteValueByIdAsync(int Id);
        Task<ValueModel> GetValueByIdAsync(int Id);
        Task<List<ValueModel>> GetValuesAsync();
        Task UpdateValueAsync(ValueModel Value);
    }
}