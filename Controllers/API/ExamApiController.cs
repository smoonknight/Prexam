using Microsoft.AspNetCore.Mvc;
using Prexam.Services;
using Prexam.Models;
using Prexam.DTOs;
using System.Net;
using Microsoft.VisualBasic;

namespace Prexam.Controllers.Api
{
    [Route("api/exam")]
    [ApiController]
    public class ExamApiController(IExamService service) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var exams = service.GetAllAsync();
            return Ok(new ApiResponse<IEnumerable<Exam>>(HttpStatusCode.OK, "Success", await exams));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var exam = service.GetByIdAsync(id);
            if (exam == null)
            {
                return NotFound(new ApiResponse<Exam>(HttpStatusCode.NotFound, "Exam not found"));
            }
            return Ok(new ApiResponse<Exam>(HttpStatusCode.OK, "Success create data", await exam));
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Exam exam)
        {
            await service.AddAsync(exam);
            return Created("", new ApiResponse<Exam>(HttpStatusCode.Created, "Success", exam));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Exam exam)
        {
            var success = await service.UpdateAsync(id, exam);
            if (!success) return NotFound(new ApiResponse<Exam>(HttpStatusCode.NotFound, "Exam not found"));
            return Ok(new ApiResponse<Exam>(HttpStatusCode.OK, "Success update data", exam));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var success = await service.DeleteAsync(id);
            if (!success) return NotFound(new ApiResponse<Exam>(HttpStatusCode.NotFound, "Exam not found"));
            return Ok(new ApiResponse<Exam>(HttpStatusCode.OK, "Success delete data"));
        }
    }
}