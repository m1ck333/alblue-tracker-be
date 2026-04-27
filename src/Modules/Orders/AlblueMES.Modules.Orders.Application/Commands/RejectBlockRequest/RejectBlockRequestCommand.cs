using AlblueMES.Modules.Orders.Application.DTOs;
using MediatR;

namespace AlblueMES.Modules.Orders.Application.Commands.RejectBlockRequest;

public record RejectBlockRequestCommand(Guid Id, Guid HandledByUserId, string? RejectionNote) : IRequest<BlockRequestDto>;
