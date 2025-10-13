using Prexam.DTOs;
using Prexam.Models;
using Prexam.Repositories;

namespace Prexam.Services
{
    public class ExamService(IRepository<Exam> repository) : ServiceBase<IRepository<Exam>, Exam, ExamRequest>(repository), IService<Exam, ExamRequest>
    {
        public override Exam GetEntity(ExamRequest request) => new()
        {
            CollectionCode = request.CollectionCode,
            Question = request.Question,
            Options = request.Options,
            Answer = request.Answer,
            Explanation = request.Explanation,
            Subject = request.Subject,
            LevelType = request.LevelType,
        };

        public override void Update(Exam selectedEntity, Exam entity)
        {
            selectedEntity.Question = entity.Question;
            selectedEntity.Options = entity.Options;
            selectedEntity.Answer = entity.Answer;
            selectedEntity.Explanation = entity.Explanation;
            selectedEntity.Subject = entity.Subject;
            selectedEntity.LevelType = entity.LevelType;
        }
    }
}