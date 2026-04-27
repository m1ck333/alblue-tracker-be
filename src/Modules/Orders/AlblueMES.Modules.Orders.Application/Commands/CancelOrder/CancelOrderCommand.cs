using MediatR;

namespace AlblueMES.Modules.Orders.Application.Commands.CancelOrder;

public record CancelOrderCommand(Guid Id) : IRequest<Unit>;
