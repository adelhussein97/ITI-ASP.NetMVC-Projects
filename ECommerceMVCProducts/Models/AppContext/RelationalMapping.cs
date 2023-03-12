using Microsoft.EntityFrameworkCore;

namespace ECommerceMVCProducts.Models
{
    public static class RelationalMapping
    {
        // Extension Methods To Map Relational Entity
        public static void MapRelation(this ModelBuilder builder)
        {
            // 1. Product ------- Category
            //    M    ------- 1
            builder.Entity<Product>().HasOne(a=>a.Categories)
                .WithMany(a=>a.Products).HasForeignKey(a=>a.CategoryID)
                .IsRequired().OnDelete(DeleteBehavior.NoAction);
            // 2. Products --------- Product Images
            //    1          --------- M
            builder.Entity<Product_Image>().HasOne(a => a.Product)
                .WithMany(a =>a.Images ).HasForeignKey(a => a.PrdId)
                .IsRequired().OnDelete(DeleteBehavior.NoAction);
            

        }
    }
}
