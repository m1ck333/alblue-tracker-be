using AlblueMES.Modules.Orders.Application.DTOs.Reports;
using AlblueMES.Modules.Orders.Application.Interfaces;
using MediatR;

namespace AlblueMES.Modules.Orders.Application.Queries.Reports.GetTimeTracking;

public class GetTimeTrackingQueryHandler : IRequestHandler<GetTimeTrackingQuery, TimeTrackingReportDto>
{
    private readonly IReportingQueryService _reportingQueryService;

    public GetTimeTrackingQueryHandler(IReportingQueryService reportingQueryService)
    {
        _reportingQueryService = reportingQueryService;
    }

    public async Task<TimeTrackingReportDto> Handle(GetTimeTrackingQuery request, CancellationToken cancellationToken)
    {
        return await _reportingQueryService.GetTimeTrackingReportAsync(
            request.TenantId, request.From, request.To, request.ProcessId, request.Complexity, cancellationToken);
    }
}
