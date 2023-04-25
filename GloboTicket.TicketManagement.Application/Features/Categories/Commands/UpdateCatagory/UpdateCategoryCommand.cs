using MediatR;

namespace GloboTicket.TicketManagement.Application.Features.Categories.Commands.UpdateCatagory;

public record UpdateCategoryCommand(
    Guid CategoryId,
    string Name) : IRequest;

