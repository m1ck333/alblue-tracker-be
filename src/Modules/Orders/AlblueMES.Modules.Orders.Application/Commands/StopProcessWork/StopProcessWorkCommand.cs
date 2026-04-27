using MediatR;

namespace AlblueMES.Modules.Orders.Application.Commands.StopProcessWork;

public record StopProcessWorkCommand(Guid OrderItemProcessId, Guid UserId) : IRequest<Unit>;
