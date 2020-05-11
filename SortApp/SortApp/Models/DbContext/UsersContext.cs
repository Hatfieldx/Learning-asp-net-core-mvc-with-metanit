namespace SortApp.Models.DbContext
{
    public enum SortState
    {
        NameAsc,    // по имени по возрастанию
        NameDesc,   // по имени по убыванию
        AgeAsc, // по возрасту по возрастанию
        AgeDesc,    // по возрасту по убыванию
        CompanyAsc, // по компании по возрастанию
        CompanyDesc // по компании по убыванию
    }
    public class UsersContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public Microsoft.EntityFrameworkCore.DbSet<User> Users;
        public Microsoft.EntityFrameworkCore.DbSet<Company> Companies;

        public UsersContext(Microsoft.EntityFrameworkCore.DbContextOptions<UsersContext> options) 
            :base(options)
        {
            Database.EnsureCreated();
        }        
    }
}
