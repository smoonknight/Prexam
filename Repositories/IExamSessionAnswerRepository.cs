using Prexam.Models;

namespace Prexam.Repositories
{
    public interface IExamSessionAnswerRepository
    {
        Task<IEnumerable<ExamSessionAnswer>> GetAllAsync();
        Task<ExamSessionAnswer?> GetByIdAsync(Guid id);
        Task UpdateAsync(ExamSessionAnswer examSessionAnswer);
        Task DeleteAsync(Guid id);
    }
}