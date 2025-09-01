using BLL.Abstract;
using Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly IContactService _contactService;


        public ContactController(IContactService contact)
        {
            _contactService = contact;

        }
        [HttpGet]
        public async Task<Contact> GetAsync()
        {
            return await _contactService.GetAsync();
        }
    }
}
