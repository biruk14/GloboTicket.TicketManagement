﻿namespace GloboTicket.TicketManagement.Application.Features.Categories.Queries.GetCategoriesList;

public sealed class CategoryListVm
{
    public Guid CategoryId { get; set; }
    public string Name { get; set; } = string.Empty;
}