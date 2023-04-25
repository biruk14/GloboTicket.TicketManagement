using GloboTicket.TicketManagement.Application.Contracts.Infrastructure;
using GloboTicket.TicketManagement.Application.Models.Mail;
using GloboTicket.TicketManagement.Infrastructure.FileExport;
using GloboTicket.TicketManagement.Infrastructure.Mail;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GloboTicket.TicketManagement.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfratructure(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.Configure<EmailSettings>(configuration.GetSection(EmailSettings.SectionName));

        services.AddTransient<ICsvExporter, CsvExporter>();
        services.AddTransient<IEmailService, EmailService>();

        return services;
    }
}
