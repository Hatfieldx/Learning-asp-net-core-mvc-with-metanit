using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using TagHelpers.Models;

namespace TagHelpers.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        
        IEnumerable<Company> _companies = new List<Company>
        {
            new Company { Id = 1, Name = "Apple" },
            new Company { Id = 2, Name = "Samsung" },
            new Company { Id = 3, Name = "Google" }
        };

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

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

        public IActionResult Create()
        {
            ViewBag.Companies = new SelectList(_companies, "Id", "Name");
            return View();
        }
        [HttpPost]
        public string Create(Product product)
        {
            Company company = _companies.FirstOrDefault(c => c.Id == product.CompanyId);
            return $"Добавлен новый элемент: {product.Name} ({company?.Name})";
        }
    }
}
