using Prexam.DTOs;
using Prexam.Models;

namespace Prexam.Services
{
    public interface IService<T, R> where T : class where R : Request
    {
        T GetEntity(R request);
        Task<IEnumerable<T>> GetAllAsync();
        Task<T?> GetByIdAsync(Guid id);
        Task<bool> AddAsync(T exam);
        Task<bool> UpdateAsync(Guid id, T exam);
        Task<bool> DeleteAsync(Guid id);
    }
}