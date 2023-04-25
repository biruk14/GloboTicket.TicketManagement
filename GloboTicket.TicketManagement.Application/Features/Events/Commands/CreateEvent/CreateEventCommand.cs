﻿using MediatR;

namespace GloboTicket.TicketManagement.Application.Features.Events.Commands.CreateEvent;

public record CreateEventCommand : IRequest<Guid>
{
    public string Name{ get; set; }=string.Empty;
    public int Price { get; set; }
    public string? Artist { get; set; }
    public DateTime Date { get; set; }
    public string? Description { get; set; }
    public string? ImageUrl { get; set; }
    public Guid CategoryId { get; set; }

    public override string ToString()
    {
        return $"Event anem: {Name}; Price: {Price}; By: {Artist}; On: {Date.ToShortDateString()}; Description: {Description}";
    }
}
