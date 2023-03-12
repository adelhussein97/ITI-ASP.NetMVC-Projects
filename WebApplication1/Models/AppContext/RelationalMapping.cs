using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Models.AppContext
{
    public static class RelationalMapping
    {
        // Extension Methods To Map Relational Entity
        public static void MapRelation(this ModelBuilder builder)
        {
            // 1. Book ------- Author
            //    M    ------- 1
            builder.Entity<Book>().HasOne(a=>a.Author)
                .WithMany(a=>a.BookAuthor).HasForeignKey(a=>a.AuthorId)
                .IsRequired().OnDelete(DeleteBehavior.NoAction);
            // 2. Categories --------- Book
            //    1          --------- M
            builder.Entity<Book>().HasOne(a => a.Category)
                .WithMany(a => a.Books).HasForeignKey(a => a.CategoryId)
                .IsRequired().OnDelete(DeleteBehavior.NoAction);
            

        }
    }
}
