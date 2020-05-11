using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ViewComponentsPractice.Models;
using System.IO;
using System.Text.Json;
using Microsoft.AspNetCore.Hosting;

namespace ViewComponentsPractice.Controllers
{    
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IWebHostEnvironment _webHostEnvironment;

        [HttpGet]
        public async Task<IActionResult> GenerateUsers(int count)
        {
            List<User> users = new List<User>(count);

            Random rnd = new Random();

            var options = new JsonSerializerOptions{ WriteIndented = true };
            
            for (int i = 1; i <= count; i++)
            {
                users.Add(new User {Name = $"User{i}", Id = i, Age = rnd.Next(10, 80)});
            }

            using (StreamWriter sr = new StreamWriter(Path.Combine(_webHostEnvironment.ContentRootPath, "Files", "users.json"), false, System.Text.Encoding.UTF8))
            {
                await sr.WriteAsync(JsonSerializer.Serialize<List<User>>(users, options));
            }

            return View("Index");
        }

        public HomeController(ILogger<HomeController> logger, IWebHostEnvironment env)
        {
            _logger = logger;
            _webHostEnvironment = env;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
