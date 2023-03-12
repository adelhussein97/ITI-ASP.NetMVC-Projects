using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace ECommerceMVCProducts.Models.PrdImages
{
    public class ProductImagesConfiguration : IEntityTypeConfiguration<Product_Image>
    {
        public void Configure(EntityTypeBuilder<Product_Image> builder)
        {
            builder.ToTable("ProductImages");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Property(x => x.Url).IsRequired();
            

        }


    }

}
