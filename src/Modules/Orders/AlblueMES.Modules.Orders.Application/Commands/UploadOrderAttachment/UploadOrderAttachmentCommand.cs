using AlblueMES.Modules.Orders.Application.DTOs;
using MediatR;

namespace AlblueMES.Modules.Orders.Application.Commands.UploadOrderAttachment;

public record UploadOrderAttachmentCommand(
    Guid OrderId,
    Guid TenantId,
    Guid UserId,
    string FileName,
    string ContentType,
    long FileSizeBytes,
    Stream FileStream,
    Guid? OrderItemId = null) : IRequest<OrderAttachmentDto>;
