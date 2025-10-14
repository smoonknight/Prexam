using Prexam.DTOs;
using Prexam.Models;
using Prexam.Repositories;

namespace Prexam.Services
{
    public class CollectionService(IRepository<Collection> repository, IRepository<User> userRepository) : ServiceBase<IRepository<Collection>, Collection, CollectionRequest>(repository), IService<Collection, CollectionRequest>
    {
        private readonly IRepository<User> userRepository = userRepository;

        public override async Task<bool> AddAsync(Collection entity)
        {
            var user = await userRepository.GetByIdAsync(entity.UserId);
            if (user == null) return false;

            return await base.AddAsync(entity);
        }

        public override Collection GetEntity(CollectionRequest request) => new()
        {
            UserId = request.UserId,
            Title = request.Title,
            Description = request.Description,
            Duration = request.Duration,
        };

        public override void Update(Collection selectedEntity, Collection entity)
        {
            selectedEntity.Title = entity.Title;
            selectedEntity.Description = entity.Description;
            selectedEntity.Duration = entity.Duration;
        }
    }
}