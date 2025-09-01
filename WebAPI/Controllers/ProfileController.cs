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
        [HttpGet("{id}")]
        public async Task<Profile> GetProfileİdAsync(int id)
        {
            var profile = await _profileService.GetByIdAsync(id);

            return profile;
        }
        [HttpPost]
        public async Task<IActionResult> CreateProfileAsync([FromBody] Profile profile)
        {
            if (profile == null)
                return BadRequest("Profil boş olamaz.");

            await _profileService.CreateAsync(profile);

            return Ok(new { Message = "Profil başarıyla eklendi.", Profile = profile });
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> EditProfileAsync(Profile profile, int id)
        {
            var profile1 = await _profileService.GetByIdAsync(id);

            profile1.Phone = profile.Phone;
            profile1.Text = profile.Text;
            profile1.Title = profile.Title;
            profile1.Name = profile.Name;
            await _profileService.UpdateAsync();

            return Ok();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProfileAsync(int id)
        {
            var profile = await _profileService.GetByIdAsync(id);
            if (profile == null)
            {
                return NotFound();
            }
            await _profileService.DeleteAsync(id);
            return NoContent();
        }
    }
}
