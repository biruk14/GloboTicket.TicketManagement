using AutoMapper;
using GloboTicket.TicketManagement.Application.Contracts.Persistence;
using GloboTicket.TicketManagement.Application.Features.Categories.Commands.CreateCategory;
using GloboTicket.TicketManagement.Application.Mappings;
using GloboTicket.TicketManagement.Application.UnitTest.Mocks;
using GloboTicket.TicketManagement.Domain.Entities;
using Moq;
using Shouldly;
using System.Reflection.Metadata;

namespace GloboTicket.TicketManagement.Application.UnitTest.Categories.Commands;

public class CreateCategoryTest
{
    private readonly IMapper _mapper;
    private readonly Mock<IAsyncRepository<Category>> _mockCategoryRepository;

    public CreateCategoryTest()
    {
        _mockCategoryRepository = RepositoryMocks.GetCategoryRepository();
        var configurationProvider = new MapperConfiguration(config =>
        {
            config.AddProfile<MappingProfile>();
        });

        _mapper = configurationProvider.CreateMapper();
    }

    [Fact]
    public async Task Handle_ValidCategory_AddToCategoriesRepo()
    {
        var handler = new CreateCategoryCommandHandler(_mockCategoryRepository.Object, _mapper);
        await handler.Handle(new CreateCategoryCommand("Test"), CancellationToken.None);

        var allCategories = await _mockCategoryRepository.Object.ListAllAsync();
        allCategories.Count.ShouldBe(5);
    }
}
