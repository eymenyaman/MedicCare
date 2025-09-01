using BLL.Abstract;
using Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestimonialController : ControllerBase
    {
        private readonly ITestimonialsService testimonials;


        public TestimonialController(ITestimonialsService testimonialsService)
        {
            testimonials = testimonialsService;

        }
        [HttpGet]
        public async Task<List<Testimonials>> GetAsync()
        {
            return await testimonials.GetAllAsync();
        }
    }
}
