using Microsoft.AspNetCore.Mvc;
using Prexam.Services;
using Prexam.Models;
using Prexam.DTOs;

namespace Prexam.Controllers
{
    [Route("[controller]")]
    [ApiExplorerSettings(IgnoreApi = true)]
    public class QuestionPageController(IService<Question, QuestionRequest> service) : Controller
    {
        [HttpGet("create/{collectionId}")]
        public IActionResult Create(Guid collectionId)
        {
            var questionRequest = new QuestionRequest { CollectionCode = collectionId };
            return View(questionRequest);
        }

        [HttpPost("create")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(QuestionRequest questionRequest)
        {
            var question = service.GetEntity(questionRequest);
            if (!ModelState.IsValid)
                return View(question);

            await service.AddAsync(question);
            return RedirectToAction("Edit", "Collection", new { id = question.CollectionCode });
        }

        [HttpGet("edit/{id}")]
        public async Task<IActionResult> Edit(Guid id)
        {
            var question = await service.GetByIdAsync(id);
            if (question == null) return NotFound();
            var questionRequest = service.GetRequest(question);
            return View(questionRequest);
        }

        [HttpPost("edit/{id}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, QuestionRequest updated)
        {
            var existing = service.GetEntity(updated);
            if (!ModelState.IsValid)
                return View(updated);

            var success = await service.UpdateAsync(id, existing);
            return RedirectToAction("Edit", "Collection", new { id = existing.CollectionCode });
        }

        [HttpGet("delete/{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var question = await service.GetByIdAsync(id);
            if (question == null) return NotFound();

            await service.DeleteAsync(id);
            return RedirectToAction("Edit", "Collection", new { id = question.CollectionCode });
        }
    }

}