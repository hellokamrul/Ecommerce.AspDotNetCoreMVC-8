using Ecommerce.MVC.Models;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.MVC.Persistence
{
    public class ApplicationDbContext : DbContext 
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) :base(options)
        {
                
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category { Id=1, Name = "Acton", DisplayOrder = 1},
                new Category { Id=2, Name = "Scifi", DisplayOrder = 2},
                new Category { Id=3, Name = "History", DisplayOrder = 3}
                );
        }
    }

}
