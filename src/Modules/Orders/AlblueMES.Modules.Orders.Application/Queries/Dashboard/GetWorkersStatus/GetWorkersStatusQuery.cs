using AlblueMES.Modules.Orders.Application.DTOs.Dashboard;
using MediatR;

namespace AlblueMES.Modules.Orders.Application.Queries.Dashboard.GetWorkersStatus;

public record GetWorkersStatusQuery(Guid TenantId) : IRequest<IReadOnlyList<WorkerStatusDto>>;
