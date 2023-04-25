using AutoMapper;
using GloboTicket.TicketManagement.Application.Contracts.Persistence;
using GloboTicket.TicketManagement.Application.Features.Categories.Queries.GetCategoriesList;
using GloboTicket.TicketManagement.Application.Mappings;
using GloboTicket.TicketManagement.Application.UnitTest.Mocks;
using GloboTicket.TicketManagement.Domain.Entities;
using Moq;
using Shouldly;

namespace GloboTicket.TicketManagement.Application.UnitTest.Categories.Queries;

public class GetCategoriesListQueryHandlerTest
{
    private readonly IMapper _mapper;
    private readonly Mock<IAsyncRepository<Category>> _mockCategoryRepository;

    public GetCategoriesListQueryHandlerTest()
    {
        _mockCategoryRepository = RepositoryMocks.GetCategoryRepository();
        var configurationProvider = new MapperConfiguration(config =>
        {
            config.AddProfile<MappingProfile>();
        });
        _mapper = configurationProvider.CreateMapper();
    }

    [Fact]
    public async Task GetCategoriesListTest()
    {
        var handler = new GetCategoriesListQueryHandler(_mockCategoryRepository.Object, _mapper);
        var result = await handler.Handle(new GetCategoriesListQuery(), CancellationToken.None);

        result.ShouldBeOfType<List<CategoryListVm>>();

        result.Count.ShouldBe(4);
    }
}
