using Microsoft.EntityFrameworkCore;
using Prexam.Data;
using Prexam.Models;

namespace Prexam.Repositories
{
    public class ExamRepository(AppDbContext context) : IExamRepository
    {

        public async Task AddAsync(Exam exam)
        {
            context.Exams.Add(exam);
            await context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var exam = await GetByIdAsync(id);
            if (exam != null)
            {
                context.Exams.Remove(exam);
                await context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Exam>> GetAllAsync() => await context.Exams.AsNoTracking().ToListAsync();

        public async Task<Exam?> GetByIdAsync(int id)
        {
            return await context.Exams.FindAsync(id);
        }

        public async Task UpdateAsync(Exam exam)
        {
            context.Exams.Update(exam);
            await context.SaveChangesAsync();
        }
    }
}