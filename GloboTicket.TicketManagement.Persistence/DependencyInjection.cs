using GloboTicket.TicketManagement.Application.Contracts.Persistence;
using GloboTicket.TicketManagement.Persistence.Data;
using GloboTicket.TicketManagement.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace GloboTicket.TicketManagement.Persistence;

public static class DependencyInjection
{
    public static IServiceCollection AddPersistence(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddDbContext<GloboTicketDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("GloboTicketManagementConnectionString")));

        services.AddScoped(typeof(IAsyncRepository<>), typeof(BaseRepository<>));
        services.AddScoped<IEventRepository,Eventrepository>();
        services.AddScoped<ICategoryRepository,CategoryRepository>();
        services.AddScoped<IOrderRepository,OrderRepository>();

        return services;
    }
}
