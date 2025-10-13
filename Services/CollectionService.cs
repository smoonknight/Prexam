using Prexam.DTOs;
using Prexam.Models;
using Prexam.Repositories;

namespace Prexam.Services
{
    public class CollectionService(IRepository<Collection> repository) : ServiceBase<IRepository<Collection>, Collection, CollectionRequest>(repository), IService<Collection, CollectionRequest>
    {
        public override Collection GetEntity(CollectionRequest request) => new()
        {
            Title = request.Title,
            Description = request.Description,
            Duration = request.Duration,
        };

        public override void Update(Collection selectedEntity, Collection entity)
        {
            selectedEntity.User = entity.User;
        }
    }
}