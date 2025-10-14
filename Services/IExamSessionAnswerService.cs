using Prexam.Models;

namespace Prexam.Services
{
    public interface IExamSessionAnswerService
    {
        Task<IEnumerable<ExamSessionAnswer>> GetAllAsync();
        Task<bool> UpdateAsync(Guid id, ExamSessionAnswer examSessionAnswer);
        Task<bool> DeleteAsync(Guid id);
    }
}