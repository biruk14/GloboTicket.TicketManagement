using AutoMapper;
using Blazored.LocalStorage;
using GloboTicket.TicketManagement.App.Contracts;
using GloboTicket.TicketManagement.App.Services.Base;
using GloboTicket.TicketManagement.App.ViewModels;

namespace GloboTicket.TicketManagement.App.Services;


public class CategoryDataService : BaseDataService, ICategoryDataService
{
    private readonly IMapper _mapper;
    public CategoryDataService(
        IMapper mapper,
        ILocalStorageService localStorageService, 
        IClient client) 
        : base(localStorageService, client)
    {
        _mapper = mapper;
    }

    public async Task<ApiResponse<CategoryDto>> CreateCategory(CategoryViewModel categoryViewModel)
    {
        try
        {
            ApiResponse<CategoryDto> apiResponse = new();
            CreateCategoryCommand command = _mapper.Map<CreateCategoryCommand>(categoryViewModel);
            var createCategoryCommandResponse = await _client.AddCategoryAsync(command);
            if (createCategoryCommandResponse.Success)
            {
                apiResponse.Data = _mapper.Map<CategoryDto>(createCategoryCommandResponse.Category);
                apiResponse.Success = true;
            }
            else
            {
                apiResponse.Data = null;
                foreach (var error in createCategoryCommandResponse.ValidationErrors) 
                {
                    apiResponse.ValidationErrors += error + Environment.NewLine;
                }
            }
            return apiResponse;
        }
        catch (ApiException ex)
        {
            return ConvertApiExceptions<CategoryDto>(ex);
        }
    }

    public async Task<List<CategoryViewModel>> GetAllCategories()
    {
        await AddBearerToken();

        var allcategories = await _client.GetAllCategoriesAsync();
        var mappedCategories = _mapper.Map<ICollection<CategoryViewModel>>(allcategories);

        return mappedCategories.ToList();
    }

    public async Task<List<CategoryEventsViewModel>> GetAllCategoriesWithEvents(bool includeHistory)
    {
        await AddBearerToken();

        var allCategories = await _client.GetCategoriesWithEventsAsync(includeHistory);
        var mappedCategories = _mapper.Map<ICollection<CategoryEventsViewModel>>(allCategories);
        return mappedCategories.ToList();
    }
}
