using AlblueMES.Modules.Orders.Application.DTOs;
using MediatR;

namespace AlblueMES.Modules.Orders.Application.Commands.StartProcessWork;

public record StartProcessWorkCommand(Guid OrderItemProcessId, Guid UserId) : IRequest<OrderItemProcessDto>;
