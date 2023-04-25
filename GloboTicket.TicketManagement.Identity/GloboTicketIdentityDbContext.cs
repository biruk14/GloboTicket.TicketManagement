﻿using GloboTicket.TicketManagement.Identity.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace GloboTicket.TicketManagement.Identity;

public class GloboTicketIdentityDbContext : IdentityDbContext<ApplicationUser>
{
    public GloboTicketIdentityDbContext()
    {        
    }

    public GloboTicketIdentityDbContext(DbContextOptions<GloboTicketIdentityDbContext> options)
        : base(options) 
    {
    }
}
