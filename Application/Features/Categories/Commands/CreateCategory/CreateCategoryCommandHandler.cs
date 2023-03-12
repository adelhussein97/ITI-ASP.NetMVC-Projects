
using APIDTO.Category;
using Application.Contract;
using Domains;
using MediatR;


namespace Application.Features.Categories.Commands.CreateCategory
{
    public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, CategoryMinimalDto>
    {
        private readonly ICategoryRepository category;

        public CreateCategoryCommandHandler(ICategoryRepository category)
        {
            this.category = category;
        }
        public async Task<CategoryMinimalDto> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            // Mapping Oject to Category
            Category? ParentCategory = null;
            if (request.ParentCategoryId != null)
            {
                ParentCategory = await category.GetDetailsAsync(request.ParentCategoryId.Value);
            }
            var item = new Category(request.Name, ParentCategory);
            item=await category.CreateAsync(item);
            await category.SaveOnDBChanges();
            return new CategoryMinimalDto () { Id= item.Id,Name=item.Name };
        }
    }
}
