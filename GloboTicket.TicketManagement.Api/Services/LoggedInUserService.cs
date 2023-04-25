using GloboTicket.TicketManagement.Application.Contracts;
using System.Security.Claims;

namespace GloboTicket.TicketManagement.Api.Services;

public class LoggedInUserService : ILoggedInUserService
{
    private readonly IHttpContextAccessor _contextAccessor;
    public LoggedInUserService(IHttpContextAccessor ContextAccessor)
    {
        _contextAccessor = ContextAccessor;
    }
    public string UserId
    {
        get
        {
            return _contextAccessor
                .HttpContext?
                .User?
                .FindFirstValue((ClaimTypes.NameIdentifier));
        }
    }
}
