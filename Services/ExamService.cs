using Prexam.Models;
using Prexam.Services;

namespace Prexam.Services
{
    public class ExamService : IExamService
    {
        #region Example Exam (just placeholder)
        private readonly List<Exam> _exampleExams =
        [
            new() {
                Id = 1,
                Question = "What is the capital of France?",
                Options = new[] { "Berlin", "Madrid", "Paris", "Rome" },
                Answer = 2,
                Explanation = "Paris is the capital and most populous city of France.",
                Subject = "Geography",
                LevelType = LevelType.Easy
            },
            new() {
                Id = 2,
                Question = "Which data type is used to store true or false values in C#?",
                Options = new[] { "int", "bool", "string", "char" },
                Answer = 1,
                Explanation = "The 'bool' type is used to store Boolean values: true or false.",
                Subject = "Programming",
                LevelType = LevelType.Medium
            },
            new() {
                Id = 3,
                Question = "Solve: 12 × (3 + 5) = ?",
                Options = new[] { "96", "120", "60", "144" },
                Answer = 0,
                Explanation = "12 × (3 + 5) = 12 × 8 = 96.",
                Subject = "Math",
                LevelType = LevelType.Easy
            },
        ];
        #endregion

        public void Add(Exam exam) => _exampleExams.Add(exam);
        public List<Exam> GetAll() => _exampleExams;
        public Exam? GetById(int id) => _exampleExams.FirstOrDefault(s => s.Id == id);
    }
}