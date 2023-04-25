using GloboTicket.TicketManagement.Application.Features.Orders.Queries.GetOrderForMonth;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace GloboTicket.TicketManagement.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IMediator _mediator;

        public OrderController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("/getpagedordrsformonth", Name ="GetPagedOrdersForMonth")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<PagedOrdersForMonthVm>> GetPagedOrdersForMonth(DateTime date,int page,int size)
        {
            var getOrdersFordMonthQuery = new GetOrdersForMonthQuery(date, page, size);
            var dtos = await _mediator.Send(getOrdersFordMonthQuery);

            return Ok(dtos);
        }
    }
}
