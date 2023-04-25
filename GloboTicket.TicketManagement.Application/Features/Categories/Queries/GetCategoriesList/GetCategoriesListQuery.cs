﻿using MediatR;

namespace GloboTicket.TicketManagement.Application.Features.Categories.Queries.GetCategoriesList;

public record GetCategoriesListQuery : IRequest<List<CategoryListVm>>;

