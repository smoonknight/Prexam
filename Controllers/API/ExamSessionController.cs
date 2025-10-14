using System.Net;
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
        [HttpPost("start")]
        public async Task<IActionResult> StartExam([FromBody] ExamSessionRequest request)
        {
            var examSession = service.GetEntity(request);
            var success = await service.AddAsync(examSession);
            if (!success) return NotFound(new ApiResponse<ExamSession>(HttpStatusCode.NotFound, "Collection not found"));
            return Ok(new ApiResponse<ExamSession>(HttpStatusCode.OK, "Success", examSession));
        }
    }
}