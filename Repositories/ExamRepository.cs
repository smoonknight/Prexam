using Microsoft.EntityFrameworkCore;
using Prexam.Data;
using Prexam.Models;

namespace Prexam.Repositories
{
    public class ExamRepository(AppDbContext context) : RepositoryBase<Exam>(context), IRepository<Exam>
    {
    }
}