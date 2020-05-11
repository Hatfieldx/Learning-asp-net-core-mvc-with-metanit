using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ValidationApp.Models;

namespace ValidationApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View("Create");
        }

        [HttpPost]
        public IActionResult Create(Person person)
        {
            if (person.Name == person.Password)
            {
                ModelState.AddModelError("", "user name and pswd mustn't equals");
            }            
            
            if (ModelState.IsValid)
            {
                return Content($"{person.Name} - {person.Email}");
            }


            return View(person);
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

        [AcceptVerbs("Get","Post")]
        public IActionResult CheckAge(int age)
        {
            if (age < 18)
            return Json(false);

            return Json(true);
        }
    }
}
