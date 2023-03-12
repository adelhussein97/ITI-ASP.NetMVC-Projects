using APIDTO.Product;
using Domains;
using MediatR;


namespace Application.Features.Products.Commands.CreateProduct
{
    public class CreateProductCommand:IRequest<ProductMinimalDto>
    {
        

        public int ProductId { get; set; }
        public string Name { get; set; }
        public float Price { get; set; }
        public string? Description { get; set; }

        public int Quantity { get; set; }

        public Category Category { get; set; }

        public Brand Brand { get; set; }

        public CreateProductCommand(int productId, string name, float price, string? description, int quantity, Category category, Brand brand)
        {
            ProductId = productId;
            Name = name;
            Price = price;
            Description = description;
            Quantity = quantity;
            Category = category;
            Brand = brand;
        }
    }
}
