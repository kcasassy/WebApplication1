using Microsoft.EntityFrameworkCore;
using WebApplication1.Models.Domain;

namespace WebApplication1.Models.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options) { }

        public DbSet<Product> Product => Set<Product>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            

            
        }
    }
}