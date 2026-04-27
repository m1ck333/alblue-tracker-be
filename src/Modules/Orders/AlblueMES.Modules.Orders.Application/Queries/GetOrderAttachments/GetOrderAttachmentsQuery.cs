using AlblueMES.Modules.Orders.Application.DTOs;
using MediatR;

namespace AlblueMES.Modules.Orders.Application.Queries.GetOrderAttachments;

public record GetOrderAttachmentsQuery(Guid OrderId, Guid? OrderItemId = null) : IRequest<IReadOnlyList<OrderAttachmentDto>>;
