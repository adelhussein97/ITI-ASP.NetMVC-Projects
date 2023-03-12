using Application.Features.Products.Commands.CreateProduct;
using Application.Features.Products.Commands.DeleteProduct;
using Application.Features.Products.Commands.UpdateProduct;
using Application.Features.Products.Queries.GetAllProducts;
using Application.Features.Products.Queries.GetProductDetails;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;


namespace ECommerce_MVC_ModelWithAPI.Controllers
{
    public class ProductController : Controller
    {
        private readonly IMediator mediator;

        public ProductController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        // URL - https://localhost:44378/api/Products/ type GET
      
        public async Task<IActionResult> Index(string? Filter = null)
        {
            return View(await mediator.Send(new FiltersProductsQuery(Filter)));

        }

        // URL - https://localhost:44378/api/Products/{id} type GET
      
        public async Task<IActionResult> Details(int id, GetProductDetailsQuery command)
        {
            command.Id = id;
            return View(await mediator.Send(command));
        }
        // URL - https://localhost:44378/api/Products/ type Post
        [HttpPost]
        public async Task<IActionResult> Create(CreateProductCommand query)
        {
            return View(await mediator.Send(query));
        }
        // URL - https://localhost:44378/api/Products/{id} type Put (Update)
        [HttpPatch("{id}")]
        public async Task<IActionResult> Update(int id, UpdateProductCommand command)
        {
            command.Id = id;
            return View(await mediator.Send(command));

        }
        // URL - https://localhost:44378/api/Products/{id} type Delete
        [HttpDelete]
        public async Task<IActionResult> Delete(int id, DeleteProductCommand command)
        {
            command.Id = id;
            return View(await mediator.Send(command));
        }


    }
}