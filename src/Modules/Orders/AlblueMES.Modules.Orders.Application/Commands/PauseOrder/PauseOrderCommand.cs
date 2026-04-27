using MediatR;

namespace AlblueMES.Modules.Orders.Application.Commands.PauseOrder;

public record PauseOrderCommand(Guid Id) : IRequest<Unit>;
