using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RazorPagesApp.Pages
{
    public class IndexModel : PageModel
    {
        public int? Age { get; set; }
        public string Name { get; set; }
        public bool IsCorrect { get; set; } = true;

        public void OnGet(string name, int? age)
        {
            if (age == null || string.IsNullOrEmpty(name) || age > 100 || age < 1)
            {
                IsCorrect = false;
                return;
            }
            Age = age;
            Name = name;
        }
    }
}
