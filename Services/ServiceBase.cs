using Prexam.DTOs;
using Prexam.Repositories;

namespace Prexam.Services
{
    public abstract class ServiceBase<T, E, D>(T repository) where T : IRepository<E> where E : class where D : Request
    {
        protected readonly T repository = repository;

        public async virtual Task<bool> AddAsync(E entity)
        {
            await repository.AddAsync(entity);
            return true;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var selectedEntity = await repository.GetByIdAsync(id);
            if (selectedEntity == null) return false;

            await repository.DeleteAsync(id);
            return true;
        }

        public async Task<IEnumerable<E>> GetAllAsync() => await repository.GetAllAsync();
        public async Task<E?> GetByIdAsync(Guid id) => await repository.GetByIdAsync(id);

        public async Task<bool> UpdateAsync(Guid id, E entity)
        {
            var selectedEntity = await repository.GetByIdAsync(id);
            if (selectedEntity == null) return false;

            Update(selectedEntity, entity);

            await repository.UpdateAsync(selectedEntity);
            return true;
        }

        public abstract D GetRequest(E entity);
        public abstract E GetEntity(D request);
        public abstract void Update(E selectedEntity, E entity);
    }

}