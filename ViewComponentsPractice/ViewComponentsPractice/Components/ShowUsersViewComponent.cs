using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Html;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json;
using ViewComponentsPractice.Models;
using System.IO;

namespace ViewComponentsPractice.Components
{
    public class ShowUsers : ViewComponent
    {
        private readonly IWebHostEnvironment _webHostEnvironment;

        public async Task<IViewComponentResult> InvokeAsync()
        {
            List<User> users = new List<User>();

            using (var sr = File.OpenRead(Path.Combine(_webHostEnvironment.ContentRootPath, "Files", "users.json")))
            {
                users = await JsonSerializer.DeserializeAsync<List<User>>(sr);
            }
            ViewBag.Title = "User list:";

            return View("UserList", users);
        }
         
        public ShowUsers(IWebHostEnvironment env)
        {
            _webHostEnvironment = env;
        }
    }

}
