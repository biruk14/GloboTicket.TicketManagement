using GloboTicket.TicketManagement.App.Contracts;
using GloboTicket.TicketManagement.App.Services;
using GloboTicket.TicketManagement.App.Services.Base;
using GloboTicket.TicketManagement.App.ViewModels;
using Microsoft.AspNetCore.Components;

namespace GloboTicket.TicketManagement.App.Pages;

public partial class AddCategory
{
    [Inject]
    public ICategoryDataService CategoryDataService { get; set; }
    
    public CategoryViewModel CategoryViewModel { get; set; }
    public string Message { get; set; }

    protected override void OnInitialized()
    {
        CategoryViewModel = new();
    }

    protected async Task HandleValidSubmit()
    {
        var response = await CategoryDataService.CreateCategory(CategoryViewModel);
        HandleResponse(response);
    }

    private void HandleResponse(ApiResponse<CategoryDto> apiResponse)
    {
        if (apiResponse.Success)
        {
            Message = "Category created successfully!!!";
        }
        else
        {
            Message =apiResponse.Message;
            if(!string.IsNullOrEmpty(apiResponse.ValidationErrors))
            {
                Message += apiResponse.ValidationErrors;
            }
        }
    }
}
