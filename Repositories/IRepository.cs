using System.Linq.Expressions;
using Prexam.Models;

namespace Prexam.Repositories
{
    public interface IRepository<T>
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T?> GetByIdAsync(Guid id);
        Task<T?> GetByParamAsync(Expression<Func<T, bool>> predicate);
        Task AddAsync(T exam);
        Task UpdateAsync(T exam);
        Task DeleteAsync(Guid id);
    }
}