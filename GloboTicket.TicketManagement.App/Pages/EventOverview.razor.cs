﻿using GloboTicket.TicketManagement.App.Contracts;
using GloboTicket.TicketManagement.App.ViewModels;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace GloboTicket.TicketManagement.App.Pages;

public partial class EventOverview
{
    [Inject]
    public IEventDataService EventDataService { get; set; }
    [Inject]
    public NavigationManager NavigationManager { get; set; }
    [Inject]
    public IJSRuntime JSRuntime { get; set; }

    public ICollection<EventListViewModel> Events { get; set; }
    [Inject]
    public HttpClient HttpClient { get; set; }

    protected override async Task OnInitializedAsync()
    {
        Events = await EventDataService.GetAllEvents();
    }

    protected void AddNewEvent()
    {
        NavigationManager.NavigateTo("/eventDetails");
    }

    protected async Task ExportEvents()
    {
        if(await JSRuntime.InvokeAsync<bool>("confirm",$"Do you want to export this list to Excel?"))
        {
            var response = await HttpClient.GetAsync($"https://localhost:7020/api/events/export");
            response.EnsureSuccessStatusCode();
            var fileBytes = await response.Content.ReadAsByteArrayAsync();
            var fileName = $"Events{DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss", System.Globalization.CultureInfo.InvariantCulture)}.csv";
            await JSRuntime.InvokeAsync<object>("saveAsFile", fileName, Convert.ToBase64String(fileBytes));
        }
    }
}
