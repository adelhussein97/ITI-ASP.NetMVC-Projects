using APIDTO.Product;
using MediatR;


namespace Application.Features.Products.Queries.GetProductDetails
{
    public class GetProductDetailsQuery : IRequest<ProductDetailsDto>
    {
        //Parameter Search
        public int Id { get; set; }
    }
}
