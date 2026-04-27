using AlblueMES.Modules.Orders.Application.DTOs;
using MediatR;

namespace AlblueMES.Modules.Orders.Application.Commands.StartSubProcess;

public record StartSubProcessCommand(Guid OrderItemSubProcessId, Guid UserId) : IRequest<OrderItemSubProcessDto>;
