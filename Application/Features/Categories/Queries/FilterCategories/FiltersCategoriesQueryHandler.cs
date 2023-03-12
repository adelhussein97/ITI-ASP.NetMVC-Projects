using APIDTO.Category;
using Application.Contract;
using MediatR;


namespace Application.Features.Categories.Queries.FilterCategories
{
    public class FiltersCategoriesQueryHandler : IRequestHandler<FiltersCategoriesQuery, IEnumerable<CategoryMinimalDto>>
    {
        private readonly ICategoryRepository category;

        public FiltersCategoriesQueryHandler(ICategoryRepository category)
        {
            this.category = category;
        }
        public async Task<IEnumerable<CategoryMinimalDto>> Handle(FiltersCategoriesQuery request, CancellationToken cancellationToken)
        {
            return  (await category.FilterByAsync(request.Filter)).Select(c => new CategoryMinimalDto { Id=c.Id, Name=c.Name });
        }
    }
}
