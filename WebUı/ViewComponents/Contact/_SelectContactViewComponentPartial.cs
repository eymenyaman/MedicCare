using Entity;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace WebUI.ViewComponents.Contact
{
    public class _SelectContactViewComponentPartial:ViewComponent
    {
        private readonly HttpClient client = new HttpClient();

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var response = await client.GetAsync("https://localhost:7006/api/Contact");
            var model = await response.Content.ReadAsStringAsync();

            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            };

            Entity.Contact profile = JsonSerializer.Deserialize<Entity.Contact>(model, options);

            return View(profile);
        }
    }
}
