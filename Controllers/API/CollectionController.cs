using Microsoft.AspNetCore.Mvc;
using Prexam.Services;
using Prexam.Models;
using Prexam.DTOs;
using System.Net;

namespace Prexam.Controllers.Api
{
    [ApiController]
    [Route("api/[controller]")]
    public class CollectionController(IService<Collection, CollectionRequest> collectionService) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var collections = await collectionService.GetAllAsync();
            return Ok(new ApiResponse<IEnumerable<Collection>>(HttpStatusCode.OK, "Success", collections));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var collection = await collectionService.GetByIdAsync(id);

            if (collection == null)
            {
                return NotFound(new ApiResponse<Collection>(HttpStatusCode.NotFound, "Collection not found"));
            }

            return Ok(new ApiResponse<Collection>(HttpStatusCode.OK, "Success", collection));
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CollectionRequest request)
        {
            Collection collection = collectionService.GetEntity(request);
            var success = await collectionService.AddAsync(collection);
            if (!success) return NotFound(new ApiResponse<Collection>(HttpStatusCode.NotFound, "UserId not found"));

            return Created("", new ApiResponse<Collection>(HttpStatusCode.Created, "Success create data", collection));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] CollectionRequest request)
        {
            Collection collection = collectionService.GetEntity(request);
            var success = await collectionService.UpdateAsync(id, collection);
            if (!success) return NotFound(new ApiResponse<CollectionRequest>(HttpStatusCode.NotFound, "Collection not found"));

            return Ok(new ApiResponse<CollectionRequest>(HttpStatusCode.OK, "Success update data", request));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var success = await collectionService.DeleteAsync(id);
            if (!success) return NotFound(new ApiResponse<Collection>(HttpStatusCode.NotFound, "Collection not found"));

            return Ok(new ApiResponse<Collection>(HttpStatusCode.OK, "Success delete data"));
        }
    }
}