using System.Threading.Tasks;
using Prexam.DTOs;
using Prexam.Models;
using Prexam.Repositories;
using Prexam.Utils;

namespace Prexam.Services
{
    public class UserService(IRepository<User> repository) : ServiceBase<IRepository<User>, User, UserRequest>(repository), IService<User, UserRequest>
    {
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

            PasswordHelper passwordHelper = new();

            user.PasswordHash = passwordHelper.HashPassword(user, request.Password);
            return user;
        }

        public override void Update(User selectedEntity, User entity)
        {
            selectedEntity.Name = entity.Name;
        }
    }
}