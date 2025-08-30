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
        private readonly IExperiencesService _experiences;


        public ExperiencesController(IExperiencesService experiences)
        {
            _experiences = experiences;

        }
        [HttpGet]
        public async Task<List<Experiences>> GetAsync()
        {
            return await _experiences.GetAllAsync();
        }

    }
}
