using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using Prexam.DTOs;
using Prexam.Models;

namespace Prexam.Controllers
{
    public class CollectionController(IHttpClientFactory httpClientFactory) : Controller
    {
        private readonly HttpClient http = httpClientFactory.CreateClient("PrexamApi");

        public async Task<IActionResult> Dashboard()
        {
            var response = await http.GetAsync("api/collection");
            if (!response.IsSuccessStatusCode)
            {
                return View("Error");
            }

            var apiResponse = await response.Content.ReadFromJsonAsync<ApiResponse<IEnumerable<Collection>>>();

            if (apiResponse == null)
            {
                return View("Error");

            }
            return View(apiResponse.Data);
        }

    }
}
