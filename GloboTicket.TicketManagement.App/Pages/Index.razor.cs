using GloboTicket.TicketManagement.App.Auth;
using GloboTicket.TicketManagement.App.Contracts;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;

namespace GloboTicket.TicketManagement.App.Pages;

public partial class Index
{
    [Inject]
    private AuthenticationStateProvider _authenticationStateProvider { get; set; }

    [Inject]
    public NavigationManager NavigationManager { get; set; }

    [Inject]
    public IAuthenticationService AuthenticationService { get; set; }

    protected override async Task OnInitializedAsync()
    {
        await ((CustomAuthenticationStateProvider)_authenticationStateProvider).GetAuthenticationStateAsync();
    }

    protected void NavigateToLogin()
    {
        NavigationManager.NavigateTo("login");
    }
    protected void NavigateToRegister()
    {
        NavigationManager.NavigateTo("register");
    }

    protected async void Logout()
    {
        await AuthenticationService.Logout();
    }

}
