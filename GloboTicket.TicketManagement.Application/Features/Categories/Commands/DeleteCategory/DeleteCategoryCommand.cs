using MediatR;

namespace GloboTicket.TicketManagement.Application.Features.Categories.Commands.DeleteCategory;

public record DeleteCategoryCommand(Guid CategoryId) : IRequest;
