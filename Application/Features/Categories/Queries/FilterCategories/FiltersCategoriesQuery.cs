using APIDTO.Category;
using MediatR;


namespace Application.Features.Categories.Queries.FilterCategories
{
    public class FiltersCategoriesQuery :IRequest<IEnumerable<CategoryMinimalDto>>
    {
        // PArameters
        public string? Filter { get; set; }
        public int? ParentCategoryId { get; set; }

        public FiltersCategoriesQuery(string? filter, int? parentCategoryId)
        {
            Filter = filter;
            ParentCategoryId = parentCategoryId;
        }
    }
}
