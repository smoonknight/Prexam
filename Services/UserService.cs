using System.Threading.Tasks;
using Prexam.DTOs;
using Prexam.Models;
using Prexam.Repositories;

namespace Prexam.Services
{
    public class UserService(IRepository<User> repository) : ServiceBase<IRepository<User>, User, UserRequest>(repository), IService<User, UserRequest>
    {
        readonly IRepository<User> repository = repository;

        public async override Task<bool> AddAsync(User entity)
        {
            var user = await repository.GetByParamAsync(t => t.Email == entity.Email);
            if (user != null)
            {
                return false;
            }
            return await base.AddAsync(entity);
        }

        public override User GetEntity(UserRequest request)
        {
            User user = new()
            {
                Email = request.Email,
                Name = request.Name,
            };

            PasswordService passwordService = new();

            user.PasswordHash = passwordService.HashPassword(user, request.Password);
            return user;
        }

        public override void Update(User selectedEntity, User entity)
        {
            selectedEntity.Name = entity.Name;
        }
    }
}