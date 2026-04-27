using AlblueMES.Modules.Orders.Application.DTOs;
using MediatR;

namespace AlblueMES.Modules.Orders.Application.Commands.SetOrderInvoiced;

public record SetOrderInvoicedCommand(Guid OrderId, bool IsInvoiced) : IRequest<OrderDto>;
