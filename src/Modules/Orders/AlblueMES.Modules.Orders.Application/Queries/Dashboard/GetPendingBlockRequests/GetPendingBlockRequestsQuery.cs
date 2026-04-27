using AlblueMES.Modules.Orders.Application.DTOs.Dashboard;
using MediatR;

namespace AlblueMES.Modules.Orders.Application.Queries.Dashboard.GetPendingBlockRequests;

public record GetPendingBlockRequestsQuery(Guid TenantId) : IRequest<IReadOnlyList<PendingBlockRequestDto>>;
