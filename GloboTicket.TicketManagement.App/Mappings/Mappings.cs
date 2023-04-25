using AutoMapper;
using GloboTicket.TicketManagement.App.Services;
using GloboTicket.TicketManagement.App.ViewModels;

namespace GloboTicket.TicketManagement.App.Mappings;

public class Mappings : Profile
{
    public Mappings()
    {

        CreateMap<CategoryListVm, CategoryViewModel>();
        CreateMap<CategoryEventListVm, CategoryEventsViewModel>().ReverseMap();

        CreateMap<EventListVm, EventListViewModel>().ReverseMap();
        CreateMap<EventDetailVm, EventDetailViewModel>().ReverseMap();

        CreateMap<EventDetailViewModel, CreateEventCommand>().ReverseMap();
        CreateMap<EventDetailViewModel, UpdateEventCommand>().ReverseMap();

        CreateMap<CategoryEventDto,EventNestedViewModel>().ReverseMap();

        CreateMap<CategoryDto, CategoryViewModel>().ReverseMap();
        CreateMap<CreateCategoryCommand,CategoryViewModel>().ReverseMap();
        CreateMap<CreateCategoryDto,CategoryDto>().ReverseMap();

        CreateMap<PagedOrdersForMonthVm,PagedOrderForMonthViewModel>().ReverseMap();
        CreateMap<OrdersForMonthDto,OrdersForMonthListViewModel>().ReverseMap();
    }
}
