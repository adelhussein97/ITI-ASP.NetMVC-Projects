using System.ComponentModel.DataAnnotations;

namespace ECommerceMVCProducts.Models
{
    public class Product
    {

        public long Id { get; set; }

        [MinLength(3), MaxLength(200)]
        public string Name { get; set; }
        [MinLength(10), MaxLength(500)]
        public string? Discription { get; set; }

        public int Quantity { get; set; }

        public float UnitPrice { get; set; }

        [Range(0,100)]
        public byte? DiscountPercent { get; set; }

        public bool IsValid { get; set; }

        private readonly IList<Product_Image> images; // For Set intenal and prevent set from external

        public int CategoryID { get; set; }
        public Product(string name, float unitPrice, bool isValid, int quantity, Category category, string? discription = null, byte? discountPercent = null)
        {
            Name = name;
            Discription = discription;
            UnitPrice = unitPrice;
            DiscountPercent = discountPercent;
            IsValid = isValid;
            Quantity = quantity;
            images = new List<Product_Image>();
            Categories = category;

           
        }
        // Using Private Constructor For EF Only because the EF not understand objects when create DB 
        private Product() : this(null!, 0!,true!,0!,null!,null,null)
        {

        }
        public IEnumerable<Product_Image> Images { get { return images; } }

        public Category Categories { get; }

        public bool AddImage(Product_Image image)
        {
            // Check sub category name exist or not
            var imageItem = Images.FirstOrDefault(i => i.Url == image.Url);
            if (imageItem == null)
            {
                images.Add(image);
                return true;
            }
            else
                return false;
        }
       

    }
}
