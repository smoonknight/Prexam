using System.Net;
using Microsoft.AspNetCore.Mvc;
using Prexam.DTOs;
using Prexam.Models;
using Prexam.Services;

namespace Prexam.Controllers.Api
{
    [ApiController]
    [Route("api/[controller]")]
    public class ExamSessionAnswerController(IExamSessionAnswerService service) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var examSessionAnswers = await service.GetAllAsync();
            return Ok(new ApiResponse<IEnumerable<ExamSessionAnswer>>(HttpStatusCode.OK, "Success", examSessionAnswers));
        }
        [HttpPost("{id}/submit")]
        public async Task<IActionResult> Submit(Guid id, [FromBody] int selectedOptionIndex)
        {
            ExamSessionAnswer examSessionAnswer = new()
            {
                SelectedOptionIndex = selectedOptionIndex
            };

            var success = await service.UpdateAsync(id, examSessionAnswer);
            if (!success) return NotFound(new ApiResponse<ExamSessionAnswer>(HttpStatusCode.NotFound, "Exam Session Answer not found"));
            return Ok(new ApiResponse<int>(HttpStatusCode.OK, "Success", selectedOptionIndex));
        }
    }
}