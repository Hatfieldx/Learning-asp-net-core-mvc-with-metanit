using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using CachingMVC.Models;
using CachingMVC.Services;

namespace CachingMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly UserService _userservice;

        public HomeController(ILogger<HomeController> logger, UserService us)
        {
            _logger = logger;
            _userservice = us;

            _userservice.Initialize();
        }

        public async Task<IActionResult> Index(int id)
        {
            User user = await _userservice.GetUserAsync(id);

            if (user != null)
                return Content($"User: {user.Name}");
            return Content("User not found");
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
