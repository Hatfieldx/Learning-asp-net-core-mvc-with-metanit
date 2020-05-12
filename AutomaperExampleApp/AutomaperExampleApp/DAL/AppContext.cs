using AutomaperExampleApp.Models;
using Microsoft.EntityFrameworkCore;

namespace AutomaperExampleApp.DAL
{
    public class AppContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public AppContext(DbContextOptions<AppContext> options)
            : base(options)
        {
            //for testing only
            Database.EnsureDeleted();
            Database.EnsureCreated(); 
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(
                 new User[]
                 {
                            new User { Id=1, Name="Tom", Age=23, Email = "test1@gaga.ru"},
                            new User { Id=2, Name="Alice", Age=26, Email = "test2@gaga.ru"},
                            new User { Id=3, Name="Sam", Age=28, Email = "test3@gaga.ru"}
                 });
        }
    }
}
