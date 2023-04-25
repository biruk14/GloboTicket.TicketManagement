using MediatR;

namespace GloboTicket.TicketManagement.Application.Features.Events.Commands.UpdateEvent;

public record UpdateEventCommand(
    Guid EventId,
    string Name,
    int Price,
    string? Artist,
    DateTime Date,
    string? Description,
    string? ImageUrl,
    Guid CategoryId) : IRequest;
