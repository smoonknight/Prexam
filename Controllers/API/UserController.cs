using System.Net;
using Microsoft.AspNetCore.Mvc;
using Prexam.DTOs;
using Prexam.Models;
using Prexam.Services;

namespace Prexam.Controllers.Api
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController(IService<User, UserRequest> service) : ControllerBase
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
                return NotFound(new ApiResponse<Question>(HttpStatusCode.NotFound, "Exam not found"));
            }
            return Ok(new ApiResponse<User>(HttpStatusCode.OK, "Success create data", exam));
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] UserRequest request)
        {
            var user = service.GetEntity(request);
            bool success = await service.AddAsync(user);

            if (!success) return Conflict(new ApiResponse<User>(HttpStatusCode.Conflict, "This email is already registered. Please use a different email."));
            return Created("", new ApiResponse<User>(HttpStatusCode.Created, "Success", user));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] UserRequest request)
        {
            var user = service.GetEntity(request);
            var success = await service.UpdateAsync(id, user);

            if (!success) return NotFound(new ApiResponse<UserRequest>(HttpStatusCode.NotFound, "Exam not found"));
            return Ok(new ApiResponse<UserRequest>(HttpStatusCode.OK, "Success update data", request));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var success = await service.DeleteAsync(id);
            if (!success) return NotFound(new ApiResponse<Question>(HttpStatusCode.NotFound, "Exam not found"));
            return Ok(new ApiResponse<Question>(HttpStatusCode.OK, "Success delete data"));
        }
    }
}