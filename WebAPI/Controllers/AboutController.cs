using BLL.Abstract;
using BLL.Service;
using Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AboutController : ControllerBase
    {
        private readonly IAboutService aboutService;
        public AboutController(IAboutService about)
        {
            aboutService = about;

        }
        [HttpGet]
        public async Task<About> GetAsync()
        {
            return await aboutService.GetAsync();
        }
        [HttpGet("{id}")]
        public async Task<About> GetAboutİdAsync(int id)
        {
            var about = await aboutService.GetByIdAsync(id);

            return about;
        }
        [HttpPost]
        public async Task<IActionResult> CreateAboutAsync([FromBody] About about)
        {
            if (about == null)
                return BadRequest("About boş olamaz.");

            await aboutService.CreateAsync(about);

            return Ok(new { Message = "About başarıyla eklendi.", About = about });
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> EditAboutAsync(About about, int id)
        {
            var about1 = await aboutService.GetByIdAsync(id);

            about1.Title = about.Title;
            about1.Text = about.Text;
            about1.Years = about.Years;
            about1.İmage1 = about.İmage1;
            about1.İmage2 = about.İmage2;

            await aboutService.UpdateAsync();

            return Ok();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAboutAsync(int id)
        {
            var about = await aboutService.GetByIdAsync(id);
            if (about == null)
            { 
                return NotFound();
            }
            await aboutService.DeleteAsync(id);
            return NoContent();
        }
    }

}


