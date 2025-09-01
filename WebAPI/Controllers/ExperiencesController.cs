using BLL.Abstract;
using Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExperiencesController : ControllerBase
    {
        private readonly IExperiencesService _experiencesService;

        public ExperiencesController(IExperiencesService experiencesService)
        {
            _experiencesService = experiencesService;
        }

        // Tüm Experiences listesini getir
        [HttpGet]
        public async Task<List<Experiences>> GetAsync()
        {
            return await _experiencesService.GetAllAsync();
        }

        // ID'ye göre tek Experience getir
        [HttpGet("{id}")]
        public async Task<ActionResult<Experiences>> GetByIdAsync(int id)
        {
            var experience = await _experiencesService.GetByIdAsync(id);

            if (experience == null)
                return NotFound();

            return experience;
        }

        // Yeni Experience ekle
        [HttpPost]
        public async Task<IActionResult> CreateExperienceAsync([FromBody] Experiences experience)
        {
            if (experience == null)
                return BadRequest("Experience boş olamaz.");

            await _experiencesService.CreateAsync(experience);

            return Ok(new { Message = "Experience başarıyla eklendi.", Experience = experience });
        }

        // Experience güncelle
        [HttpPut("{id}")]
        public async Task<IActionResult> EditExperienceAsync([FromBody] Experiences experience, int id)
        {
            var existing = await _experiencesService.GetByIdAsync(id);

            if (existing == null)
                return NotFound();

            existing.Title = experience.Title;
            existing.Text = experience.Text;
            existing.Icon = experience.Icon;
            existing.DateTime = experience.DateTime;


            await _experiencesService.UpdateAsync();

            return Ok(new { Message = "Experience güncellendi.", Experience = existing });
        }

        // Experience sil
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteExperienceAsync(int id)
        {
            var experience = await _experiencesService.GetByIdAsync(id);

            if (experience == null)
                return NotFound();

            await _experiencesService.DeleteAsync(id);

            return NoContent();
        }
    }

}
