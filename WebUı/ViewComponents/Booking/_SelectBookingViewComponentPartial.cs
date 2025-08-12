using Microsoft.AspNetCore.Mvc;

namespace WebUI.ViewComponents.Booking
{
    public class _SelectBookingViewComponentPartial:ViewComponent  
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View();
        }
    }
}
