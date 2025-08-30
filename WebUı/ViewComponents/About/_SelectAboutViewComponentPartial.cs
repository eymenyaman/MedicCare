using Entity;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace WebUI.ViewComponents.About
{
    public class _SelectAboutViewComponentPartial:ViewComponent
    {
        private readonly HttpClient client = new HttpClient();

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var response = await client.GetAsync("https://localhost:7006/api/About");
            var model = await response.Content.ReadAsStringAsync();

            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            };

            Entity.About about = JsonSerializer.Deserialize<Entity.About>(model, options);

            return View(about);
        }
    }
}
