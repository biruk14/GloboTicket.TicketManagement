﻿using GloboTicket.TicketManagement.App.Contracts;
using GloboTicket.TicketManagement.App.ViewModels;
using Microsoft.AspNetCore.Components;

namespace GloboTicket.TicketManagement.App.Pages;

public partial class CategoryOverview
{
    [Inject]
    public ICategoryDataService CategoryDataService { get; set; }

    public ICollection<CategoryEventsViewModel> Categories { get; set; }

    protected override async Task OnInitializedAsync()
    {
        Categories = await CategoryDataService.GetAllCategoriesWithEvents(false);
    }

    protected async void OnIncludeHistoryChanged(ChangeEventArgs args)
    {
        if ((bool)args.Value)
        {
            Categories = await CategoryDataService.GetAllCategoriesWithEvents(true);
        }
        else
        {
            Categories = await CategoryDataService.GetAllCategoriesWithEvents(false);
        }
    }
}
