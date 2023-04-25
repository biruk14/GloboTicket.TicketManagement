using GloboTicket.TicketManagement.App.Contracts;
using GloboTicket.TicketManagement.App.ViewModels;
using Microsoft.AspNetCore.Components;

namespace GloboTicket.TicketManagement.App.Pages;

public partial class Login
{
    public LoginViewModel LoginViewModel { get; set; }

    [Inject]
    public NavigationManager NavigationManager { get; set; }

    public string Message { get; set; }

    [Inject]
    private IAuthenticationService authenticationService { get; set; }

    public Login()
    {        
    }

    protected override void OnInitialized()
    {
        LoginViewModel = new LoginViewModel();
    }

    protected async void HandleValidSubmit()
    {
        if(await authenticationService.Authenticate(LoginViewModel.Email, LoginViewModel.Password))
        {
            NavigationManager.NavigateTo("home");
        }

        Message = "Username/Password is not correct.";
    }
}
