using Prexam.Models;

namespace Prexam.Services
{
    public interface IExamService
    {
        Task<IEnumerable<Exam>> GetAllAsync();
        Task<Exam?> GetByIdAsync(int id);
        Task AddAsync(Exam exam);
        Task<bool> UpdateAsync(int id, Exam exam);
        Task<bool> DeleteAsync(int id);
    }
}