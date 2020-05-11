using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using EFDataApp.Models;
using EFDataApp.Models.AppContext;
using Microsoft.EntityFrameworkCore;

namespace EFDataApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationContext _db;

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
                return NoContent();

            _db.Users.Remove(
             await _db.Users.SingleOrDefaultAsync(x => x.Id == id));

            await _db.SaveChangesAsync();                       

            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Edit(int? id)
        {
            if (id != null)
            {
                User user = await _db.Users.FirstOrDefaultAsync(p => p.Id == id);
                if (user != null)
                    return View(user);
            }
            return NotFound();
        }
        [HttpPost]
        public async Task<IActionResult> Edit(User user)
        {
            _db.Entry(user).State = EntityState.Modified;
            
           // _db.Users.Update(user);
            await _db.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Details(int? id)
        {
            if (id != null)
            {
                User user = await _db.Users.FirstOrDefaultAsync(p => p.Id == id);
                if (user != null)
                    return View(user);
            }
            return NotFound();
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(User user)
        {
            if (ModelState.IsValid)
            {
                await _db.Users.AddAsync(user);

                await _db.SaveChangesAsync();

                return RedirectToAction("Index");
            }

            return RedirectToAction("Error");
        }

        [HttpGet]
        public IActionResult ShowUsers()
        {
            return View(_db.Users.ToList());
        }

        public IActionResult Index()
        {
            return View(_db.Users.ToList());
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
        public HomeController(ILogger<HomeController> logger, ApplicationContext context)
        {
            _logger = logger;
            _db = context;
        }
    }
}
