using Microsoft.EntityFrameworkCore;
using Prexam.Data;
using Prexam.Models;

namespace Prexam.Repositories
{
    public class ExamSessionAnswerRepository(AppDbContext context) : IExamSessionAnswerRepository
    {
        public async Task DeleteAsync(Guid id)
        {
            var selectedExamSessionAnswer = await GetByIdAsync(id);
            if (selectedExamSessionAnswer == null) return;

            context.ExamSessionAnswers.Remove(selectedExamSessionAnswer);
            await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<ExamSessionAnswer>> GetAllAsync() => await context.ExamSessionAnswers.AsNoTracking().ToListAsync();

        public async Task<ExamSessionAnswer?> GetByIdAsync(Guid id) => await context.ExamSessionAnswers.FindAsync(id);

        public async Task UpdateAsync(ExamSessionAnswer examSessionAnswer)
        {
            context.ExamSessionAnswers.Update(examSessionAnswer);
            await context.SaveChangesAsync();
        }
    }
}