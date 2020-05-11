using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorPagesApp.Models;
using RazorPagesApp.Models.ModelsContext;

namespace RazorPagesApp
{
    public class PersonsDetailsModel : PageModel
    {
        private readonly PersonsContext _context;

        public PersonsDetailsModel(PersonsContext context)
        {
            _context = context;
        }
        [BindProperty]
        public Person Person { get; set; }

        public IActionResult OnGet()
        {
            if (Person == null)
            {
                Person = new Person();
            }
            
            return Page();
        }

        public async Task<IActionResult> OnPostSavePerson()
        {
            if (Person == null)            
                await _context.AddAsync(Person);
            else
                _context.Update(Person);

            await _context.SaveChangesAsync();

            return RedirectToPage("Person");
        }
    }
}
