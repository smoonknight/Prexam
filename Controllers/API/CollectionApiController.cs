using Microsoft.AspNetCore.Mvc;
using Prexam.Services;
using Prexam.Models;
using Prexam.DTOs;
using System.Net;

namespace Prexam.Controllers.Api
{
    [Route("api/collection")]
    [ApiController]
    public class CollectionApiController(IService<Collection, CollectionRequest> service) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var collections = await service.GetAllAsync();
            return Ok(new ApiResponse<IEnumerable<Collection>>(HttpStatusCode.OK, "Success", collections));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var collection = await service.GetByIdAsync(id);

            if (collection == null)
            {
                return NotFound(new ApiResponse<Collection>(HttpStatusCode.NotFound, "Collection not found"));
            }

            return Ok(new ApiResponse<Collection>(HttpStatusCode.OK, "Success", collection));
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CollectionRequest request)
        {
            Collection collection = service.GetEntity(request);
            await service.AddAsync(collection);
            return Created("", new ApiResponse<Collection>(HttpStatusCode.Created, "Success create data", collection));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] CollectionRequest request)
        {
            Collection collection = service.GetEntity(request);
            var success = await service.UpdateAsync(id, collection);
            if (!success) return NotFound(new ApiResponse<Collection>(HttpStatusCode.NotFound, "Collection not found"));

            return Ok(new ApiResponse<Collection>(HttpStatusCode.OK, "Success update data", collection));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var success = await service.DeleteAsync(id);
            if (!success) return NotFound(new ApiResponse<Collection>(HttpStatusCode.NotFound, "Collection not found"));

            return Ok(new ApiResponse<Collection>(HttpStatusCode.OK, "Success delete data"));
        }
    }
}