using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace WebApplication1.Models
{
    public class AuthorConfiguration : IEntityTypeConfiguration<Author>
    {
        public void Configure(EntityTypeBuilder<Author> builder)
        {
            // Rename Table in Dbs
            builder.ToTable("Author");
            builder.HasKey(a => a.Id); // Set PK
            builder.Property(a => a.Id).IsRequired().ValueGeneratedOnAdd(); // Set IDentity
            builder.Property(a => a.Name).IsRequired()
                .HasMaxLength(100).HasColumnName("NameofAuthor");

        }
    }
}
