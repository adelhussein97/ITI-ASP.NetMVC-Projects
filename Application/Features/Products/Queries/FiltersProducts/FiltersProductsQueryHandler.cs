using APIDTO.Category;
using APIDTO.Product;
using Application.Contract;
using Domains;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Products.Queries.GetAllProducts
{
    public class FiltersProductsQueryHandler : IRequestHandler<FiltersProductsQuery, IEnumerable<ProductMinimalDto>>
    {
        private readonly IProductRepository product;

        public FiltersProductsQueryHandler(IProductRepository product)
        {
            this.product = product;
        }
        public async Task<IEnumerable<ProductMinimalDto>> Handle(FiltersProductsQuery request, CancellationToken cancellationToken)
        {
            return (await product.FilterByAsync(request.Name)).Select(c => new ProductMinimalDto { Id = c.Id, Name = c.Name });
        }
    }
}
