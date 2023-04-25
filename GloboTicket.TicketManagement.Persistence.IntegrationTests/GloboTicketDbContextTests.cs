﻿using GloboTicket.TicketManagement.Application.Contracts;
using GloboTicket.TicketManagement.Domain.Entities;
using GloboTicket.TicketManagement.Persistence.Data;
using Microsoft.EntityFrameworkCore;
using Moq;
using Shouldly;

namespace GloboTicket.TicketManagement.Persistence.IntegrationTests;

public class GloboTicketDbContextTests
{
    private readonly GloboTicketDbContext _globoTicketDbContext;
    private readonly Mock<ILoggedInUserService> _loggedInUserServiceMock;
    private readonly string _loggedInUserId;

    public GloboTicketDbContextTests()
    {
        var dbContextOptions = new DbContextOptionsBuilder<GloboTicketDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString()).Options;

        _loggedInUserId = "00000000-0000-0000-0000-000000000000";
        _loggedInUserServiceMock = new Mock<ILoggedInUserService>();
        _loggedInUserServiceMock.Setup(x => x.UserId).Returns(_loggedInUserId);

        _globoTicketDbContext = new GloboTicketDbContext(dbContextOptions, _loggedInUserServiceMock.Object);

    }

    [Fact]
    public async Task Save_SetCreatedByProperty()
    {
        var newEvent = new Event()
        {
            EventId = Guid.NewGuid(),
            Name = "Test Event"
        };

        _globoTicketDbContext.Events.Add(newEvent);
        await _globoTicketDbContext.SaveChangesAsync();

        newEvent.CreatedBy.ShouldBe(_loggedInUserId);
    }
}
