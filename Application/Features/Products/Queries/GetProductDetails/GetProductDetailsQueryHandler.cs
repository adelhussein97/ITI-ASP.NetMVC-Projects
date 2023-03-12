using APIDTO.Category;
using APIDTO.Product;
using Application.Contract;
using Domains;
using MediatR;


namespace Application.Features.Products.Queries.GetProductDetails
{
    public class GetProductDetailsQueryHandler : IRequestHandler<GetProductDetailsQuery, ProductDetailsDto>
    {
        private readonly IProductRepository product;

        public GetProductDetailsQueryHandler(IProductRepository product)
        {
            this.product = product;
        }
        public async Task<ProductDetailsDto> Handle(GetProductDetailsQuery request, CancellationToken cancellationToken)
        {
            var item = await product.GetDetailsAsync(request.Id);
            return new ProductDetailsDto(item.Id,item.Name,item.UnitPrice,item.Discription);
        }
    }
}
