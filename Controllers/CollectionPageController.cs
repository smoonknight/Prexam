using Microsoft.AspNetCore.Mvc;
using Prexam.DTOs;
using Prexam.Models;
using Prexam.Services;

namespace Prexam.Controllers
{
    [Route("[controller]")]
    [ApiExplorerSettings(IgnoreApi = true)]
    public class CollectionPageController(
        IService<Collection, CollectionRequest> collectionService,
        IService<Question, QuestionRequest> questionService) : Controller
    {
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var collections = await collectionService.GetAllAsync();
            return View(collections);
        }

        [HttpGet("edit/{collectionCode}")]
        public async Task<IActionResult> Edit(Guid collectionCode)
        {
            var collection = await collectionService.GetByIdAsync(collectionCode);
            if (collection == null) return NotFound();
            return View(collection);
        }

        [HttpPost("edit/{collectionCode}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid collectionCode, CollectionRequest updated)
        {
            if (!ModelState.IsValid)
                return View(updated);

            var entity = collectionService.GetEntity(updated);
            var success = await collectionService.UpdateAsync(collectionCode, entity);

            if (!success)
                ModelState.AddModelError("", "Failed to update collection.");

            return RedirectToAction(nameof(Index));
        }

        // ==============================
        // CREATE QUESTION
        // ==============================
        [HttpGet("edit/{collectionCode}/question/create")]
        public IActionResult CreateQuestion(Guid collectionCode)
        {
            var model = new QuestionRequest { CollectionCode = collectionCode };
            ViewData["FormAction"] = "CreateQuestion";
            return View("QuestionForm", model);
        }

        [HttpPost("edit/{collectionCode}/question/create")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateQuestion(Guid collectionCode, QuestionRequest request)
        {
            if (!ModelState.IsValid)
            {
                ViewData["FormAction"] = "CreateQuestion";
                return View("QuestionForm", request);
            }

            var entity = questionService.GetEntity(request);
            await questionService.AddAsync(entity);

            return RedirectToAction("Edit", new { collectionCode });
        }

        // ==============================
        // EDIT QUESTION
        // ==============================
        [HttpGet("edit/{collectionCode}/question/{questionId}/edit")]
        public async Task<IActionResult> EditQuestion(Guid collectionCode, Guid questionId)
        {
            var question = await questionService.GetByIdAsync(questionId);
            if (question == null) return NotFound();

            var model = questionService.GetRequest(question);
            ViewData["FormAction"] = "EditQuestion";
            ViewBag.QuestionId = questionId;
            return View("QuestionForm", model);
        }

        [HttpPost("edit/{collectionCode}/question/{questionId}/edit")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditQuestion(Guid collectionCode, Guid questionId, QuestionRequest updated)
        {
            if (!ModelState.IsValid)
            {
                ViewData["FormAction"] = "EditQuestion";
                return View("QuestionForm", updated);
            }

            var entity = questionService.GetEntity(updated);
            var success = await questionService.UpdateAsync(questionId, entity);

            if (!success)
                ModelState.AddModelError("", "Failed to update question.");

            return RedirectToAction("Edit", new { collectionCode });
        }

        [HttpDelete("edit/{collectionCode}/question/{questionId}/delete")]
        public async Task<IActionResult> Delete(Guid collectionCode, Guid questionId)
        {

            bool success = await questionService.DeleteAsync(questionId);
            if (!success) return NotFound();
            return RedirectToAction("Edit", "Collection", new { collectionCode });
        }
    }
}
