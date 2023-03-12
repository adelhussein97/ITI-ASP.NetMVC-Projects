using Application.Contract;
using Application.Features.Categories.Commands.DeleteCategory;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Products.Commands.DeleteProduct
{
    public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand, bool>
    {
        private readonly IProductRepository product;

        public DeleteProductCommandHandler(IProductRepository product)
        {
            this.product = product;
        }
        public async Task<bool> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            var item = await product.GetDetailsAsync(request.Id);
            if (item != null)
            {
                await product.DeleteAsync(item.Id);
                await product.SaveOnDBChanges();
                return true;
            }
            else
                return false;



        }
    }
}
