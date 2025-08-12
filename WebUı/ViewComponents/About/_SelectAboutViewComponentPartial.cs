using Microsoft.AspNetCore.Mvc;

namespace WebUI.ViewComponents.About
{
    public class _SelectAboutViewComponentPartial:ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View();
        }
    }
}
