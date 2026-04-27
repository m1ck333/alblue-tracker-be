using MediatR;

namespace AlblueMES.Modules.Orders.Application.Commands.RemoveOrderItem;

public record RemoveOrderItemCommand(Guid OrderId, Guid ItemId) : IRequest<Unit>;
