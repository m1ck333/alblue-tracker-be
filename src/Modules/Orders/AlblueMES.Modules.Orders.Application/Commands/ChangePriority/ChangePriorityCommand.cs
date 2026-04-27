using AlblueMES.Modules.Orders.Application.DTOs;
using MediatR;

namespace AlblueMES.Modules.Orders.Application.Commands.ChangePriority;

public record ChangePriorityCommand(Guid OrderId, int Priority) : IRequest<OrderDto>;
