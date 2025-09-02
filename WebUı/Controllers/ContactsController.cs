using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DAL.Concrete.Context;
using Entity;
using System.Text.Json;

namespace WebUI.Controllers
{
    public class ContactsController : Controller
    {
        private readonly HttpClient client;

        public ContactsController(HttpClient httpClient)
        {
            client = httpClient;
        }

        // GET: Contact
        public async Task<IActionResult> Index()
        {
            var response = await client.GetAsync("https://localhost:7006/api/Contact");
            var model = await response.Content.ReadAsStringAsync();

            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            };

            Contact contact = JsonSerializer.Deserialize<Contact>(model, options);

            return View(contact);
        }

        // GET: Contact/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            return Ok();
        }

        // GET: Contact/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Contact/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Contact contact)
        {
            if (ModelState.IsValid)
            {
                var json = JsonSerializer.Serialize(contact);
                var content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

                var response = await client.PostAsync("https://localhost:7006/api/Contact", content);

                if (response.IsSuccessStatusCode)
                {
                    ViewBag.Message = "Contact başarıyla eklendi.";
                    return View();
                }
                else
                {
                    ModelState.AddModelError("", "Contact eklenirken bir hata oluştu.");
                }
            }

            return View(contact);
        }
        // GET: Contact/Edit/5
        public async Task<IActionResult> Edit()
        {
            var response = await client.GetAsync("https://localhost:7006/api/Contact");

            if (!response.IsSuccessStatusCode)
                return NotFound();

            var result = await response.Content.ReadAsStringAsync();
            if (string.IsNullOrWhiteSpace(result))
                return NotFound();

            var contact = JsonSerializer.Deserialize<Contact>(result, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });

            if (contact == null)
                return NotFound();

            return View(contact);

        }
        // POST: Contact/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Contact model)
        {
            if (ModelState.IsValid)
            {
                var json = JsonSerializer.Serialize(model);
                var content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

                var response = await client.PutAsync($"https://localhost:7006/api/Contact/{model.Id}", content);

                if (response.IsSuccessStatusCode)
                {
                    TempData["SuccessMessage"] = "Contact başarıyla güncellendi.";
                    return RedirectToAction(nameof(Edit)); // Tek Contact olduğu için tekrar edit sayfasına dön
                }
                else
                {
                    ModelState.AddModelError("", "Contact güncellenirken bir hata oluştu.");
                }
            }

            return View(model);
        }
        // GET: Contact/Delete
        public async Task<IActionResult> Delete()
        {
            var response = await client.GetAsync("https://localhost:7006/api/Contact");

            if (!response.IsSuccessStatusCode)
                return NotFound();

            var result = await response.Content.ReadAsStringAsync();
            if (string.IsNullOrWhiteSpace(result))
                return NotFound();

            var contact = JsonSerializer.Deserialize<Contact>(result, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });

            if (contact == null)
                return NotFound();

            return View(contact); // Onay formu göster
        }
        // POST: Contact/Delete
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed()
        {
            // Önce tek contactı çek
            var responseGet = await client.GetAsync("https://localhost:7006/api/Contact");
            var result = await responseGet.Content.ReadAsStringAsync();
            var contact = JsonSerializer.Deserialize<Contact>(result, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });

            if (contact == null)
                return NotFound();

            // Silme isteği
            var responseDelete = await client.DeleteAsync($"https://localhost:7006/api/Contact/{contact.Id}");
            if (responseDelete.IsSuccessStatusCode)
            {
                TempData["SuccessMessage"] = "Contact başarıyla silindi.";
                return RedirectToAction("Index"); // veya başka sayfa
            }
            else
            {
                ModelState.AddModelError("", "Contact silinirken bir hata oluştu.");
                return View(contact);
            }
        }
    }
}