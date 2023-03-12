
using Microsoft.EntityFrameworkCore;
namespace ToDoListProjectMVC.Models.AppContext
{
    public class ToDoListContext : DbContext
    {
         // Dependancy Injection call base 
        public ToDoListContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Tasks> Tasks { get; set; }
        public DbSet<User> Users { get; set; }

        public DbSet<TaskCategory> TasksCategories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            new UserConfiguration().Configure(modelBuilder.Entity<User>());
            new TasksConfiguration().Configure(modelBuilder.Entity<Tasks>());
            new TaskCategoryConfiguration().Configure(modelBuilder.Entity<TaskCategory>());
            // Calling RelationShip
            modelBuilder.MapRelation();
        }
    }
}
