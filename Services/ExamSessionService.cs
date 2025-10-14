using Prexam.DTOs;
using Prexam.Models;
using Prexam.Repositories;

namespace Prexam.Services
{
    public class ExamSessionService(IRepository<ExamSession> repository) : ServiceBase<IRepository<ExamSession>, ExamSession, ExamSessionRequest>(repository), IService<ExamSession, ExamSessionRequest>
    {
        public override ExamSession GetEntity(ExamSessionRequest request)
        {
            throw new NotImplementedException();
        }

        public override void Update(ExamSession selectedEntity, ExamSession entity)
        {
            throw new NotImplementedException();
        }
    }
}