using AlblueMES.Modules.Orders.Application.DTOs;
using MediatR;

namespace AlblueMES.Modules.Orders.Application.Commands.CompleteSubProcess;

public record CompleteSubProcessCommand(Guid OrderItemSubProcessId, Guid UserId) : IRequest<OrderItemSubProcessDto>;
