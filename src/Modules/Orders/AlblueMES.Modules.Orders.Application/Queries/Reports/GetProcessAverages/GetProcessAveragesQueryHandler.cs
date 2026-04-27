using AlblueMES.Modules.Orders.Application.DTOs.Reports;
using AlblueMES.Modules.Orders.Application.Interfaces;
using MediatR;

namespace AlblueMES.Modules.Orders.Application.Queries.Reports.GetProcessAverages;

public class GetProcessAveragesQueryHandler : IRequestHandler<GetProcessAveragesQuery, ProcessAveragesDto>
{
    private readonly IReportingQueryService _reportingQueryService;

    public GetProcessAveragesQueryHandler(IReportingQueryService reportingQueryService)
    {
        _reportingQueryService = reportingQueryService;
    }

    public async Task<ProcessAveragesDto> Handle(GetProcessAveragesQuery request, CancellationToken cancellationToken)
    {
        return await _reportingQueryService.GetProcessAveragesAsync(request.TenantId, cancellationToken);
    }
}
