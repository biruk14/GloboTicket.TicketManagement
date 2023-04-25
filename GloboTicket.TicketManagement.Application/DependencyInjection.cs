using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace GloboTicket.TicketManagement.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        services.AddMediatR(config => 
            config.RegisterServicesFromAssembly(typeof(DependencyInjection).Assembly));
         
        return services;
    }
}
