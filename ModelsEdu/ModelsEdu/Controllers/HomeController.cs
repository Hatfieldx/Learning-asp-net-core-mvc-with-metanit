using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ModelsEdu.Models;
using ModelsEdu.ViewModel;

namespace ModelsEdu.Controllers
{
        
    public class HomeController : Controller
    {
        private readonly List<Phone> _phones;
        private readonly List<Company> _companies;

        private readonly ILogger<HomeController> _logger;
        static List<Event> _events = new List<Event>();
       [Route("Events")]
       public IActionResult Events()
        {
            return View(_events);
        }

        [HttpGet]
        [Route("CreateEvent")]
        public IActionResult CreateEvent()
        {
            return View();
        }
        
        [HttpPost]
        [Route("CreateEvent")]
        public IActionResult CreateEvent(ModelsEdu.Models.Event ev)
        {
            if (ModelState.IsValid)
            {
               
                
                _events.Add(ev);
            }
            
            return RedirectToAction("Events");
        }

        public IActionResult Index(int? companyId)
        {
            if (!ModelState.IsValid)
            {

            }
            
            List<CompanyModel> companies = _companies.Select(x => new CompanyModel() { Id = x.Id, Name = x.Name }).ToList<CompanyModel>();

            companies.Insert(0, new CompanyModel() {Id=0, Name= "All companies"});

            IEnumerable<Phone> phones = _phones;
            
            if (companyId != null && companyId != 0)
            {
                phones = (from phone in _phones
                          where phone.Manufacturer.Id == companyId
                          select phone).ToList<Phone>();
            }
            
            return View(new IndexViewModel(phones, companies));
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

        
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;

            Company apple = new Company { Id = 1, Name = "Apple", Country = "США" };
            Company microsoft = new Company { Id = 2, Name = "Samsung", Country = "Республика Корея" };
            Company google = new Company { Id = 3, Name = "Google", Country = "США" };

            _companies = new List<Company> { apple, microsoft, google };

            _phones = new List<Phone>
            {
                new Phone { Id=1, Manufacturer= apple, Name="iPhone X", Price=56000 },
                new Phone { Id=2, Manufacturer= apple, Name="iPhone XZ", Price=41000 },
                new Phone { Id=3, Manufacturer= microsoft, Name="Galaxy 9", Price=9000 },
                new Phone { Id=4, Manufacturer= microsoft, Name="Galaxy 10", Price=40000 },
                new Phone { Id=5, Manufacturer= google, Name="Pixel 2", Price=30000 },
                new Phone { Id=6, Manufacturer= google, Name="Pixel XL", Price=50000 }
            };
        }
    }
}
