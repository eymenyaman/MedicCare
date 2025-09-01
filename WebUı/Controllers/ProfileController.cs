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
    public class ProfileController : Controller
    {
        private readonly HttpClient client;

        public ProfileController(HttpClient httpClient)
        {
            client = httpClient;
        }

        // GET: Profile
        public async Task<IActionResult> Index()
        {
            var response = await client.GetAsync("https://localhost:7006/api/Profile");
            var model = await response.Content.ReadAsStringAsync();

            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            };

            Profile profile = JsonSerializer.Deserialize<Profile>(model, options);

            return View(profile);
        }

        // GET: Profile/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            return Ok();
        }

        // GET: Profile/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Profile/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Profile profile)
        {
            if (ModelState.IsValid)
            {
                var json = JsonSerializer.Serialize(profile);
                var content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

                var response = await client.PostAsync("https://localhost:7006/api/Profile", content);

                if (response.IsSuccessStatusCode)
                {
                    ViewBag.Message = "Profil başarıyla eklendi.";
                    return View();
                }
                else
                {
                    ModelState.AddModelError("", "Profil eklenirken bir hata oluştu.");
                }
            }

            return View(profile);
        }
        // GET: Profile/Edit/5
        public async Task<IActionResult> Edit()
        {
            var response = await client.GetAsync("https://localhost:7006/api/Profile");

            if (!response.IsSuccessStatusCode)
                return NotFound();

            var result = await response.Content.ReadAsStringAsync();
            if (string.IsNullOrWhiteSpace(result))
                return NotFound();

            var profile = JsonSerializer.Deserialize<Profile>(result, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });

            if (profile == null)
                return NotFound();

            return View(profile);

        }
        // POST: Profile/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Profile model)
        {
            if (ModelState.IsValid)
            {
                var json = JsonSerializer.Serialize(model);
                var content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

                var response = await client.PutAsync($"https://localhost:7006/api/Profile/{model.Id}", content);

                if (response.IsSuccessStatusCode)
                {
                    TempData["SuccessMessage"] = "Profil başarıyla güncellendi.";
                    return RedirectToAction(nameof(Edit)); // Tek profil olduğu için tekrar edit sayfasına dön
                }
                else
                {
                    ModelState.AddModelError("", "Profil güncellenirken bir hata oluştu.");
                }
            }

            return View(model);
        }
        // GET: Profile/Delete
        public async Task<IActionResult> Delete()
        {
            var response = await client.GetAsync("https://localhost:7006/api/Profile");

            if (!response.IsSuccessStatusCode)
                return NotFound();

            var result = await response.Content.ReadAsStringAsync();
            if (string.IsNullOrWhiteSpace(result))
                return NotFound();

            var profile = JsonSerializer.Deserialize<Profile>(result, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });

            if (profile == null)
                return NotFound();

            return View(profile); // Onay formu göster
        }
        // POST: Profile/Delete
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed()
        {
            // Önce tek profilü çek
            var responseGet = await client.GetAsync("https://localhost:7006/api/Profile");
            var result = await responseGet.Content.ReadAsStringAsync();
            var profile = JsonSerializer.Deserialize<Profile>(result, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });

            if (profile == null)
                return NotFound();

            // Silme isteği
            var responseDelete = await client.DeleteAsync($"https://localhost:7006/api/Profile/{profile.Id}");
            if (responseDelete.IsSuccessStatusCode)
            {
                TempData["SuccessMessage"] = "Profil başarıyla silindi.";
                return RedirectToAction("Index"); // veya başka sayfa
            }
            else
            {
                ModelState.AddModelError("", "Profil silinirken bir hata oluştu.");
                return View(profile);
            }
        }


    }
}
