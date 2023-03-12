using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ToDoListProjectMVC.Models
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            // Rename Table in Dbs
            builder.ToTable("Users");
            builder.HasKey(a => a.Id); // Set PK
            builder.Property(a => a.Id).IsRequired().ValueGeneratedOnAdd(); // Set IDentity
            builder.Property(a => a.Name).IsRequired()
                .HasMaxLength(100);

        }
    }
}
