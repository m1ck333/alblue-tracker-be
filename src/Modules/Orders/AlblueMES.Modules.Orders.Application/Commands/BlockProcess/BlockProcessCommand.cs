using MediatR;

namespace AlblueMES.Modules.Orders.Application.Commands.BlockProcess;

public record BlockProcessCommand(Guid OrderItemProcessId, Guid UserId, string Reason) : IRequest<Unit>;
