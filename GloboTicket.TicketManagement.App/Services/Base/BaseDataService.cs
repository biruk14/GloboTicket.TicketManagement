using Blazored.LocalStorage;
using System.Net.Http.Headers;

namespace GloboTicket.TicketManagement.App.Services.Base;

public class BaseDataService
{
    protected readonly ILocalStorageService _localStorageService;
    protected IClient _client;

    public BaseDataService(
        ILocalStorageService localStorageService,
        IClient client)
    {
        _localStorageService = localStorageService;
        _client = client;
    }

    protected ApiResponse<Guid> ConvertApiExceptions<Guid>(ApiException ex)
    {
        if (ex.StatusCode == 400)
        {
            return new ApiResponse<Guid>()
            {
                Message = "Validation errors have occured.",
                ValidationErrors = ex.Response,
                Success = false
            };
        }
        else if (ex.StatusCode == 404)
        {
            return new ApiResponse<Guid>()
            {
                Message = "The requested item could not be found.",
                Success = false,
            };
        }
        else
        {
            return new ApiResponse<Guid>()
            {
                Message = "Something went wrong, Please try again.",
                Success = false,
            };
        }

    }
    protected async Task AddBearerToken()
    {
        if (await _localStorageService.ContainKeyAsync("token"))
            _client.HttpClient.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", await _localStorageService.GetItemAsync<string>("token"));

    }
}
