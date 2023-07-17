using Microsoft.EntityFrameworkCore;

namespace ApiTesting.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext>option):base(option) 
        {
                
        }
        public DbSet<Employee> Employees { get; set; }
    }
}
