﻿using FluentValidation;
using GloboTicket.TicketManagement.Application.Contracts.Persistence;

namespace GloboTicket.TicketManagement.Application.Features.Events.Commands.CreateEvent;

public sealed class CreateEventCommandValidator : AbstractValidator<CreateEventCommand>
{
	private readonly IEventRepository _eventRepository;

    public CreateEventCommandValidator(IEventRepository eventRepository)
	{
		_eventRepository = eventRepository;

		RuleFor(e=>e.Name)
			.NotEmpty().WithMessage("{ProoertyName} is required.")
			.NotNull()
			.MaximumLength(50).WithMessage("{PropertyName} must not excedd 50 characters.");

		RuleFor(e => e.Date)
			.NotEmpty().WithMessage("{PropertyName} is required.")
			.NotNull()
			.GreaterThan(DateTime.Now);

		RuleFor(e => e)
			.MustAsync(EventNameAndDateUnique)
			.WithMessage("An event with the same name and date already exest.");

		RuleFor(e => e.Price)
			.NotEmpty().WithMessage("{PropertyName} is required.")
			.GreaterThan(0);
	}

	private async Task<bool> EventNameAndDateUnique(CreateEventCommand e, CancellationToken cancellationToken)
	{
		return !(await _eventRepository.IsEventNameAndDateUnique(e.Name, e.Date));
	}
}
