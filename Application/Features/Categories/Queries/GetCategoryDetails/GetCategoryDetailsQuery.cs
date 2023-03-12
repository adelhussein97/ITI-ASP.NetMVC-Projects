using APIDTO.Category;
using MediatR;


namespace Application.Features.Categories.Queries.GetCategoryDetails
{
    public class GetCategoryDetailsQuery:IRequest<CategoryDetailsDto>
    {
        //Parameter Search
        public int Id { get; set; }
    }
}
