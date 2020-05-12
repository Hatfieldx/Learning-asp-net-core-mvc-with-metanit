using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using AutomaperExampleApp.Models;
using AutoMapper;
using AutomaperExampleApp.ViewModels;

namespace AutomaperExampleApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly DAL.AppContext _db;
        private readonly IMapper _mapper;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, IMapper mapper, DAL.AppContext db)
        {
            _db = db;
            _mapper = mapper;
            _logger = logger;
        }

        public IActionResult Index()
        {
            var users = _mapper.Map<List<UserViewModel>>(_db.Users.ToList());
            
            return View(users);
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
