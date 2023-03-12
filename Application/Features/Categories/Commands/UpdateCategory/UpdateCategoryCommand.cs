using MediatR;


namespace Application.Features.Categories.Commands.EditCategory
{
    public class UpdateCategoryCommand : IRequest<bool>
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
