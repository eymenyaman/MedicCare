using Microsoft.AspNetCore.Mvc;

namespace WebUı.ViewComponents.Hero
{
    public class _SelectHeroViewComponentPartial: ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View();
        }
    }
}
