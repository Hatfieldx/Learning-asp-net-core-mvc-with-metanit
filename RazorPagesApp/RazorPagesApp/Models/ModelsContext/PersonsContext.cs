using Microsoft.EntityFrameworkCore;

namespace RazorPagesApp.Models.ModelsContext
{
    public class PersonsContext : DbContext
    {
        public DbSet<Person> Persons { get; set; }

        public PersonsContext(DbContextOptions<PersonsContext> options)
            :base(options)
        {
            Database.EnsureCreated();
        }
    }
}
