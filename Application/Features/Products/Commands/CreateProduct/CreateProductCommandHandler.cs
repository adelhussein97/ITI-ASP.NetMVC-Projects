using APIDTO.Category;
using APIDTO.Product;
using Application.Contract;
using Application.Features.Categories.Commands.CreateCategory;
using Domains;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Products.Commands.CreateProduct
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, ProductMinimalDto>
    {
        private readonly IProductRepository product;

        public CreateProductCommandHandler(IProductRepository product)
        {
            this.product = product;
        }
        public async Task<ProductMinimalDto> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            // Mapping Oject to Product
            var item = new Product(request.Name,request.Price,true,request.Quantity,request.Category,request.Brand);
            item = await product.CreateAsync(item);
            await product.SaveOnDBChanges();
            return new ProductMinimalDto() { Id = item.Id, Name = item.Name };
        }
    
    }
}
