using Microsoft.EntityFrameworkCore;

namespace UoWMvcApp.Models
{
    public class OrderContext : DbContext
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
