using AutoMapper;
using GloboTicket.TicketManagement.Application.Contracts.Persistence;
using GloboTicket.TicketManagement.Application.Exceptions;
using GloboTicket.TicketManagement.Domain.Entities;
using MediatR;

namespace GloboTicket.TicketManagement.Application.Features.Events.Commands.UpdateEvent;

public sealed class UpdateEventCommandHandler : IRequestHandler<UpdateEventCommand>
{
    private readonly IAsyncRepository<Event> _eventRepository;
    private readonly IMapper _mapper;

    public UpdateEventCommandHandler(
        IAsyncRepository<Event> eventRepository,
        IMapper mapper)
    {
        _eventRepository = eventRepository;
        _mapper = mapper;
    }

    public async Task Handle(UpdateEventCommand request, CancellationToken cancellationToken)
    {
        var eventToUpdate = await _eventRepository.GetByIdAsync(request.EventId);
        if(eventToUpdate is null)
        {
            throw new NotFoundException(nameof(Event), request.EventId);
        }
        
        var validate = new UpdateEventCommandValidator();
        var validationResult = await validate.ValidateAsync(request, cancellationToken);
        
        if(validationResult.Errors.Count > 0)
        {
            throw new ValidationException(validationResult);
        }

        _mapper.Map(request, eventToUpdate, typeof(UpdateEventCommand), typeof(Event));
        await _eventRepository.UpdateAsync(eventToUpdate);
        return;
    }
}
