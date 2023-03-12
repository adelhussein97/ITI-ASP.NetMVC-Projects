using Application.Contract;
using MediatR;
using System.Diagnostics.CodeAnalysis;

namespace Application.Features.Products.Commands.UpdateProduct
{
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, bool>
    {
        private readonly IProductRepository product;

        public UpdateProductCommandHandler(IProductRepository product)
        {
            this.product = product;
        }
        public async Task<bool> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var item = await product.GetDetailsAsync(request.Id);
            if (item != null && request.Name!=null)
            {
                item.Name = request.Name;
               // item.Categories.Select(i => i.Id) = request.Id;
                await product.UpdateAsync(item);
                await product.SaveOnDBChanges();
                return true;
            }
            else
                return false;



        }
    }
}

