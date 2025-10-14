using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Prexam.Data;

namespace Prexam.Repositories
{
    public abstract class RepositoryBase<T>(AppDbContext context) where T : class
    {
        protected readonly AppDbContext context = context;
        protected readonly DbSet<T> dbSet = context.Set<T>();

        public async Task AddAsync(T entity)
        {
            dbSet.Add(entity);
            await context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var entity = await GetByIdAsync(id);
            if (entity != null)
            {
                dbSet.Remove(entity);
                await context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<T>> GetAllAsync() => await dbSet.AsNoTracking().ToListAsync();

        public async virtual Task<T?> GetByIdAsync(Guid id)
        {
            return await dbSet.FindAsync(id);
        }

        public async Task<T?> GetByParamAsync(Expression<Func<T, bool>> predicate)
        {
            return await dbSet.Where(predicate).FirstOrDefaultAsync();
        }

        public async Task UpdateAsync(T entity)
        {
            dbSet.Update(entity);
            await context.SaveChangesAsync();
        }
    }
}