using GloboTicket.TicketManagement.Application.Features.Categories.Commands.CreateCategory;
using GloboTicket.TicketManagement.Application.Features.Categories.Commands.DeleteCategory;
using GloboTicket.TicketManagement.Application.Features.Categories.Commands.UpdateCatagory;
using GloboTicket.TicketManagement.Application.Features.Categories.Queries.GetCategoriesList;
using GloboTicket.TicketManagement.Application.Features.Categories.Queries.GetCategoriesListWithEvents;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GloboTicket.TicketManagement.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CategoryController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("all", Name ="GetAllCategories")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<List<CategoryListVm>>> GetAllCategories()
        {
            var categories = await _mediator.Send(new GetCategoriesListQuery());
            return Ok(categories);
        }

        [HttpGet("allwithevents", Name ="GetCategoriesWithEvents")]
        [ProducesDefaultResponseType]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<List<CategoryEventListVm>>> GetCategoriesWithEvents(bool includeHistory)
        {
            var getCategoriesListWithEventsQuery = new GetCategoriesListWithEventsQuery(includeHistory);

            var categoriesWithEvents = await _mediator.Send(getCategoriesListWithEventsQuery);
            return Ok(categoriesWithEvents);
        }

        [HttpPost(Name ="AddCategory")]
        public async Task<ActionResult<CreateCategoryCommandResponse>> Create([FromBody] CreateCategoryCommand createCategoryCommand)
        {
            var response = await _mediator.Send(createCategoryCommand);
            return Ok(response);
        }

        [HttpPut(Name ="UpdateCategory")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> Update([FromBody]UpdateCategoryCommand updateCategoryCommand)
        {
            await _mediator.Send(updateCategoryCommand);
            return NoContent();
        }

        [HttpDelete("{id}",Name ="DeleteCategory")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> Delete(Guid id)
        {
            var deletedCategory = new DeleteCategoryCommand(id);
            await _mediator.Send(deletedCategory);
            return NoContent();
        }
    }
}
