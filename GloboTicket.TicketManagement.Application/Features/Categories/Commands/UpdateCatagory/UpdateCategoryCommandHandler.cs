using AutoMapper;
using GloboTicket.TicketManagement.Application.Contracts.Persistence;
using GloboTicket.TicketManagement.Application.Exceptions;
using GloboTicket.TicketManagement.Domain.Entities;
using MediatR;

namespace GloboTicket.TicketManagement.Application.Features.Categories.Commands.UpdateCatagory;

public sealed class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommand>
{
    private readonly IAsyncRepository<Category> _categoryRepository;
    private readonly IMapper _mapper;

    public UpdateCategoryCommandHandler(
        IAsyncRepository<Category> categoryRepository,
        IMapper mapper)
    {
        _categoryRepository = categoryRepository;
        _mapper = mapper;
    }

    public async Task Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
    {
        var updatedCategory = await _categoryRepository.GetByIdAsync(request.CategoryId);
        if(updatedCategory is null) 
        {
            throw new NotFoundException(nameof(Category), request.CategoryId);
        }

        var validateCategory = new UpdateCategoryCommandValidator();
        var validationResult = await validateCategory.ValidateAsync(request, cancellationToken);

        if(validationResult.Errors.Count > 0)
        {
            throw new ValidationException(validationResult);
        }

        _mapper.Map(request, updatedCategory, typeof(UpdateCategoryCommand), typeof(Category));
        await _categoryRepository.UpdateAsync(updatedCategory);
        return;
    }
}

