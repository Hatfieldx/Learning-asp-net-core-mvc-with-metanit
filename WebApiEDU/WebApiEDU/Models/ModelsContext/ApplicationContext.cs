using Microsoft.EntityFrameworkCore;

namespace WebApiEDU.Models.ModelsContext
{
    public class ApplicationContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public ApplicationContext(DbContextOptions<ApplicationContext> option)
            :base(option)
        {
            Database.EnsureCreated();
        }
    }
}
