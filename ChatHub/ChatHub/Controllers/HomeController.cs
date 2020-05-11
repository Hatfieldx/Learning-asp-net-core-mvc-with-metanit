using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace ChatHub.Controllers
{
    public class HomeController : Controller
    {
        private readonly IHubContext<ChatHub> hubContext;

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Create(string product, string connectionId)
        {
            await hubContext.Clients.Client(connectionId).SendAsync("Notify", $"buying prod {product}");

            await hubContext.Clients.AllExcept(connectionId).SendAsync("Notify", $"To ALL: buying prod {product}");

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult UserChange()
        {
            return View();
        }

        public HomeController(IHubContext<ChatHub> hub)
        {
            hubContext = hub;
        }
    }
}