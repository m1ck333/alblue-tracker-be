using AlblueMES.Modules.Orders.Application.DTOs;
using AlblueMES.Modules.Orders.Domain.Enums;
using MediatR;

namespace AlblueMES.Modules.Orders.Application.Commands.CreateChangeRequest;

public record CreateChangeRequestCommand(
    Guid TenantId,
    Guid OrderId,
    Guid RequestedByUserId,
    ChangeRequestType RequestType,
    string Description) : IRequest<ChangeRequestDto>;
