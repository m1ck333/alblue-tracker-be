using AlblueMES.Modules.Orders.Application.DTOs;
using MediatR;

namespace AlblueMES.Modules.Orders.Application.Queries.GetOrderById;

public record GetOrderByIdQuery(Guid Id) : IRequest<OrderDetailDto>;
