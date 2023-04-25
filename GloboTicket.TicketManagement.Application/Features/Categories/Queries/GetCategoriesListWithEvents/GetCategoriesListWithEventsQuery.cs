using MediatR;

namespace GloboTicket.TicketManagement.Application.Features.Categories.Queries.GetCategoriesListWithEvents;

public record GetCategoriesListWithEventsQuery(bool IncludeHistory) : IRequest<List<CategoryEventListVm>>;
