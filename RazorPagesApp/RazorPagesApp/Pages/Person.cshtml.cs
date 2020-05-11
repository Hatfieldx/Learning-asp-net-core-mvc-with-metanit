using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPagesApp.Models;
using RazorPagesApp.Models.ModelsContext;

namespace RazorPagesApp
{
    [IgnoreAntiforgeryToken]
    public class PersonModel : PageModel
    {        
        public string Message { get; set; }
        private readonly PersonsContext _db;
        
        public List<Person> DisplayedPeople { get; set; }

        public void OnGet()
        {
            DisplayedPeople = _db.Persons.ToList();
        }

        public async Task<IActionResult> OnGetDelete(int? id)
        {
            if (id == null)
                return NotFound("Person not found");
            
            _db.Remove(DisplayedPeople.FirstOrDefault(person => person.Id == id));

            await _db.SaveChangesAsync();

            return Page();
        }
        //public void OnGetByName(string name)
        //{
        //    DisplayedPeople = people.Where(x => x.Name.Contains(name)).ToList();
        //}
        //public IActionResult OnGetByAge(int age)
        //{
        //    DisplayedPeople = people.Where(x => x.Age == age).ToList();

        //    return Page();
        //}

        public PersonModel(PersonsContext dbcontext)
        {
            _db = dbcontext;
        }
    }
}