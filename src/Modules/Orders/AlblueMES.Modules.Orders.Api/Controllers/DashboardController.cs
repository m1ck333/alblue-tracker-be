using AlblueMES.Modules.Orders.Application.Queries.Dashboard.GetDashboardStatistics;
using AlblueMES.Modules.Orders.Application.Queries.Dashboard.GetDeadlineWarnings;
using AlblueMES.Modules.Orders.Application.Queries.Dashboard.GetLiveView;
using AlblueMES.Modules.Orders.Application.Queries.Dashboard.GetPendingBlockRequests;
using AlblueMES.Modules.Orders.Application.Queries.Dashboard.GetWorkersStatus;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AlblueMES.Modules.Orders.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class DashboardController : ControllerBase
{
    private readonly IMediator _mediator;

    public DashboardController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("warnings")]
    public async Task<IActionResult> GetDeadlineWarnings([FromQuery] Guid tenantId, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(new GetDeadlineWarningsQuery(tenantId), cancellationToken);
        return Ok(result);
    }

    [HttpGet("live-view")]
    public async Task<IActionResult> GetLiveView([FromQuery] Guid tenantId, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(new GetLiveViewQuery(tenantId), cancellationToken);
        return Ok(result);
    }

    [HttpGet("workers-status")]
    public async Task<IActionResult> GetWorkersStatus([FromQuery] Guid tenantId, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(new GetWorkersStatusQuery(tenantId), cancellationToken);
        return Ok(result);
    }

    [HttpGet("pending-blocks")]
    public async Task<IActionResult> GetPendingBlockRequests([FromQuery] Guid tenantId, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(new GetPendingBlockRequestsQuery(tenantId), cancellationToken);
        return Ok(result);
    }

    [HttpGet("statistics")]
    public async Task<IActionResult> GetDashboardStatistics([FromQuery] Guid tenantId, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(new GetDashboardStatisticsQuery(tenantId), cancellationToken);
        return Ok(result);
    }
}
