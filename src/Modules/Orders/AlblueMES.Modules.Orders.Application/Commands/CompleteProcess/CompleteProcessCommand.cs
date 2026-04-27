using MediatR;

namespace AlblueMES.Modules.Orders.Application.Commands.CompleteProcess;

public record CompleteProcessCommand(Guid OrderItemProcessId) : IRequest<Unit>;
