using AlblueMES.Modules.Orders.Application.DTOs;
using MediatR;

namespace AlblueMES.Modules.Orders.Application.Commands.RejectChangeRequest;

public record RejectChangeRequestCommand(Guid Id, Guid HandledByUserId, string? ResponseNote) : IRequest<ChangeRequestDto>;
