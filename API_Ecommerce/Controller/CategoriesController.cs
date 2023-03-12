using Application.Features.Categories.Commands.CreateCategory;
using Application.Features.Categories.Commands.DeleteCategory;
using Application.Features.Categories.Commands.EditCategory;
using Application.Features.Categories.Queries.FilterCategories;
using Application.Features.Categories.Queries.GetCategoryDetails;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_Ecommerce.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly IMediator mediator;

        public CategoriesController(IMediator mediator)
        {
         
            this.mediator = mediator;
        }

        // URL - https://localhost:44378/api/Categories/ type GET
        [HttpGet]
        public async Task< IActionResult> GetAllCategories([FromQuery] string ? Filter =null,int ? parentCategoryId=null)
        {
            return Ok(await mediator.Send(new FiltersCategoriesQuery(Filter,parentCategoryId)));

        }

        // URL - https://localhost:44378/api/Categories/{id} type GET
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCategoryDetails(int id, [FromQuery] GetCategoryDetailsQuery command)
        {
            command.Id = id;
            return Ok(await mediator.Send(command));
        }
        // URL - https://localhost:44378/api/Categories/ type Post
        [HttpPost]
        public async Task< IActionResult> AddCategory([FromBody] CreateCategoryCommand query)
        {
            return Ok(await mediator.Send(query));
        }
        // URL - https://localhost:44378/api/Categories/{id} type Put (Update)
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCategory(int id,[FromBody] UpdateCategoryCommand command)
        {
            command.Id = id;
            return Ok(await mediator.Send(command));
           
        }
        // URL - https://localhost:44378/api/Categories/{id} type Delete
        [HttpDelete]
        public async Task<IActionResult> DeleteCategory(int id,[FromQuery] DeleteCategoryCommand command)
        {
            command.Id = id;
            return Ok(await mediator.Send(command));
        }
    }
}
