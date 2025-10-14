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

            entity.ExamSessionAnswers = [.. collection.Exams.Select(q => new ExamSessionAnswer
            {
                Question = q.Question,
                Options = q.Options,
                Answer = q.Answer,
                Explanation = q.Explanation,
                SelectedOptionIndex = -1,
            })];

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