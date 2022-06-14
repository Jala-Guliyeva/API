using Microsoft.EntityFrameworkCore;

namespace API.DAL
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext>option):base(option)
        {

        }
        public DbSet<Product> Products { get; set; }
    }
}
