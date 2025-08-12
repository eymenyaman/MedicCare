using Microsoft.AspNetCore.Mvc;

namespace WebUI.ViewComponents.Gallery
{
    public class _SelectGalleryViewComponentPartial:ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View();
        }
    }
}
