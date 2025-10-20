using Prexam.DTOs;
using Prexam.Models;
using Prexam.Repositories;

namespace Prexam.Services
{
    public class QuestionService(IRepository<Question> examRepository, IRepository<Collection> collectionRepository) : ServiceBase<IRepository<Question>, Question, QuestionRequest>(examRepository), IService<Question, QuestionRequest>
    {
        public async override Task<bool> AddAsync(Question entity)
        {
            var collection = await collectionRepository.GetByIdAsync(entity.CollectionCode);
            if (collection == null) return false;

            return await base.AddAsync(entity);
        }
        public override Question GetEntity(QuestionRequest request) => new()
        {
            CollectionCode = request.CollectionCode,
            Description = request.Description,
            Options = request.Options,
            Answer = request.Answer,
            Explanation = request.Explanation,
            Subject = request.Subject,
            LevelType = request.LevelType,
        };

        public override QuestionRequest GetRequest(Question entity) => new()
        {
            CollectionCode = entity.CollectionCode,
            Description = entity.Description,
            Options = entity.Options,
            Answer = entity.Answer,
            Explanation = entity.Explanation,
            Subject = entity.Subject,
            LevelType = entity.LevelType,
        };

        public override void Update(Question selectedEntity, Question entity)
        {
            selectedEntity.Description = entity.Description;
            selectedEntity.Options = entity.Options;
            selectedEntity.Answer = entity.Answer;
            selectedEntity.Explanation = entity.Explanation;
            selectedEntity.Subject = entity.Subject;
            selectedEntity.LevelType = entity.LevelType;
        }
    }
}