using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ControllersEdu.Models;
using ControllersEdu.Utils;
using Microsoft.AspNetCore.Hosting;
using System.IO;

namespace ControllersEdu.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly string _rootPath;

        public IActionResult GetFile()
        {
            
            
            string path = Path.Combine(_rootPath, "Files", "Elasticsearch.pdf");

            byte[] book = System.IO.File.ReadAllBytes(path);

            string filetype = "application/octet-stream";

            return File(book, filetype, "elastic");
        }

        public HomeController(ILogger<HomeController> logger, IWebHostEnvironment env)
        {
            _logger = logger;
            _rootPath = env.ContentRootPath;
        }

        public HtmlResult Index()
        {
            return new HtmlResult("<h2>Привет ASP.NET 5</h2>");
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
