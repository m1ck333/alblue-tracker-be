using MediatR;

namespace AlblueMES.Modules.Orders.Application.Commands.AddSpecialRequest;

public record AddSpecialRequestCommand(Guid OrderId, Guid OrderItemId, Guid SpecialRequestTypeId) : IRequest<Unit>;
