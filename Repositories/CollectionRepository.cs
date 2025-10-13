using Prexam.Data;
using Prexam.Models;
using Prexam.Repositories;

namespace Prexam.Repositories
{
    public class CollectionRepository(AppDbContext context) : RepositoryBase<Collection>(context), IRepository<Collection>
    {
    }
}