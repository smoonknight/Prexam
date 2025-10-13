using Microsoft.AspNetCore.Mvc;
using Prexam.Services;
using Prexam.Models;
using Prexam.DTOs;
using System.Net;

namespace Prexam.Controllers.Api
{
    [Route("api/exam")]
    [ApiController]
    public class ExamApiController(IService<Exam, ExamRequest> service) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var exams = await service.GetAllAsync();
            return Ok(new ApiResponse<IEnumerable<Exam>>(HttpStatusCode.OK, "Success", exams));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var exam = await service.GetByIdAsync(id);
            if (exam == null)
            {
                return NotFound(new ApiResponse<Exam>(HttpStatusCode.NotFound, "Exam not found"));
            }
            return Ok(new ApiResponse<Exam>(HttpStatusCode.OK, "Success create data", exam));
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ExamRequest request)
        {
            Exam exam = service.GetEntity(request);
            await service.AddAsync(exam);
            return Created("", new ApiResponse<Exam>(HttpStatusCode.Created, "Success", exam));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] ExamRequest request)
        {
            Exam exam = service.GetEntity(request);
            var success = await service.UpdateAsync(id, exam);
            if (!success) return NotFound(new ApiResponse<Exam>(HttpStatusCode.NotFound, "Exam not found"));
            return Ok(new ApiResponse<Exam>(HttpStatusCode.OK, "Success update data", exam));
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