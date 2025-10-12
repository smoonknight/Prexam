using Prexam.Models;

namespace Prexam.Services
{
    public interface IExamService
    {
        List<Exam> GetAll();
        Exam? GetById(int id);
        void Add(Exam exam);
    }
}