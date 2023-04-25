using GloboTicket.TicketManagement.Api.Middleware;
using GloboTicket.TicketManagement.Api.Services;
using GloboTicket.TicketManagement.Api.Utility;
using GloboTicket.TicketManagement.Application;
using GloboTicket.TicketManagement.Application.Contracts;
using GloboTicket.TicketManagement.Identity;
using GloboTicket.TicketManagement.Infrastructure;
using GloboTicket.TicketManagement.Persistence;
using GloboTicket.TicketManagement.Persistence.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

namespace GloboTicket.TicketManagement.Api;

public static class StartupExtensions
{
    public static WebApplication ConfigureServices(this WebApplicationBuilder builder)
    {
        AddSwagger(builder.Services);

        builder.Services.AddApplication();
        builder.Services.AddInfratructure(builder.Configuration);
        builder.Services.AddPersistence(builder.Configuration);
        builder.Services.AddIndentityService(builder.Configuration);


        builder.Services.AddScoped<ILoggedInUserService, LoggedInUserService>();
        builder.Services.AddHttpContextAccessor();

        builder.Services.AddControllers();

        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();


        builder.Services.AddCors(options =>
        {
            options.AddPolicy("Open", builder =>
                builder.AllowAnyOrigin()
                       .AllowAnyHeader()
                       .AllowAnyMethod());
        });

        return builder.Build();
    }

    public static WebApplication ConfigurePipelines(this WebApplication app)
    {
        

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "GloboTicket Ticket Management API");
            });
        }

        app.UseHttpsRedirection();

        app.UseRouting();

        app.UseAuthentication();

        app.UseMiddleware<ExceptionHandleMiddleware>();
        
        app.UseCors("Open");

        app.UseAuthorization();

        app.MapControllers();

        return app;
    }
    private static void AddSwagger(IServiceCollection services)
    {
        services.AddSwaggerGen(c =>
        {
            c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
            {
                Description = @"JWT Authorization header using the beare schema. \r\n\r\n
                              Enter 'Bearer' [space] and then your token in the text input below. \r\n\r\n
                              Example: 'Bearer 12345abcdef'",
                Name = "Authorization",
                In = ParameterLocation.Header,
                Type = SecuritySchemeType.ApiKey,
                Scheme = "Bearer"
            });

            c.AddSecurityRequirement(new OpenApiSecurityRequirement()
            {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference= new OpenApiReference
                        {
                            Type=ReferenceType.SecurityScheme,
                            Id="Bearer"
                        },
                        Scheme="oauth2",
                        Name="Bearer",
                        In=ParameterLocation.Header
                    },
                    new List<string>()
                }
            });

            c.SwaggerDoc("v1", new OpenApiInfo
            {
                Version="v1",
                Title="GloboTicket Ticket Management API"
            });

            c.OperationFilter<FileResultContentTypeOperationFilter>();
        });
    }

    public static async Task ResetDatabaseAsync(this WebApplication app)
    {
        using var scope = app.Services.CreateScope();
        try
        {
            var context = scope.ServiceProvider.GetService<GloboTicketDbContext>();
            if(context is not null)
            {
                await context.Database.EnsureDeletedAsync();
                await context.Database.MigrateAsync();
            }
        }
        catch (Exception)
        {

            throw;
        }
    }
}
