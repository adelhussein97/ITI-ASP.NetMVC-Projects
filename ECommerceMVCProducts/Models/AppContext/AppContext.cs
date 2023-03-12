
using ECommerceMVCProducts.Models.PrdImages;
using ECommerceMVCProducts.Models.Products;
using Microsoft.EntityFrameworkCore;
namespace ECommerceMVCProducts.Models
{
    public class AppContext : DbContext
    {
         // Dependancy Injection call base 
        public AppContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }

        public DbSet<Product_Image> Product_Images { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            new ProductConfiguration().Configure(modelBuilder.Entity<Product>());
            new CategoryConfiguration().Configure(modelBuilder.Entity<Category>());
            new ProductImagesConfiguration().Configure(modelBuilder.Entity<Product_Image>());
            // Calling RelationShip
            modelBuilder.MapRelation();
        }

        
    }
}
