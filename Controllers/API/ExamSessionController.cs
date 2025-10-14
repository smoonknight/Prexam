using Microsoft.AspNetCore.Mvc;
using Prexam.Data;
using Prexam.DTOs;
using Prexam.Models;
using Prexam.Services;

namespace Prexam.Controllers.Api
{
    [ApiController]
    [Route("api/[controller]")]
    public class ExamSessionController(IService<ExamSession, ExamSessionRequest> service) : ControllerBase
    {
        // [HttpPost("start")]
        // public async Task<IActionResult> StartExam([FromBody] StartExamRequest request)
        // {

        // }
    }
}