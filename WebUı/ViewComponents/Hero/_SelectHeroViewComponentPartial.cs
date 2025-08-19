using BLL.Service;
using Entity;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace WebUı.ViewComponents.Hero
{
    public class _SelectHeroViewComponentPartial: ViewComponent
    {
        private readonly HttpClient client = new HttpClient();

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var response = await client.GetAsync("https://localhost:7006/api/Profile");
            var model = await response.Content.ReadAsStringAsync();

            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            };

            Profile profile = JsonSerializer.Deserialize<Profile>(model, options);

            return View(profile);
        }

    }
}
