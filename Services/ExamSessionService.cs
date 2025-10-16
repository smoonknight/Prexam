using Prexam.DTOs;
using Prexam.Models;
using Prexam.Repositories;

namespace Prexam.Services
{
    public class ExamSessionService(IRepository<ExamSession> examSessionRepository, IRepository<Collection> collectionRepository) : ServiceBase<IRepository<ExamSession>, ExamSession, ExamSessionRequest>(examSessionRepository), IService<ExamSession, ExamSessionRequest>
    {
        public override async Task<bool> AddAsync(ExamSession entity)
        {
            var collection = await collectionRepository.GetByIdAsync(entity.CollectionCode);
            if (collection == null) return false;
            entity.Duration = collection.Duration;

            var random = new Random();

            entity.ExamSessionAnswers = [.. collection.Exams.Where(exam => !exam.LevelType.HasValue || exam.LevelType <= entity.MaximumLevelType).OrderBy(x => random.Next()).Select(exam =>
            {
                var shuffledOptions = exam.Options.OrderBy(x => random.Next()).ToList();
                var correctIndex = shuffledOptions.IndexOf(exam.Options[exam.Answer]);
                return new ExamSessionAnswer
                {
                    Question = exam.Question,
                    Options = [.. shuffledOptions],
                    Answer = correctIndex,
                    Explanation = exam.Explanation,
                    SelectedOptionIndex = -1,
                    ExamSession = entity,
                };
            })];

            entity.TotalExam = entity.ExamSessionAnswers.Count;

            return await base.AddAsync(entity);
        }
        public override ExamSession GetEntity(ExamSessionRequest request) => new()
        {
            CollectionCode = request.CollectionCode,
            Name = request.Name,
            MaximumLevelType = request.MaximumLevelType,
        };

        public override void Update(ExamSession selectedEntity, ExamSession entity)
        {
            selectedEntity.Name = entity.Name;
            selectedEntity.MaximumLevelType = entity.MaximumLevelType;
            selectedEntity.CollectionCode = entity.CollectionCode;
            selectedEntity.Collection = entity.Collection;
            selectedEntity.Duration = entity.Duration;
            selectedEntity.EndTime = entity.EndTime;
            selectedEntity.Status = entity.Status;
            selectedEntity.ExamSessionAnswers = entity.ExamSessionAnswers;
        }
    }
}