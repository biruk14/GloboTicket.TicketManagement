using Blazored.LocalStorage;
using GloboTicket.TicketManagement.App.Auth;
using GloboTicket.TicketManagement.App.Contracts;
using GloboTicket.TicketManagement.App.Services.Base;
using Microsoft.AspNetCore.Components.Authorization;
using System.Net.Http.Headers;

namespace GloboTicket.TicketManagement.App.Services;

public class AuthenticationService : BaseDataService, IAuthenticationService
{
    private readonly AuthenticationStateProvider _authenticationStateProvider;
    public AuthenticationService(
        ILocalStorageService localStorageService, 
        IClient client, 
        AuthenticationStateProvider authenticationStateProvider) 
        : base(localStorageService, client)
    {
        _authenticationStateProvider = authenticationStateProvider;
    }

    public async Task<bool> Authenticate(string email, string password)
    {
        try
        {
            AuthenticationRequest authenticationRequest = new AuthenticationRequest() { Email = email, Password = password };
            var authenticationResponse = await _client.AuthenticateAsync(authenticationRequest);

            if (!string.IsNullOrEmpty(authenticationResponse.Token))
            {
                await _localStorageService.SetItemAsync("token", authenticationResponse.Token);
                ((CustomAuthenticationStateProvider)_authenticationStateProvider).SetUserAuthenticated(email);
                _client.HttpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", authenticationResponse.Token);
                return true;
            }
            return false;
        }
        catch (Exception)
        {
            return false;
        }
    }

    public async Task Logout()
    {
        await _localStorageService.RemoveItemAsync("token");
        ((CustomAuthenticationStateProvider)_authenticationStateProvider).SetUserLoggedOut();
        _client.HttpClient.DefaultRequestHeaders.Authorization = null;
    }

    public async Task<bool> Register(string firstName, string lastName, string userName, string email, string password)
    {
        RegistrationRequest registrationRequest = new() { FirstName = firstName, LastName = lastName, UserName = userName, Email = email,Password= password };
        var response = await _client.RegisterAsync(registrationRequest);

        if(!string.IsNullOrEmpty(response.UserId))
            return true;

        return false;
    }
}
