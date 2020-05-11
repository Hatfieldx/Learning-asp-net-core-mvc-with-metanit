using Microsoft.EntityFrameworkCore;

namespace MonolitMvcApp.Models
{
    public class MobileContext : DbContext
    {
        public DbSet<Phone> Phones { get; set; }

        public DbSet<Order> Orders { get; set; }

        public MobileContext()
        {
            Database.EnsureCreated();
        }
    }
}
