using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using WebUı.Models;

namespace WebUı.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
