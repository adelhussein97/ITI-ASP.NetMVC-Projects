
using Application.Features.Products.Commands.CreateProduct;
using Application.Features.Products.Commands.DeleteProduct;
using Application.Features.Products.Commands.UpdateProduct;
using Application.Features.Products.Queries.GetAllProducts;
using Application.Features.Products.Queries.GetProductDetails;

using MediatR;
using Microsoft.AspNetCore.Mvc;
namespace API_Ecommerce.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IMediator mediator;

        public ProductsController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        // URL - https://localhost:44378/api/Products/ type GET
        [HttpGet]
        public async Task<IActionResult> GetAllProducts([FromQuery] string? Filter = null)
        {
            return Ok(await mediator.Send(new FiltersProductsQuery(Filter)));

        }

        // URL - https://localhost:44378/api/Products/{id} type GET
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductDetails(int id, [FromQuery] GetProductDetailsQuery command)
        {
            command.Id = id;
            return Ok(await mediator.Send(command));
        }
        // URL - https://localhost:44378/api/Products/ type Post
        [HttpPost]
        public async Task<IActionResult> CreateProduct([FromBody] CreateProductCommand query)
        {
            return Ok(await mediator.Send(query));
        }
        // URL - https://localhost:44378/api/Products/{id} type Put (Update)
        [HttpPatch("{id}")]
        public async Task<IActionResult> UpdateProduct(int id,[FromBody] UpdateProductCommand command)
        {
            command.Id = id;
            return Ok(await mediator.Send(command));

        }
        // URL - https://localhost:44378/api/Products/{id} type Delete
        [HttpDelete]
        public async Task<IActionResult> DeleteProduct(int id,[FromQuery] DeleteProductCommand command)
        {
            command.Id = id;
            return Ok(await mediator.Send(command));
        }



    }
}
