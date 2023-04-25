using GloboTicket.TicketManagement.Application.Exceptions;
using System.Net;
using System.Text.Json;

namespace GloboTicket.TicketManagement.Api.Middleware;

public class ExceptionHandleMiddleware
{
    private readonly RequestDelegate _next;

    public ExceptionHandleMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            await ConvertException(context, ex);
        }
    }

    private Task ConvertException(HttpContext context, Exception execption)
    {
        HttpStatusCode statusCode= HttpStatusCode.InternalServerError;

        context.Response.ContentType ="application/json";

        var result = string.Empty;
        switch(execption)
        {
            case ValidationException validationException:
                statusCode = HttpStatusCode.BadRequest;
                result = JsonSerializer.Serialize(validationException.ValidationErrors);
                break;
            case BadRequestException badRequestException:
                statusCode = HttpStatusCode.BadRequest;
                result = badRequestException.Message;
                break;
            case NotFoundException:
                statusCode = HttpStatusCode.NotFound;
                break;
            case Exception:
                statusCode = HttpStatusCode.BadRequest;
                break;
        }

        context.Response.StatusCode = (int)statusCode;
        if(string.IsNullOrEmpty(result))
        {
            result = JsonSerializer.Serialize(new { error = execption.Message });
        }

        return context.Response.WriteAsync(result);
    }
}
