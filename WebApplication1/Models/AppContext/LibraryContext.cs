
using Microsoft.EntityFrameworkCore;
namespace WebApplication1.Models.AppContext
{
    public class LibraryContext : DbContext
    {
         // Dependancy Injection call base 
        public LibraryContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<ContactUs> ContactUs { get; set; }
        public DbSet<TeamMember> TeamMembers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            new AuthorConfiguration().Configure(modelBuilder.Entity<Author>());
            new BookConfiguration().Configure(modelBuilder.Entity<Book>());
            new CategoryConfiguration().Configure(modelBuilder.Entity<Category>());
            new ContactUsConfiguration().Configure(modelBuilder.Entity<ContactUs>());
            new TeamMemberConfiguration().Configure(modelBuilder.Entity<TeamMember>());
            // Calling RelationShip
            modelBuilder.MapRelation();
        }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=LibraryDb; Integrated Security=True; TrustServerCertificate=True;");
        //}
    }
}
