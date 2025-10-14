using Microsoft.EntityFrameworkCore;
using Prexam.Data;
using Prexam.Models;
using Prexam.Repositories;

namespace Prexam.Repositories
{
    public class UserRepository(AppDbContext context) : RepositoryBase<User>(context), IRepository<User>
    {

    }
}