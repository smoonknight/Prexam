using Microsoft.EntityFrameworkCore;
using Prexam.Data;
using Prexam.Models;

namespace Prexam.Repositories
{
    public class QuestionRepository(AppDbContext context) : RepositoryBase<Question>(context), IRepository<Question>
    {
        public override async Task<Question?> GetByIdAsync(Guid id)
        {
            return await dbSet.Include(t => t.Collection).FirstOrDefaultAsync(c => c.Id == id);
        }
    }
}