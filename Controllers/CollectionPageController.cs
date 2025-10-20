using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using Prexam.DTOs;
using Prexam.Models;
using Prexam.Services;

namespace Prexam.Controllers
{
    [Route("[controller]")]
    [ApiExplorerSettings(IgnoreApi = true)]
    public class CollectionPageController(IService<Collection, CollectionRequest> service) : Controller
    {
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var collections = await service.GetAllAsync();
            return View(collections);
        }

        [HttpGet("edit/{id}")]
        public async Task<IActionResult> Edit(Guid id)
        {
            var collection = await service.GetByIdAsync(id);
            if (collection == null) return NotFound();
            return View(collection);
        }

        [HttpPost("edit/{id}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, CollectionRequest updatedCollectionRequest)
        {
            var updatedCollection = service.GetEntity(updatedCollectionRequest);
            if (!ModelState.IsValid)
            {
                return View(updatedCollection);
            }

            var success = await service.UpdateAsync(id, updatedCollection);

            return RedirectToAction(nameof(Index));
        }
    }
}
