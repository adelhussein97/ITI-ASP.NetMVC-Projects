using Application.Contract;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Categories.Commands.EditCategory
{
    public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommand, bool>
    {
        private readonly ICategoryRepository category;

        public UpdateCategoryCommandHandler(ICategoryRepository category)
        {
            this.category = category;
        }
        public async Task<bool> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
        {
            var item =await category.GetDetailsAsync(request.Id);
            
            if (item != null)
            {
                item.Name = request.Name;
                await category.UpdateAsync(item);
                await category.SaveOnDBChanges();
                return true;
            }
            else
                return false;
            
            
            
        }
    }
}
