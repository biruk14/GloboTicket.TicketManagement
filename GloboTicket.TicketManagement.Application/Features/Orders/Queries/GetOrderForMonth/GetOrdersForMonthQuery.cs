using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GloboTicket.TicketManagement.Application.Features.Orders.Queries.GetOrderForMonth;

public record GetOrdersForMonthQuery(DateTime Date, int Page, int size) : IRequest<PagedOrdersForMonthVm>;

