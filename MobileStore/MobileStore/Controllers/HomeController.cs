using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MobileStore.Models;

namespace MobileStore.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        MobileContext _db;

        public HomeController(ILogger<HomeController> logger, MobileContext context)
        {
            _logger = logger;
            _db = context;
        }

        public IActionResult Index()
        {
            //return View(_db.Phones.ToList());
            return View(new Phone()
            {   Name = "Samsung Galaxy Edge",
                Company = "Samsung",
                Price = 550
            });
        }
        [HttpGet]
       public IActionResult Buy(int? id)
        {
            if (id == null)
                return RedirectToAction("Index");

            ViewBag.PhoneId = id;

            return View();
        }

        [HttpPost]
        public string Buy(Order order)
        {
            _db.Orders.Add(order);
            // сохраняем в бд все изменения
            _db.SaveChanges();
            return "Спасибо, " + order.User + ", за покупку!";
        }
    }
}
