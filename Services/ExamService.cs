using Prexam.Models;
using Prexam.Repositories;
using Prexam.Services;

namespace Prexam.Services
{
    public class ExamService(IExamRepository repository) : IExamService
    {
        public async Task AddAsync(Exam exam) => await repository.AddAsync(exam);

        public async Task<bool> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Exam>> GetAllAsync() => await repository.GetAllAsync();
        public async Task<Exam?> GetByIdAsync(int id) => await repository.GetByIdAsync(id);

        public async Task<bool> UpdateAsync(int id, Exam exam)
        {
            var selectedExam = await repository.GetByIdAsync(id);
            if (selectedExam == null) return false;

            selectedExam.Question = exam.Question;
            selectedExam.Answer = exam.Answer;
            selectedExam.Explanation = exam.Explanation;
            selectedExam.Subject = exam.Subject;
            selectedExam.LevelType = exam.LevelType;

            await repository.UpdateAsync(selectedExam);
            return true;
        }

    }
}