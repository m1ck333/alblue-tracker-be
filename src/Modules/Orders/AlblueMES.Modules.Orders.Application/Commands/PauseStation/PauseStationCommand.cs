using MediatR;

namespace AlblueMES.Modules.Orders.Application.Commands.PauseStation;

public record PauseStationCommand(Guid ProcessId, Guid TenantId, Guid UserId) : IRequest;
