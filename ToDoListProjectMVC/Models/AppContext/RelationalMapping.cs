using Microsoft.EntityFrameworkCore;

namespace ToDoListProjectMVC.Models.AppContext
{
    public static class RelationalMapping
    {
        // Extension Methods To Map Relational Entity
        public static void MapRelation(this ModelBuilder builder)
        {
            // 1. Task ------- User
            //    M    ------- 1
            builder.Entity<Tasks>().HasOne(a=>a.User)
                .WithMany(a=>a.TaskUser).HasForeignKey(a=>a.OwnerId)
                .IsRequired().OnDelete(DeleteBehavior.NoAction);
            // 2. Categories --------- Task
            //    1          --------- M
            builder.Entity<Tasks>().HasOne(a => a.Category)
                .WithMany(a => a.CategoryTasks).HasForeignKey(a => a.CategoryId)
                .IsRequired().OnDelete(DeleteBehavior.NoAction);
            

        }
    }
}
