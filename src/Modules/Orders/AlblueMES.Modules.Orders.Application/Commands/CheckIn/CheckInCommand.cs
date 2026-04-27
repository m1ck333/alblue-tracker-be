using AlblueMES.Modules.Orders.Application.DTOs;
using MediatR;

namespace AlblueMES.Modules.Orders.Application.Commands.CheckIn;

public record CheckInCommand(Guid TenantId, Guid UserId) : IRequest<WorkSessionDto>;
