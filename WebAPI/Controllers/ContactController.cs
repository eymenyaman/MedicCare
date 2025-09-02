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
        private readonly IContactService _ContactService;
        public ContactController(IContactService contactService)
        {
            _ContactService = contactService;

        }
        [HttpGet]
        public async Task<Contact> GetAsync()
        {
            return await _ContactService.GetAsync();
        }
        [HttpGet("{id}")]
        public async Task<Contact> GetContactIdAsync(int id)
        {
            var contact = await _ContactService.GetByIdAsync(id);

            return contact;
        }
        [HttpPost]
        public async Task<IActionResult> CreateContactAsync([FromBody] Contact contact)
        {
            if (contact == null)
                return BadRequest("Contact Alanı boş olamaz.");

            await _ContactService.CreateAsync(contact);

            return Ok(new { Message = "Contact Alanı başarıyla eklendi.", contact = contact });
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> EditContactAsync(Contact contact, int id)
        {
            var contact1 = await _ContactService.GetByIdAsync(id);

            contact1.SocialThree = contact.SocialThree;
            contact1.SocialTwo = contact.SocialTwo;
            contact1.SocialOne = contact.SocialOne;
            contact1.Address = contact.Address;
            contact1.Email = contact.Email;

            await _ContactService.UpdateAsync();
            return Ok();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteContactAsync(int id)
        {
            var contact = await _ContactService.GetByIdAsync(id);
            if (contact == null)
            {
                return NotFound();
            }
            await _ContactService.DeleteAsync(id);
            return NoContent();
        }
    }
}

