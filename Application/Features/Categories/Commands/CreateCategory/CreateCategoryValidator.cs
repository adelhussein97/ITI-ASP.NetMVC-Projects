using FluentValidation;

namespace Application.Features.Categories.Commands.CreateCategory
{
    internal class CreateCategoryValidator :AbstractValidator<CreateCategoryCommand>
    {
        public CreateCategoryValidator() 
        { 
            RuleFor(c => c.Name)
                .NotEmpty().WithMessage("Name is Empty")
                .NotNull().WithMessage("Name is Reuired")
                .MinimumLength(3).WithMessage("Name must at least 3 Char")
                .MaximumLength(3).WithMessage("Name must not exceed 200 Char");
        }
    }
}
