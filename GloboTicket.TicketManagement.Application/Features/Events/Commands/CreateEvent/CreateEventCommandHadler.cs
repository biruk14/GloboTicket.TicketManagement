using AutoMapper;
using GloboTicket.TicketManagement.Application.Contracts.Infrastructure;
using GloboTicket.TicketManagement.Application.Contracts.Persistence;
using GloboTicket.TicketManagement.Application.Models.Mail;
using GloboTicket.TicketManagement.Domain.Entities;
using MediatR;
using Microsoft.Extensions.Logging;

namespace GloboTicket.TicketManagement.Application.Features.Events.Commands.CreateEvent;

public sealed class CreateEventCommandHadler : IRequestHandler<CreateEventCommand, Guid>
{
    private readonly IEventRepository _eventRepository;
    private readonly IMapper _mapper;
    private readonly IEmailService _emalService;
    private readonly ILogger<CreateEventCommandHadler> _logger;
    public CreateEventCommandHadler(
        IEventRepository eventRepository,
        IMapper mapper,
        IEmailService emalService,
        ILogger<CreateEventCommandHadler> logger)
    {
        _eventRepository = eventRepository;
        _mapper = mapper;
        _emalService = emalService;
        _logger = logger;
    }

    public async Task<Guid> Handle(CreateEventCommand request, CancellationToken cancellationToken)
    {

        var validator = new CreateEventCommandValidator(_eventRepository);
        var validationResult = await validator.ValidateAsync(request);

        if (validationResult.Errors.Count > 0)
            throw new Exceptions.ValidationException(validationResult);

        var @event = _mapper.Map<Event>(request);

        @event = await _eventRepository.AddAsync(@event);

        //sending email notification to admin address
        var email = new Email()
        {
            To = "brookbeck2@gmail.com",
            Body = $"A new event was created: {request}",
            Subject = "A new event was created."
        };

        try
        {
            await _emalService.SendEmail(email);
        }
        catch (Exception ex)
        {
            _logger.LogError($"Mailing abount event {@event.EventId} failed due to an error with the mail service:{ex.Message}");
        }
        return @event.EventId;
    }
}
