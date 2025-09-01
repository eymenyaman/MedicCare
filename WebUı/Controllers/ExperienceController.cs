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
    public class ExperienceController : Controller
    {
        private readonly HttpClient _client;

        public ExperienceController(HttpClient client)
        {
            _client = client;
        }

        // GET: Experiences
        public async Task<IActionResult> Index()
        {
            var response = await _client.GetAsync("https://localhost:7006/api/Experiences");
            if (!response.IsSuccessStatusCode)
                return View(new List<Experiences>());

            var json = await response.Content.ReadAsStringAsync();
            var list = JsonSerializer.Deserialize<List<Experiences>>(json,
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            return View(list);
        }

        // GET: Experiences/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var response = await _client.GetAsync($"https://localhost:7006/api/Experiences/{id}");
            if (!response.IsSuccessStatusCode) return NotFound();

            var json = await response.Content.ReadAsStringAsync();
            var exp = JsonSerializer.Deserialize<Experiences>(json,
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            return View(exp);
        }

        // GET: Experiences/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Experiences/Create
        [HttpPost]
        public async Task<IActionResult> Create(Experiences exp)
        {
            var response = await _client.PostAsJsonAsync("https://localhost:7006/api/Experiences", exp);
            if (response.IsSuccessStatusCode) return RedirectToAction(nameof(Index));
            return View(exp);
        }

        
        // GET: Experience/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var response = await _client.GetAsync($"https://localhost:7006/api/Experiences/{id}");
            if (!response.IsSuccessStatusCode)
            {
                return NotFound();
            }

            var result = await response.Content.ReadAsStringAsync();
            var experience = JsonSerializer.Deserialize<Experiences>(result, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });

            if (experience == null)
                return NotFound();

            return View(experience);
        }

        // POST: Experience/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Experiences model)
        {
            if (id != model.Id)
            {
                return BadRequest();
            }

            if (ModelState.IsValid)
            {
                var json = JsonSerializer.Serialize(model);
                var content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

                var response = await _client.PutAsync($"https://localhost:7006/api/Experiences/{id}", content);

                if (response.IsSuccessStatusCode)
                {
                    TempData["SuccessMessage"] = "Tecrübe başarıyla güncellendi.";
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    ModelState.AddModelError("", "Tecrübe güncellenirken hata oluştu.");
                }
            }

            return View(model);
        }


        // POST: Experiences/Delete/5
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var response = await _client.DeleteAsync($"https://localhost:7006/api/Experiences/{id}");
            if (response.IsSuccessStatusCode) return RedirectToAction(nameof(Index));
            return BadRequest();
        }
    }
}