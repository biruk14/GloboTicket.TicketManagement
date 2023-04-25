using MediatR;

namespace GloboTicket.TicketManagement.Application.Features.Events.Queries.GetEventDetail;

public sealed record GetEventDetailQuery(Guid Id) : IRequest<EventDetailVm>;
