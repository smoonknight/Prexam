using Microsoft.EntityFrameworkCore;
using Prexam.Data;
using Prexam.Models;

namespace Prexam.Repositories
{
    public class ExamRepository(AppDbContext context) : RepositoryBase<Exam>(context), IRepository<Exam>
    {
        public override async Task<Exam?> GetByIdAsync(Guid id)
        {
            return await dbSet.Include(t => t.Collection).FirstOrDefaultAsync(c => c.Id == id);
        }
    }
}