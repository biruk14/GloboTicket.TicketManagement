using GloboTicket.TicketManagement.App.Components;
using GloboTicket.TicketManagement.App.Contracts;
using GloboTicket.TicketManagement.App.ViewModels;
using Microsoft.AspNetCore.Components;

namespace GloboTicket.TicketManagement.App.Pages;

public partial class TicketSales
{
    [Inject]
    public IOrderDataService OrderDataService { get; set; }

    [Inject]
    public NavigationManager NavigationManager { get; set; }

    public string SelectedMonth { get; set; }
    public string SelectYear { get; set; }

    public List<string> MonthList { get; set; } = Enumerable.Range(1, 12).Select(n => n < 10 ? $"0{n}" : n.ToString()).ToList();
    public List<string> YearList { get; set; } = Enumerable.Range(2022, 10).Select(y => y.ToString()).ToList();

    private int? pageNumber = 1;

    private PaginatedList<OrdersForMonthListViewModel> paginatedList
        = new PaginatedList<OrdersForMonthListViewModel>();

    private IEnumerable<OrdersForMonthListViewModel> ordersList;

    protected async Task GetSales()
    {
        DateTime dt = new DateTime(int.Parse(SelectYear), int.Parse(SelectedMonth), 1);

        var orders = await OrderDataService.GetPagedOrderForMonth(dt, pageNumber.Value, 5);
        paginatedList = new PaginatedList<OrdersForMonthListViewModel>(orders.OrdersForMonth.ToList(), orders.Count, pageNumber.Value, 5);
        ordersList = paginatedList.Items;

        StateHasChanged();
    }

    public async void PageIndexChanged(int newPageNumber)
    {
        if(newPageNumber < 1 || newPageNumber > paginatedList.TotalPages)
        {
            return;
        }

        pageNumber = newPageNumber;
        await GetSales();
        StateHasChanged();
    }

}
