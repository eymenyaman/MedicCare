using BLL.Abstract;
using BLL.Service;
using Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfileController : ControllerBase
    {
        private readonly IProfileService _profileService;
      

        public ProfileController(IProfileService profile) 
        {
            _profileService = profile;
       
        }
        [HttpGet]
        public async Task<Profile> GetAsync()
        {
            return await _profileService.GetAsync();
        }
     
    }
}
