using Microsoft.EntityFrameworkCore;

namespace BlogAPI.DataAccessLayer
{
    public class Context : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=FARUK\\SQLEXPRESS;database=CoreBlogApiDb;integrated security=true;Encrypt=False");
        }

        public DbSet<Employee> Employees { get; set; }

    }
}
