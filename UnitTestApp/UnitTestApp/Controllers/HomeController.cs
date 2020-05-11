using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using UnitTestApp.Models;

namespace UnitTestApp.Controllers
{
    public class HomeController : Controller
    {
        IRepository repo;
        public HomeController(IRepository r)
        {
            repo = r;
        }
        public IActionResult Index()
        {
            return View(repo.GetAll());
        }
        public IActionResult GetUser(int? id)
        {
            if (!id.HasValue)
                return BadRequest();
            User user = repo.Get(id.Value);
            if (user == null)
                return NotFound();
            return View(user);
        }

        public IActionResult AddUser() => View();

        [HttpPost]
        public IActionResult AddUser(User user)
        {
            if (ModelState.IsValid)
            {
                repo.Create(user);
                return RedirectToAction("Index");
            }
            return View(user);
        }
    }
}
