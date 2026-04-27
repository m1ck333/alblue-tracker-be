using MediatR;

namespace AlblueMES.Modules.Orders.Application.Commands.ReopenOrder;

public record ReopenOrderCommand(Guid Id) : IRequest<Unit>;
