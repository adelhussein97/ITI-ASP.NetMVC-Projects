using APIDTO.Category;
using Application.Contract;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Categories.Queries.GetCategoryDetails
{
    public class GetCategoryDetailsQueryHandler : IRequestHandler<GetCategoryDetailsQuery, CategoryDetailsDto>
    {
        private readonly ICategoryRepository category;

        public GetCategoryDetailsQueryHandler(ICategoryRepository category)
        {
            this.category = category;
        }
        public async Task<CategoryDetailsDto> Handle(GetCategoryDetailsQuery request, CancellationToken cancellationToken)
        {
            var item = await category.GetDetailsAsync(request.Id);
            return new CategoryDetailsDto( item.Id,item.Name);

        }
    }
}
