using Microsoft.EntityFrameworkCore;
using Prexam.Data;
using Prexam.Models;
using Prexam.Repositories;

namespace Prexam.Repositories
{
    public class CollectionRepository(AppDbContext context) : RepositoryBase<Collection>(context), IRepository<Collection>
    {
        public override async Task<Collection?> GetByIdAsync(Guid id)
        {
            return await dbSet.Include(c => c.User).Include(c => c.Questions).FirstOrDefaultAsync(c => c.CollectionCode == id);
        }
    }
}