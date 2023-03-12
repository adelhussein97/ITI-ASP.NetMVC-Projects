using Application.Contract;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Categories.Commands.DeleteCategory
{
    public class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommand, bool>
    {
        private readonly ICategoryRepository category;

        public DeleteCategoryCommandHandler(ICategoryRepository category) 
        {
            this.category = category;
        }   
        public async Task<bool> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
        {
            var item = await category.GetDetailsAsync(request.Id);
            if (item != null)
            {
                await category.DeleteAsync(item.Id);
                await category.SaveOnDBChanges();
                return true;
            }
            else
                return false;
           
            
            
        }
    }
}
