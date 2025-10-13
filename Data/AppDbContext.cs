using Microsoft.EntityFrameworkCore;
using Prexam.Models;

namespace Prexam.Data
{
    public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
    {
        public DbSet<Exam> Exams => Set<Exam>();
        public DbSet<Collection> Collections => Set<Collection>();
        public DbSet<User> Users => Set<User>();
    }
}