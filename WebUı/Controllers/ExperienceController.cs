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


        // GET: Experience/Edit
        public async Task<IActionResult> Edit()
        {
            var response = await _client.GetAsync("https://localhost:7006/api/Experiences");

            if (!response.IsSuccessStatusCode)
                return NotFound();

            var result = await response.Content.ReadAsStringAsync();
            if (string.IsNullOrWhiteSpace(result))
                return NotFound();

            // Listeyi deserialize et
            var expList = JsonSerializer.Deserialize<List<Experiences>>(result, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });

            if (expList == null)
                return NotFound();

            return View(expList); 
        }

        // POST: Experience/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(List<Experiences> model)
        {
            if (!ModelState.IsValid)
                return View(model);

            foreach (var exp in model)
            {
                var json = JsonSerializer.Serialize(exp);
                var content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

                // Her deneyimi ayrı ayrı PUT ile gönder
                var response = await _client.PutAsync($"https://localhost:7006/api/Experiences/{exp.Id}", content);

                if (!response.IsSuccessStatusCode)
                {
                    ModelState.AddModelError("", $"Tecrübe (ID: {exp.Id}) güncellenirken hata oluştu.");
                    return View(model);
                }
            }

            TempData["SuccessMessage"] = "Tüm tecrübeler başarıyla güncellendi.";
            return RedirectToAction(nameof(Index));
        }

        // GET: Experience/Delete
        public async Task<IActionResult> Delete()
        {
            var response = await _client.GetAsync("https://localhost:7006/api/Experiences");

            if (!response.IsSuccessStatusCode)
                return NotFound();

            var result = await response.Content.ReadAsStringAsync();
            if (string.IsNullOrWhiteSpace(result))
                return NotFound();

            // Listeyi deserialize et
            var expList = JsonSerializer.Deserialize<List<Experiences>>(result, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });

            if (expList == null || !expList.Any())
                return NotFound();

            return View(expList); // View @model List<Experiences> olmalı
        }

        // POST: Experience/Delete
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(List<int> selectedIds)
        {
            if (selectedIds == null || !selectedIds.Any())
            {
                ModelState.AddModelError("", "Hiçbir tecrübe seçilmedi.");
                // Tekrar listeyi çek ve göster
                var response = await _client.GetAsync("https://localhost:7006/api/Experiences");
                var result = await response.Content.ReadAsStringAsync();
                var expList = JsonSerializer.Deserialize<List<Experiences>>(result, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });
                return View(expList);
            }

            foreach (var id in selectedIds)
            {
                var responseDelete = await _client.DeleteAsync($"https://localhost:7006/api/Experiences/{id}");
                if (!responseDelete.IsSuccessStatusCode)
                {
                    ModelState.AddModelError("", $"Tecrübe (ID: {id}) silinirken hata oluştu.");
                    // Listeyi tekrar çek ve göster
                    var response = await _client.GetAsync("https://localhost:7006/api/Experiences");
                    var result = await response.Content.ReadAsStringAsync();
                    var expList = JsonSerializer.Deserialize<List<Experiences>>(result, new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    });
                    return View(expList);
                }
            }

            TempData["SuccessMessage"] = "Seçilen tüm tecrübeler başarıyla silindi.";
            return RedirectToAction("Index");
        }



    }
}