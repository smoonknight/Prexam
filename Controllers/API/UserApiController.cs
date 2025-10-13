using System.Net;
using Microsoft.AspNetCore.Mvc;
using Prexam.DTOs;
using Prexam.Models;
using Prexam.Services;

namespace Prexam.Controllers.Api
{
    [ApiController]
    [Route("api/user")]
    public class UserApiController(IService<User, UserRequest> service) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var exams = await service.GetAllAsync();
            return Ok(new ApiResponse<IEnumerable<User>>(HttpStatusCode.OK, "Success", exams));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var exam = await service.GetByIdAsync(id);
            if (exam == null)
            {
                return NotFound(new ApiResponse<Exam>(HttpStatusCode.NotFound, "Exam not found"));
            }
            return Ok(new ApiResponse<User>(HttpStatusCode.OK, "Success create data", exam));
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] UserRequest request)
        {
            var user = service.GetEntity(request);
            bool success = await service.AddAsync(user);

            UserResponse userResponse = new()
            {
                Email = user.Email,
                Name = user.Name,
            };

            if (!success) return Conflict(new ApiResponse<UserResponse>(HttpStatusCode.Conflict, "This email is already registered. Please use a different email."));
            return Created("", new ApiResponse<UserResponse>(HttpStatusCode.Created, "Success", userResponse));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] UserRequest request)
        {
            var user = service.GetEntity(request);
            var success = await service.UpdateAsync(id, user);

            UserResponse userResponse = new()
            {
                Email = user.Email,
                Name = user.Name,
            };

            if (!success) return NotFound(new ApiResponse<UserResponse>(HttpStatusCode.NotFound, "Exam not found"));
            return Ok(new ApiResponse<UserResponse>(HttpStatusCode.OK, "Success update data", userResponse));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var success = await service.DeleteAsync(id);
            if (!success) return NotFound(new ApiResponse<Exam>(HttpStatusCode.NotFound, "Exam not found"));
            return Ok(new ApiResponse<Exam>(HttpStatusCode.OK, "Success delete data"));
        }
    }
}