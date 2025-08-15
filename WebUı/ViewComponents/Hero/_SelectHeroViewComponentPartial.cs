using BLL.Service;
using Microsoft.AspNetCore.Mvc;

namespace WebUı.ViewComponents.Hero
{
    public class _SelectHeroViewComponentPartial: ViewComponent
    {
        private readonly  ProfileService _profileService;
        public _SelectHeroViewComponentPartial(ProfileService profile)
        {
            _profileService = profile;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var profile =  _profileService.GetProfile();
            return View(profile);
        }
    }
}
