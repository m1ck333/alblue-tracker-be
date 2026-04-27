using AlblueMES.Modules.Orders.Application.DTOs;
using MediatR;

namespace AlblueMES.Modules.Orders.Application.Commands.ApproveBlockRequest;

public record ApproveBlockRequestCommand(Guid Id, Guid HandledByUserId, string BlockReason) : IRequest<BlockRequestDto>;
