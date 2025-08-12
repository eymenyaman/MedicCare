using Microsoft.AspNetCore.Mvc;

namespace WebUI.ViewComponents.Reviews
{
    public class _SelectReviewsViewComponentPartial:ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View();
        }
    }
}
