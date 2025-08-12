using Microsoft.AspNetCore.Mvc;

namespace WebUI.ViewComponents.Timeline
{
    public class _SelectTimelineViewComponentPartial:ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View();
        }
    }
}
