using MediatR;

namespace AlblueMES.Modules.Orders.Application.Commands.DeleteOrderAttachment;

public record DeleteOrderAttachmentCommand(
    Guid OrderId,
    Guid AttachmentId,
    Guid TenantId) : IRequest<Unit>;
