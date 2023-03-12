using APIDTO.Product;
using MediatR;

namespace Application.Features.Products.Queries.GetAllProducts
{
    public class FiltersProductsQuery : IRequest<IEnumerable<ProductMinimalDto>>
    {
        
        public string? Name { get; set; }

        public FiltersProductsQuery(string? Filter=null )
        {
            Name = Filter;
        }
    }
}
