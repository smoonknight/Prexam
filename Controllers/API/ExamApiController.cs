using Microsoft.AspNetCore.Mvc;
using Prexam.Services;
using Prexam.Models;
using Prexam.DTOs;

namespace Prexam.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExamApiController(IExamService examService) : ControllerBase
    {
        private readonly IExamService examService = examService;

        [HttpGet]
        public IActionResult GetAll()
        {
            var exams = examService.GetAll();
            return Ok(new ApiResponse<List<Exam>>(200, "Success", exams));
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var exam = examService.GetById(id);
            if (exam == null)
            {
                return NotFound(new ApiResponse<Exam>(404, "Exam not found"));
            }
            return Ok(new ApiResponse<Exam>(200, "Success", exam));
        }

        [HttpPost]
        public IActionResult Create([FromBody] Exam exam)
        {
            examService.Add(exam);
            return Ok(new ApiResponse<Exam>(201, "Success", exam));
        }
    }
}