using Entity;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace WebUI.ViewComponents.Timeline
{
    public class _SelectTimelineViewComponentPartial:ViewComponent
    {
        private readonly HttpClient client = new HttpClient();

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var response = await client.GetAsync("https://localhost:7006/api/Experiences");
            var model = await response.Content.ReadAsStringAsync();

            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            };

           List<Experiences> experiences = JsonSerializer.Deserialize<List<Experiences>>(model, options);

            return View(experiences);
        }
    }
}
