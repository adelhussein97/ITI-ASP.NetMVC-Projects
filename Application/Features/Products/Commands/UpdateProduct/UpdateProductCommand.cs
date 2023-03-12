using MediatR;


namespace Application.Features.Products.Commands.UpdateProduct
{
    public class UpdateProductCommand : IRequest<bool>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int CategoryID { get; set; }
    }
}
