using AlblueMES.Modules.Orders.Application.DTOs.Dashboard;
using AlblueMES.Modules.Orders.Application.Interfaces;
using MediatR;

namespace AlblueMES.Modules.Orders.Application.Queries.Dashboard.GetPendingBlockRequests;

public class GetPendingBlockRequestsQueryHandler : IRequestHandler<GetPendingBlockRequestsQuery, IReadOnlyList<PendingBlockRequestDto>>
{
    private readonly IDashboardQueryService _dashboardQueryService;

    public GetPendingBlockRequestsQueryHandler(IDashboardQueryService dashboardQueryService)
    {
        _dashboardQueryService = dashboardQueryService;
    }

    public async Task<IReadOnlyList<PendingBlockRequestDto>> Handle(GetPendingBlockRequestsQuery request, CancellationToken cancellationToken)
    {
        return await _dashboardQueryService.GetPendingBlockRequestsAsync(request.TenantId, cancellationToken);
    }
}
