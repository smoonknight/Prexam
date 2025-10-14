using Prexam.Data;
using Prexam.Models;

namespace Prexam.Repositories
{
    public class ExamSessionRepository(AppDbContext context) : RepositoryBase<ExamSession>(context), IRepository<ExamSession>
    {
    }
}