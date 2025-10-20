using Prexam.DTOs;
using Prexam.Models;

namespace Prexam.Services
{
    public interface IService<T, R> where T : class where R : Request
    {
        T GetEntity(R request);
        R GetRequest(T entity);
        Task<IEnumerable<T>> GetAllAsync();
        Task<T?> GetByIdAsync(Guid id);
        Task<bool> AddAsync(T entity);
        Task<bool> UpdateAsync(Guid id, T entity);
        Task<bool> DeleteAsync(Guid id);
    }
}