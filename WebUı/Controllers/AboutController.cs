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
    public class AboutController : Controller
    {
        private readonly HttpClient client;

        public AboutController(HttpClient httpClient)
        {
            client = httpClient;
        }

        // GET: About
        public async Task<IActionResult> Index()
        {
            var response = await client.GetAsync("https://localhost:7006/api/About");
            var model = await response.Content.ReadAsStringAsync();

            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            };

            About about = JsonSerializer.Deserialize<About>(model, options);

            return View(about);
        }

        // GET: About/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            return Ok();
        }

        // GET: About/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: About/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(About about)
        {
            if (ModelState.IsValid)
            {
                var json = JsonSerializer.Serialize(about);
                var content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

                var response = await client.PostAsync("https://localhost:7006/api/About", content);

                if (response.IsSuccessStatusCode)
                {
                    ViewBag.Message = "Hakkımızda başarıyla eklendi.";
                    return View();
                }
                else
                {
                    ModelState.AddModelError("", "Hakkımızda eklenirken bir hata oluştu.");
                }
            }

            return View(about);
        }
        // GET: About/Edit/5
        public async Task<IActionResult> Edit()
        {
            var response = await client.GetAsync("https://localhost:7006/api/About");

            if (!response.IsSuccessStatusCode)
                return NotFound();

            var result = await response.Content.ReadAsStringAsync();
            if (string.IsNullOrWhiteSpace(result))
                return NotFound();

            var about = JsonSerializer.Deserialize<About>(result, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });

            if (about == null)
                return NotFound();

            return View(about);

        }
        // POST: About/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(About model)
        {
            if (ModelState.IsValid)
            {
                var json = JsonSerializer.Serialize(model);
                var content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

                var response = await client.PutAsync($"https://localhost:7006/api/About/{model.Id}", content);

                if (response.IsSuccessStatusCode)
                {
                    TempData["SuccessMessage"] = "Hakkımızda başarıyla güncellendi.";
                    return RedirectToAction(nameof(Edit)); // Tek profil olduğu için tekrar edit sayfasına dön
                }
                else
                {
                    ModelState.AddModelError("", "Hakkımızda güncellenirken bir hata oluştu.");
                }
            }

            return View(model);
        }
        // GET: About/Delete
        public async Task<IActionResult> Delete()
        {
            var response = await client.GetAsync("https://localhost:7006/api/About");

            if (!response.IsSuccessStatusCode)
                return NotFound();

            var result = await response.Content.ReadAsStringAsync();
            if (string.IsNullOrWhiteSpace(result))
                return NotFound();

            var about = JsonSerializer.Deserialize<About>(result, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });

            if (about == null)
                return NotFound();

            return View(about); // Onay formu göster
        }
        // POST: About/Delete
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed()
        {
            // Önce tek Aboutu çek
            var responseGet = await client.GetAsync("https://localhost:7006/api/About");
            var result = await responseGet.Content.ReadAsStringAsync();
            var about = JsonSerializer.Deserialize<About>(result, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });

            if (about == null)
                return NotFound();

            // Silme isteği
            var responseDelete = await client.DeleteAsync($"https://localhost:7006/api/About/{about.Id}");
            if (responseDelete.IsSuccessStatusCode)
            {
                TempData["SuccessMessage"] = "Hakkımızda başarıyla silindi.";
                return RedirectToAction("Index"); // veya başka sayfa
            }
            else
            {
                ModelState.AddModelError("", "Hakkımızda silinirken bir hata oluştu.");
                return View(about);
            }
        }

    }
    }
